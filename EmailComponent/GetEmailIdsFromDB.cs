

using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace EmailComponent
{
    public class GetEmailIdsFromDB
    {
        public string connectionString
        {
            get;
            set;
        }
        public string storedProcName
        {
            get;
            set;
        }
        public DataSet GetCustomerLateContract()
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcName, conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds);
            }
           
                return ds;
        }

       
    }
}