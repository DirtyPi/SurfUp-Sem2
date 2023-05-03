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

namespace SurfUp
{
    public partial class TypeOfPost : Form
    {
        private Users users;
        public TypeOfPost(Users user)
        {
            InitializeComponent();
            this.users = user;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (rbAnnoucement.Checked)
            {
                CreateAnnoucement ca = new CreateAnnoucement(users);
                ca.ShowDialog();
                this.Close();
            }
            else if (rbMedia.Checked)
            {
                CreateMediaPost cm = new CreateMediaPost(users);
                cm.ShowDialog();
                this.Close();
            }
            else if (rbImage.Checked)
            {
                CreateImagePost ci = new CreateImagePost(users);
                ci.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Pease select a type of post you want to create");
            }
        }
    }
}
