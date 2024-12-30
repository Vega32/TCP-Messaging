using System.Net.Sockets;
using System.Net;

namespace MessagingApp
{
    public partial class MainMenu : Form
    {
        //Form data
        private string IP;
        private int Port;
        private string ChatName;
        private string Username;
        private bool IsHosting;

        public MainMenu()
        {
            InitializeComponent();
        }

        //nothing happens when the window is done loading
        private void Main_Load(object sender, EventArgs e)
        {

        }

        //Server thread function
        static void RunServer(string name, int port)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Server(name, port));
        }

        //Client thread function
        static void RunClient(string IP, int port, string name)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Client(IP, port, name));
        }

        /*
         Clicking on the Join button hides the join and host buttons
         and displays the form fields
         */
        private void Join_Click(object sender, EventArgs e)
        {
            IsHosting = false;

            JoinButton.Visible = false;
            HostButton.Visible = false;

            UsernameLabel.Visible = true;
            UsernameEntry.Visible = true;
            PortLabel.Visible = true;
            PortEntry.Visible = true;
            IPLabel.Visible = true;
            IPEntry.Visible = true;

            StartButton.Visible = true;
        }

        /*
         Same as Join_Click but shows different form fields
         */
        private void Host_Click(object sender, EventArgs e)
        {
            IsHosting = true;

            JoinButton.Visible = false;
            HostButton.Visible = false;

            ChatRoomNameLabel.Visible = true;
            ChatRoomNameEntry.Visible = true;
            UsernameLabel.Visible = true;
            UsernameEntry.Visible = true;
            PortLabel.Visible = true;
            PortEntry.Visible = true;

            StartButton.Visible = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //The user will both host and join a chat room
            if (IsHosting)
            {
                //Checking if the fields are not empty
                if(ChatRoomNameEntry.Text==string.Empty)
                {
                    MessageBox.Show("Missing chat room name");
                }
                else if(UsernameEntry.Text==string.Empty)
                {
                    MessageBox.Show("Missing username");
                }
                else if (PortEntry.Text == string.Empty)
                {
                    MessageBox.Show("Missing port number");
                }
                else
                {
                    IP = GetLocalIPAddress();
                    Username = UsernameEntry.Text;
                    ChatName = ChatRoomNameEntry.Text;
                    //To make sure that the Port is a number
                    try
                    {
                        Port = Int32.Parse(PortEntry.Text);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Invalid port number");
                        return;
                    }
                    //Start server and client threads
                    Thread server = new Thread(() => RunServer(ChatName, Port));
                    Thread client = new Thread(() => RunClient(IP, Port, Username));

                    server.Start();
                    client.Start();
                    this.Close();
                }
            }
            //User just wants to join an existing chat room
            else
            {
                //Checks that the fields are not empty
                if (IPEntry.Text == string.Empty)
                {
                    MessageBox.Show("Missing IP address");
                }
                else if (UsernameEntry.Text == string.Empty)
                {
                    MessageBox.Show("Missing username");
                }
                else if (PortEntry.Text == string.Empty)
                {
                    MessageBox.Show("Missing port number");
                }
                else
                {
                    IP = IPEntry.Text;
                    Username = UsernameEntry.Text;
                    //To make sure the Port is a number
                    try
                    {
                        Port = Int32.Parse(PortEntry.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid port number");
                        return;
                    }
                    //Start client thread
                    Thread client = new Thread(() => RunClient(IP, Port, Username));
                    client.Start();
                    this.Close();
                }
            }
        }

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
    }
}
