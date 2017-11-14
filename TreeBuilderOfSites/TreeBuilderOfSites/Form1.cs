using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeBuilderOfSites
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string testUrl = "https://professorweb.ru/";
            BLL obj = new BLL(testUrl);
            obj.recursAdd(testUrl);
            var s= obj.AllUrl.Count;

        }
    }
}
