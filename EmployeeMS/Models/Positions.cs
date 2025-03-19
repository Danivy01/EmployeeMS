using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeMS.Models
{
    public class Positions
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Positions> GetAllRecords()
        {
            List<Positions> positions = new List<Positions>();
            
            SqlConnection con = new SqlConnection ("SERVER=JOSEITSD\\RAP; DATABASE = dbEMS; INTEGRATED SECURITY = TRUE");
            con.Open();
            var cm = new SqlCommand("SELECT * FROM tbl_positions", con);
            var dt = new DataTable();
            dt.Load(cm.ExecuteReader());
            foreach (DataRow r in dt.Rows)
            {
                Positions p = new Positions();
                p.Id = Convert.ToInt32(r["id"]);
                p.Title = r["title"].ToString();
                p.Description = r["description"].ToString();

                positions.Add(p);
            }
            con.Close();
            return positions;
        }

        public void InsertRecord(Positions pos)
        {
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=TRUE");
            con.Open();
            var cm = new SqlCommand("INSERT INTO tbl_positions (title, description) VALUES (@title, @description)", con);
            cm.Parameters.Add(new SqlParameter("@title", pos.Title));
            cm.Parameters.Add(new SqlParameter("@description", pos.Description));
            cm.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateRecord(Positions pos)
        {
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=TRUE");
            con.Open();
            var cm = new SqlCommand("UPDATE tbl_positions SET title = @title, description = @description WHERE Id = @Id", con);
            cm.Parameters.Add(new SqlParameter("@Id", pos.Id));
            cm.Parameters.Add(new SqlParameter("@title", pos.Title));
            cm.Parameters.Add(new SqlParameter("@description", pos.Description));
            cm.ExecuteNonQuery();
            con.Close();
        }

        public Positions FindRecord(int Id)
        {
            var item = new Positions();
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=TRUE");
            con.Open();
            var cm = new SqlCommand("SELECT * FROM tbl_positions WHERE Id = @Id", con);
            cm.Parameters.Add(new SqlParameter("@Id", Id));
            var dt = new DataTable();
            dt.Load(cm.ExecuteReader());
            foreach (DataRow row in dt.Rows)
            {
                item = new Positions()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString()
                };
            }
            con.Close();
            return item;
        }

        public void DeleteRecord(Positions pos)
        {
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=TRUE");
            con.Open();
            var cm = new SqlCommand("DELETE FROM tbl_positions WHERE Id = @Id", con);
            cm.Parameters.Add(new SqlParameter("@Id", pos.Id));
            cm.ExecuteNonQuery();
            con.Close();
        }
    }
}