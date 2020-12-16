using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CAD;

namespace middleware
{
    public class Class_middleware
    {
        private string rq_sql;
        private int id;
        private string nom;
        private string prenom;

        public string selectAll()
        {
            this.rq_sql = "SELECT * FROM TB_A2_WS2";
            return this.rq_sql;
        }

        public string selectByName()
        {
            this.rq_sql = "SELECT * FROM TB_A2_WS2 WHERE nom ='"+ this.nom +"'";
            return this.rq_sql;
        }

        public string delete()
        {
            this.rq_sql = "DELETE FROM TB_A2_WS2 WHERE id =" + this.id + "";
            return this.rq_sql;
        }

        public string insert()
        {
            this.rq_sql = "INSERT INTO TB_A2_WS2(id,nom,prenom) VALUES ('"+this.id+"','"+this.nom+"','"+this.prenom+"')";
            return this.rq_sql;
        }

        public string update()
        {
            this.rq_sql = "UPDATE TB_A2_WS2 set nom='"+this.nom+"',prenom='"+this.prenom+"' WHERE id="+this.id+"";
            return this.rq_sql;
        }

        public int get_id()
        {
            return this.id;
        }

        public string get_nom()
        {
            return this.nom;
        }

        public string get_prenom()
        {
            return this.prenom;
        }

        public void set_id(int id)
        {
            this.id = id;
        }

        public void set_nom(string nom)
        {
            this.nom = nom;
        }

        public void set_prenom(string prenom)
        {
            this.prenom = prenom;
        }
    }

}
