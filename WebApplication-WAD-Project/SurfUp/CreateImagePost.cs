using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClassLibrary;
using ClassLibraryService;

namespace SurfUp
{
    public partial class CreateImagePost : Form
    {
        private Users users;
        private PostMediator postMediator = new PostMediator();
        private PostManager pm;//= new PostManager();
        private string name = (Guid.NewGuid().ToString().Replace("-", string.Empty));
        public CreateImagePost(Users u)
        {
            InitializeComponent();
            this.users = u;
            pm = new PostManager(postMediator);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            this.name = Guid.NewGuid().ToString().Replace("-", string.Empty);


            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbFilePath.Text = dialog.FileName.ToString();
                tbFileName.Text = Path.GetFileName(dialog.FileName);
                string path = Path.Combine(@"C:\HRISTO TANCHEV\Fontaka\Sem2 T3\OOD_WAD\project-hristo-wad\WebApplication-WAD-Project\WebApplication-WAD-Project\wwwroot\images\");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var fileName = System.IO.Path.GetFileName(dialog.FileName);
                path = path + this.name;
                File.Copy(dialog.FileName, path);
                File.Move(path, Path.ChangeExtension(path, ".jpg"));

            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string postedOn = DateTime.Now.ToString("g");
           //int posteBy = users.Id;
            var posttype = TypeOfPostEnum.ImagePosts;

            if (tbFilePath.Text == "" && tbTitle.Text == "")
            {
                MessageBox.Show("Please fill the data");
            }
            else
            {

                ImagePost imagePost = new ImagePost(this.name, tbTitle.Text, postedOn, users, (ClassLibrary.TypeOfPostEnum)posttype);
                pm.Add(imagePost);
                MessageBox.Show("Success!");
                this.Close();

            }
        }
    }
}
