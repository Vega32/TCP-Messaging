namespace MessagingApp
{
    internal static class Messaging
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Thread server = new Thread( () => RunServer("chat", 6000));
            Thread client = new Thread(() => RunClient("10.0.0.34", 6000, "Dio"));

           server.Start();
            client.Start();*/
            ApplicationConfiguration.Initialize();
            Application.Run(new MainMenu());
        }

        static void RunServer(string name, int port)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Server(name, port));
        }

        static void RunClient(string IP, int port, string name)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Client(IP, port, name));
        }
    }
}