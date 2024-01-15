using FINAP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FINAP.Domain.Interfaces.ICustomerRepository;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using FINAP.Domain.Models.Customer;
using FINAP.Domain.Models.Response;
using System.Transactions;

namespace FINAP.Insfrastructure.Repositories.CustomerRepo
{
    public class CustomerRepo : ICustomerRepository
    {
        private readonly IConfiguration _config;

        public CustomerRepo(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("DBConnection")))
            {
                var response =  await conn.QueryAsync<Customer>("dbo.spGetCustomerList", commandType: CommandType.StoredProcedure);
                return response;
            }
        }

        public async Task<Response> addEditCustomer(Customer customer)
        {
            Response response = new();
            using (TransactionScope scope = new(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("DBConnection"))) 
                    {
                        DynamicParameters para = new DynamicParameters();

                        para.Add("numCus_Id", customer.numCus_Id, DbType.Int32, ParameterDirection.Input);
                        para.Add("varName", customer.varName, DbType.String, ParameterDirection.Input);
                        para.Add("numPhone", customer.numPhone, DbType.Int32, ParameterDirection.Input);
                        para.Add("varAddress", customer.varAddress, DbType.String, ParameterDirection.Input);
                        para.Add("varEmail", customer.varEmail, DbType.String, ParameterDirection.Input);
                        para.Add("bitActive", customer.bitActive, DbType.Boolean, ParameterDirection.Input);
                        para.Add("numUserID", customer.numCreatedBy, DbType.Int32, ParameterDirection.Input);
                        para.Add("@outID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        para.Add("@outMsg", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);


                        await conn.ExecuteAsync("spAddEditCustomer", para, commandType: CommandType.StoredProcedure);

                        int numCusID = para.Get<int>("@outID");
                        var outMsg = para.Get<string>("@outMsg");

                        if (numCusID > 0)
                        {
                            scope.Complete();

                            response.bitSuccess = true;
                            response.numResponseID = numCusID;
                            response.varResponseMessage = outMsg;
                        }
                        else
                        {
                            scope.Dispose();

                            response.bitSuccess = false;
                            response.numResponseID = 0;
                            response.varResponseMessage = "Operation Failed !.";
                        }
                    }
                }
                catch (TransactionException ex)
                {
                    scope.Dispose();

                    response.bitSuccess = false;
                    response.numResponseID = 0;
                    response.varResponseMessage = ex.Message;

                }
            }
            return response;
        }



    }
}
