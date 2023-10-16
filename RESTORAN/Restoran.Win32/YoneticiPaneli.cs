using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran.Win32
{
    public partial class YoneticiPaneli : Form
    {

        public YoneticiPaneli()
        {
            InitializeComponent();
            btnTamamIslem.Enabled = false;
        }
        dbRestoranEntities re = new dbRestoranEntities();
        private void chcEklePer_CheckedChanged(object sender, EventArgs e)
        {
            if (chcEklePer.Checked == true)
            {
                chcSilPer.Enabled = false;
                chcGuncellePer.Enabled = false;
                txtIDpersonel.ReadOnly = true;
                txtIDpersonel.Text = "ID otomatik eklenecektir.";
            }
            else
            {
                chcSilPer.Enabled = true;
                chcGuncellePer.Enabled = true;
                txtIDpersonel.ReadOnly = false;
                txtIDpersonel.Clear();
            }
        }

        private void chcSilPer_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSilPer.Checked == true)
            {
                chcEklePer.Enabled = false;
                chcGuncellePer.Enabled = false;
                txtIDpersonel.ReadOnly = true;
                txtPersonelAdiSoyadiPer.ReadOnly = true;
                txtPersonelTcKimlikNoPer.ReadOnly = true;
                txtPersonelGsmNoPer.ReadOnly = true;
                txtIseGirisTarihiPer.ReadOnly = true;
                txtIstenCikisTarihiPer.ReadOnly = true;
            }
            else
            {
                chcEklePer.Enabled = true;
                chcGuncellePer.Enabled = true;
                txtIDpersonel.ReadOnly = false;
                txtPersonelAdiSoyadiPer.ReadOnly = false;
                txtPersonelTcKimlikNoPer.ReadOnly = false;
                txtPersonelGsmNoPer.ReadOnly = false;
                txtIseGirisTarihiPer.ReadOnly = false;
                txtIstenCikisTarihiPer.ReadOnly = false;
            }
        }

        private void chcGuncellePer_CheckedChanged(object sender, EventArgs e)
        {
            if (chcGuncellePer.Checked == true)
            {
                chcEklePer.Enabled = false;
                chcSilPer.Enabled = false;

                txtIDpersonel.ReadOnly = true;
                txtIDpersonel.Text = "ID güncellenemez.";
            }
            else
            {
                chcEklePer.Enabled = true;
                chcSilPer.Enabled = true;

                txtIDpersonel.ReadOnly = false;
                txtIDpersonel.Clear();
            }
        }

        private void chcEkleFiyat_CheckedChanged(object sender, EventArgs e)
        {
            if (chcEkleFiyat.Checked == true)
            {
                chcSilFiyatlar.Enabled = false;
                chcGuncelleFiyat.Enabled = false;

                txtIDfiyat.ReadOnly = true;
                txtIDfiyat.Text = "ID otomatik eklenecektir.";
            }
            else
            {
                chcSilFiyatlar.Enabled = true;
                chcGuncelleFiyat.Enabled = true;

                txtIDfiyat.ReadOnly = false;
                txtIDfiyat.Clear() ;
            }
        }

        private void chcSilFiyatlar_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSilFiyatlar.Checked == true)
            {
                chcEkleFiyat.Enabled = false;
                chcGuncelleFiyat.Enabled = false;

                txtIDfiyat.ReadOnly = true;
                txtUrunAdiFiyat.ReadOnly = true;
                txtAlisFiyatiFiyat.ReadOnly = true;
                txtSatisFiyatiFiyat.ReadOnly = true;
            }
            else
            {
                chcEkleFiyat.Enabled = true;
                chcGuncelleFiyat.Enabled = true;

                txtIDfiyat.ReadOnly = false;
                txtUrunAdiFiyat.ReadOnly = false;
                txtAlisFiyatiFiyat.ReadOnly = false;
                txtSatisFiyatiFiyat.ReadOnly = false;
            }
        }

        private void chcGuncelleFiyat_CheckedChanged(object sender, EventArgs e)
        {
            if (chcGuncelleFiyat.Checked == true)
            {
                chcEkleFiyat.Enabled = false;
                chcSilFiyatlar.Enabled = false;

                txtIDfiyat.ReadOnly = true;
                txtIDfiyat.Text = "ID güncellenemez.";
            }
            else
            {
                chcEkleFiyat.Enabled = true;
                chcSilFiyatlar.Enabled = true;

                txtIDfiyat.ReadOnly = false;
                txtIDfiyat.Clear();
            }
        }

        private void chcEkleMus_CheckedChanged(object sender, EventArgs e)
        {
            if (chcEkleMus.Checked == true)
            {
                chcSilMus.Enabled = false;
                chcGuncelleMus.Enabled = false;
                txtMusteriIDMus.ReadOnly = true;
                txtMusteriIDMus.Text = "ID otomatik eklenecektir.";
            }
            else
            {
                chcSilMus.Enabled = true;
                chcGuncelleMus.Enabled = true;
                txtMusteriIDMus.ReadOnly = false;
                txtMusteriIDMus.Clear();
            }
        }

        private void chcSilMus_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSilMus.Checked == true)
            {
                chcEkleMus.Enabled = false;
                chcGuncelleMus.Enabled = false;
                txtMusteriIDMus.ReadOnly = true;
                txtMusteriAdiSoyadiMus.ReadOnly = true;
                txtrezervasyonTarihiMus.ReadOnly = true;
                txtMusteriGsmMus.ReadOnly = true;
            }
            else
            {
                chcEkleMus.Enabled = true;
                chcGuncelleMus.Enabled = true;
                txtMusteriIDMus.ReadOnly = false;
                txtMusteriAdiSoyadiMus.ReadOnly = false;
                txtrezervasyonTarihiMus.ReadOnly = false;
                txtMusteriGsmMus.ReadOnly = false;
            }
        }

        private void chcGuncelleMus_CheckedChanged(object sender, EventArgs e)
        {
            if (chcGuncelleMus.Checked == true)
            {
                chcEkleMus.Enabled = false;
                chcSilMus.Enabled = false;
                txtMusteriIDMus.ReadOnly = true;
                txtMusteriIDMus.Text = "ID güncellenemez.";
            }
            else
            {
                chcEkleMus.Enabled = true;
                chcSilMus.Enabled = true;
                txtMusteriIDMus.ReadOnly = false;
                txtMusteriIDMus.Clear();
            }
        }

        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {
            var hasilat = re.tbHasilat.ToList();
       
            dataRapor.DataSource = hasilat;
        }

        private void chcEkleIslem_CheckedChanged(object sender, EventArgs e)
        {
            if (chcEkleIslem.Checked == true)
            {
                chcSilIslem.Enabled = false;
                chcGuncelleIslem.Enabled =false;
                txtIDislem.ReadOnly = true;
                txtIDislem.Text = "ID otomatik eklencektir.";
                btnTamamIslem.Enabled = true;
            }
            else
            {
                chcSilIslem.Enabled = true;
                chcGuncelleIslem.Enabled = true;
                txtIDislem.ReadOnly = false;
                txtIDislem.Clear();
                btnTamamIslem.Enabled = false;
            }
        }

        private void chcSilIslem_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSilIslem.Checked == true)
            {
                chcEkleIslem.Enabled = false;
                chcGuncelleIslem.Enabled = false;
                txtIDislem.ReadOnly = true;
                txtSifreislem.ReadOnly = true;
                txtSifreTekrarislem.ReadOnly = true;
                btnTamamIslem.Enabled = true;
            }
            else
            {
                chcEkleIslem.Enabled = true;
                chcGuncelleIslem.Enabled = true;
                txtIDislem.ReadOnly = false;
                txtSifreislem.ReadOnly = false;
                txtSifreTekrarislem.ReadOnly = false;
                btnTamamIslem.Enabled = false;
            }
        }

        private void chcGuncelleIslem_CheckedChanged(object sender, EventArgs e)
        {
            if (chcGuncelleIslem.Checked == true)
            {
                chcSilIslem.Enabled = false;
                chcEkleIslem.Enabled = false;
                txtIDislem.ReadOnly = true;
                txtIDislem.Text = "ID güncellenemez.";
                btnTamamIslem.Enabled = true;
            }
            else
            {
                chcSilIslem.Enabled = true;
                chcEkleIslem.Enabled = true;
                txtIDislem.ReadOnly = false;
                txtIDislem.Clear();
                btnTamamIslem.Enabled = false;
            }
        }

        private void btnTamamIslem_Click(object sender, EventArgs e)
        {
            if (chcEkleIslem.Checked == true && txtSifreislem.Text == txtSifreTekrarislem.Text && cmbxGirisYontemIslem.Text == "Yönetici")
            {
                tbYonetici adminEkle= new tbYonetici();
                adminEkle.adminNo = txtKAislem.Text;
                adminEkle.sifre = txtSifreislem.Text;

                re.tbYonetici.Add(adminEkle);
                re.SaveChanges();
               
                MessageBox.Show("Admin eklendi");
            }
            else if (chcEkleIslem.Checked == true && txtSifreislem.Text == txtSifreTekrarislem.Text && cmbxGirisYontemIslem.Text == "Garson")
            {
                tbGarson garsonEkle = new tbGarson();
                garsonEkle.garsonNo = txtKAislem.Text;
                garsonEkle.sifre = txtSifreislem.Text;

                re.tbGarson.Add(garsonEkle);
                re.SaveChanges();
               
                MessageBox.Show("Garson eklendi");
            }
            else if (chcSilIslem.Checked == true && txtSifreislem.Text == txtSifreTekrarislem.Text && cmbxGirisYontemIslem.Text == "Yönetici")
            {
                string adminNo = txtKAislem.Text.ToString();
                var hangiAdmin = re.tbYonetici.Where(x => x.adminNo == adminNo).FirstOrDefault();
                re.tbYonetici.Remove(hangiAdmin);
                re.SaveChanges();

                MessageBox.Show("KA ve Şifre silindi.");
            }
            else if (chcSilIslem.Checked == true && txtSifreislem.Text == txtSifreTekrarislem.Text && cmbxGirisYontemIslem.Text == "Garson")
            {
                string garsonNo = txtKAislem.Text.ToString();
                var hangiGarson = re.tbGarson.Where(x => x.garsonNo == garsonNo).FirstOrDefault();
                re.tbGarson.Remove(hangiGarson);
                re.SaveChanges();

                MessageBox.Show("KA ve Şifre silindi.");
            }
            else if (chcGuncelleIslem.Checked == true && txtSifreislem.Text == txtSifreTekrarislem.Text && cmbxGirisYontemIslem.Text == "Yönetici")
            {
                string adminNo = txtKAislem.Text;
                var hangiAdmin = re.tbYonetici.Where(x => x.adminNo == adminNo).FirstOrDefault();

                //hangiAdmin.adminNo = txtKAislem.Text;
                hangiAdmin.sifre = txtSifreislem.Text;

                MessageBox.Show("KA ve Şifre güncellendi.");
            }
            else if (chcGuncelleIslem.Checked == true && txtSifreislem.Text == txtSifreTekrarislem.Text && cmbxGirisYontemIslem.Text == "Garson")
            {
                string garsonNo = txtKAislem.Text;
                var hangiGarson = re.tbGarson.Where(x => x.garsonNo == garsonNo).FirstOrDefault();

                //hangiGarson.garsonNo = txtKAislem.Text;
                hangiGarson.sifre = txtSifreislem.Text;

                MessageBox.Show("KA ve Şifre güncellendi.");
            }
            else
            {
                if (txtSifreislem.Text != txtSifreTekrarislem.Text)
                {
                    MessageBox.Show("Girilen şifreler aynı değil, lütfen geçerli şifre giriniz.");
                }
            }
        
        }
    }
}
