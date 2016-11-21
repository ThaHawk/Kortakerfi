using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kortakerfi
{
    public partial class MainForm : Form
    {
        Connections connection = new Connections();

        public string currentMemberID;

        public MainForm()
        {
            InitializeComponent();

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
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDefault();
        }

        // Add Member
        private void btn_addMember_Click(object sender, EventArgs e)
        {
            AddMember am = new AddMember();
            am.Show();
        }

        // Visit Journal
        private void btn_journal_Click(object sender, EventArgs e)
        {
            VisitJournal vj = new VisitJournal(currentMemberID);
            vj.Show();
        }

        // Record Payment
        private void btn_recordPayment_Click(object sender, EventArgs e)
        {
            RecordPayment rp = new RecordPayment();
            rp.Show();
        }

        // Comment
        private void btn_comment_Click(object sender, EventArgs e)
        {
            Comment c = new Comment(currentMemberID);
            c.ShowDialog();

            LoadMember(currentMemberID);
        }

        // Edit Member Info
        private void btn_editMemberInfo_Click(object sender, EventArgs e)
        {
            EditInfo ei = new EditInfo(currentMemberID);
            ei.ShowDialog();

            LoadMember(currentMemberID);
        }

        // Record Visit
        private void btn_recordVisit_Click(object sender, EventArgs e)
        {
            try
            {
                string cardType = null;
                string passesRemaining = null;
                string dueDate = null;

                List<string> list = new List<string>();

                list = connection.GetMemberInfo(currentMemberID);

                foreach (string line in list)
                {
                    string[] results = line.Split('*');

                    cardType = results[5];
                    passesRemaining = results[6];
                    dueDate = results[7];
                }

                if (isActive(cardType, passesRemaining, dueDate))
                {
                    if (cardType == "10 Time Card")
                    {
                        connection.RecordVisit(currentMemberID, 1);
                    }
                    else
                    {
                        connection.RecordVisit(currentMemberID, 0);
                    }
                }
                else
                {
                    MessageBox.Show("Membership Expired.");
                }
                
                LoadMember(currentMemberID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Clear
        private void btn_clear_Click(object sender, EventArgs e)
        {
            LoadDefault();
        }

        // Search Button
        private void btn_search_Click(object sender, EventArgs e)
        {
            SearchMember();
        }

        // Search Enter
        private void txtbox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SearchMember();
            }
        }

        // ================== METHODS ==================

        private void SearchMember()
        {
            string searchString = txtbox_search.Text;

            if (string.IsNullOrEmpty(searchString))
            {
                MessageBox.Show("Missing Search String.");
            }
            else
            {
                Search s = new Search(searchString);
                s.ShowDialog();

                currentMemberID = s.MembershipID;

                s.Close();

                LoadMember(currentMemberID);
            }
        }

        // Default Values For Main Form
        private void LoadDefault()
        {
            txtbox_number.Text = "#";
            txtbox_name.Text = "Enter Member Name or #";
            txtbox_active.Text = "";
            txtbox_active.BackColor = Color.Red;
            txtbox_comment.Text = "";
            lbl_cardType.Text = "-";
            lbl_dueDateOrPasses.Text = "--/--/--";
            lbl_lastVisit.Text = "--/--/-- 00:00:00";
            lbl_totalVisits.Text = "-";
            lbl_signUp.Text = "--/--/--";
            lbl_lastPaid.Text = "--/--/--";
            lbl_id.Text = "-";
            lbl_phone.Text = "-";
            lbl_email.Text = "-";

            btn_recordVisit.Enabled = false;
            btn_editMemberInfo.Enabled = false;
            btn_comment.Enabled = false;
            btn_recordPayment.Enabled = false;
            btn_visitJournal.Enabled = false;
        }

        private void LoadMember(string memberID)
        {
            List<string> list = new List<string>();

            try
            {
                list = connection.GetMemberInfo(memberID);

                foreach (string line in list)
                {
                    string[] results = line.Split('*');

                    // Load Member Info
                    txtbox_number.Text = "#" + memberID;
                    txtbox_name.Text = results[1];
                    lbl_id.Text = results[0];
                    lbl_phone.Text = results[2];
                    lbl_email.Text = results[3];
                    txtbox_comment.Text = results[4];
                    lbl_cardType.Text = results[5];

                    // Change Date Format
                    DateTime date2 = Convert.ToDateTime(results[8]);
                    results[8] = date2.ToShortDateString();
                    DateTime date3 = Convert.ToDateTime(results[9]);
                    results[9] = date3.ToShortDateString();

                    lbl_lastPaid.Text = results[8];
                    lbl_signUp.Text = results[9];

                    // Check if membership is active
                    if (isActive(results[5], results[6], results[7]))
                    {
                        if (results[5] == "10 Time Card")
                        {
                            lbl_dueOrPasses.Text = "Passes Remaining";
                            lbl_dueDateOrPasses.Text = results[6];

                            txtbox_active.Text = "Active";
                            txtbox_active.BackColor = Color.LimeGreen;
                        }
                        else
                        {
                            lbl_dueOrPasses.Text = "Due Date";
                            DateTime date1 = Convert.ToDateTime(results[7]);
                            results[7] = date1.ToShortDateString();
                            lbl_dueDateOrPasses.Text = results[7];

                            txtbox_active.Text = "Active";
                            txtbox_active.BackColor = Color.LimeGreen;
                        }
                    }
                    else
                    {
                        if (results[5] == "10 Time Card")
                        {
                            lbl_dueOrPasses.Text = "Passes Remaining";
                            lbl_dueDateOrPasses.Text = results[6];

                            txtbox_active.Text = "Expired";
                            txtbox_active.BackColor = Color.Red;
                        }
                        else
                        {
                            lbl_dueOrPasses.Text = "Due Date";
                            DateTime date = Convert.ToDateTime(results[7]);
                            results[7] = date.ToShortDateString();
                            lbl_dueDateOrPasses.Text = results[7];

                            txtbox_active.Text = "Expired";
                            txtbox_active.BackColor = Color.Red;
                        }
                    }

                    btn_recordVisit.Enabled = true;
                    btn_editMemberInfo.Enabled = true;
                    btn_comment.Enabled = true;
                    btn_recordPayment.Enabled = true;
                    btn_visitJournal.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Check if membership is active
        private bool isActive(string cardType, string passesRemaining, string dueDate)
        {
            if (cardType == "10 Time Card")
            {
                if (Convert.ToInt32(passesRemaining) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                DateTime today = DateTime.Now;
                DateTime dtDueDate = Convert.ToDateTime(dueDate);

                TimeSpan difference = dtDueDate - today;

                if (difference.TotalDays > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
