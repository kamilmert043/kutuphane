using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }
        string ka ="";
        string ky ="";
        public void kitapEkle(string kitapAdi, string kitapYazari)
        {
            listBox1.Items.Add(kitapAdi);
            listBox2.Items.Add(kitapYazari);

        }
        public void kitapDuzenle(string dKitapAdi, string dKitapYazari)
        {

            int secim = listBox1.SelectedIndex;
            listBox1.Items[secim] = dKitapAdi;
            listBox2.Items[secim] = dKitapYazari;

        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KitapEklemeEkrani kitapEklemeEkrani = new KitapEklemeEkrani(this);
            kitapEklemeEkrani.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Bu Kayıt Düzenlenemez.");
                return;
            }

            ka = listBox1.Items[listBox1.SelectedIndex].ToString();
            ky = listBox2.Items[listBox1.SelectedIndex].ToString();
            KitapDuzenlemeEkrani kitapDuzenlemeEkrani = new KitapDuzenlemeEkrani(this);
            kitapDuzenlemeEkrani.textBox1.Text = ka;
            kitapDuzenlemeEkrani.textBox2.Text = ky;
            kitapDuzenlemeEkrani.Show();
            button1.Visible = false;
            button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Bu Kayıt Silinemez.");
                return;
            }
            DialogResult silme = new DialogResult();
            silme = MessageBox.Show("Kaydı Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (silme == DialogResult.Yes)
            {

                
                listBox2.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            button1.Visible = false;
            button2.Visible = false;
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
        }

        private void AnaEkran_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
        }
    }
}
