using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LevensteinMatrix
{
    public partial class TestLevenstein : Form
    {
        
        public TestLevenstein()
        {
            InitializeComponent();
            
        }

        private void InText_Path2learnfrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') {
                string test = InText_Path2learnfrom.Text;
                if (File.Exists(test))
                {

                }
            }
        }
    }
}
