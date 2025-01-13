using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MachineTask2.Controllers
{
    public class SocietyModel
    {
        public int Society_id { get; set; }
        public string Society_name { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Owner { get; set; }
        public string Type { get; set; }

        public int ContactNo { get; set; }
        public string Eyear { get; set; }

    }

    public class WebApiController : ApiController
    {
        private string str = @"data source=LAPTOP-RVQF2M3N\SQLEXPRESS;initial catalog=NtierPractice;integrated security=true";

        //http://localhost:60258/api/WebApi/GetAllSociety
        [HttpGet]
       public DataTable GetAllSociety()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("SPGetAllSociety", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;


            

        }

        //http://localhost:60258/api/WebApi/GetBySocietyId?id=1000
        [HttpGet]
        public DataTable GetBySocietyId(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("SPGetBySocietyId", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Society_id",id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        //http://localhost:60258/api/WebApi/SaveSociety
        [HttpPost]

        public int SaveSociety(SocietyModel model)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("SPSaveSociety", con);
            cmd.CommandType = CommandType.StoredProcedure;

           

            cmd.Parameters.AddWithValue("@Society_name",model.Society_name);

            cmd.Parameters.AddWithValue("@Location", model.Society_name);

            cmd.Parameters.AddWithValue("@City", model.City);

            cmd.Parameters.AddWithValue("@Owner", model.Owner);

            cmd.Parameters.AddWithValue("@Type", model.Type);

            cmd.Parameters.AddWithValue("@ContactNo", model.ContactNo);

            cmd.Parameters.AddWithValue("@Eyear", model.Eyear);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            return res;
        }

        [HttpPut]
        //http://localhost:60258/api/WebApi/UpdateSociety?id=1002
        public int UpdateSociety(int id,SocietyModel model)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("SPUpdateSociety", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Society_id",id);
            cmd.Parameters.AddWithValue("@Society_name", model.Society_name);

            cmd.Parameters.AddWithValue("@Location", model.Society_name);

            cmd.Parameters.AddWithValue("@City", model.City);

            cmd.Parameters.AddWithValue("@Owner", model.Owner);

            cmd.Parameters.AddWithValue("@Type", model.Type);

            cmd.Parameters.AddWithValue("@ContactNo", model.ContactNo);

            cmd.Parameters.AddWithValue("@Eyear", model.Eyear);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            return res;
        }

        //http://localhost:60258/api/WebApi/DeleteSociety?id=1002
        [HttpDelete]
        public int DeleteSociety(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("SpDeleteSociety", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Society_id", id);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            return res;
        }

    }
}
