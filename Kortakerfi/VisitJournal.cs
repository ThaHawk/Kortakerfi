using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kortakerfi
{
    public partial class VisitJournal : Form
    {
        Connections connection = new Connections();

        private string memberID;

        public VisitJournal(string in_memberID)
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
        private void VisitJournal_Load(object sender, EventArgs e)
        {
            try
            {
                ColumnHeader header1 = new ColumnHeader();
                ColumnHeader header2 = new ColumnHeader();

                // Set the text, alignment and width for each column header.
                header1.Text = "ID";
                header1.TextAlign = HorizontalAlignment.Center;
                header1.Width = 50;
                listView.Columns.Add(header1);

                header2.Text = "Check-In Time";
                header2.TextAlign = HorizontalAlignment.Center;
                header2.Width = 250;
                listView.Columns.Add(header2);

                List<string> list = new List<string>();
                ListViewItem itm;

                list = connection.GetVisits(memberID);

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
    }
}
