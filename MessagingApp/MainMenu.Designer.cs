namespace MessagingApp
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            JoinButton = new Button();
            HostButton = new Button();
            Title = new Label();
            StartButton = new Button();
            ChatRoomNameLabel = new Label();
            ChatRoomNameEntry = new TextBox();
            UsernameEntry = new TextBox();
            UsernameLabel = new Label();
            PortEntry = new TextBox();
            PortLabel = new Label();
            IPEntry = new TextBox();
            IPLabel = new Label();
            SuspendLayout();
            // 
            // JoinButton
            // 
            JoinButton.BackColor = Color.FromArgb(64, 0, 64);
            JoinButton.FlatAppearance.BorderColor = Color.Fuchsia;
            JoinButton.FlatAppearance.BorderSize = 2;
            JoinButton.FlatStyle = FlatStyle.Flat;
            JoinButton.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            JoinButton.ForeColor = Color.Yellow;
            JoinButton.Location = new Point(250, 165);
            JoinButton.Margin = new Padding(3, 2, 3, 2);
            JoinButton.Name = "JoinButton";
            JoinButton.Size = new Size(300, 85);
            JoinButton.TabIndex = 0;
            JoinButton.Text = "Join chat room";
            JoinButton.UseVisualStyleBackColor = false;
            JoinButton.Click += Join_Click;
            // 
            // HostButton
            // 
            HostButton.BackColor = Color.FromArgb(64, 0, 64);
            HostButton.FlatAppearance.BorderColor = Color.Fuchsia;
            HostButton.FlatAppearance.BorderSize = 2;
            HostButton.FlatStyle = FlatStyle.Flat;
            HostButton.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HostButton.ForeColor = Color.Yellow;
            HostButton.Location = new Point(250, 304);
            HostButton.Margin = new Padding(3, 2, 3, 2);
            HostButton.Name = "HostButton";
            HostButton.Size = new Size(300, 85);
            HostButton.TabIndex = 1;
            HostButton.Text = "Host chat room";
            HostButton.UseVisualStyleBackColor = false;
            HostButton.Click += Host_Click;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Lucida Console", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Title.ForeColor = Color.Fuchsia;
            Title.Location = new Point(200, 45);
            Title.Name = "Title";
            Title.Size = new Size(397, 48);
            Title.TabIndex = 2;
            Title.Text = "TCP-Messenger";
            // 
            // StartButton
            // 
            StartButton.BackColor = Color.FromArgb(64, 0, 64);
            StartButton.FlatAppearance.BorderColor = Color.Fuchsia;
            StartButton.FlatAppearance.BorderSize = 2;
            StartButton.FlatStyle = FlatStyle.Flat;
            StartButton.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartButton.ForeColor = Color.Yellow;
            StartButton.Location = new Point(300, 400);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(200, 50);
            StartButton.TabIndex = 3;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Visible = false;
            StartButton.Click += StartButton_Click;
            // 
            // ChatRoomNameLabel
            // 
            ChatRoomNameLabel.AutoSize = true;
            ChatRoomNameLabel.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ChatRoomNameLabel.ForeColor = Color.Fuchsia;
            ChatRoomNameLabel.Location = new Point(74, 147);
            ChatRoomNameLabel.Name = "ChatRoomNameLabel";
            ChatRoomNameLabel.Size = new Size(220, 24);
            ChatRoomNameLabel.TabIndex = 4;
            ChatRoomNameLabel.Text = "Chat room name:";
            ChatRoomNameLabel.Visible = false;
            // 
            // ChatRoomNameEntry
            // 
            ChatRoomNameEntry.BackColor = Color.FromArgb(64, 0, 64);
            ChatRoomNameEntry.BorderStyle = BorderStyle.None;
            ChatRoomNameEntry.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ChatRoomNameEntry.ForeColor = Color.Yellow;
            ChatRoomNameEntry.Location = new Point(300, 147);
            ChatRoomNameEntry.Name = "ChatRoomNameEntry";
            ChatRoomNameEntry.Size = new Size(392, 24);
            ChatRoomNameEntry.TabIndex = 5;
            ChatRoomNameEntry.Visible = false;
            // 
            // UsernameEntry
            // 
            UsernameEntry.BackColor = Color.FromArgb(64, 0, 64);
            UsernameEntry.BorderStyle = BorderStyle.None;
            UsernameEntry.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsernameEntry.ForeColor = Color.Yellow;
            UsernameEntry.Location = new Point(300, 205);
            UsernameEntry.Name = "UsernameEntry";
            UsernameEntry.Size = new Size(392, 24);
            UsernameEntry.TabIndex = 7;
            UsernameEntry.Visible = false;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsernameLabel.ForeColor = Color.Fuchsia;
            UsernameLabel.Location = new Point(74, 205);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(136, 24);
            UsernameLabel.TabIndex = 6;
            UsernameLabel.Text = "Username:";
            UsernameLabel.Visible = false;
            // 
            // PortEntry
            // 
            PortEntry.BackColor = Color.FromArgb(64, 0, 64);
            PortEntry.BorderStyle = BorderStyle.None;
            PortEntry.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PortEntry.ForeColor = Color.Yellow;
            PortEntry.Location = new Point(300, 267);
            PortEntry.Name = "PortEntry";
            PortEntry.Size = new Size(392, 24);
            PortEntry.TabIndex = 9;
            PortEntry.Visible = false;
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PortLabel.ForeColor = Color.Fuchsia;
            PortLabel.Location = new Point(74, 267);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(178, 24);
            PortLabel.TabIndex = 8;
            PortLabel.Text = "Port number:";
            PortLabel.Visible = false;
            // 
            // IPEntry
            // 
            IPEntry.BackColor = Color.FromArgb(64, 0, 64);
            IPEntry.BorderStyle = BorderStyle.None;
            IPEntry.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IPEntry.ForeColor = Color.Yellow;
            IPEntry.Location = new Point(300, 147);
            IPEntry.Name = "IPEntry";
            IPEntry.Size = new Size(392, 24);
            IPEntry.TabIndex = 11;
            IPEntry.Visible = false;
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Font = new Font("Lucida Console", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IPLabel.ForeColor = Color.Fuchsia;
            IPLabel.Location = new Point(74, 147);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(164, 24);
            IPLabel.TabIndex = 10;
            IPLabel.Text = "IP address:";
            IPLabel.Visible = false;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(784, 461);
            Controls.Add(IPEntry);
            Controls.Add(IPLabel);
            Controls.Add(PortEntry);
            Controls.Add(PortLabel);
            Controls.Add(UsernameEntry);
            Controls.Add(UsernameLabel);
            Controls.Add(ChatRoomNameEntry);
            Controls.Add(ChatRoomNameLabel);
            Controls.Add(StartButton);
            Controls.Add(Title);
            Controls.Add(HostButton);
            Controls.Add(JoinButton);
            Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainMenu";
            Text = "TCP-Messaging";
            Load += Main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button JoinButton;
        private Button HostButton;
        private Label Title;
        private Button StartButton;
        private Label ChatRoomNameLabel;
        private TextBox ChatRoomNameEntry;
        private TextBox UsernameEntry;
        private Label UsernameLabel;
        private TextBox PortEntry;
        private Label PortLabel;
        private TextBox IPEntry;
        private Label IPLabel;
    }
}