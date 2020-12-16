using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CAD
{
    public class Class_CAD
    {
        private string cnx;
        private string rq_sql;
        private SqlDataAdapter data_Adapt;
        private SqlConnection sql_connect;
        private SqlCommand sql_command;
        private DataSet data_set;

        public Class_CAD()
        {
            //this.cnx = "data source = (local); Initial Catalog = DB_A2_WS2; Integrated Security = SSPI";
            this.cnx = @"Data Source = DESKTOP-B1V69NA\SQLEXPRESS01;  Initial Catalog = DB_A2_WS2; Integrated Security = SSPI";
            this.rq_sql = "";
            this.sql_connect = new SqlConnection(this.cnx);
            this.data_Adapt = new SqlDataAdapter();
            this.sql_command = new SqlCommand();
            this.data_set = new DataSet();

            this.sql_command.CommandType = System.Data.CommandType.Text;
            this.sql_command.Connection = this.sql_connect;
        }

        public string get_cnx()
        {
            return this.cnx;
        }

        public void actionRows(string rq_sql)
        {
            this.sql_connect.Open();
            this.rq_sql = rq_sql;
            this.sql_command.CommandText = this.rq_sql;
            this.sql_command.ExecuteReader();
            this.sql_connect.Close();
        }

        public DataSet getRows(string rq_sql, string dataTableName)
        {
            this.data_set.Clear();

            this.rq_sql = rq_sql;
            this.sql_command.CommandText = this.rq_sql;
            this.data_Adapt.SelectCommand = this.sql_command;
            this.data_Adapt.Fill(this.data_set, dataTableName);

            return this.data_set;
        }

        public void delete(string rq_sql)
        {
            this.sql_connect.Open();
            this.rq_sql = rq_sql;
            this.sql_command.CommandText = this.rq_sql;
            this.sql_command.ExecuteNonQuery();
            this.sql_connect.Close();
        }

    }
}
