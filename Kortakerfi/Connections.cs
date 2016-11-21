using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Kortakerfi
{
    class Connections
    {
        /*
         *  ---------------------------
         *  Connections to the database
         *  ---------------------------
         */

        private string server;
        private string database;
        private string userID;
        private string password;
        string connString = null;
        string command = null;

        MySqlConnection SQLconnection;
        MySqlCommand SQLcommand;
        MySqlDataReader SQLreader;

        public void ConnectionToDatabase()
        {
            server = "82.148.66.15";
            database = "2905962709_kortakerfi";
            userID = "2905962709";
            password = "teketill";

            connString = "server=" + server + ";userid=" + userID + ";password=" + password + ";database=" + database;
            SQLconnection = new MySqlConnection(connString);
        }

        public bool OpenConnection()
        {
            try
            {
                SQLconnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                SQLconnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Insert Member Punchcard
        public void InsertMemberPunchcard(string id, string name, string phone, string email, string membershipType, string passesRemaining)
        {
            if (OpenConnection())
            {
                command = "CALL InsertMember('" + id + "', '" + name + "', '" + phone + "', '" + email + "', '" + membershipType + "', NULL, " + passesRemaining + ");";
                SQLcommand = new MySqlCommand(command, SQLconnection);
                SQLcommand.ExecuteNonQuery();
                CloseConnection();
            }
        }

        // Insert Member Membership
        public void InsertMemberMembership(string id, string name, string phone, string email, string membershipType, string dueDate)
        {
            if (OpenConnection())
            {
                command = "CALL InsertMember('" + id + "', '" + name + "', '" + phone + "', '" + email + "', '" + membershipType + "', '" + dueDate + "', NULL);";
                SQLcommand = new MySqlCommand(command, SQLconnection);
                SQLcommand.ExecuteNonQuery();
                CloseConnection();
            }
        }

        // Update Member Punchcard
        public void UpdateMemberPunchcard(string id, string name, string phone, string email, string membershipType, string passesRemaining)
        {
            if (OpenConnection())
            {
                command = "CALL UpdateMember('" + id + "', '" + name + "', '" + phone + "', '" + email + "', '" + membershipType + "', NULL, " + passesRemaining + ");";
                SQLcommand = new MySqlCommand(command, SQLconnection);
                SQLcommand.ExecuteNonQuery();
                CloseConnection();
            }
        }

        // Update Member Membership
        public void UpdateMemberMembership(string id, string name, string phone, string email, string membershipType, string dueDate)
        {
            if (OpenConnection())
            {
                command = "CALL UpdateMember('" + id + "', '" + name + "', '" + phone + "', '" + email + "', '" + membershipType + "', '" + dueDate + "', NULL);";
                SQLcommand = new MySqlCommand(command, SQLconnection);
                SQLcommand.ExecuteNonQuery();
                CloseConnection();
            }
        }

        // Add Comment
        public void AddComment(string id, string comment)
        {
            if (OpenConnection())
            {
                command = "CALL AddComment('" + id + "', '" + comment + "');";
                SQLcommand = new MySqlCommand(command, SQLconnection);
                SQLcommand.ExecuteNonQuery();
                CloseConnection();
            }
        }

        // Record Visit
        public void RecordVisit(string id, int isPunchcard)
        {
            if (OpenConnection())
            {
                command = "CALL RecordVisit('" + id + "', " + isPunchcard + ");";
                SQLcommand = new MySqlCommand(command, SQLconnection);
                SQLcommand.ExecuteNonQuery();
                CloseConnection();
            }
        }

        // Member list for search from ID
        public List<string> MemberSearchListFromID(string id)
        {
            List<string> data = new List<string>();
            string line = null;

            if (OpenConnection())
            {
                command = "CALL MemberSearchListFromID('" + id + "')";
                SQLcommand = new MySqlCommand(command, SQLconnection);
                SQLreader = SQLcommand.ExecuteReader();

                while (SQLreader.Read())
                {
                    for (int i = 0; i < SQLreader.FieldCount; i++)
                    {
                        line += (SQLreader.GetValue(i).ToString()) + "*";
                    }
                    data.Add(line);
                    line = null;
                }
                CloseConnection();
                return data;
            }
            return data;
        }

        // Member list for search from Name
        public List<string> MemberSearchListFromName(string name)
        {
            List<string> data = new List<string>();
            string line = null;

            if (OpenConnection())
            {
                command = "CALL MemberSearchListFromName('" + name + "')";
                SQLcommand = new MySqlCommand(command, SQLconnection);
                SQLreader = SQLcommand.ExecuteReader();

                while (SQLreader.Read())
                {
                    for (int i = 0; i < SQLreader.FieldCount; i++)
                    {
                        line += (SQLreader.GetValue(i).ToString()) + "*";
                    }
                    data.Add(line);
                    line = null;
                }
                CloseConnection();
                return data;
            }
            return data;
        }

        // Get All Member Info (Returns: SocialSecurityID, Name, Phone, Email, Comment, MembershipType, PassesRemaining, DueDate, LastPaidDate, SignUpDate)
        public List<string> GetMemberInfo(string id)
        {
            List<string> data = new List<string>();
            string line = null;

            if (OpenConnection())
            {
                command = "CALL GetMemberInfo('" + id + "')";
                SQLcommand = new MySqlCommand(command, SQLconnection);
                SQLreader = SQLcommand.ExecuteReader();

                while (SQLreader.Read())
                {
                    for (int i = 0; i < SQLreader.FieldCount; i++)
                    {
                        line += (SQLreader.GetValue(i).ToString()) + "*";
                    }
                    data.Add(line);
                    line = null;
                }
                CloseConnection();
                return data;
            }
            return data;
        }

        // Get Visits
        public List<string> GetVisits(string id)
        {
            List<string> data = new List<string>();
            string line = null;

            if (OpenConnection())
            {
                command = "CALL GetVisits('" + id + "')";
                SQLcommand = new MySqlCommand(command, SQLconnection);
                SQLreader = SQLcommand.ExecuteReader();

                while (SQLreader.Read())
                {
                    for (int i = 0; i < SQLreader.FieldCount; i++)
                    {
                        line += (SQLreader.GetValue(i).ToString()) + "*";
                    }
                    data.Add(line);
                    line = null;
                }
                CloseConnection();
                return data;
            }
            return data;
        }

        // Get Number of Passengers on a Flight 
        public int NumberOfPassengers(string flightNumber, string flightDate)
        {
            int line = 0;

            if (OpenConnection())
            {
                command = "SELECT NumberOfPassengers('" + flightNumber + "', '" + flightDate + "')";
                SQLcommand = new MySqlCommand(command, SQLconnection);
                SQLreader = SQLcommand.ExecuteReader();

                while (SQLreader.Read())
                {
                    line = ((int)SQLreader.GetValue(0));
                }
                CloseConnection();
            }

            return line;
        }
    }
}
