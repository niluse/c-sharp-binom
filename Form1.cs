using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;

            label1.Text = "Ulaşmak istediğiniz binom seviyesini giriniz.";
            label2.Text = " ";

            button1.Text = "hesapla";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] oldBin = new int[] { 1, 1 };
            int[] newBin = new int[3];
            int sayac = 0,
                boyut = 3,
                seviye;

            seviye = Convert.ToInt32(textBox1.Text);

            if (seviye == 1)
                label2.Text = "1";

            else if(seviye>1)
            {
                label2.Text = "1\n";            //ilk seviye
                
                for(;sayac<seviye-1;sayac++)
                {
                    System.Array.Resize(ref newBin, boyut);     

                    newBin[0] = 1;          //en sağ ve en sol 1 yapılır
                    newBin[boyut-1] = 1;

                    for(int i=1;i<boyut-1;i++)          //üstündeki değerlerin toplamı yeni dizideki ilgili yere atanır
                        newBin[i] = oldBin[i - 1] + oldBin[i];

                    System.Array.Resize(ref oldBin, boyut);
                    System.Array.Copy(newBin, 0, oldBin, 0, boyut);

                    for(int i=0;i<boyut;i++)            //yazdırma
                        label2.Text += newBin[i]+" ";

                    label2.Text += "\n";

                    boyut++;
                }
            }

            else         //negatif ve sıfır için:
                MessageBox.Show("lütfen geçerli bir değer girin!");
        }
    }
}
