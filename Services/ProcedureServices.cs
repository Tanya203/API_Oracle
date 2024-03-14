using API.ViewModels;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Services
{
    public class ProcedureServices
    {
        public ProcedureServices() { }
        public async Task AutoSchedule(string month)
        {
            using (OracleConnection connection = new OracleConnection("Data Source = localhost:1521 / orcl; User Id = CUOIKY; Password = 12345; Validate Connection = true; "))
            {
                await connection.OpenAsync();

                using (OracleCommand command = connection.CreateCommand())
                {
                    command.CommandText = "ADD_TIME_TABLE_MONTH";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_parameter", OracleDbType.Varchar2).Value = month;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<List<object>> MonthlySalaryStatistics(string month)
        {
            List<object> salaryResults = new List<object>();

            using (OracleConnection connection = new OracleConnection("Data Source=localhost:1521/orcl;User Id=CUOIKY;Password=12345;"))
            {
                await connection.OpenAsync();

                // Create command to call the procedure
                using (OracleCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CACULATE_MONTH_SALARY";
                    command.CommandType = CommandType.StoredProcedure;

                    // Add output parameter for the refcursor
                    OracleParameter outParameter = new OracleParameter();
                    outParameter.ParameterName = "rec";
                    outParameter.Direction = ParameterDirection.Output;
                    outParameter.OracleDbType = OracleDbType.RefCursor;
                    command.Parameters.Add(outParameter);

                    // Add input parameter for the month
                    OracleParameter inParameter = new OracleParameter();
                    inParameter.ParameterName = "in_Month";
                    inParameter.Value = month;
                    command.Parameters.Add(inParameter);

                    // Execute the procedure asynchronously
                    await command.ExecuteNonQueryAsync();

                    // Retrieve the refcursor result
                    OracleRefCursor refCursor = (OracleRefCursor)outParameter.Value;

                    using (OracleDataReader reader = await Task.Run(() => refCursor.GetDataReader()))
                    {
                        // Read the result and populate the list
                        while (await reader.ReadAsync())
                        {
                            MonthlySalaryStatisticsViewModels salary = new MonthlySalaryStatisticsViewModels();
                            salary.StaffId = reader.GetString(0);
                            salary.TotalHour = reader.GetDecimal(1);
                            salary.Salary = reader.GetDecimal(2);
                            salaryResults.Add(salary);
                        }
                        reader.Close();
                    }
                        
                }
                connection.Close();
            }
            return salaryResults;
        }        
    }
}
