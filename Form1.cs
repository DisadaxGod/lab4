using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        List<string> spisok = new List<string>();
        List<Body> bodiesList = new List<Body>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }
        
        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.bodiesList.Clear();
            txtprint.Text = "";
            
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                
                switch(rnd.Next() % 3)
                {
                    case 0:
                        this.bodiesList.Add(Planets.Generate());
                        
                        break;
                    case 1:
                        this.bodiesList.Add(Stars.Generate());
                        
                        break;
                    case 2:
                        this.bodiesList.Add(Comets.Generate());
                        
                        break;
                }
            }
            
            ShowInfo();
        }
        private void ShowInfo()
        {
            int planetsCount = 0;
            int starsCount = 0;
            int cometsCount = 0;
            foreach(var body in this.bodiesList)
            {
                if (body is Planets)
                {
                    planetsCount += 1;
                    
                }
                else if (body is Stars)
                {
                    starsCount += 1;
                    
                }
                else if (body is Comets)
                {
                    cometsCount += 1;
                    
                }
            }
            txtInfo.Text = "Планеты\tЗвезды\tКометы";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", planetsCount, starsCount, cometsCount);
        }

        public void btnGet_Click(object sender, EventArgs e)
        {
            if (this.bodiesList.Count == 0)
            {
                txtOut.Text = "Пусто ¯/_(ツ)_/¯ "; //после "пусто" идёт смайлик, который несет чисто визуальный характер//
                txtprint.Text = "Пусто ¯/_(ツ)_/¯"; //после "пусто" идёт смайлик, который несет чисто визуальный характер//
                ShowInfo();

                return;
            }
            
            var body = this.bodiesList[0];                   
            txtOut.Text = body.GetInfo();


            txtprint.Text = "";
            foreach(var bodys in this.bodiesList)
            {
                if (bodys is Planets)
                {
                    
                    txtprint.Text += "планета" + "\n";
                }
                else if (bodys is Stars)
                {
                    
                    txtprint.Text +=  "звезда" + "\n";
                }
                else if (bodys is Comets)
                {
                    
                    txtprint.Text +=  "комета" + "\n";
                }
            }
            string c = null;
            var bod = bodiesList[0];
            if (bod is Planets)
            {
                c = "планета";
            }
            else if (bod is Stars)
            {
                c = "звезда";
            }
            else if (bod is Comets){
                c = "комета";
            }
           
            int pos = txtprint.Find(c);
            if (pos != -1)
            {
                txtprint.Select(0, c.Length);
                txtprint.SelectionColor = Color.Red;
            }
                
            this.bodiesList.RemoveAt(0);

            ShowInfo();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            Form2 inf = new Form2();
            if (inf.ShowDialog() == DialogResult.OK)
            {

            }           
        }

        private void txtprint_TextChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}
