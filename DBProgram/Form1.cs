using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using DBProgram.Model;

namespace DBProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ISession session = SessionFactory.GetFactory().OpenSession())
            {
                var query = session.CreateQuery("from Customer").List<Customer>();
                richTextBox1.Text = "Query:\n";
                foreach (var obj in query)
                    richTextBox1.Text += obj.ToString();
            }
        }
    }
}
