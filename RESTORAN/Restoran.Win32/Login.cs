using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Diagnostics.Eventing.Reader;

namespace Restoran.Win32
{
    public partial class Login : Form
    {
        SqlConnection conn;
        SqlDataReader rdr;
        SqlCommand cmd;

        public Login()
        {
            InitializeComponent();
        }

        private void btnGirisLogin_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtLoginKA.Text;
            string sifre = txtLoginSifre.Text;

            conn = new SqlConnection("Data Source=ONUR\\SQLEXPRESS;Initial Catalog=dbRestoran;Integrated Security=True");
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            if (cmbxLoginGirisYontem.Text == "Yönetici")
            {
                cmd.CommandText = "select * from tbYonetici where adminNo='" + txtLoginKA.Text + "' and sifre='" + txtLoginSifre.Text + "'";
            }
            else if (cmbxLoginGirisYontem.Text == "Garson")
            {
                cmd.CommandText = "select * from tbGarson where garsonNo='" + txtLoginKA.Text + "' and sifre='" + txtLoginSifre.Text + "'";
            }
            
            rdr = cmd.ExecuteReader();

            if (rdr.Read()) 
            {
                MessageBox.Show("Giriş başarılı.");
                Restoran restoran = new Restoran(kullaniciAdi);
                restoran.Show();
                this.Hide();
            }
            else
            {
                lblStatusLogin.Text = "Hatalı kullanıcı adı veya şifre.";
            }
            conn.Close();
        }
    }
}
