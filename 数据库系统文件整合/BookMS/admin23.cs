using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS
{
    public partial class admin23 : Form
    {
        string ID = "";
        public admin23()
        {
            InitializeComponent();
        }
        //构造方法，将书的那几个参数直接传进来
        public admin23(string id, string name, string author, string press, string number)
        {
            InitializeComponent();
            ID=textBox4.Text = id;
            textBox2.Text = name;
            textBox1.Text = author;
            textBox3.Text = press;
            textBox5.Text = number;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_book set id='{textBox4.Text}'," +
                $"[name]='{textBox2.Text}',author='{textBox1.Text}'," +
                $"press='{textBox3.Text}',number={textBox5.Text} where id='{ID}'";
            Dao dao = new Dao();
            if (dao.Execute(sql)>0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
