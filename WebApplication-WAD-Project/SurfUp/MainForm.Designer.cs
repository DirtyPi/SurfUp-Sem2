
namespace SurfUp
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAsnDsn = new System.Windows.Forms.Button();
            this.btnSortByDate = new System.Windows.Forms.Button();
            this.btnSortByTitle = new System.Windows.Forms.Button();
            this.btnSortByID = new System.Windows.Forms.Button();
            this.btnRemovePost = new System.Windows.Forms.Button();
            this.btnAddPost = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTypeOfPosts = new System.Windows.Forms.ComboBox();
            this.lbPosts = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnViewUser = new System.Windows.Forms.Button();
            this.btnPrmDem = new System.Windows.Forms.Button();
            this.btnBan = new System.Windows.Forms.Button();
            this.lbAdminList = new System.Windows.Forms.ListBox();
            this.lbUserList = new System.Windows.Forms.ListBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1087, 397);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAsnDsn);
            this.tabPage1.Controls.Add(this.btnSortByDate);
            this.tabPage1.Controls.Add(this.btnSortByTitle);
            this.tabPage1.Controls.Add(this.btnSortByID);
            this.tabPage1.Controls.Add(this.btnRemovePost);
            this.tabPage1.Controls.Add(this.btnAddPost);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbSearchBar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbTypeOfPosts);
            this.tabPage1.Controls.Add(this.lbPosts);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1079, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manage Posts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAsnDsn
            // 
            this.btnAsnDsn.Location = new System.Drawing.Point(847, 167);
            this.btnAsnDsn.Name = "btnAsnDsn";
            this.btnAsnDsn.Size = new System.Drawing.Size(176, 29);
            this.btnAsnDsn.TabIndex = 10;
            this.btnAsnDsn.Text = "Reverse";
            this.btnAsnDsn.UseVisualStyleBackColor = true;
            this.btnAsnDsn.Click += new System.EventHandler(this.btnAsnDsn_Click_1);
            // 
            // btnSortByDate
            // 
            this.btnSortByDate.Location = new System.Drawing.Point(847, 132);
            this.btnSortByDate.Name = "btnSortByDate";
            this.btnSortByDate.Size = new System.Drawing.Size(176, 29);
            this.btnSortByDate.TabIndex = 9;
            this.btnSortByDate.Text = "Sort by date";
            this.btnSortByDate.UseVisualStyleBackColor = true;
            this.btnSortByDate.Click += new System.EventHandler(this.btnSortByDate_Click);
            // 
            // btnSortByTitle
            // 
            this.btnSortByTitle.Location = new System.Drawing.Point(847, 97);
            this.btnSortByTitle.Name = "btnSortByTitle";
            this.btnSortByTitle.Size = new System.Drawing.Size(176, 29);
            this.btnSortByTitle.TabIndex = 8;
            this.btnSortByTitle.Text = "Sort by title";
            this.btnSortByTitle.UseVisualStyleBackColor = true;
            this.btnSortByTitle.Click += new System.EventHandler(this.btnSortByTitle_Click_1);
            // 
            // btnSortByID
            // 
            this.btnSortByID.Location = new System.Drawing.Point(847, 62);
            this.btnSortByID.Name = "btnSortByID";
            this.btnSortByID.Size = new System.Drawing.Size(176, 29);
            this.btnSortByID.TabIndex = 7;
            this.btnSortByID.Text = "Sort by ID";
            this.btnSortByID.UseVisualStyleBackColor = true;
            this.btnSortByID.Click += new System.EventHandler(this.btnSortByID_Click_1);
            // 
            // btnRemovePost
            // 
            this.btnRemovePost.Location = new System.Drawing.Point(321, 272);
            this.btnRemovePost.Name = "btnRemovePost";
            this.btnRemovePost.Size = new System.Drawing.Size(300, 68);
            this.btnRemovePost.TabIndex = 6;
            this.btnRemovePost.Text = "Remove post";
            this.btnRemovePost.UseVisualStyleBackColor = true;
            this.btnRemovePost.Click += new System.EventHandler(this.btnRemovePost_Click);
            // 
            // btnAddPost
            // 
            this.btnAddPost.Location = new System.Drawing.Point(7, 272);
            this.btnAddPost.Name = "btnAddPost";
            this.btnAddPost.Size = new System.Drawing.Size(300, 68);
            this.btnAddPost.TabIndex = 5;
            this.btnAddPost.Text = "Add Post";
            this.btnAddPost.UseVisualStyleBackColor = true;
            this.btnAddPost.Click += new System.EventHandler(this.btnAddPost_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search:";
            // 
            // tbSearchBar
            // 
            this.tbSearchBar.Location = new System.Drawing.Point(377, 22);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(464, 27);
            this.tbSearchBar.TabIndex = 3;
            this.tbSearchBar.TextChanged += new System.EventHandler(this.tbSearchBar_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type:";
            // 
            // cbTypeOfPosts
            // 
            this.cbTypeOfPosts.FormattingEnabled = true;
            this.cbTypeOfPosts.Location = new System.Drawing.Point(139, 19);
            this.cbTypeOfPosts.Name = "cbTypeOfPosts";
            this.cbTypeOfPosts.Size = new System.Drawing.Size(151, 28);
            this.cbTypeOfPosts.TabIndex = 1;
            this.cbTypeOfPosts.SelectedIndexChanged += new System.EventHandler(this.cbTypeOfPosts_SelectedIndexChanged_1);
            // 
            // lbPosts
            // 
            this.lbPosts.FormattingEnabled = true;
            this.lbPosts.ItemHeight = 20;
            this.lbPosts.Location = new System.Drawing.Point(8, 62);
            this.lbPosts.Name = "lbPosts";
            this.lbPosts.Size = new System.Drawing.Size(833, 204);
            this.lbPosts.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnViewUser);
            this.tabPage2.Controls.Add(this.btnPrmDem);
            this.tabPage2.Controls.Add(this.btnBan);
            this.tabPage2.Controls.Add(this.lbAdminList);
            this.tabPage2.Controls.Add(this.lbUserList);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1079, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manage Users";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnViewUser
            // 
            this.btnViewUser.Location = new System.Drawing.Point(757, 230);
            this.btnViewUser.Name = "btnViewUser";
            this.btnViewUser.Size = new System.Drawing.Size(254, 58);
            this.btnViewUser.TabIndex = 4;
            this.btnViewUser.Text = "View Selected User";
            this.btnViewUser.UseVisualStyleBackColor = true;
            this.btnViewUser.Click += new System.EventHandler(this.btnViewUser_Click_1);
            // 
            // btnPrmDem
            // 
            this.btnPrmDem.Location = new System.Drawing.Point(757, 144);
            this.btnPrmDem.Name = "btnPrmDem";
            this.btnPrmDem.Size = new System.Drawing.Size(254, 58);
            this.btnPrmDem.TabIndex = 3;
            this.btnPrmDem.Text = "Promote/Demote Selected User";
            this.btnPrmDem.UseVisualStyleBackColor = true;
            this.btnPrmDem.Click += new System.EventHandler(this.btnPrmDem_Click);
            // 
            // btnBan
            // 
            this.btnBan.Location = new System.Drawing.Point(757, 50);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(254, 58);
            this.btnBan.TabIndex = 2;
            this.btnBan.Text = "Ban Selected User";
            this.btnBan.UseVisualStyleBackColor = true;
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click_1);
            // 
            // lbAdminList
            // 
            this.lbAdminList.FormattingEnabled = true;
            this.lbAdminList.ItemHeight = 20;
            this.lbAdminList.Location = new System.Drawing.Point(417, 50);
            this.lbAdminList.Name = "lbAdminList";
            this.lbAdminList.Size = new System.Drawing.Size(245, 264);
            this.lbAdminList.TabIndex = 1;
            // 
            // lbUserList
            // 
            this.lbUserList.FormattingEnabled = true;
            this.lbUserList.ItemHeight = 20;
            this.lbUserList.Location = new System.Drawing.Point(83, 45);
            this.lbUserList.Name = "lbUserList";
            this.lbUserList.Size = new System.Drawing.Size(245, 264);
            this.lbUserList.TabIndex = 0;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(993, 409);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(94, 29);
            this.btnLogOut.TabIndex = 11;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 450);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnAsnDsn;
        private System.Windows.Forms.Button btnSortByDate;
        private System.Windows.Forms.Button btnSortByTitle;
        private System.Windows.Forms.Button btnSortByID;
        private System.Windows.Forms.Button btnRemovePost;
        private System.Windows.Forms.Button btnAddPost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSearchBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTypeOfPosts;
        private System.Windows.Forms.ListBox lbPosts;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnViewUser;
        private System.Windows.Forms.Button btnPrmDem;
        private System.Windows.Forms.Button btnBan;
        private System.Windows.Forms.ListBox lbAdminList;
        private System.Windows.Forms.ListBox lbUserList;
        private System.Windows.Forms.Button btnLogOut;
    }
}