using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CryptographyPrescriptions
{
    public partial class formCryptographyPrescriptions : System.Windows.Forms.Form
    {
        public formCryptographyPrescriptions()
        {
            InitializeComponent();
        }

        private void buttonSaveParty_Click(object sender, EventArgs e)
        {
            try //code regarding the database connection
            {
                OleDbConnection connect = new OleDbConnection();
              

                string ConnString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\MS Cyber Security\\Modern Cryptography\\Project 2\\CryptographyPrescriptions.mdb";
                connect.ConnectionString = ConnString;
                connect.Open();
                String query = "Insert into Party(Party1, Party2,CreatedBy,CreatedDate) values('" + textBoxParty1.Text + "','" + textBoxParty2.Text + "','RRashid', '" + DateTime.Now +"' ) ";

                OleDbCommand CmdSql = new OleDbCommand(query, connect);
                CmdSql.CommandType = CommandType.Text;
                               
                
                CmdSql.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A problem occured while trying to establish a stable connection to the database:  " + ex.Message, "A wild error has appeared");
            } // end of that code
          
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            DataGridViewCellContextMenuStripNeededEventHandler.
        }
    }    
}
