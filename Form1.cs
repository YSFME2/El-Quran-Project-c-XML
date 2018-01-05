using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Quran
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fontDialog1.Font = richTextBox2.Font;
            XmlReader xml = XmlReader.Create("muyassar");
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.Element && xml.Name == "sura")
                {
                    if (xml.HasAttributes)
                    {
                        string Name = string.Format("({0}) {1}", xml.GetAttribute("index"), xml.GetAttribute("name"));
                        comboBox1.Items.Add(Name);
                    }
                }
            }
            XmlReader xml1 = XmlReader.Create("quran");
            while (xml1.Read())
            {
                if (xml1.NodeType == XmlNodeType.Element && xml1.Name == "sura")
                {
                    if (xml1.HasAttributes)
                    {
                        string Name = string.Format("({0}) {1}", xml1.GetAttribute("index"), xml1.GetAttribute("name"));
                        comboBox3.Items.Add(Name);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = comboBox1.SelectedIndex;
            richTextBox1.Text = "";
            XmlDocument xml = new XmlDocument();
            xml.Load("muyassar");
            comboBox2.Items.Clear();
            comboBox2.Items.Add("السورة بالكامل");
            foreach(XmlNode xmlNode in xml.DocumentElement.ChildNodes[num])
            {
                comboBox2.Items.Add("الاية رقم {" + xmlNode.Attributes["index"].Value + "}");
            }
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            int num1 = comboBox1.SelectedIndex;
            int num2 = comboBox2.SelectedIndex;
            richTextBox1.Text = "";
            XmlDocument xml = new XmlDocument();
            xml.Load("muyassar");
            if(num2 == 0)
            {
                foreach (XmlNode xmlNode in xml.DocumentElement.ChildNodes[num1])
                {
                    richTextBox1.Text = richTextBox1.Text  + xmlNode.Attributes["index"].Value + " - " + xmlNode.Attributes["text"].Value + "\n\n";
                }
            }
            else 
            {
                foreach (XmlNode xmlNode in xml.DocumentElement.ChildNodes[num1])
                {
                    if (xmlNode.Attributes["index"].Value == string.Format("" + num2))
                    {
                        richTextBox1.Text = richTextBox1.Text  + xmlNode.Attributes["index"].Value + " - " + xmlNode.Attributes["text"].Value + "\n\n";

                    }
                }
            }
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK) 
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = comboBox3.SelectedIndex;
            richTextBox2.Text = "";
            XmlDocument xml = new XmlDocument();
            xml.Load("quran");
            comboBox4.Items.Clear();
            comboBox4.Items.Add("السورة بالكامل");
            foreach (XmlNode xmlNode in xml.DocumentElement.ChildNodes[num])
            {
                comboBox4.Items.Add("الاية رقم {" + xmlNode.Attributes["index"].Value + "}");
            }
            comboBox4.SelectedIndex = 0;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num1 = comboBox3.SelectedIndex;
            int num2 = comboBox4.SelectedIndex;
            richTextBox2.Text = "";
            XmlDocument xml = new XmlDocument();
            xml.Load("quran");
            if (num2 == 0)
            {
                if (num1 == 0) { }
                else { richTextBox2.Text = "بِسْمِ ٱللَّهِ ٱلرَّحْمَٰنِ ٱلرَّحِيمِ\n"; }
                foreach (XmlNode xmlNode in xml.DocumentElement.ChildNodes[num1])
                {
                    richTextBox2.Text = richTextBox2.Text + xmlNode.Attributes["text"].Value + " ۝" + xmlNode.Attributes["index"].Value + " ";
                }
            }
            else
            {
                foreach (XmlNode xmlNode in xml.DocumentElement.ChildNodes[num1])
                {
                    if (xmlNode.Attributes["index"].Value == string.Format("" + num2))
                    {
                        richTextBox2.Text = richTextBox2.Text + xmlNode.Attributes["text"].Value + " ۝" + xmlNode.Attributes["index"].Value + " ";

                    }
                }
            }
            richTextBox2.SelectAll();
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.Font = fontDialog1.Font;
            }
        }
    }
}
