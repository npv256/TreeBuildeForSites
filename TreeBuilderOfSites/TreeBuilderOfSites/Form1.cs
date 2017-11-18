using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsQuery.ExtensionMethods.Internal;

namespace TreeBuilderOfSites
{
    public partial class Form1 : Form
    {
        BLL obj = new BLL();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            obj.AllUrl.Clear();
            listView1.Items.Clear();
            listView2.Items.Clear();
            comboBox1.Items.Clear();
            string testUrl = "";
            if (textBoxUrl.Text.ToString().IsNullOrEmpty() || textBoxUrl.Text == "Please input url of site")
            {
                testUrl = "http://www.ci.nsu.ru/";
            }
            else
            {
                testUrl = textBoxUrl.Text;
            }
            obj.domein = testUrl;
            obj.recursAdd(testUrl);
            obj.setGenerals();
            obj.setParent();
            var s = obj.AllUrl;
            foreach (var key in obj.AllUrl.Keys)
            {
                comboBox1.Items.Add(key.tag);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void SelectByTag_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                listView2.Items.Clear();
                ElementEntity ElObj = obj.AllUrl.Keys.Where(entity => entity.tag.Contains( comboBox1.Text.ToUpper())).FirstOrDefault();
                ListViewItem lvi = new ListViewItem(ElObj.tag);
                lvi.SubItems.Add(ElObj.url);
                lvi.SubItems.Add(ElObj.parent.tag);
                listView2.Items.Add(lvi);
                foreach (var key in ElObj.generals)
                {
                    ElementEntity GenObj = new ElementEntity();
                    GenObj = key;
                    ListViewItem lvi2 = new ListViewItem(GenObj.tag);
                    lvi2.SubItems.Add(GenObj.url);
                    lvi2.SubItems.Add(GenObj.parent.tag);
                    listView1.Items.Add(lvi2);
                }
            }
            catch (Exception)
            {

                
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
