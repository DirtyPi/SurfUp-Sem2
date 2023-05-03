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
    public partial class CreateAnnoucement : Form
    {
        private Users users;
        private PostMediator postMediator = new PostMediator();
        private PostManager pm;//= new PostManager();
        
        public CreateAnnoucement(Users user)
        {
            InitializeComponent();
            pm = new PostManager(postMediator);
            this.users = user;
            tbDescription.MaxLength = 400;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            labelCounter.Text = tbDescription.Text.Length.ToString();
            if(tbDescription.Text.Length ==  400)
            {
                MessageBox.Show("You've reached the max charecter on this annoucement!");
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            //int posteBy = users.Id;
            string postedOn = DateTime.Now.ToString("g");
            var posttype = TypeOfPostEnum.Annoucements;
            
            if(tbTitle.Text == "" && tbDescription.Text == "")
            {
                MessageBox.Show("Please fill the data");

            }
            else
            {
                Annoucement annoucement = new Annoucement(tbDescription.Text, tbTitle.Text, postedOn, users, (ClassLibrary.TypeOfPostEnum)posttype);
                pm.Add(annoucement);
                MessageBox.Show("Success");
                this.Close();
            }
        }
    }
}
