using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeMS.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string location { get; set; }

        public List<Departments> GetAllRecordDept()
        {
            List<Departments> department = new List<Departments>();
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=True");
            con.Open();
            var cm = new SqlCommand("SELECT * FROM tbl_departments", con);
            var dt = new DataTable();
            dt.Load(cm.ExecuteReader());
            foreach (DataRow r in dt.Rows)
            {
                Departments dept = new Departments();
                dept.Id = Convert.ToInt32(r["Id"]);
                dept.name = r["name"].ToString();
                dept.location = r["location"].ToString();

                department.Add(dept);
            }

            con.Close();
            return department;
        }

        public void InsertDept(Departments dept)
        {
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=True");
            con.Open();
            var cm = new SqlCommand("INSERT INTO tbl_departments (name, location) VALUES (@name, @location)", con);
            cm.Parameters.Add(new SqlParameter("@name", dept.name));
            cm.Parameters.Add(new SqlParameter("@location", dept.location));
            cm.ExecuteNonQuery();
            con.Close();
        }

        public Departments Find(int Id)
        {
            var department = new Departments();
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=True");
            con.Open();
            var cm = new SqlCommand("SELECT * FROM tbl_departments WHERE Id = @Id", con);
            cm.Parameters.Add(new SqlParameter("@Id", Id));
            var dt = new DataTable();
            dt.Load(cm.ExecuteReader());
            foreach (DataRow d in dt.Rows)
            {
                department = new Departments()
                {
                    Id = Convert.ToInt32(d["Id"]),
                    name = d["name"].ToString(),
                    location = d["location"].ToString(),
                };
            }

            con.Close();
            return department;
        }

        public void Update(Departments dept)
        {
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=True");
            con.Open();
            var cm = new SqlCommand("UPDATE tbl_departments SET name = @name, location = @location WHERE Id = @Id", con);
            cm.Parameters.Add(new SqlParameter("@Id", dept.Id));
            cm.Parameters.Add(new SqlParameter("@name", dept.name));
            cm.Parameters.Add(new SqlParameter("@location", dept.location));
            cm.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteDept(Departments dept)
        {
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY= TRUE");
            con.Open();
            var cm = new SqlCommand("DELETE FROM tbl_departments WHERE Id = @Id", con);
            cm.Parameters.Add(new SqlParameter("@Id", dept.Id));
            cm.ExecuteNonQuery();
            con.Close();
        }
    }
}