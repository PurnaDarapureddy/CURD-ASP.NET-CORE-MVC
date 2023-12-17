using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace WebApplication13.Models
{
    public class repo
    {
        public void insert(EmpModel e)
        {
            var db = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string s = db["getconn:DefaultConnection"];
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("proc_insertemp",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", e.empid);
            cmd.Parameters.AddWithValue("@b", e.Name);
            cmd.Parameters.AddWithValue("@c", e.City);
            cmd.Parameters.AddWithValue("@d", e.Address);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<EmpModel> Display()
        {
            var db = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string s = db["getconn:DefaultConnection"];
            SqlConnection con = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("proc_displayemp", con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            List<EmpModel> em = new List<EmpModel>();
            foreach(DataRow dr in ds.Rows)
            {
                EmpModel e1 = new EmpModel();
                e1.empid = Convert.ToInt32(dr["empid"]);
                e1.Name = dr["empname"].ToString();
                e1.City = dr["city"].ToString();
                e1.Address = dr["address"].ToString();
                em.Add(e1);
            }
            return em;
        }
        public void update(EmpModel e)
        {
            var db = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            SqlConnection con = new SqlConnection(db["getconn:DefaultConnection"]);
            SqlCommand cmd = new SqlCommand("proc_updateemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", e.empid);
            cmd.Parameters.AddWithValue("@b", e.Name);
            cmd.Parameters.AddWithValue("@c", e.City);
            cmd.Parameters.AddWithValue("@d", e.Address);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(int id)
        {
            var db = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            SqlConnection con = new SqlConnection(db["getconn:DefaultConnection"]);
            SqlCommand cmd = new SqlCommand("proc_deleteemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
    }
}
