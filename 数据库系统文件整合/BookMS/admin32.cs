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
    public partial class admin32 : Form
    {
        public admin32()
        {
            InitializeComponent();
        }

        string ID = "";
       
        //构造方法，将书的那几个参数直接传进来
        public admin32(string id, string name, string sex, string psw, string money)
        {
            InitializeComponent();
            ID = textBox4.Text = id;
            textBox2.Text = name;
            textBox1.Text = sex;
            textBox3.Text = psw;
            textBox5.Text = money;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_user set id='{textBox4.Text}'," +
                $"[name]='{textBox2.Text}',sex='{textBox1.Text}'," +
                $"psw='{textBox3.Text}',money={textBox5.Text} where id='{ID}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        }
    }
}
