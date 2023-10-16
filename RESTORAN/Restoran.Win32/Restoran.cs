using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran.Win32
{
    public partial class Restoran : Form
    {
        dbRestoranEntities re = new dbRestoranEntities();

        private int childFormNumber = 0;
        ComboBox comboBoxMasalar = new ComboBox();

        public Restoran(string kullaniciAdi)
        {
            InitializeComponent();
            lblAktifKullanici.Text = kullaniciAdi;
            
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


        private void yöneticiPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();
            yoneticiPaneli.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            SiparisEkrani siparisEkrani = new SiparisEkrani();
            siparisEkrani.Show();
        }

        private void btnMasa1_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x=>x.masaNo == btnMasa1.Text).ToList();
        }

        private void btnMasa2_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa2.Text).ToList();
        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa3.Text).ToList();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa4.Text).ToList();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa5.Text).ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasaa6.Text).ToList();
        }

        private void btnAdisyon_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.ToList();
        }

        private void btnMasa7_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa7.Text).ToList();
        }

        private void btnMasa8_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa8.Text).ToList();
      
        }

        private void btnMasa9_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa9.Text).ToList();
        }

        private void btnMasa10_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa10.Text).ToList();
        }

        private void btnMasa11_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa11.Text).ToList();
        }

        private void btnMasa12_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa12.Text).ToList();
        }

        private void btnMasa13_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa13.Text).ToList();
        }

        private void btnMasa14_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa14.Text).ToList();
        }
        private void btnMasa15_Click(object sender, EventArgs e)
        {
            dataMasa.DataSource = re.tbSiparis.Where(x => x.masaNo == btnMasa15.Text).ToList();
        }
    }
}
