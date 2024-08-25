using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookMS
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
            
        }

        //登陆方法
        public void Login()
        {
            //用户
            if (radioButtonUser.Checked == true)
            {
                Dao dao = new Dao();
                string sql = "select* from t_user where id='"+textBox1.Text+"'and psw='"+textBox2.Text+"'";
               
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    Data.UID = dc["id"].ToString();//存放登录用户的id
                    Data.UID = dc["name"].ToString();
                    MessageBox.Show("登陆成功");
                    user1 user = new user1();//窗体实例化
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登陆失败");
                    
                }
                dao.DaoClose();
            }
            //管理员
            if (radioButtonAdmin.Checked == true)
            {
                Dao dao = new Dao();
                string sql = "select* from t_admin where id='" + textBox1.Text + "'and psw='" + textBox2.Text + "'";

                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登陆成功");
                    admin1 admin = new admin1();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登陆失败");
                    
                }
                dao.DaoClose();
            }
            MessageBox.Show("登陆失败");
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
