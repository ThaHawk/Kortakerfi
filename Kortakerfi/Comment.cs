using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kortakerfi
{
    public partial class Comment : Form
    {
        Connections connection = new Connections();

        public string memberID;
        public string memberSSN;

        public Comment(string in_memberID)
        {
            InitializeComponent();

            memberID = in_memberID;

            try
            {
                connection.ConnectionToDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Form Load
        private void Comment_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>();

                list = connection.GetMemberInfo(memberID);

                foreach (string line in list)
                {
                    string[] results = line.Split('*');

                    txtbox_comment.Text = results[4];
                    memberSSN = results[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Confirm
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                string comment = txtbox_comment.Text;
                connection.AddComment(memberSSN, comment);

                MessageBox.Show("Comment Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Close();
        }
    }
}
