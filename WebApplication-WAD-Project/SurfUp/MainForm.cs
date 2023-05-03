using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClassLibrary;
using ClassLibraryService;

namespace SurfUp
{
    public partial class MainForm : Form
    {
        private UserManager userManager;// = new UserManager();
        private Users users;
        private PostMediator postMediator = new PostMediator();
        private PostManager pm;
        private UserMediator userMediator = new UserMediator();
        public MainForm(Users user)
        {
            InitializeComponent();
           
            pm = new PostManager(postMediator);
            userManager = new UserManager(userMediator);
            PopulateUserList();
            this.users = user;
            cbTypeOfPosts.DataSource = Enum.GetValues(typeof(TypeOfPostEnum));
            LoadData();
        }

        private void PopulateUserList()
        {
            lbAdminList.Items.Clear();
            foreach (Users e in userManager.GetAdminUsers())
            {
                lbAdminList.Items.Add(e.ToString());
            }
            lbUserList.Items.Clear();
            foreach (Users e in userManager.GetBaseUsers())
            {
                lbUserList.Items.Add(e.ToString());
            }
        }
        private void DataToListBox(List<Post> data)
        {
            lbPosts.Items.Clear();
            foreach (Post p in data)
            {
                lbPosts.Items.Add(p.ToString());
            }
        }
        private List<Post> LoadData()
        {
            int type = cbTypeOfPosts.SelectedIndex;
            List<Post> postList = new List<Post>();
            foreach (Post p in pm.GetPostByType(type))
            {
                postList.Add(p);
            }
            return postList;
        }
       
       

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSortByID_Click_1(object sender, EventArgs e)
        {
            SortByID sortByID = new SortByID();
            List<Post> temp = LoadData();
            temp.Sort(sortByID);
            DataToListBox(temp);
        }
        private void btnAsnDsn_Click_1(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            foreach (object o in lbPosts.Items)
            {
                list.Add(o);
            }
            list.Reverse();
            lbPosts.Items.Clear();
            foreach (object o in list)
            {
                lbPosts.Items.Add(o);
            }
        }
        private void btnSortByTitle_Click_1(object sender, EventArgs e)
        {
            SortByTitlePost sortByT = new SortByTitlePost();
            List<Post> temp = LoadData();
            temp.Sort(sortByT);
            DataToListBox(temp);
        }
        private void btnSortByDate_Click(object sender, EventArgs e)
        {
            SortByDatePost sortByDate = new SortByDatePost();
            List<Post> temp = LoadData();
            temp.Sort(sortByDate);
            DataToListBox(temp);
        }
        private void btnAddPost_Click(object sender, EventArgs e)
        {
            TypeOfPost top = new TypeOfPost(users);
            top.ShowDialog();
            DataToListBox(LoadData());
        }
        private void btnRemovePost_Click(object sender, EventArgs e)
        {
            if (lbPosts.SelectedIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this post?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int filtered = Convert.ToInt32(lbPosts.SelectedItem.ToString().Substring(0, lbPosts.SelectedItem.ToString().IndexOf(" ")));
                    Post p = pm.GetPostById(filtered);
                    pm.Delete(p);
                    MessageBox.Show("Post has been deleted successfully");
                    DataToListBox(LoadData());
                }
            }
        }
        private void tbSearchBar_TextChanged_1(object sender, EventArgs e)
        {
            lbPosts.Items.Clear();
            string text = tbSearchBar.Text;
            if (text == "")
            {
                DataToListBox(LoadData());
            }
            else
            {
                foreach (Post p in pm.SearchPost(text))
                {
                    this.lbPosts.Items.Add(p);
                }
            }
        }
        private void cbTypeOfPosts_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataToListBox(LoadData());
        }
        private void btnBan_Click_1(object sender, EventArgs e)
        {
            if (lbUserList.SelectedIndex >= 0)
            {
                int filtered = Convert.ToInt32(lbUserList.SelectedItem.ToString().Substring(0, lbUserList.SelectedItem.ToString().IndexOf(" ")));
                Users u = userManager.GetUserByID(filtered);
                userManager.UpdateUserStatus(u);
                MessageBox.Show("User has been banned from the application!");
            }
            else if ((lbAdminList.SelectedIndex >= 0))
            {
                MessageBox.Show("Admins can not be banned!");
            }
        }
        private void btnPrmDem_Click(object sender, EventArgs e)
        {
            if (lbUserList.SelectedIndex >= 0)
            {
                int filtered = Convert.ToInt32(lbUserList.SelectedItem.ToString().Substring(0, lbUserList.SelectedItem.ToString().IndexOf(" ")));
                Users u = userManager.GetUserByID(filtered);
                userManager.UpdateUserRole(u);
                PopulateUserList();
            }
            else if (lbAdminList.SelectedIndex >= 0)
            {
                int filteredAdmin = Convert.ToInt32(lbAdminList.SelectedItem.ToString().Substring(0, lbAdminList.SelectedItem.ToString().IndexOf(" ")));
                Users u = userManager.GetUserByID(filteredAdmin);
                if (users.Id == filteredAdmin)
                {
                    MessageBox.Show("Current logged in user can not be self demoted!");
                }
                else
                {
                    userManager.UpdateUserRole(u);
                }
                PopulateUserList();
            }
            else
            {
                MessageBox.Show("Please select a user! ");
            }
        }
        private void btnViewUser_Click_1(object sender, EventArgs e)
        {
            if (lbUserList.SelectedIndex >= 0)
            {
                int filtered = Convert.ToInt32(lbUserList.SelectedItem.ToString().Substring(0, lbUserList.SelectedItem.ToString().IndexOf(" ")));
                Users u = userManager.GetUserByID(filtered);
                UserView uv = new UserView(users, filtered);
                uv.ShowDialog();
            }
            else if (lbAdminList.SelectedIndex >= 0)
            {
                int filtered = Convert.ToInt32(lbAdminList.SelectedItem.ToString().Substring(0, lbAdminList.SelectedItem.ToString().IndexOf(" ")));
                Users u = userManager.GetUserByID(filtered);
                UserView uv = new UserView(users, filtered);
                uv.ShowDialog();
            }
        }
    }
}
