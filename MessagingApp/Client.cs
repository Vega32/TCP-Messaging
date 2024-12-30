using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessagingApp
{
    public partial class Client : Form
    {

        public readonly string ServerAddress;
        public readonly int Port;
        private TcpClient client;
        public bool Running { get; private set; }
        private bool disconnectRequested = false;

        //Buffer
        private readonly int BufferSize = 2 * 1024;
        private NetworkStream msgStream;

        public readonly string Username;

        //Threading
        private ThreadStart ts;
        private Thread t;
        private delegate void loggerDelegate();
        private Queue<string> toLog = new Queue<string>();

        public Client(string serverAddress, int port, string name)
        {

            client = new TcpClient();
            client.SendBufferSize = BufferSize;
            client.ReceiveBufferSize = BufferSize;
            Running = false;

            ServerAddress = serverAddress;
            Port = port;
            Username = name;

            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Client_FormClosing);
        }

        //Disconnects happens when the window is closed
        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
            cleanupNetworkResources();
        }

        public void Connect()
        {
            // Try to connect
            EndPoint endPoint = null;
            try
            {
                client.Connect(ServerAddress, Port);
                endPoint = client.Client.RemoteEndPoint;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (client.Connected)
            {
                Console.WriteLine("Connected to the server");

                //Registering to the server
                msgStream = client.GetStream();
                byte[] msgBuffer = Encoding.UTF8.GetBytes(String.Format("name:{0}", Username));
                msgStream.Write(msgBuffer, 0, msgBuffer.Length);

                //Check if the server has accepted the connection
                if (!isDisconnected(client))
                    Running = true;
                else
                {
                    cleanupNetworkResources();
                    toLog.Enqueue("The server rejected you; \"" + Username + "\" is probably in use.");
                    messageView.BeginInvoke(new loggerDelegate(addLog));
                }
            }
            else
            {
                cleanupNetworkResources();
                toLog.Enqueue("Wasn't able to connect to the server");
                messageView.BeginInvoke(new loggerDelegate(addLog));
            }
        }

        public void Disconnect()
        {
            Running = false;
            disconnectRequested = true;
            toLog.Enqueue("Disconnecting from the chat...");
            messageView.BeginInvoke(new loggerDelegate(addLog));
        }

        //Starts the threads and connects to the server after the window has loaded
        private void Client_Load(object sender, EventArgs e)
        {
            ts = new ThreadStart(ListenForMessages);
            t = new Thread(ts);
            t.Start();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string msg = messageEntry.Text;
            if(msg != string.Empty && Running==true)
            {
                byte[] msgBuffer = Encoding.UTF8.GetBytes(msg);
                msgStream.Write(msgBuffer, 0, msgBuffer.Length);
            }
        }

        public void ListenForMessages()
        {
            Connect();//Starts connection to server

            // Listen for messages
            while (Running)
            {
                // Do we have a new message?
                int messageLength = client.Available;
                if (messageLength > 0)
                {
                    // Read the whole message
                    byte[] msgBuffer = new byte[messageLength];
                    msgStream.Read(msgBuffer, 0, messageLength);

                    // Decode it and print it
                    string msg = Encoding.UTF8.GetString(msgBuffer);
                    if (msg == "ifyouarereadingthislmaogetalife")
                    {
                        Disconnect();
                    }
                    else
                    {
                        toLog.Enqueue(msg);
                        messageView.BeginInvoke(new loggerDelegate(addLog));
                    }
                    
                }

                // Use less CPU
                Thread.Sleep(10);

                // Check if the server has disconnected
                if (isDisconnected(client))
                {
                    Running = false;
                    toLog.Enqueue("Server has disconnected");
                    messageView.BeginInvoke(new loggerDelegate(addLog));
                }

                // Check that a cancel has been requested by the user
                Running &= !disconnectRequested;
            }

            // Cleanup
            cleanupNetworkResources();
            
        }

        private void cleanupNetworkResources()
        {
            msgStream?.Close();
            msgStream = null;
            client.Close();
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

        //Function to write to the message viewer
        private void addLog()
        {
            messageView.AppendText(toLog.Dequeue() + "\n");
            messageView.ScrollToCaret();
            messageEntry.Clear();
        }
    }
}
