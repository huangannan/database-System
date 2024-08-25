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
    public partial class admin3 : Form
    {
        public admin3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


   
        //读取数据显示在表格
        public void Table()
        {
            dataGridView2.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select*from t_user";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView2.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin31 admin = new admin31();
            admin.ShowDialog();//实现页面跳转
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //点击某一行图书信息，获取这一行的信息，再通过主键(书号)来删除
            try
            {
                string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();//获取书号
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from t_book where id='{id}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败" + sql);
                    }
                    dao.DaoClose();
                }
            }
            catch
            {
                MessageBox.Show("请先在表格选中所要删除的图书", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                string press = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                string number = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                admin32 admin = new admin32(id, name, author, press, number);
                admin.ShowDialog();//实现页面跳转
                Table();//刷新数据
            }
            catch
            {
                MessageBox.Show("EROORE");
            }
        }

        private void admin3_Load(object sender, EventArgs e)
        {
            Table();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Table();
           
        }
    }

    
}
