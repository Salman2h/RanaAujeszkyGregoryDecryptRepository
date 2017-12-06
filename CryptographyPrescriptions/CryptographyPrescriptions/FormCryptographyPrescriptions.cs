using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
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
              

                string ConnString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ..\\..\\..\\CryptographyPrescriptions.mdb";
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
            
        }


        private void LoadPrimitives(int primitiveId)
        {
            dataGridViewCreateHash.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewSoreHash.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewRetrieveHash.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            OleDbConnection connect = new OleDbConnection();
            string ConnString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ..\\..\\..\\CryptographyPrescriptions.mdb";
            connect.ConnectionString = ConnString;
            connect.Open();

            String query = "SELECT PrimitiveDetails FROM PrimitiveDetail WHERE PrimitiveId = " + primitiveId.ToString() + " ORDER BY PrimitiveDetailId";

            OleDbCommand CmdSql = new OleDbCommand(query, connect);

            DataTable master = new DataTable();
            
            // Fill Table 1 with Data

            OleDbDataAdapter da = new OleDbDataAdapter(CmdSql);

            da.Fill(master);

            connect.Close();

            if (textBoxParty1.Text.Trim().Length > 0 && textBoxParty2.Text.Trim().Length > 0)
            {
                foreach (DataRow row in master.Rows)
                {
                    if (textBoxParty1.Text.Trim().Length > 0)
                    {
                        row["PrimitiveDetails"] = row["PrimitiveDetails"].ToString().Replace("Alice", textBoxParty1.Text.Trim());
                    }

                    if (textBoxParty2.Text.Trim().Length > 0)
                    {
                        row["PrimitiveDetails"] = row["PrimitiveDetails"].ToString().Replace("Bob", textBoxParty2.Text.Trim());
                    }
                }
            }

            if (primitiveId == 1)
            {
                dataGridViewCreateHash.DataSource = master;
            }
            else if (primitiveId == 2)
            {
                dataGridViewSoreHash.DataSource = master;
            }
            else if (primitiveId == 3)
            {
                dataGridViewRetrieveHash.DataSource = master;
            }


        }

        private void formCryptographyPrescriptions_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cryptographyPrescriptionsDataSet.Primitive' table. You can move, or remove it, as needed.
            //this.primitiveTableAdapter.Fill(this.cryptographyPrescriptionsDataSet.Primitive);

        }

        private void tabMianOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPrimitives(1);
            LoadPrimitives(2);
            LoadPrimitives(3);

        }

    
        private void linkHash_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewCreateHash.Visible)
            {
                labelExpandHash.Text = "+";
            }
            else
            {
                labelExpandHash.Text = "-";
            }
            
            dataGridViewCreateHash.Visible = !dataGridViewCreateHash.Visible;
        }

        private void expandHash_Click(object sender, EventArgs e)
        {

            if (dataGridViewCreateHash.Visible)
            {
                labelExpandHash.Text = "+";
            }
            else
            {
                labelExpandHash.Text = "-";
            }       

            dataGridViewCreateHash.Visible = !dataGridViewCreateHash.Visible;
        }

        private void linkStoringHash_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewSoreHash.Visible)
            {
                labelStoringHash.Text = "+";
                
                labelStep2A.Visible = false;
                labelStep2B.Visible = false;
                labelStep2C.Visible = false;
                labelStep2D.Visible = false;
            }
            else
            {
                labelStoringHash.Text = "-";

                labelStep2A.Visible = true;
                labelStep2B.Visible = true;
                labelStep2C.Visible = true;
                labelStep2D.Visible = true;

            }

            dataGridViewSoreHash.Visible = !dataGridViewSoreHash.Visible;            
        }

        private void LoadGrid()
        {

            OleDbConnection connect = new OleDbConnection();
            string ConnString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ..\\..\\..\\CryptographyPrescriptions.mdb";
            connect.ConnectionString = ConnString;
            connect.Open();

            String query = "SELECT * FROM Primitive";

            OleDbCommand CmdSql = new OleDbCommand(query, connect);

            DataTable master = new DataTable();

            DataTable child = new DataTable();



            // Fill Table 1 with Data

            OleDbDataAdapter da = new OleDbDataAdapter(CmdSql);

            da.Fill(master);

            // Fill Table 1 with data
            query = "SELECT * FROM PrimitiveDetail";
            CmdSql = new OleDbCommand("select * from PrimitiveDetail", connect);

            da.Fill(child);

            connect.Close();

            DataSet ds = new DataSet();

            //Add two DataTables  in Dataset

            ds.Tables.Add(master);

            ds.Tables.Add(child);



            // Create a Relation in Memory

            DataRelation relation = new DataRelation("", ds.Tables[0].Columns[0], ds.Tables[1].Columns[0], true);

            ds.Relations.Add(relation);

            // Set DataSource
            // dataGrid1.DataSource = ds.Tables[0];
        }

        private void linkLabelRetrieveHash_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            if (dataGridViewRetrieveHash.Visible)
            {
                labelRerieveHash.Text = "+";
            }
            else
            {
                labelRerieveHash.Text = "-";
            }

            dataGridViewRetrieveHash.Visible = !dataGridViewRetrieveHash.Visible;
        }

        private void labelStoringHash_Click(object sender, EventArgs e)
        {            
            if (dataGridViewSoreHash.Visible)
            {               
                labelStep2A.Visible = false;
                labelStep2B.Visible = false;
                labelStep2C.Visible = false;
                labelStep2D.Visible = false;
            }
            else
            {
                labelStoringHash.Text = "-";
                labelStoringHash.Text = "+";
                labelStep2A.Visible = true;
                labelStep2B.Visible = true;
                labelStep2C.Visible = true;
                labelStep2D.Visible = true;

            }

            dataGridViewSoreHash.Visible = !dataGridViewSoreHash.Visible;
        }

        private void labelRerieveHash_Click(object sender, EventArgs e)
        {
            if (dataGridViewRetrieveHash.Visible)
            {
                labelRerieveHash.Text = "+";
            }
            else
            {
                labelRerieveHash.Text = "-";
            }

            dataGridViewRetrieveHash.Visible = !dataGridViewRetrieveHash.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabMainOptions.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabMainOptions.SelectedIndex = 2;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            tabMainOptions.SelectedIndex = 0;
        }

        private void buttonBack4_Click(object sender, EventArgs e)
        {
            tabMainOptions.SelectedIndex = 2;
        }

        private void buttonNextTab3_Click(object sender, EventArgs e)
        {
            tabMainOptions.SelectedIndex = 3;
        }

        private void buttonBack3_Click(object sender, EventArgs e)
        {
            tabMainOptions.SelectedIndex = 1;
        }

        private void linkLabelWebServiceUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(textBoxWebServiceURL.Text);
            Process.Start(sInfo);
        }

        private void linkLabelSha512_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(textBoxWebServiceURL.Text + "?op=SHA512HashPassword");
            Process.Start(sInfo);
        }

        private void AESEncrypt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(textBoxWebServiceURL.Text + "?op=AESEncrypt");
            Process.Start(sInfo);
        }

        private void linkLabelAESDec_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(textBoxWebServiceURL.Text + "?op=AESDecrypt");
            Process.Start(sInfo);            
        }

        private void linkLabelRSAEnc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(textBoxWebServiceURL.Text + "?op=RSAEncrypt");
            Process.Start(sInfo);
            
        }

        private void linkLabelRSADec_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(textBoxWebServiceURL.Text + "?op=RSADecrypt");
            Process.Start(sInfo);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://blogs.msdn.microsoft.com/wsdevsol/2012/12/21/help-me-how-do-i-connect-to-an-asmx-web-service");
            Process.Start(sInfo);            
        }

        private void linkLabelRSAPublic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(textBoxWebServiceURL.Text + "?op=RSAPublicParameters");
            Process.Start(sInfo);
        }
    }


}
