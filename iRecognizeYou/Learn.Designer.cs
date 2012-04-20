namespace iRecognizeYou
{
	partial class Learn
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
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
		private void InitializeComponent( )
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.display = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.startButton = new iRecognizeYou.RoundButton();
			this.imageFromCamera = new OvalPictureBox();
			this.closeButton = new iRecognizeYou.RoundButton();
			((System.ComponentModel.ISupportInitialize)(this.imageFromCamera)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// display
			// 
			this.display.AutoSize = true;
			this.display.BackColor = System.Drawing.Color.Transparent;
			this.display.Font = new System.Drawing.Font("Microsoft Sans Serif", 40.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.display.ForeColor = System.Drawing.Color.Red;
			this.display.Location = new System.Drawing.Point(169, 175);
			this.display.Name = "display";
			this.display.Size = new System.Drawing.Size(57, 63);
			this.display.TabIndex = 3;
			this.display.Text = "0";
			// 
			// nameTextBox
			// 
			this.nameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.nameTextBox.ForeColor = System.Drawing.Color.Black;
			this.nameTextBox.Location = new System.Drawing.Point(107, 267);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(205, 20);
			this.nameTextBox.TabIndex = 0;
			this.nameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.BackColor = System.Drawing.Color.Transparent;
			this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.nameLabel.ForeColor = System.Drawing.Color.Red;
			this.nameLabel.Location = new System.Drawing.Point(102, 238);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(210, 26);
			this.nameLabel.TabIndex = 5;
			this.nameLabel.Text = "Name and surname:";
			this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// startButton
			// 
			this.startButton.BackColor = System.Drawing.Color.WhiteSmoke;
			this.startButton.FlatStyle = EllipticalButton.Style.Standard;
			this.startButton.Location = new System.Drawing.Point(176, 188);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(50, 50);
			this.startButton.TabIndex = 2;
			this.startButton.Text = "Start";
			this.startButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.startButton_MouseClick);
			// 
			// imageFromCamera
			// 
			this.imageFromCamera.BackColor = System.Drawing.Color.Transparent;
			this.imageFromCamera.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageFromCamera.Location = new System.Drawing.Point(0, 0);
			this.imageFromCamera.Name = "imageFromCamera";
			this.imageFromCamera.Size = new System.Drawing.Size(400, 400);
			this.imageFromCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imageFromCamera.TabIndex = 1;
			this.imageFromCamera.TabStop = false;
			this.imageFromCamera.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
			this.imageFromCamera.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
			this.imageFromCamera.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
			// 
			// closeButton
			// 
			this.closeButton.BackColor = System.Drawing.Color.WhiteSmoke;
			this.closeButton.FlatStyle = EllipticalButton.Style.Standard;
			this.closeButton.ForeColor = System.Drawing.Color.Black;
			this.closeButton.Location = new System.Drawing.Point(132, 54);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(141, 28);
			this.closeButton.TabIndex = 6;
			this.closeButton.Text = "Close";
			this.closeButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.closeButton_MouseClick);
			// 
			// Learn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(400, 400);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.display);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.imageFromCamera);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(400, 400);
			this.MinimumSize = new System.Drawing.Size(400, 400);
			this.Name = "Learn";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Learn";
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Learn_FormClosing);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.imageFromCamera)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private OvalPictureBox imageFromCamera;
		private System.Windows.Forms.Timer timer1;
		private RoundButton startButton;
		private System.Windows.Forms.Label display;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label nameLabel;
		private RoundButton closeButton;

	}
}