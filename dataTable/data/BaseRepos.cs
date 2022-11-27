using Dapper;
using dataTable.Dtos;
using dataTable.Models;
using dataTable.Models.Dt;
using Microsoft.Data.SqlClient;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace dataTable.data
{

public  class BaseRepos : IbaseRepo
    {
        private readonly IConfiguration _configration;
        private readonly string constring;

       

        public BaseRepos(IConfiguration configuration)
        {
            _configration = configuration;
            constring = configuration.GetConnectionString("default");
        }




        public IEnumerable<T> ReturnList<T>(string procrdureName, DynamicParameters parameter)
        {
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procrdureName, parameter, commandType: CommandType.StoredProcedure);
            }
           
        }


        public async Task<Result> ReturnMultipule(string procrdureName, DynamicParameters parameter)
        {
            var res = new Result();
            using (SqlConnection sql = new SqlConnection(constring))
            {
               
                sql.Open();
                using (var entity = sql.QueryMultiple(procrdureName, parameter, commandType: CommandType.StoredProcedure))
                {
                    
                        res.Rec = entity.Read<DTEmployee>().AsList<DTEmployee>();
                        if (!entity.IsConsumed)
                            res.TotalRec= entity.Read<int>().FirstOrDefault();


                    return res;
                }





                    }







                }







        public async Task<ResultP> ReturnMultipuleDtp(string procrdureName, DynamicParameters parameter)
        {
            var res = new ResultP();
            using (SqlConnection sql = new SqlConnection(constring))
            {

                sql.Open();
                using (var entity = sql.QueryMultiple(procrdureName, parameter, commandType: CommandType.StoredProcedure))
                {

                    res.Rec = entity.Read<DtProduct>().AsList<DtProduct>();
                    if (!entity.IsConsumed)
                        res.TotalRec = entity.Read<int>().FirstOrDefault();


                    return res;
                }

            }
        }


                public int ReturnInt(string procrdureName, DynamicParameters parameter = null)
        {
             using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                sqlCon.Execute(procrdureName, parameter, commandType: CommandType.StoredProcedure);
                return parameter.Get<int>("EmloyeeId");
                
            }
        }


        public int ReturnIntPro(string procrdureName, DynamicParameters parameter = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                sqlCon.Execute(procrdureName, parameter, commandType: CommandType.StoredProcedure);
                return parameter.Get<int>("Id");

            }
        }






        public T ExecuteReturnScalar<T>(string procrdureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.Execute(procrdureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }

        }








    }













    }

