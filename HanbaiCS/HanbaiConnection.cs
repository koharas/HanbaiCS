using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HanbaiCS
{
    class HanbaiConnection
    {
        public MySqlConnection Connection {get;private set;}

        public HanbaiConnection()
        {
            Connection = new MySqlConnection("userid=root;password=;database=hanbai;Host=localhost");
        }
        public void Open()
        {
            Connection.Open();
        }
        public void Close()
        {
            Connection.Close();
        }
    }
}
