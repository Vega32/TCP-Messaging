namespace MessagingApp
{
    partial class Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            messageView = new RichTextBox();
            messageEntry = new TextBox();
            sendButton = new Button();
            SuspendLayout();
            // 
            // messageView
            // 
            messageView.BackColor = Color.FromArgb(0, 0, 64);
            messageView.BorderStyle = BorderStyle.None;
            messageView.Font = new Font("Lucida Console", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageView.ForeColor = Color.Fuchsia;
            messageView.Location = new Point(12, 12);
            messageView.Name = "messageView";
            messageView.ReadOnly = true;
            messageView.Size = new Size(760, 352);
            messageView.TabIndex = 0;
            messageView.Text = "";
            // 
            // messageEntry
            // 
            messageEntry.BackColor = Color.FromArgb(64, 0, 64);
            messageEntry.BorderStyle = BorderStyle.None;
            messageEntry.Font = new Font("Lucida Console", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageEntry.ForeColor = Color.Yellow;
            messageEntry.Location = new Point(12, 370);
            messageEntry.Multiline = true;
            messageEntry.Name = "messageEntry";
            messageEntry.Size = new Size(615, 79);
            messageEntry.TabIndex = 1;
            // 
            // sendButton
            // 
            sendButton.BackColor = Color.FromArgb(64, 0, 64);
            sendButton.FlatAppearance.BorderColor = Color.Fuchsia;
            sendButton.FlatAppearance.BorderSize = 2;
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.Font = new Font("Lucida Console", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sendButton.ForeColor = Color.Yellow;
            sendButton.Location = new Point(633, 370);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(139, 79);
            sendButton.TabIndex = 2;
            sendButton.Text = "SEND";
            sendButton.UseVisualStyleBackColor = false;
            sendButton.Click += sendButton_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(784, 461);
            Controls.Add(sendButton);
            Controls.Add(messageEntry);
            Controls.Add(messageView);
            Name = "Client";
            Text = "TCP-Messaging (Client)";
            Load += Client_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox messageView;
        private TextBox messageEntry;
        private Button sendButton;
    }
}
