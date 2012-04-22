namespace iRecognizeYou
{
	partial class Forma
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
			this.timerRecognize = new System.Windows.Forms.Timer(this.components);
			this.foundPersonName = new System.Windows.Forms.Label();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addFacesToDatabasesByDetectingThemFromFolderWithFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.chooseDir = new System.Windows.Forms.FolderBrowserDialog();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.addImagesWorker = new System.ComponentModel.BackgroundWorker();
			this.foundPerson = new OvalPictureBox();
			this.roundButton4 = new iRecognizeYou.RoundButton();
			this.exitButton = new iRecognizeYou.RoundButton();
			this.roundButton2 = new iRecognizeYou.RoundButton();
			this.roundButton1 = new iRecognizeYou.RoundButton();
			this.saveEigenfacesToDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveEigenValuesToDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.foundPerson)).BeginInit();
			this.SuspendLayout();
			// 
			// timerRecognize
			// 
			this.timerRecognize.Tick += new System.EventHandler(this.timerRecognize_Tick);
			// 
			// foundPersonName
			// 
			this.foundPersonName.BackColor = System.Drawing.Color.Transparent;
			this.foundPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.foundPersonName.ForeColor = System.Drawing.Color.Red;
			this.foundPersonName.Location = new System.Drawing.Point(64, 374);
			this.foundPersonName.Name = "foundPersonName";
			this.foundPersonName.Size = new System.Drawing.Size(130, 25);
			this.foundPersonName.TabIndex = 11;
			this.foundPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem [] {
            this.addFacesToDatabasesByDetectingThemFromFolderWithFilesToolStripMenuItem,
            this.saveEigenfacesToDesktopToolStripMenuItem,
            this.saveEigenValuesToDesktopToolStripMenuItem});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(380, 92);
			// 
			// addFacesToDatabasesByDetectingThemFromFolderWithFilesToolStripMenuItem
			// 
			this.addFacesToDatabasesByDetectingThemFromFolderWithFilesToolStripMenuItem.Name = "addFacesToDatabasesByDetectingThemFromFolderWithFilesToolStripMenuItem";
			this.addFacesToDatabasesByDetectingThemFromFolderWithFilesToolStripMenuItem.Size = new System.Drawing.Size(379, 22);
			this.addFacesToDatabasesByDetectingThemFromFolderWithFilesToolStripMenuItem.Text = "Add faces to databases by detecting them from folder with files";
			this.addFacesToDatabasesByDetectingThemFromFolderWithFilesToolStripMenuItem.Click += new System.EventHandler(this.detectFacesFromFolder);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(27, 125);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(195, 23);
			this.progressBar.TabIndex = 12;
			this.progressBar.Visible = false;
			// 
			// addImagesWorker
			// 
			this.addImagesWorker.WorkerReportsProgress = true;
			this.addImagesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.addImagesWorker_DoWork);
			this.addImagesWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.addImagesWorker_RunWorkerCompleted);
			this.addImagesWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.addImagesWorker_ProgressChanged);
			// 
			// foundPerson
			// 
			this.foundPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.foundPerson.Location = new System.Drawing.Point(67, 30);
			this.foundPerson.Name = "foundPerson";
			this.foundPerson.Size = new System.Drawing.Size(123, 119);
			this.foundPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.foundPerson.TabIndex = 10;
			this.foundPerson.TabStop = false;
			// 
			// roundButton4
			// 
			this.roundButton4.FlatStyle = EllipticalButton.Style.Standard;
			this.roundButton4.Location = new System.Drawing.Point(110, 243);
			this.roundButton4.Name = "roundButton4";
			this.roundButton4.Size = new System.Drawing.Size(30, 30);
			this.roundButton4.TabIndex = 9;
			this.roundButton4.Text = "Info";
			this.roundButton4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.info_Click);
			// 
			// exitButton
			// 
			this.exitButton.BackColor = System.Drawing.Color.WhiteSmoke;
			this.exitButton.FlatStyle = EllipticalButton.Style.Standard;
			this.exitButton.Location = new System.Drawing.Point(79, 318);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(93, 23);
			this.exitButton.TabIndex = 8;
			this.exitButton.Text = "Exit";
			this.exitButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.exit_stop_Click);
			// 
			// roundButton2
			// 
			this.roundButton2.FlatStyle = EllipticalButton.Style.Standard;
			this.roundButton2.Location = new System.Drawing.Point(153, 174);
			this.roundButton2.Name = "roundButton2";
			this.roundButton2.Size = new System.Drawing.Size(69, 35);
			this.roundButton2.TabIndex = 7;
			this.roundButton2.Text = "Recognize";
			this.roundButton2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.recognize_Click);
			// 
			// roundButton1
			// 
			this.roundButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.roundButton1.FlatStyle = EllipticalButton.Style.Standard;
			this.roundButton1.ForeColor = System.Drawing.Color.Black;
			this.roundButton1.Location = new System.Drawing.Point(27, 174);
			this.roundButton1.Name = "roundButton1";
			this.roundButton1.Size = new System.Drawing.Size(69, 35);
			this.roundButton1.TabIndex = 6;
			this.roundButton1.Text = "Enroll";
			this.roundButton1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.train_Click);
			// 
			// saveEigenfacesToDesktopToolStripMenuItem
			// 
			this.saveEigenfacesToDesktopToolStripMenuItem.Name = "saveEigenfacesToDesktopToolStripMenuItem";
			this.saveEigenfacesToDesktopToolStripMenuItem.Size = new System.Drawing.Size(379, 22);
			this.saveEigenfacesToDesktopToolStripMenuItem.Text = "Save Eigenfaces to desktop";
			// 
			// saveEigenValuesToDesktopToolStripMenuItem
			// 
			this.saveEigenValuesToDesktopToolStripMenuItem.Name = "saveEigenValuesToDesktopToolStripMenuItem";
			this.saveEigenValuesToDesktopToolStripMenuItem.Size = new System.Drawing.Size(379, 22);
			this.saveEigenValuesToDesktopToolStripMenuItem.Text = "Save EigenValues to desktop";
			// 
			// Forma
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::iRecognizeYou.Properties.Resources.face;
			this.ClientSize = new System.Drawing.Size(250, 425);
			this.ContextMenuStrip = this.contextMenu;
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.foundPersonName);
			this.Controls.Add(this.foundPerson);
			this.Controls.Add(this.roundButton4);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.roundButton2);
			this.Controls.Add(this.roundButton1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(250, 425);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(250, 425);
			this.Name = "Forma";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "iRecognizeYou";
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
			this.contextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.foundPerson)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RoundButton roundButton1;
		private RoundButton roundButton2;
		private RoundButton exitButton;
		private RoundButton roundButton4;
		private System.Windows.Forms.Timer timerRecognize;
		private OvalPictureBox foundPerson;
		private System.Windows.Forms.Label foundPersonName;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem addFacesToDatabasesByDetectingThemFromFolderWithFilesToolStripMenuItem;
		private System.Windows.Forms.FolderBrowserDialog chooseDir;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.ComponentModel.BackgroundWorker addImagesWorker;
		private System.Windows.Forms.ToolStripMenuItem saveEigenfacesToDesktopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveEigenValuesToDesktopToolStripMenuItem;
	}
}

