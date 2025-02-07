using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using AdoCrudByme.Models;


namespace AdoCrudByme.Models.Domain
{
    public class OldStudConnectivityModel
    {
       SqlConnection con =new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
        SqlCommand cmd;
       public string query { get; set; }    

        public bool AdOldStudent(AddOldStudModel ns)
        {
            query = "oldInsert";
            cmd=new SqlCommand(query, con); 
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", ns.Name);
            cmd.Parameters.AddWithValue("@FName", ns.FName);
            cmd.Parameters.AddWithValue("@Email", ns.Email);
            cmd.Parameters.AddWithValue("@Mobile", ns.Mobile);
            cmd.Parameters.AddWithValue("@City", ns.City);
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();  

            return true;
        }
        public List<AddOldStudModel> GetAll()
        {
            List<AddOldStudModel>list = new List<AddOldStudModel>();
            query = "oldSelect";
            cmd = new SqlCommand(query, con);   
            cmd.CommandType= CommandType.StoredProcedure;   
            SqlDataAdapter adp=new SqlDataAdapter(cmd);     
            DataTable dt=new DataTable();   
            adp.Fill(dt);   
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new AddOldStudModel
                {
                    Id=Convert.ToInt32(dr["id"]),
                    Name = dr["Name"].ToString(),
                    FName = dr["FName"].ToString(), 
                    Email=dr["Email"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    City = dr["City"].ToString()

                });
            }
            return list;
        }

        public bool deleteOld(int id)
        {
            query = "oldDelete";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int res=(int)cmd.ExecuteNonQuery();   
            if(res>=1)
            {
                return true;    
            }
            else
            {
                return false;
            }
        }
        public bool Editt(AddOldStudModel od)
        {
            query = "oldUpdate";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", od.Name);
            cmd.Parameters.AddWithValue("@FName", od.FName);
            cmd.Parameters.AddWithValue("@Email", od.Email);
            cmd.Parameters.AddWithValue("@Mobile", od.Mobile);
            cmd.Parameters.AddWithValue("@City", od.City);
            cmd.Parameters.AddWithValue("@id", od.Id);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int res = (int)cmd.ExecuteNonQuery();
            if (res >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}