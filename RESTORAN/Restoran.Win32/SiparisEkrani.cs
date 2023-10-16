using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restoran.Win32
{
    public partial class SiparisEkrani : Form
    {
        public SiparisEkrani()
        {
            InitializeComponent();

            btnHesaplaOdeme.Enabled = false;
            txtSiparisNo.ReadOnly = true;
            chcNakitOdeme.Checked = false;

            btnHesaplaOdeme.BackColor = SystemColors.GrayText;

            lblMenuFiyat.TextChanged += HesaplaToplamUcret;
            lblIcecekFiyat.TextChanged += HesaplaToplamUcret;
            lblSosFiyat.TextChanged += HesaplaToplamUcret;
            lblBoyFiyat.TextChanged += HesaplaToplamUcret;

            txtOdenenTutar.TextChanged += HesaplaParaUstu;
            txtKalanTutarOdeme.TextChanged += HesaplaParaUstu;
            txtSiparisTutarOdeme.TextChanged += HesaplaParaUstu;
        }

        dbRestoranEntities re = new dbRestoranEntities();

        void listele()
        {
           dataSiparisListesi.DataSource = re.tbSiparis.ToList();
        }

        void masaKoduGonder()
        {
            comboBoxMasalar.Items.Clear();
            cmbxOdemeMasaSec.Items.Clear();
            var idList = re.tbMasalar.ToList();
            foreach (var item in idList)
            {
                comboBoxMasalar.Items.Add(item.MasaNo);
                cmbxOdemeMasaSec.Items.Add(item.MasaNo);
            }
        }

        void menuKoduGonder()
        {
            comboBoxMenuSec.Items.Clear();
            var idList = re.tbMenu.ToList();
            foreach (var item in idList)
            {
                comboBoxMenuSec.Items.Add(item.MenuKodu);
            }
        }

        void icecekKoduGonder()
        {
            comboBoxIcecekSec.Items.Clear();
            var idList = re.tbIcecekler.ToList();
            foreach (var item in idList)
            {
                comboBoxIcecekSec.Items.Add(item.IcecekAdi);
            }
        }

        void sosKoduGonder()
        {
            comboBoxSosSec.Items.Clear();
            var idList = re.tbSoslar.ToList();
            foreach (var item in idList)
            {
                comboBoxSosSec.Items.Add(item.SosAdi);
            }
        }

        void boyKoduGonder()
        {
            comboBoxBoy.Items.Clear();
            var idList = re.tbBoylar.ToList();
            foreach (var item in idList)
            {
                comboBoxBoy.Items.Add(item.BoyAdi);
            }
        }

        void veriGonder()
        {
            cbmxSiparisID.Items.Clear();
            var idList = re.tbSiparis.ToList();
            foreach (var item in idList)
            {
                cbmxSiparisID.Items.Add(item.ID);
            }
        }

        void odemeSiparisKoduGonder()
        {
            cmbxOdemeSiparisNo.Items.Clear();
            var idList = re.tbSiparis.ToList();
            foreach (var item in idList)
            {
                cmbxOdemeSiparisNo.Items.Add(item.siparisNo);
            }
        }

        void siparisNoAttir()
        {
                string yeniSiparisKodu;

                try
                {
                    var sonSiparis = re.tbSiparis.OrderByDescending(s => s.siparisNo).FirstOrDefault();

                    if (sonSiparis != null)
                    {
                        string sonSiparisKodu = sonSiparis.siparisNo;
                        int sonSiparisNumarasi = int.Parse(sonSiparisKodu.Substring(3)); // "SIP" kısmını atla
                        sonSiparisNumarasi++;

                        yeniSiparisKodu = $"SIP{sonSiparisNumarasi:D4}";
                    }
                    else
                    {
                        yeniSiparisKodu = "SIP0001";
                    }
                    txtSiparisNo.Text = yeniSiparisKodu;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
        private int siparisKoduCounter = 1;
        private string GenerateSiparisKodu()
        {
                string siparisKodu;
                bool unique = false;

                do
                {
                    // Yeni bir sipariş kodu oluştur
                    siparisKodu = $"SIP{siparisKoduCounter:D4}";
                    siparisKoduCounter++;

                    // SQL veritabanında aynı sipariş numarasını kontrol et
                    bool exists = re.tbSiparis.Any(s => s.siparisNo == siparisKodu);

                    if (!exists)
                    {
                        unique = true;
                    }
                    else
                    {
                        lblStatusSiparis.Text = siparisKodu + " numaralı sipariş kodu sistemde mevcuttur.";
                    }
                } while (!unique);

                return siparisKodu;

        }

        private void SiparisEkrani_Load(object sender, EventArgs e)
        {
            listele();
            veriGonder();
            menuKoduGonder();
            icecekKoduGonder();
            sosKoduGonder();
            boyKoduGonder();
            masaKoduGonder();
            odemeSiparisKoduGonder();
            string siparisKodu = GenerateSiparisKodu();
            txtSiparisNo.Text = siparisKodu;
            txtOdenenTutar.ReadOnly = true;
        }

        private void HesaplaParaUstu(object sender, EventArgs e)
        {
            int verilenPara, masaToplami, siparisTutar;
            if (chcHesapBolOdeme.Checked == false && int.TryParse(txtOdenenTutar.Text, out verilenPara) && int.TryParse(txtKalanTutarOdeme.Text, out masaToplami))
            {
                int paraUstu = verilenPara - masaToplami;
                txtParaUstu.Text = paraUstu.ToString("C");
            }
            else if (chcHesapBolOdeme.Checked == true && int.TryParse(txtSiparisTutarOdeme.Text, out siparisTutar) && int.TryParse(txtOdenenTutar.Text, out verilenPara))
            {
                int paraUstu = verilenPara - siparisTutar;
                txtParaUstu.Text = paraUstu.ToString("C");
            }
            else
            {
                txtParaUstu.Text = "0";
            }
        }

    private void HesaplaToplamUcret(object sender, EventArgs e)
        {
            int menuFiyat, icecekFiyat, sosFiyat, boyFiyat;

            if (int.TryParse(lblMenuFiyat.Text, out menuFiyat) && int.TryParse(lblIcecekFiyat.Text, out icecekFiyat) && int.TryParse(lblSosFiyat.Text, out sosFiyat) && int.TryParse(lblBoyFiyat.Text, out boyFiyat))
            {
                int toplamUcret = menuFiyat + icecekFiyat + sosFiyat + boyFiyat;
                txtToplamTutar.Text = toplamUcret.ToString();
            }
            else
            {
                txtToplamTutar.Text = "";
            }
        }

        void siparisEkle()
        {
            tbSiparis yeniSiparis = new tbSiparis();
            yeniSiparis.siparisNo = txtSiparisNo.Text;
            yeniSiparis.tarih = DateTime.Now;
            yeniSiparis.masaNo = comboBoxMasalar.SelectedItem.ToString();
            yeniSiparis.menu = comboBoxMenuSec.SelectedItem.ToString();
            yeniSiparis.icecek = comboBoxIcecekSec.SelectedItem.ToString();
            yeniSiparis.sos = comboBoxSosSec.SelectedItem.ToString();
            yeniSiparis.notlar = txtSiparisNotSiparisEkrani.Text.ToString();
            yeniSiparis.boy = comboBoxBoy.SelectedItem.ToString();
            yeniSiparis.masaToplamTutar = int.Parse(txtToplamTutar.Text);
            if (chcNakitOdeme.Checked)
            {
                yeniSiparis.odemeTuru = chcNakitOdeme.Text.ToString();
            }
            else if (chcKrediKartiOdeme.Checked)
            {
                yeniSiparis.odemeTuru = chcKrediKartiOdeme.Text.ToString();
            }
            else if (chcTicketOdeme.Checked)
            {
                yeniSiparis.odemeTuru = chcTicketOdeme.Text.ToString();
            }

            re.tbSiparis.Add(yeniSiparis);
            try
            {
                re.SaveChanges();
            }
            catch (DbEntityValidationException eMessage)
            {
                Console.WriteLine(eMessage);
            }

            lblStatusSiparis.Text = "Sipariş alındı.";

            listele();
            veriGonder();
        }

        void siparisSil()
        {
            string siparisNo = txtSiparisNo.Text;
            var hangiSiparis = re.tbSiparis.Where(x => x.siparisNo == siparisNo).FirstOrDefault();
            re.tbSiparis.Remove(hangiSiparis);
            re.SaveChanges();
            lblStatusSiparis.Text = "Sipariş Silindi.";
            listele();
            veriGonder();
        }

        void siparisGuncelle()
        {
            string siparisNo = txtSiparisNo.Text;
            var hangiSiparis = re.tbSiparis.Where(x => x.siparisNo == siparisNo).FirstOrDefault();

            hangiSiparis.menu = comboBoxMenuSec.Text;
            hangiSiparis.icecek = comboBoxIcecekSec.Text;
            hangiSiparis.sos = comboBoxSosSec.Text;
            hangiSiparis.notlar = txtSiparisNotSiparisEkrani.Text;
            hangiSiparis.boy = comboBoxBoy.SelectedItem.ToString();
            lblStatusSiparis.Text = "Sipariş Güncellendi.";
            listele();
            veriGonder();
        }

        void temizle()
        {
            comboBoxMasalar.Text = string.Empty;
            comboBoxIcecekSec.Text = string.Empty;
            comboBoxMenuSec.Text = string.Empty;
            comboBoxSosSec.Text = string.Empty;
            comboBoxBoy.Text = string.Empty;
            txtSiparisNotSiparisEkrani.Text = string.Empty;
            cbmxSiparisID.Text = string.Empty;
            lblBoyFiyat.Text = string.Empty;
            lblIcecekFiyat.Text = string.Empty;
            lblMenuFiyat.Text = string.Empty;
            lblSosFiyat.Text = string.Empty;
            lblStatusSiparis.Text = "...";
        }

        private void btnSiparisIptal_Click(object sender, EventArgs e)
        {
            comboBoxMasalar.Text = string.Empty;
            comboBoxIcecekSec.Text = string.Empty;
            comboBoxMenuSec.Text = string.Empty;
            comboBoxSosSec.Text = string.Empty;
            comboBoxBoy.Text = string.Empty;
            txtSiparisNotSiparisEkrani.Text = string.Empty;
            txtSiparisNo.Text = string.Empty;
            cbmxSiparisID.Text = string.Empty;
            lblBoyFiyat.Text = string.Empty;
            lblIcecekFiyat.Text = string.Empty;
            lblMenuFiyat.Text = string.Empty;
            lblSosFiyat.Text = string.Empty;
            lblStatusSiparis.Text = "...";
        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            if (chcSiparisGuncelle.Checked == true)
            {
                siparisGuncelle();
                listele();
                veriGonder();
                temizle();
                chcSiparisSil.Checked = false;
                chcSiparisGuncelle.Checked = false;
            }
            else if (chcSiparisSil.Checked == true)
            {
                siparisSil();
                listele();
                veriGonder();
                temizle();
                chcSiparisSil.Checked = false;
                chcSiparisGuncelle.Checked = false;
            }
            else if (chcSiparisGuncelle.Checked == false && chcSiparisSil.Checked == false)
            {
                siparisNoAttir();
                siparisEkle();
                listele();
                veriGonder();
                temizle();
                chcSiparisSil.Checked = false;
                chcSiparisGuncelle.Checked = false;
            }
        }

        private void cbmxSiparisListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(cbmxSiparisID.Text);

            var idSiparis = re.tbSiparis.Where(x => x.ID == ID).ToList();

            foreach (var item in idSiparis) 
            {
                txtSiparisNo.Text = item.siparisNo;
                comboBoxMasalar.Text = item.masaNo;
                comboBoxMenuSec.Text = item.menu;
                comboBoxIcecekSec.Text = item.icecek;
                comboBoxSosSec.Text = item.sos;
                comboBoxBoy.Text = item.boy;
                txtSiparisNotSiparisEkrani.Text = item.notlar;
            }
        }

        private void chcSiparisSil_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSiparisSil.Checked == true)
            {
                chcSiparisGuncelle.Enabled = false;
            }
            else
            {
                chcSiparisGuncelle.Enabled = true;
            }
        }

        private void chcSiparisGuncelle_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSiparisGuncelle.Checked == true)
            {
                chcSiparisSil.Enabled = false;
                txtSiparisNo.ReadOnly = true;
            }
            else
            {
                chcSiparisSil.Enabled = true;
                txtSiparisNo.ReadOnly = false;
                txtSiparisNo.Clear();
            }
        }

        private void comboBoxMenuSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenMenu = comboBoxMenuSec.SelectedItem.ToString();

            var menuFiyat = re.tbFiyatlar.Where(x=>x.UrunAdi== secilenMenu).Select(x=>x.SatisFiyati).FirstOrDefault();
            
                lblMenuFiyat.Text = menuFiyat.ToString();
        }

        private void comboBoxIcecekSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenIcecek = comboBoxIcecekSec.SelectedItem.ToString();

            var icecekFiyat = re.tbFiyatlar.Where(x => x.UrunAdi == secilenIcecek).Select(x => x.SatisFiyati).FirstOrDefault();

            lblIcecekFiyat.Text = icecekFiyat.ToString();
        }

        private void comboBoxSosSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenSos = comboBoxSosSec.SelectedItem.ToString();

            var sosFiyat = re.tbFiyatlar.Where(x => x.UrunAdi == secilenSos).Select(x => x.SatisFiyati).FirstOrDefault();

            lblSosFiyat.Text = sosFiyat.ToString();
        }

        private void comboBoxBoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenBoy = comboBoxBoy.SelectedItem.ToString();

            var boyFiyat = re.tbFiyatlar.Where(x => x.UrunAdi == secilenBoy).Select(x => x.SatisFiyati).FirstOrDefault();

            lblBoyFiyat.Text = boyFiyat.ToString();
        }

        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            // ONUR NOT - bu butona tıklandığı zaman seçili masanın datalarını tbHasilat tablosuna gönderecek ve tbSiparis tablosundan o masaya ait verileri silecek.
            if (chcNakitOdeme.Checked == false && chcKrediKartiOdeme.Checked == false && chcTicketOdeme.Checked == false)
            {
                MessageBox.Show("Geçerli bir ödeme türü seçiniz.");
            }
            else
            {
                hasilatAktar();
                satisAktar();
                siparisMasaSil();
            }
            
        }

        void siparisMasaSil()
        {
            if (chcHesapBolOdeme.Checked == true)
            {
                string connectionString = "Data Source=ONUR\\SQLEXPRESS;Initial Catalog=dbRestoran;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Siparişi silmek için SQL sorgusu oluşturun
                        string deleteQuery = "DELETE FROM tbSiparis WHERE siparisNo = @siparisNo";

                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@siparisNo", cmbxOdemeSiparisNo.Text.ToString());

                        int affectedRows = deleteCommand.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            // Sipariş başarıyla silindi
                            MessageBox.Show("Sipariş başarıyla silindi.");

                        }
                        else
                        {
                            MessageBox.Show("Sipariş silinemedi.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
            else
            {
                string connectionString = "Data Source=ONUR\\SQLEXPRESS;Initial Catalog=dbRestoran;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Siparişi silmek için SQL sorgusu oluşturun
                        string deleteQuery = "DELETE FROM tbSiparis WHERE masaNo = @masaNo";

                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@masaNo", cmbxOdemeMasaSec.Text.ToString());

                        int affectedRows = deleteCommand.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            // Sipariş başarıyla silindi
                            MessageBox.Show("Masa başarıyla silindi.");

                        }
                        else
                        {
                            MessageBox.Show("Masa silinemedi.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        void satisAktar()
        {
            string connectionString = "Data Source=ONUR\\SQLEXPRESS;Initial Catalog=dbRestoran;Integrated Security=True"; // Veritabanı bağlantı dizesini ayarlayın.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // tbSiparis tablosundaki verileri seçin
                    string siparisQuery = "SELECT * FROM tbSiparis";

                    SqlCommand siparisCommand = new SqlCommand(siparisQuery, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(siparisCommand);
                    DataTable siparisTable = new DataTable();
                    adapter.Fill(siparisTable);

                    // tbSatis tablosuna verileri aktar
                    foreach (DataRow row in siparisTable.Rows)
                    {
                        string satisNo = "STS" + row["siparisNo"].ToString().Substring(3); // Satış numarasını oluştur

                        string satisQuery = "INSERT INTO tbSatis (tarih, satisNo, garsonNo, masaNo, menu, icecek, sos, boy, notlar, odemeTuru, satisTutar) " +
                            "VALUES (@tarih, @satisNo, @garsonNo, @masaNo, @menu, @icecek, @sos, @boy, @notlar, @odemeTuru, @satisTutar)";

                        SqlCommand satisCommand = new SqlCommand(satisQuery, connection);
                        satisCommand.Parameters.AddWithValue("@tarih", row["tarih"]);
                        satisCommand.Parameters.AddWithValue("@satisNo", satisNo);
                        satisCommand.Parameters.AddWithValue("@garsonNo", row["garsonNo"]);
                        satisCommand.Parameters.AddWithValue("@masaNo", row["masaNo"]);
                        satisCommand.Parameters.AddWithValue("@menu", row["menu"]);
                        satisCommand.Parameters.AddWithValue("@icecek", row["icecek"]);
                        satisCommand.Parameters.AddWithValue("@sos", row["sos"]);
                        satisCommand.Parameters.AddWithValue("@boy", row["boy"]);
                        satisCommand.Parameters.AddWithValue("@notlar", row["notlar"]);
                        satisCommand.Parameters.AddWithValue("@odemeTuru", row["odemeTuru"]);
                        satisCommand.Parameters.AddWithValue("@satisTutar", row["masaToplamTutar"]);

                        satisCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Veriler başarıyla aktarıldı.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri aktarımında bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }
        void hasilatAktar()
        {
            DateTime today = DateTime.Now;

            string sqlDateFormat = today.ToString("yyyy-MM-dd HH:mm:ss");

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=ONUR\\SQLEXPRESS;Initial Catalog=dbRestoran;Integrated Security=True";
            conn.Open();
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into tbHasilat (Tarih, MasaNo, garsonNo, odemeTuru, toplamCiro) values (@tarih, @MasaNo, @garsonNo, @odemeTuru, @toplamCiro)";

            cmd.Parameters.AddWithValue("@Tarih", sqlDateFormat);
            cmd.Parameters.AddWithValue("@MasaNo", cmbxOdemeMasaSec.Text);
            cmd.Parameters.AddWithValue("@garsonNo", lblKullaniciNo.Text);
            cmd.Parameters.AddWithValue("@toplamCiro", lblMasaToplam.Text.ToString());

            if (chcNakitOdeme.Checked == true)
            {
            cmd.Parameters.AddWithValue("@odemeTuru", chcNakitOdeme.Text.ToString());
            }
            else if (chcKrediKartiOdeme.Checked == true)
            {
            cmd.Parameters.AddWithValue("@odemeTuru", chcKrediKartiOdeme.Text.ToString());
            }
            else if (chcTicketOdeme.Checked == true)
            {
            cmd.Parameters.AddWithValue("@odemeTuru", chcTicketOdeme.Text.ToString());
            }
            else if (chcHesapBolOdeme.Checked == true)
            {
            cmd.Parameters.AddWithValue("@odemeTuru", chcHesapBolOdeme.Text.ToString());
            }
            else
            {
            lblStatusSiparis.Text = "Geçerli bir ödeme türü giriniz.";
            }

            if (cmd.ExecuteNonQuery() > 0)
            {
            lblStatusSiparis.Text = "Ödeme Alındı.";
            }
            else
            {
            lblStatusSiparis.Text = "Hata oluştu.";
            }
           
        }
        private void chcNakitOdeme_CheckedChanged(object sender, EventArgs e)
        {
            if (chcNakitOdeme.Checked == true)
            {
                txtOdenenTutar.ReadOnly = false;
                chcKrediKartiOdeme.Enabled = false;
                chcTicketOdeme.Enabled = false;
            }
            else
            {
                txtOdenenTutar.ReadOnly = true;
                chcKrediKartiOdeme.Enabled = true;
                chcTicketOdeme.Enabled = true;
                txtOdenenTutar.Clear();
            }
        }

        private void chcKrediKartiOdeme_CheckedChanged(object sender, EventArgs e)
        {
            if (chcKrediKartiOdeme.Checked == true)
            {
                txtOdenenTutar.ReadOnly = false;
                chcNakitOdeme.Enabled = false;
                chcTicketOdeme.Enabled = false;
            }
            else
            {
                txtOdenenTutar.ReadOnly = true;
                chcNakitOdeme.Enabled = true;
                chcTicketOdeme.Enabled = true;
            }
        }

        private void chcTicketOdeme_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTicketOdeme.Checked == true)
            {
                txtOdenenTutar.ReadOnly = false;
                chcNakitOdeme.Enabled = false;
                chcKrediKartiOdeme.Enabled = false;
            }
            else
            {
                txtOdenenTutar.ReadOnly = true;
                chcNakitOdeme.Enabled = true;
                chcKrediKartiOdeme.Enabled = true;
            }
        }

        private void cmbxOdemeSiparisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSiparisAdi = cmbxOdemeSiparisNo.SelectedItem.ToString();

                var siparisDetaylari = re.tbSiparis.Where(sd => sd.siparisNo == selectedSiparisAdi).ToList();

                listSiparisListesi.Items.Clear();

                foreach (var detay in siparisDetaylari)
                {
                    listSiparisListesi.Items.Add($"Menu: {detay.menu}");
                    listSiparisListesi.Items.Add($"Icecek: {detay.icecek}");
                    listSiparisListesi.Items.Add($"Sos: {detay.sos}");
                    listSiparisListesi.Items.Add($"Boy: {detay.boy}");

                   listSiparisListesi.Items.Add("");
                }

            lblStatusSiparis.Text = cmbxOdemeMasaSec.SelectedItem.ToString();

            string selectedSiparisNo = cmbxOdemeSiparisNo.SelectedItem.ToString();

            if (chcHesapBolOdeme.Checked == true)
            {
                txtSecilenSiparisOdeme.Text = cmbxOdemeSiparisNo.SelectedItem.ToString();
                string selectedMasaNo = cmbxOdemeMasaSec.SelectedItem.ToString();
                string seciliSiparis = cmbxOdemeSiparisNo.SelectedItem.ToString();

                int siparisTutar = (int)re.tbSiparis.Where(s => s.masaNo == selectedMasaNo && s.siparisNo == seciliSiparis).Select(s => s.masaToplamTutar).FirstOrDefault();

                txtSiparisTutarOdeme.Text = siparisTutar.ToString();
                lblStatusSiparis.Text = cmbxOdemeSiparisNo.SelectedItem.ToString();
            }
            else
            {
                txtSecilenSiparisOdeme.Text = "";
                txtSiparisTutarOdeme.Text = "";
                txtSiparisTutarOdeme.Clear();
                lblStatusSiparis.Text = cmbxOdemeMasaSec.SelectedItem.ToString();
            }
        }    

        private void cmbxOdemeMasaSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxOdemeMasaSec.Text == "Masa1")
            {
                dataSiparisListesi.DataSource = re.tbSiparis.Where(x => x.masaNo == cmbxOdemeMasaSec.Text).ToList();
            }
            else if (cmbxOdemeMasaSec.Text == "Masa2")
            {
                dataSiparisListesi.DataSource = re.tbSiparis.Where(x => x.masaNo == cmbxOdemeMasaSec.Text).ToList();
            }
            else if (cmbxOdemeMasaSec.Text == "Masa3")
            {
                dataSiparisListesi.DataSource = re.tbSiparis.Where(x => x.masaNo == cmbxOdemeMasaSec.Text).ToList();
            }
            else if (cmbxOdemeMasaSec.Text == "Masa4")
            {
                dataSiparisListesi.DataSource = re.tbSiparis.Where(x => x.masaNo == cmbxOdemeMasaSec.Text).ToList();
            }
            else if (cmbxOdemeMasaSec.Text == "Masa5")
            {
                dataSiparisListesi.DataSource = re.tbSiparis.Where(x => x.masaNo == cmbxOdemeMasaSec.Text).ToList();
            }
            else if (cmbxOdemeMasaSec.Text == "Masa6")
            {
                dataSiparisListesi.DataSource = re.tbSiparis.Where(x => x.masaNo == cmbxOdemeMasaSec.Text).ToList();
            }
        }

        private void cmbxOdemeMasaSec_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedMasaNo = cmbxOdemeMasaSec.SelectedItem.ToString();

            var siparisler = re.tbSiparis.Where(s => s.masaNo== selectedMasaNo).Select(s=>s.siparisNo).ToList();
            
            cmbxOdemeSiparisNo.DataSource = siparisler;
           
            int masaToplamTutar = re.tbSiparis.Where(s => s.masaNo == selectedMasaNo).Sum(s => s.masaToplamTutar) ?? 0;

            txtMasaToplamOdeme.Text = masaToplamTutar.ToString("C");
            txtKalanTutarOdeme.Text = masaToplamTutar.ToString();
            lblMasaToplam.Text = masaToplamTutar.ToString();
                
        }

        private void chcHesapBolOdeme_CheckedChanged(object sender, EventArgs e)
        {
            if (chcHesapBolOdeme.Checked == false)
            {
                btnHesaplaOdeme.BackColor = SystemColors.GrayText;
                txtOdenenTutar.ReadOnly = true;
                txtSecilenSiparisOdeme.Text = "";
                txtSiparisTutarOdeme.Text = "";
                btnHesaplaOdeme.Enabled = false;
            }
            else
            {
                btnHesaplaOdeme.BackColor = Color.Orange;
                btnHesaplaOdeme.Enabled = true;
                txtOdenenTutar.ReadOnly = false;
            }
        }

        private void btnHesaplaOdeme_Click(object sender, EventArgs e)
        {
            int siparisTutar = int.Parse(txtSiparisTutarOdeme.Text);
            int masaToplam = int.Parse(txtKalanTutarOdeme.Text);
            int kalanTutar = masaToplam - siparisTutar;
            txtKalanTutarOdeme.Text = kalanTutar.ToString();
            txtOdenenTutar.Text = string.Empty;
        }

    }
}
