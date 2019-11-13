using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DealEat.DAL
{
    public class ReducGateway
    {
        readonly string _connectionString;

        public ReducGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        
    }
}
