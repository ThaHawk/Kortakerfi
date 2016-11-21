using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kortakerfi
{
    public partial class Search : Form
    {
        Connections connection = new Connections();

        public string MembershipID { get { return _membershipID; } set { _membershipID = value; } }
        private string _membershipID;

        private string searchString;

        public Search(string in_searchString)
        {
            InitializeComponent();

            searchString = in_searchString;

            try
            {
                connection.ConnectionToDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Load List of Members
        private void Search_Load(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(searchString, out n);

            try
            {
                listView.Columns.Add("#", 70);
                listView.Columns.Add("Name", 269);

                List<string> list = new List<string>();
                ListViewItem itm;

                if (isNumeric)
                {
                    list = connection.MemberSearchListFromID(searchString);
                }
                else
                {
                    list = connection.MemberSearchListFromName(searchString);
                }

                foreach (string line in list)
                {
                    string[] results = line.Split('*');

                    itm = new ListViewItem(results);
                    listView.Items.Add(itm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // List Double Click
        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedIndices.Count <= 0)
            {
                return;
            }
            int SelectedIndex = listView.SelectedIndices[0];

            if (SelectedIndex >= 0)
            {
                MainForm mf = new MainForm();

                MembershipID = listView.SelectedItems[0].SubItems[0].Text;
            }

            Hide();
        }
    }
}
