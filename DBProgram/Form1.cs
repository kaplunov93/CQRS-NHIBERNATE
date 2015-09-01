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

        private void button2_Click(object sender, EventArgs e)
        {
            new AddNewCustomer(FirstName.Text,LastName.Text,Number.Text);
            FirstName.Text = "";
            LastName.Text = "";
            Number.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new DeleteCustomer(Convert.ToInt32(Id.Value));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (ISession session = SessionFactory.GetFactory().OpenSession())
            {
                var obj = CustomerQuery.FindById(Convert.ToInt32(Id.Value));
                richTextBox1.Text =string.Format( "Find By Id={0}:\n", Convert.ToInt32(Id.Value));
                if(obj!= null)
                    richTextBox1.Text += obj.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (ISession session = SessionFactory.GetFactory().OpenSession())
            {
                var query = CustomerQuery.FindByFirstName(FirstName.Text);
                richTextBox1.Text = string.Format("Find By First Name = {0}:\n", FirstName.Text);
                foreach (var obj in query)
                    richTextBox1.Text += obj.ToString();
            }
            FirstName.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (ISession session = SessionFactory.GetFactory().OpenSession())
            {
                var query = CustomerQuery.FindByLastName(LastName.Text);
                richTextBox1.Text = string.Format("Find By Last Name = {0}:\n", LastName.Text);
                foreach (var obj in query)
                    richTextBox1.Text += obj.ToString();
            }
            LastName.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (ISession session = SessionFactory.GetFactory().OpenSession())
            {
                var query = CustomerQuery.FindByNumber(Number.Text);
                richTextBox1.Text = string.Format("Find By Number = {0}:\n", Number.Text);
                foreach (var obj in query)
                    richTextBox1.Text += obj.ToString();
            }
            Number.Text = "";
        }
    }
}
