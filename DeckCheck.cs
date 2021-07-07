using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WPTHoldem2
{
    public partial class DeckCheck : Form
    {
        private int[] iCount;
        private Deck d;

        public DeckCheck()
        {
            InitializeComponent();
            d = new Deck();
            d.Reset();
            iCount = new int[52];

            for (int i = 0; i < 52; i++)
            {
                iCount[i] = 0;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int tmp;
            for (int i = 0; i < 52000; i++)
            {
                d.Reset();
                d.Shuffle();
                tmp = d.Pop();
                iCount[tmp]++;
            }
            ShowCounts();
        }

        private void ShowCounts()
        {
            textBox1.Text = iCount[0] + "";
            textBox2.Text = iCount[1] + "";
            textBox3.Text = iCount[2] + "";
            textBox4.Text = iCount[3] + "";
            textBox5.Text = iCount[4] + "";
            textBox6.Text = iCount[5] + "";
            textBox7.Text = iCount[6] + "";
            textBox8.Text = iCount[7] + "";
            textBox9.Text = iCount[8] + "";
            textBox10.Text = iCount[9] + "";
            textBox11.Text = iCount[10] + "";
            textBox12.Text = iCount[11] + "";
            textBox13.Text = iCount[12] + "";
            textBox14.Text = iCount[13] + "";
            textBox15.Text = iCount[14] + "";
            textBox16.Text = iCount[15] + "";
            textBox17.Text = iCount[16] + "";
            textBox18.Text = iCount[17] + "";
            textBox19.Text = iCount[18] + "";
            textBox20.Text = iCount[19] + "";
            textBox21.Text = iCount[20] + "";
            textBox22.Text = iCount[21] + "";
            textBox23.Text = iCount[22] + "";
            textBox24.Text = iCount[23] + "";
            textBox25.Text = iCount[24] + "";
            textBox26.Text = iCount[25] + "";
            textBox27.Text = iCount[26] + "";
            textBox28.Text = iCount[27] + "";
            textBox29.Text = iCount[28] + "";
            textBox30.Text = iCount[29] + "";
            textBox31.Text = iCount[30] + "";
            textBox32.Text = iCount[31] + "";
            textBox33.Text = iCount[32] + "";
            textBox34.Text = iCount[33] + "";
            textBox35.Text = iCount[34] + "";
            textBox36.Text = iCount[35] + "";
            textBox37.Text = iCount[36] + "";
            textBox38.Text = iCount[37] + "";
            textBox39.Text = iCount[38] + "";
            textBox40.Text = iCount[39] + "";
            textBox41.Text = iCount[40] + "";
            textBox42.Text = iCount[41] + "";
            textBox43.Text = iCount[42] + "";
            textBox44.Text = iCount[43] + "";
            textBox45.Text = iCount[44] + "";
            textBox46.Text = iCount[45] + "";
            textBox47.Text = iCount[46] + "";
            textBox48.Text = iCount[47] + "";
            textBox49.Text = iCount[48] + "";
            textBox50.Text = iCount[49] + "";
            textBox51.Text = iCount[50] + "";
            textBox52.Text = iCount[51] + "";
        }
    }
}