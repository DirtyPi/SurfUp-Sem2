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
    
    public partial class Form1 : Form
    {
        private UserManager userManager;
        private UserMediator userMediator = new UserMediator();
        public Form1()
        {
            InitializeComponent();
            userManager = new UserManager(userMediator);
        }
       private Users getUser()
        {
            Users u = userManager.GetUser(tbEmail.Text);
            return u;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if(tbEmail.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Please enter the credentials!");
            }
            else
            {
                //Users user = userManager.GetUserByLogIn(tbEmail.Text, tbPassword.Text);
                if (userManager.CheckIfUserIsReal(tbEmail.Text, tbPassword.Text))
                {
                    Users u = userManager.GetUser(tbEmail.Text);
                    if (u.Role == UserRoleEnum.AdminUser)
                    {
                        MainForm mF = new MainForm(u);
                        mF.ShowDialog();
                    }
                    else
                    {
                        
                        MessageBox.Show("Access denied!");
                       
                    }
                   
                }
                else
                {
                    MessageBox.Show("Not found!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbEmail.Text = "TestUser2@abv.bg";
            tbPassword.Text = "TestUser";
        }
    }
}
