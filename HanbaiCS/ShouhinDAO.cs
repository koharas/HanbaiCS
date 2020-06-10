using System.Data;
using MySql.Data.MySqlClient;

namespace HanbaiCS
{
    class ShouhinDAO
    {
        private HanbaiConnection con;

        public ShouhinDAO(HanbaiConnection con)
        {
            this.con = con;
        }

        public void Fill(DataTable table)
        {
            table.Clear();
            var adp = new MySqlDataAdapter("SELECT * FROM shouhin", con.Connection);
            adp.Fill(table);
        }
        public Shouhin FindById(int sid)
        {
            var sql = "SELECT * FROM shouhin WHERE mid=@sid";
            var cmd = new MySqlCommand(sql, con.Connection);
            cmd.Parameters.AddWithValue("@sid", sid);

            var reader = cmd.ExecuteReader();

            Shouhin s = null;
            if (reader.Read())
            {
                var sname = reader.GetString("sname");
                var tanka = reader.GetInt32("tanka");

                s = new Shouhin(sid, sname,tanka);
            }
            reader.Close();

            return s;
        }

        public void Insert(Shouhin shouhin)
        {
            string sql = "INSERT INTO shouhin(sname,tanka) VALUES(@sname,@tanka)";
            var cmd = new MySqlCommand(sql, con.Connection);

            cmd.Parameters.AddWithValue("@sname", shouhin.Sname);
            cmd.Parameters.AddWithValue("@tanka", shouhin.Tanka);

            cmd.ExecuteNonQuery();
        }

        public void Update(Shouhin shouhin)
        {
            var sql = "UPDATE shouhin SET sname=@sname,tanka=@tanka WHERE sid=@sid";
            var cmd = new MySqlCommand(sql, con.Connection);

            cmd.Parameters.AddWithValue("@sname", shouhin.Sname);
            cmd.Parameters.AddWithValue("@tanka", shouhin.Tanka);
            cmd.Parameters.AddWithValue("@sid", shouhin.Sid);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int sid)
        {
            var sql = "DELETE FROM shouhin WHERE sid=@sid";
            var cmd = new MySqlCommand(sql, con.Connection);

            cmd.Parameters.AddWithValue("@sid", sid);

            cmd.ExecuteNonQuery();
        }
    }
}
