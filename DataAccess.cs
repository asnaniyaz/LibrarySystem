using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class DataAccess
    {
        private readonly string connectionString;

        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void BindCat(DataTable dt)
        {
            SqlConnection Con = new SqlConnection(connectionString);
            Con.Open();
            SqlCommand Cmd = new SqlCommand("BindCategory", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = Cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            Con.Close();
        }

        public void BindSubCat(DataTable dt, object CatID)
        {
            SqlConnection Con = new SqlConnection(connectionString);
            Con.Open();
            SqlCommand Cmd = new SqlCommand("BindSubCategory", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@CatID", CatID);
            SqlDataReader sdr = Cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            Con.Close();
        }


        public void GetData(DataTable dt, object CatID, object SubCatID)
        {
            SqlConnection Con = new SqlConnection(connectionString);
            Con.Open();
            SqlCommand Cmd = new SqlCommand("GetData", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@CatID", CatID);
            Cmd.Parameters.AddWithValue("@SubCatID", SubCatID);
            SqlDataReader sdr = Cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            Con.Close();
        }
    }
}