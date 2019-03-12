using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RoboticParkingSystem
{
    public partial class Form7 : Form
    {
        Color svijetloZelena = Color.FromArgb(16, 172, 132);
        //this.unos.Visible=false;
        Color tamnoZelena = Color.FromArgb(11, 111, 86);
        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
        public Form7()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database2DataSet2.Klijenti' table. You can move, or remove it, as needed.
            //this.klijentiTableAdapter.Fill(this.database2DataSet2.Klijenti);
            DataTable dt = new DataTable("Klijenti");
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RoboticParkingSystem.Properties.Settings.Database2ConnectionString"].ConnectionString))
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                //nesto ne valja sa ovom naredbom
                string sqlNaredba = "select Klijenti.Ime,Klijenti.Prezime,Klijenti.Adresa,Klijenti.Registracija,Klijenti.Vozacka,datefromparts(year(Uplate.DatumUplate),month(Uplate.DatumUplate)+Uplate.BrojMjeseci,day(Uplate.DatumUplate)) as 'Uplata vazi do' from Klijenti inner join Uplate on Uplate.ClientID = Klijenti.ClientID ";
                string sqlNaredba2 = "where datefromparts(year(Uplate.DatumUplate),month(Uplate.DatumUplate)+Uplate.BrojMjeseci,day(Uplate.DatumUplate)) >= GETDATE();";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlNaredba + sqlNaredba2, cn))
                {

                    da.Fill(dt);
                    //dataGridView1.DataSource = dt;

                }
            }
            //this.button2.BackColor = SystemColors.Control;
            //this.button2.ForeColor = SystemColors.ControlText;
            //this.button2.Font = new Font("MS Sans Serif", 13);
            //DataGridViewRow row1 = dataGridView1.Rows[0];
            //DataGridViewRow row2 = dataGridView1.Rows[1];
            //row1.DefaultCellStyle.BackColor = Color.FromArgb(198, 216, 232);
            //row2.DefaultCellStyle.BackColor = Color.FromArgb(198, 216, 232);
        }

            private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = SystemColors.Control;
            button2.ForeColor = SystemColors.ControlText;

            button3.BackColor = Color.FromArgb(72, 126, 176);
            button3.ForeColor = SystemColors.ControlLightLight;

            button2.Font = new Font("MS Sans Serif", 13);
            button3.Font = new Font("MS Sans Serif", 12);
            panel1.BackColor= Color.FromArgb(72, 126, 176);
            button1.BackColor = Color.FromArgb(72, 126, 176);
            unos.Visible = true;
            label1.Visible = true;
            //Form5.DefaultBackColor.= Color.FromArgb(72, 126, 176);
            unos.Controls.Clear();
            Form5 novaforma = new Form5();
            novaforma.TopLevel = false;
            unos.Controls.Add(novaforma);
            novaforma.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = SystemColors.Control;
            button3.ForeColor = SystemColors.ControlText;

            button2.BackColor = Color.FromArgb(255, 159, 67);
            button2.ForeColor = SystemColors.ControlLightLight;

            button3.Font = new Font("MS Sans Serif", 13);
            button2.Font = new Font("MS Sans Serif", 12);
            panel1.BackColor = Color.FromArgb(255, 159, 67);
            button1.BackColor = Color.FromArgb(255, 159, 67);
            uplata.Visible = true;
            unos.Visible = false;
            label1.Visible = false;
            //Form5.DefaultBackColor.= Color.FromArgb(72, 126, 176);
            uplata.Controls.Clear();
            FormDodajUplatu novaforma1 = new FormDodajUplatu();
            novaforma1.TopLevel = false;
            uplata.Controls.Add(novaforma1);
            novaforma1.Show();
        }
    }
}
