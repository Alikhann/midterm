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
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace midterm
{
    public partial class Form1 : Form
    {
        //String pattern = @"^\d{1}[\s\,]?\S{1-9}[\s\,]?\S{1-10}[\@]\S{1-5}[\.]\S{2-6}[\s\,]?\d{3}$";//1|space or ,|
        String pattern = @"^[0-9]+[\s\,]?(\w+)[\s\,]?(\w+)\@(\w+)\.(\w+)[\s\,]?[0-9]+$";
        BindingList<Entry> ent = new BindingList<Entry>();
        char[] delimeters = new[] {',',' '};
        String[] inputs = File.ReadAllLines(@"contact.txt");
        FileStream fs = new FileStream("data.XML", FileMode.Create);
        XmlSerializer xs = new XmlSerializer(typeof(Entry));
        
        public Form1()
        {
            InitializeComponent();
        }
        
        void Sample()
        {
            dataGridView1.DataSource = ent;
            ent.AllowRemove = true;
            
            dataGridView1.Refresh();

            for(int i = 0; i < inputs.Length; i++)
            {
                if (Regex.IsMatch(inputs[i], pattern))
                {
                    string[] elements = inputs[i].Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                    var id = Convert.ToInt32(elements[0]);
                    var name = elements[1];
                    var email = elements[2];
                    var number = elements[3];
                    ent.Add(new Entry(id, name, email, number));
                    xs.Serialize(fs, new Entry(id, name, email, number));

                    Console.WriteLine("Success!");
                }
                else throw new Exception("fail");
            }
            dataGridView1.Refresh();
            fs.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Sample();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
          
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(searchValue))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                    MessageBox.Show("no compare!");
            }

        }
    }
}
