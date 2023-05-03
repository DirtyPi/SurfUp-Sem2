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
using System.IO;

namespace SurfUp
{
    public partial class CreateMediaPost : Form
    {
        private Users users;
        private PostMediator postMediator = new PostMediator(); 
        private PostManager pm;
        private string name = (Guid.NewGuid().ToString().Replace("-", string.Empty));
        public CreateMediaPost(Users user)
        {
            this.users = user;
            //postMediator = new PostMediator();
           pm = new PostManager(postMediator);
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            this.name = Guid.NewGuid().ToString().Replace("-", string.Empty);
        

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Video files (*.mp4)|*.mp4|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbFilePath.Text = dialog.FileName.ToString();
                    tbFileName.Text = Path.GetFileName(dialog.FileName);
                string path = Path.Combine(@"C:\HRISTO TANCHEV\Fontaka\Sem2 T3\OOD_WAD\project-hristo-wad\WebApplication-WAD-Project\WebApplication-WAD-Project\wwwroot\Vid\");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileName = System.IO.Path.GetFileName(dialog.FileName);
                    path = path + this.name;
                    File.Copy(dialog.FileName, path);
                    File.Move(path, Path.ChangeExtension(path, ".mp4"));

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string postedOn = DateTime.Now.ToString("g");
           // int posteBy = users.Id;
            var posttype = TypeOfPostEnum.MediaPosts;
            if (tbFilePath.Text == "" && tbTitle.Text == "")
            {
                MessageBox.Show("Please fill the data");
            }
            else
            {
                
                MediaPost mediaPost = new MediaPost(this.name, tbTitle.Text, postedOn, users, (ClassLibrary.TypeOfPostEnum)posttype);
                pm.Add(mediaPost);
                MessageBox.Show("Success!");
                this.Close();

            }
        }
    }
}
