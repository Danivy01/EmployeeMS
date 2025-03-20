using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace EmployeeMS.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lname { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string phone { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int deptID { get; set; }

        [Display(Name = "Department")]
        public string departmentName { get; set; }

        [Required]
        [Display(Name = "Position")]
        public int posID { get; set; }

        [Display(Name = "Position")]
        public string positionTitle { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString ="{0:N0}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Salary")]
        public decimal salary { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MMM dd, yyyy}")]
        [DataType(DataType.DateTime)]
        [Display(Name ="Hired Date")]
        public DateTime hiredDate { get; set; }

        public List<Employees> GetAllEmp()
        {
            List<Employees> employees = new List<Employees>();

            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=True");
            con.Open();
            var cm = new SqlCommand("SELECT * FROM vw_employee ", con);
            var dt = new DataTable();
            dt.Load(cm.ExecuteReader());
            foreach (DataRow row in dt.Rows)
            {
                Employees emp = new Employees();
                emp.Id = Convert.ToInt32(row["Id"]);
                emp.fname = row["fname"].ToString();
                emp.lname = row["lname"].ToString();
                emp.email = row["email"].ToString();
                emp.phone = row["phone"].ToString();
                emp.deptID = Convert.ToInt32(row["departmentID"]);
                emp.departmentName = row["departmentName"].ToString();
                emp.posID = Convert.ToInt32(row["positionID"]);
                emp.positionTitle = row["positionTitle"].ToString();
                emp.salary = Convert.ToDecimal(row["salary"]);
                emp.hiredDate = Convert.ToDateTime(row["hiredDate"]);

                employees.Add(emp);
            }


            con.Close();
            return employees;
        }

        public void CreateEmployee(Employees emp)
        {
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=True");
            con.Open();
            var cm = new SqlCommand("INSERT INTO tbl_employees (fname, lname, email, phone, departmentID, positionID, salary, hiredDate) VALUES (@fname, @lname, @email, @phone, @departmentID, @positionID, @salary, @hiredDate)", con);
            cm.Parameters.Add(new SqlParameter("@fname", emp.fname));
            cm.Parameters.Add(new SqlParameter("@lname", emp.lname));
            cm.Parameters.Add(new SqlParameter("@email", emp.email));
            cm.Parameters.Add(new SqlParameter("@phone", emp.phone));
            cm.Parameters.Add(new SqlParameter("@departmentID", emp.deptID));
            cm.Parameters.Add(new SqlParameter("@positionID", emp.posID));
            cm.Parameters.Add(new SqlParameter("@salary", emp.salary));
            cm.Parameters.Add(new SqlParameter("@hiredDate", emp.hiredDate));
            cm.ExecuteNonQuery();
            con.Close();
        }

        public Employees Find(int Id)
        {
            var employees = new Employees();
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=True");
            con.Open();
            var cm = new SqlCommand("SELECT * FROM vw_employee WHERE Id = @Id", con);
            cm.Parameters.Add(new SqlParameter("@Id", Id));
            var dt = new DataTable();
            dt.Load(cm.ExecuteReader());
            foreach (DataRow e in dt.Rows)
            {
                employees = new Employees()
                {
                    Id = Convert.ToInt32(e["Id"]),
                    fname = e["fname"].ToString(),
                    lname = e["lname"].ToString(),
                    email = e["email"].ToString(),
                    phone = e["phone"].ToString(),
                    deptID = Convert.ToInt32(e["departmentID"]),
                    departmentName = e["departmentName"].ToString(),
                    posID = Convert.ToInt32(e["positionID"]),
                    positionTitle = e["positionTitle"].ToString(),
                    salary = Convert.ToDecimal(e["salary"]),
                    hiredDate = Convert.ToDateTime(e["hiredDate"])
                };
            }
            con.Close();
            return employees;
        }

        public void UpdateEmployee(Employees emp)
        {
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=True");
            con.Open();
            var cm = new SqlCommand("UPDATE tbl_employees SET fname = @fname, lname = @lname, email = @email, phone = @phone, departmentID = @departmentID, positionID = @positionID, salary = @salary, hiredDate = @hiredDate WHERE Id = @Id", con);
            cm.Parameters.Add(new SqlParameter("@Id", emp.Id));
            cm.Parameters.Add(new SqlParameter("@fname", emp.fname));
            cm.Parameters.Add(new SqlParameter("@lname", emp.lname));
            cm.Parameters.Add(new SqlParameter("@email", emp.email));
            cm.Parameters.Add(new SqlParameter("@phone", emp.phone));
            cm.Parameters.Add(new SqlParameter("@departmentID", emp.deptID));
            cm.Parameters.Add(new SqlParameter("@positionID", emp.posID));
            cm.Parameters.Add(new SqlParameter("@salary", emp.salary));
            cm.Parameters.Add(new SqlParameter("@hiredDate", emp.hiredDate));
            cm.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteEmp(Employees emp)
        {
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=True");
            con.Open();
            var cm = new SqlCommand("DELETE FROM tbl_employees WHERE Id = @Id", con);
            cm.Parameters.Add(new SqlParameter("@Id", emp.Id));
            cm.ExecuteNonQuery();
            con.Close();
        }

        public void Details(Employees emp)
        {
            SqlConnection con = new SqlConnection("SERVER=JOSEITSD\\RAP;DATABASE=dbEMS;INTEGRATED SECURITY=True");
            con.Open();
            var cm = new SqlCommand("SELECT * FROM vw_employee WHERE Id = @Id", con);
            cm.Parameters.Add(new SqlParameter("@Id", emp.Id));
            cm.ExecuteNonQuery();
            con.Close();
        }
    }
}