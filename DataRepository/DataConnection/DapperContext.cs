using DataRepository.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.DataConnection
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _commonConnectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _commonConnectionString = _configuration.GetConnectionString("CommonDatabase");
        }

     

        public IDbConnection CreateCommonConnection()
           => new SqlConnection(_commonConnectionString);
    }
}
