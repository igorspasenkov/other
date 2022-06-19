using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace TextAnalyze
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int counter=0;
        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            for (int i =0;i<textBoxSource.Text.Length;i++)
            {
                char c = char.ToLower(textBoxSource.Text[i]);
                if (char.IsLetter(c))
                {
                    if (!map.ContainsKey(c)) map.Add(c, 0);
                    map[c]++;
                    counter++;
                }
            }
            map = map.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            for (int i=0;i<map.Count;i++)
            {
                var item = map.ElementAt(i);
                float freq = item.Value / (float)counter *100;
                ListViewItem lvi = new ListViewItem();
                lvi.Text  = item.Key.ToString();
                lvi.SubItems.Add(freq.ToString());
                lvi.SubItems.Add(item.Value.ToString());
                listView1.Items.Add(lvi);
            }
            map.Clear();
            counter = 0;
        }

        public Dictionary<char, int> map = new Dictionary<char, int>();

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxSource.Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
    }
}
