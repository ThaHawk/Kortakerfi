using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kortakerfi
{
    public partial class EditInfo : Form
    {
        Connections connection = new Connections();

        public string memberID;

        public EditInfo(string in_memberID)
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
        private void EditInfo_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>();

                list = connection.GetMemberInfo(memberID);

                foreach (string line in list)
                {
                    string[] results = line.Split('*');

                    txtbox_id.Text = results[0];
                    txtbox_name.Text = results[1];
                    txtbox_phone.Text = results[2];
                    txtbox_email.Text = results[3];
                    cb_membershipType.SelectedItem = results[5];
                    txtbox_passesRemaining.Text = results[6];

                    if (results[5] != "10 Time Card")
                    {
                        dateTimePicker.Value = Convert.ToDateTime(results[7]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Membership Type Value Changed
        private void cb_membershipType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_membershipType.SelectedItem.ToString() == "10 Time Card")
            {
                txtbox_passesRemaining.Enabled = true;
                txtbox_passesRemaining.Text = "10";
                dateTimePicker.Enabled = false;
            }
            else if (cb_membershipType.SelectedItem.ToString() == "1 Month")
            {
                txtbox_passesRemaining.Enabled = false;
                txtbox_passesRemaining.Text = null;
                dateTimePicker.Enabled = true;
                dateTimePicker.Value = DateTime.Now;
                dateTimePicker.Value = dateTimePicker.Value.AddMonths(1);
            }
            else if (cb_membershipType.SelectedItem.ToString() == "3 Months")
            {
                txtbox_passesRemaining.Enabled = false;
                txtbox_passesRemaining.Text = null;
                dateTimePicker.Enabled = true;
                dateTimePicker.Value = DateTime.Now;
                dateTimePicker.Value = dateTimePicker.Value.AddMonths(3);
            }
            else if (cb_membershipType.SelectedItem.ToString() == "6 Months")
            {
                txtbox_passesRemaining.Enabled = false;
                txtbox_passesRemaining.Text = null;
                dateTimePicker.Enabled = true;
                dateTimePicker.Value = DateTime.Now;
                dateTimePicker.Value = dateTimePicker.Value.AddMonths(6);
            }
            else if (cb_membershipType.SelectedItem.ToString() == "1 Year")
            {
                txtbox_passesRemaining.Enabled = false;
                txtbox_passesRemaining.Text = null;
                dateTimePicker.Enabled = true;
                dateTimePicker.Value = DateTime.Now;
                dateTimePicker.Value = dateTimePicker.Value.AddYears(1);
            }
        }

        // Edit Info
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbox_id.Text) || string.IsNullOrEmpty(txtbox_name.Text) || cb_membershipType.SelectedIndex == -1)
            {
                MessageBox.Show("Some Information Is Missing.");
            }
            else
            {
                string id = txtbox_id.Text;
                string name = txtbox_name.Text;
                string phone = txtbox_phone.Text;
                string email = txtbox_email.Text;
                string membershipType = cb_membershipType.SelectedItem.ToString();
                string dueDate = null;
                string passesRemaining = null;

                if (membershipType == "10 Time Card")
                {
                    passesRemaining = txtbox_passesRemaining.Text;
                    dueDate = null;
                }
                else
                {
                    passesRemaining = null;
                    dueDate = dateTimePicker.Value.ToString("yyyy-MM-dd");
                }

                try
                {
                    if (membershipType == "10 Time Card")
                    {
                        connection.UpdateMemberPunchcard(id, name, phone, email, membershipType, passesRemaining);
                    }
                    else
                    {
                        connection.UpdateMemberMembership(id, name, phone, email, membershipType, dueDate);
                    }

                    MessageBox.Show("Member Updated.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                Close();
            }
        }
    }
}
