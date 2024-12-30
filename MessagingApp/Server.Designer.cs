namespace MessagingApp
{
    partial class Server
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
            log = new RichTextBox();
            shutdownButton = new Button();
            SuspendLayout();
            // 
            // log
            // 
            log.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            log.BackColor = Color.FromArgb(0, 0, 64);
            log.BorderStyle = BorderStyle.None;
            log.Font = new Font("Lucida Console", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            log.ForeColor = Color.Fuchsia;
            log.Location = new Point(12, 12);
            log.Name = "log";
            log.ReadOnly = true;
            log.Size = new Size(760, 387);
            log.TabIndex = 0;
            log.Text = "";
            log.HandleCreated += log_HandleCreated;
            // 
            // shutdownButton
            // 
            shutdownButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            shutdownButton.BackColor = Color.Purple;
            shutdownButton.FlatAppearance.BorderColor = Color.Fuchsia;
            shutdownButton.FlatAppearance.BorderSize = 2;
            shutdownButton.FlatStyle = FlatStyle.Flat;
            shutdownButton.Font = new Font("Lucida Console", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            shutdownButton.ForeColor = Color.Yellow;
            shutdownButton.Location = new Point(300, 405);
            shutdownButton.Name = "shutdownButton";
            shutdownButton.Size = new Size(200, 45);
            shutdownButton.TabIndex = 1;
            shutdownButton.Text = "Shutdown Server";
            shutdownButton.UseVisualStyleBackColor = false;
            shutdownButton.Click += shutdownButton_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(784, 461);
            Controls.Add(shutdownButton);
            Controls.Add(log);
            Name = "Server";
            Text = "TCP-Messaging (Server)";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox log;
        private Button shutdownButton;
    }
}