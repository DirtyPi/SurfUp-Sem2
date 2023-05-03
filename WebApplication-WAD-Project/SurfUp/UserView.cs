using System;
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
    public partial class UserView : Form
    {
        private Users users;
        private UserManager userManager;//= new UserManager();
        private UserMediator userMediator = new UserMediator();
        private int selectedId;
        public UserView(Users u,int id)
        {
            InitializeComponent();
            userManager = new UserManager(userMediator);
            this.users = u;
            this.selectedId = id;
            CheckUser(u, id);
            PopulateData(id);
            //MessageBox.Show($"{id}");

        }
       
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) //Update button
        {
            //int id = Convert.ToInt32(this.tbId.Text);
            //Users u = userManager.GetUserByID(id);
            if(tbUsername.Text == "" || tbFirstName.Text == "" || tbLastName.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Please feill all data!");
            }
            else
            {

                
                Users u = userManager.GetUserByID(selectedId);
                u.Username = tbUsername.Text;
                u.FirstName = tbFirstName.Text;
                u.LastName = tbLastName.Text;
                u.Password = tbPassword.Text;
                userManager.UpdateUser(u);
                MessageBox.Show("Update successful!");
                this.Close();
            }
         

        }
        private void CheckUser(Users u, int id)
        {
            //if the logged in user is viewing his own data he can edit it
            if (u.Id == id)
            {
                button1.Visible = true;
                tbUsername.Enabled = true;
                tbFirstName.Enabled = true;
                tbLastName.Enabled = true;
                tbPassword.Enabled = true;
               //the '\0' is for turning the passwordchart off
                tbPassword.PasswordChar = '\0';

            }
        }
        private void PopulateData(int id)
        {
            Users u = userManager.GetUserByID(id);
            tbId.Text = u.Id.ToString();
            tbUsername.Text = u.Username.ToString();
            tbEmail.Text = u.Email.ToString();
            tbFirstName.Text = u.FirstName.ToString();
            tbLastName.Text = u.LastName.ToString();
            tbRole.Text = u.Role.ToString();
            tbStatus.Text = u.Status.ToString();
            tbPassword.Text = u.Password.ToString();


        }
    }
}
