using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessagingApp
{
    public partial class Server : Form
    {

        // What listens in
        private TcpListener listener;

        // types of clients connected
        private List<TcpClient> clients = new List<TcpClient>();

        // Names that are taken by other messengers
        private Dictionary<TcpClient, string> names = new Dictionary<TcpClient, string>();

        // Messages that need to be sent
        private Queue<string> messageQueue = new Queue<string>();

        // Extra fun data
        public readonly string ChatName;
        public readonly int Port;
        public bool Running { get; private set; }

        // Buffer
        public readonly int BufferSize = 2 * 1024;  // 2KB

        //Threading
        private ThreadStart ts;
        private Thread t;
        private delegate void loggerDelegate();
        private Queue<string> toLog = new Queue<string>();


        public Server(string chatName, int port)
        {
            ChatName = chatName;
            Port = port;
            Running = false;

            listener = new TcpListener(IPAddress.Any, Port);

            InitializeComponent();//Set UI
            this.FormClosing += new FormClosingEventHandler(Server_FormClosing);
            
        }

        //Disconnects when the window is closed
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnectClients();
            foreach (TcpClient m in clients)
                cleanupClient(m);
            
            //listener.Stop();
            Running= false;
            clients.Clear();
        }

        //Function runs when the log has been created
        private void log_HandleCreated(object sender, EventArgs e)
        {
            ts = new ThreadStart(Run);
            t = new Thread(ts);
            t.Start();
        }

        public void Shutdown()
        {
            Running = false;
            log.AppendText("Shutting down server\n");
            shutdownButton.Enabled = false;
            disconnectClients();
        }

        //To display to the server user
        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "No IP found";
        }

        public void Run()
        {
            // print server info
            string IP = GetLocalIPAddress();
            toLog.Enqueue("Starting the \"" + ChatName + "\" chat room on port " + Port+"\n"+"Your IP address "+IP);
            log.BeginInvoke(new loggerDelegate(addLog));

            // Make the server run
            listener.Start();
            Running = true;

            // Main server loop
            while (Running)
            {
                // Check for new clients
                if (listener.Pending())
                    handleNewConnection();

                // Main functions
                checkForDisconnects();
                checkForNewMessages();
                sendMessages();

                // Use less CPU
                Thread.Sleep(10);
            }

            // Stop the server, and clean up any connected clients
            foreach (TcpClient m in clients)
                cleanupClient(m);
            listener.Stop();
            clients.Clear();

            toLog.Enqueue("Server has shut down");
            log.BeginInvoke(new loggerDelegate(addLog));
        }

        private void handleNewConnection()
        {

            bool good = false;//to check if a connection has been made
            TcpClient newClient = listener.AcceptTcpClient();
            NetworkStream netStream = newClient.GetStream();

            // Modify the default buffer sizes
            newClient.SendBufferSize = BufferSize;
            newClient.ReceiveBufferSize = BufferSize;

            // Print some info
            EndPoint endPoint = newClient.Client.RemoteEndPoint;
            toLog.Enqueue("Handling a new client from " + endPoint + "...");
            log.BeginInvoke(new loggerDelegate(addLog));

            // Registering the client
            byte[] msgBuffer = new byte[BufferSize];
            int bytesRead = netStream.Read(msgBuffer, 0, msgBuffer.Length);
            if (bytesRead > 0)
            {
                string msg = Encoding.UTF8.GetString(msgBuffer, 0, bytesRead);

                if (msg.StartsWith("name:"))
                {
                    string name = msg.Substring(msg.IndexOf(':') + 1);

                    //Check if the username is valid (no name or name already in use)
                    if ((name != string.Empty) && (!names.ContainsValue(name)))
                    {
                        good = true;
                        names.Add(newClient, name);
                        clients.Add(newClient);

                        toLog.Enqueue(endPoint + " has joined the chat as " + name);
                        log.BeginInvoke(new loggerDelegate(addLog));

                        // Tell the other clients that a new client joined
                        messageQueue.Enqueue(String.Format("{0} has joined the chat.", name));
                    }
                }
                else
                {
                    //Invalid identification sent to the server
                    toLog.Enqueue("Wasn't able to identify " + endPoint);
                    log.BeginInvoke(new loggerDelegate(addLog));
                    cleanupClient(newClient);
                }
            }

            //No new connection
            if (!good)
                newClient.Close();
        }

        private void checkForDisconnects()
        {
            foreach (TcpClient m in clients.ToArray())
            {
                if (isDisconnected(m))
                {
                    // Get info about the messenger
                    string name = names[m];

                    // Tell the chat someone has left
                    toLog.Enqueue(name + " has left");
                    log.BeginInvoke(new loggerDelegate(addLog));
                    messageQueue.Enqueue(String.Format("{0} has left the chat", name));


                    clients.Remove(m);  // Remove from list
                    names.Remove(m);    // Remove taken name
                    cleanupClient(m);
                }
            }
        }

        private void checkForNewMessages()
        {
            foreach (TcpClient client in clients)
            {
                int messageLength = client.Available;
                if (messageLength > 0)
                {
                    byte[] msgBuffer = new byte[messageLength];
                    client.GetStream().Read(msgBuffer, 0, msgBuffer.Length);

                    // Attach a name to it and shove it into the queue
                    string msg = String.Format("{0}> {1}", names[client], Encoding.UTF8.GetString(msgBuffer));
                    messageQueue.Enqueue(msg);
                }
            }
        }

        private void disconnectClients()
        {
            byte[] msgBuffer = Encoding.UTF8.GetBytes("ifyouarereadingthislmaogetalife");
            foreach (TcpClient client in clients)
            {
                client.GetStream().Write(msgBuffer, 0, msgBuffer.Length);
            }
        }

        private void sendMessages()
        {
            foreach (string msg in messageQueue)
            {
                // Encode the message
                byte[] msgBuffer = Encoding.UTF8.GetBytes(msg);

                // Send the message to each client
                foreach (TcpClient client in clients)
                    client.GetStream().Write(msgBuffer, 0, msgBuffer.Length);
            }

            // clear out the queue
            messageQueue.Clear();
        }

        private static bool isDisconnected(TcpClient client)
        {
            try
            {
                Socket s = client.Client;
                return s.Poll(10 * 1000, SelectMode.SelectRead) && (s.Available == 0);
            }
            catch (Exception)
            {
                return true;
            }
        }

        private static void cleanupClient(TcpClient client)
        {
            client.GetStream().Close();     // Close network stream
            client.Close();                 // Close client
        }

        private void shutdownButton_Click(object sender, EventArgs e)
        {
            Shutdown();
        }

        //Function to show logging messages
        private void addLog()
        {
            log.AppendText(toLog.Dequeue()+"\n");
            log.ScrollToCaret();
            
        }
    }
}
