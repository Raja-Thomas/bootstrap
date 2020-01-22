using bootstrap.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace bootstrap.Models
{
    public class sqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public sqlEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        [Obsolete]
        public RegisterViewModel Add(RegisterViewModel employee)
        {

            //create parameters to pass to the stored procedure  
            //First input Parameter
            //var param1 = new SqlParameter
            //{
            //    ParameterName = "@FirstName",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    Value = employee.firstName
            //};

            ////Second input parameter
            //var param2 = new SqlParameter
            //{
            //    ParameterName = "@lastName",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    Value = employee.lastName
            //};

            ////third out parameter
            //var param3 = new SqlParameter
            //{
            //    ParameterName = "@Nickname",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    Value = employee.nickName
            //};
            //var param4 = new SqlParameter
            //{
            //    ParameterName = "@mobile",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    Value = employee.mobile
            //};
            //var param5 = new SqlParameter
            //{
            //    ParameterName = "@email",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    Value = employee.Email
            //};
            //var param6 = new SqlParameter
            //{
            //    ParameterName = "@address",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    Value = employee.Address
            //};
            //var param7 = new SqlParameter
            //{
            //    ParameterName = "@city",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    Value = employee.city
            //};
            //var param8 = new SqlParameter
            //{
            //    ParameterName = "@country",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    Value = employee.country
            //};
            //var param9 = new SqlParameter
            //{
            //    ParameterName = "@DOB",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    Value = employee.DOB
            //};
            //var param10 = new SqlParameter
            //{
            //    ParameterName = "@password",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    Value = employee.Password
            //};
            //var param11 = new SqlParameter
            //{
            //    ParameterName = "@status",
            //    SqlDbType = SqlDbType.Int,
            //    Direction = ParameterDirection.Input,
            //    Value = employee.status
            //};

            ////compose the SQL
            //var SQLString = "EXEC [dbo].[spcreateEmployee]  @FirstName,@lastName,@Nickname,@mobile," +
            //                                                            "@email, @address,@city,@country,@DOB,@password,@status";

            //Execute the stored procedure 
            //var employees = context.Database.ExecuteSqlCommand(SQLString, param1, param2, param3,param4, param5, param6, param7, param8, param9, param10, param11);
            ////var resultParameter = new SqlParameter("@Result", SqlDbType.Int);
            ////var objectContext = ((IObjectContextAdapter)context.Database).ObjectContext;
            //var cc = new object[] {

            //                 new SqlParameter("@FirstName", employee.firstName),
            //        new SqlParameter("@lastName", employee.lastName),
            //        new SqlParameter("@Nickname", employee.nickName),
            //        new SqlParameter("@mobile", employee.mobile),
            //        new SqlParameter("@email", employee.Email),
            //        new SqlParameter("@address", employee.Email),
            //        new SqlParameter("@city", employee.Email),
            //        new SqlParameter("@country", employee.Email),
            //        new SqlParameter("@DOB", employee.Email),
            //        new SqlParameter("@password", employee.Email),
            //        new SqlParameter("@status", employee.Email) };
            ////Int32 recordID = objectContext.ExecuteStoreQuery<Int32>("EXECUTE dbo.spcreateEmployee, @FirstName, @LastName", parameter).FirstOrDefault();


            //var recordsAffected = context.Database.ExecuteSqlCommand("EXECUTE dbo.spcreateEmployee @FirstName,@lastName,@Nickname,@mobile," +
            //                                                            "@email, @address,@city,@country,@DOB,@password,@status", cc);

            //// context.Employees.Add(employee);
            ////context.SaveChanges();
            ///
            var blogs = context.Employees
       .FromSqlInterpolated($"EXECUTE dbo.[spcreateEmployee]{ employee.firstName},{employee.lastName},{employee.nickName},{employee.mobile},{employee.Email},{employee.Address},{employee.city},{employee.country},{employee.DOB},{employee.Password},{employee.status}").ToList();


            return employee;
        }

        public RegisterViewModel Delete(int Id)
        {
            RegisterViewModel employee = context.Employees.SingleOrDefault(x => x.Id == Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<RegisterViewModel> GetAllEmployees()
        {

            var blogs = context.Employees
       .FromSqlRaw("EXECUTE dbo.GetEmployees").ToList();
            return blogs;
        }

        public RegisterViewModel GetEmployeeAsync(int Id)
        {
            var blogs = context.Employees
     .FromSqlRaw("EXECUTE dbo.GetStudents {0}", Id).ToList();
            return blogs[0];
        }

        public RegisterViewModel Update(RegisterViewModel employeeChanges)
        {
            var employee = context.Employees.SingleOrDefault(x => x.Id == employeeChanges.Id);
            context.SaveChanges();
            return employeeChanges;
        }
        public IEnumerable<CountryMaster> GetCountryMaster()
        {
            return context.countryMasters;
        }

    }
}
