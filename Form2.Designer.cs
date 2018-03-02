namespace PersonalAsistance01
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vIEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hidePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.playList = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.vIEWToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(664, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.browseToolStripMenuItem.Text = "Browse";
            this.browseToolStripMenuItem.Click += new System.EventHandler(this.browseToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // vIEWToolStripMenuItem
            // 
            this.vIEWToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hidePlaylistToolStripMenuItem,
            this.showPlaylistToolStripMenuItem});
            this.vIEWToolStripMenuItem.Name = "vIEWToolStripMenuItem";
            this.vIEWToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.vIEWToolStripMenuItem.Text = "VIEW";
            // 
            // hidePlaylistToolStripMenuItem
            // 
            this.hidePlaylistToolStripMenuItem.Name = "hidePlaylistToolStripMenuItem";
            this.hidePlaylistToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.hidePlaylistToolStripMenuItem.Text = "Hide Playlist";
            this.hidePlaylistToolStripMenuItem.Click += new System.EventHandler(this.hidePlaylistToolStripMenuItem_Click);
            // 
            // showPlaylistToolStripMenuItem
            // 
            this.showPlaylistToolStripMenuItem.Name = "showPlaylistToolStripMenuItem";
            this.showPlaylistToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.showPlaylistToolStripMenuItem.Text = "Show Playlist";
            this.showPlaylistToolStripMenuItem.Click += new System.EventHandler(this.showPlaylistToolStripMenuItem_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // myPlayer
            // 
            this.myPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myPlayer.Enabled = true;
            this.myPlayer.Location = new System.Drawing.Point(0, 24);
            this.myPlayer.Name = "myPlayer";
            this.myPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("myPlayer.OcxState")));
            this.myPlayer.Size = new System.Drawing.Size(519, 320);
            this.myPlayer.TabIndex = 1;
            // 
            // playList
            // 
            this.playList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playList.BackColor = System.Drawing.Color.Black;
            this.playList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playList.ForeColor = System.Drawing.Color.Teal;
            this.playList.FormattingEnabled = true;
            this.playList.ItemHeight = 18;
            this.playList.Location = new System.Drawing.Point(518, 24);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(146, 324);
            this.playList.TabIndex = 2;
            this.playList.SelectedIndexChanged += new System.EventHandler(this.playList_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 344);
            this.Controls.Add(this.playList);
            this.Controls.Add(this.myPlayer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vIEWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hidePlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer myPlayer;
        private System.Windows.Forms.ListBox playList;
    }
}