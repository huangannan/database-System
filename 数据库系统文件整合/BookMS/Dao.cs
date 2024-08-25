using System.Data.SqlClient;

namespace BookMS
{
    class Dao
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            string str = @"Data Source=LAPTOP-INAVBO1O\SQLEXPRESS; Initial Catalog=BookDB; Integrated Security=True";//连接字符串
            sc = new SqlConnection(str);//数据库链接
            sc.Open();//打开数据库
            return sc;
        }

        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }

        public int Execute(string sql)//更新
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql)//读取
        {
            return command(sql).ExecuteReader();
        }

        public void DaoClose()
        {
            sc.Close();//关闭
        }
    }
}