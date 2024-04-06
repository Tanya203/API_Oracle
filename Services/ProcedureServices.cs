using API.ViewModels;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace API.Services
{
    public class ProcedureServices
    {
        public ProcedureServices() { }
        public async Task<string> AutoSchedule(string month)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection("Data Source = localhost:1521 / orcl; User Id = CUOIKY; Password = 12345; Validate Connection = true; "))
                {
                    await connection.OpenAsync();

                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "AUTO_METHOD.AUTO_SCHEDULE";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_parameter", OracleDbType.Varchar2).Value = month;

                        await command.ExecuteNonQueryAsync();
                        return "Success";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> AutoScheduleDate(DateTime date)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection("Data Source = localhost:1521 / orcl; User Id = CUOIKY; Password = 12345; Validate Connection = true; "))
                {
                    await connection.OpenAsync();

                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "AUTO_METHOD.AUTO_SCHEDULE_DATE";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_parameter", OracleDbType.Date).Value = date;

                        await command.ExecuteNonQueryAsync();
                        return "Success";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> AddValue()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection("Data Source = localhost:1521 / orcl; User Id = CUOIKY; Password = 12345; Validate Connection = true; "))
                {
                    await connection.OpenAsync();

                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "AUTO_METHOD.ADD_VALUE";
                        command.CommandType = CommandType.StoredProcedure;

                        await command.ExecuteNonQueryAsync();
                        return "Success";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> TimeKeeping(string staffID)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection("Data Source = localhost:1521 / orcl; User Id = CUOIKY; Password = 12345; Validate Connection = true; "))
                {
                    await connection.OpenAsync();

                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "WORK_SCHEDULE_METHOD.TIME_KEEPING_CHECK";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_parameter", OracleDbType.Varchar2).Value = staffID;

                        await command.ExecuteNonQueryAsync();
                        return "Success";
                    }
                }
            }
            catch(Exception ex) 
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            
        }
        public async Task<string> DeleteWorkSchedule(string wsID)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection("Data Source = localhost:1521 / orcl; User Id = CUOIKY; Password = 12345; Validate Connection = true; "))
                {
                    await connection.OpenAsync();

                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "CHECK_ON_DELETE.CHECK_ON_DELETE_WORK_SCHEDULE";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_parameter", OracleDbType.Varchar2).Value = wsID;

                        await command.ExecuteNonQueryAsync();
                        return "Success";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> DeleteWorkScheduleDetail(string wsID, string staffID)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection("Data Source = localhost:1521 / orcl; User Id = CUOIKY; Password = 12345; Validate Connection = true; "))
                {
                    await connection.OpenAsync();

                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "CHECK_ON_DELETE.CHECK_ON_DELETE_WORK_SCHEDULE_DETAIL";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_parameter", OracleDbType.Varchar2).Value = wsID;
                        command.Parameters.Add("p_parameter", OracleDbType.Varchar2).Value = staffID;

                        await command.ExecuteNonQueryAsync();
                        return "Success";
                    }
                }
            }
            catch(Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> DeleteTimeKeeping(string wsID, string staffID, string shiftID)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection("Data Source = localhost:1521 / orcl; User Id = CUOIKY; Password = 12345; Validate Connection = true; "))
                {
                    await connection.OpenAsync();

                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "CHECK_ON_DELETE.CHECK_ON_DELETE_TIME_KEEPING";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_parameter", OracleDbType.Varchar2).Value = wsID;
                        command.Parameters.Add("p_parameter", OracleDbType.Varchar2).Value = staffID;
                        command.Parameters.Add("p_parameter", OracleDbType.Varchar2).Value = shiftID;

                        await command.ExecuteNonQueryAsync();
                        return "Success";
                    }
                }
            }
            catch(Exception ex) 
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<List<object>> MonthlySalaryStatistics(string month)
        {
            List<object> salaryResults = new List<object>();

            using (OracleConnection connection = new OracleConnection("Data Source=localhost:1521/orcl;User Id=CUOIKY;Password=12345;"))
            {
                await connection.OpenAsync();

                using (OracleCommand command = connection.CreateCommand())
                {
                    command.CommandText = "WORK_SCHEDULE_METHOD.CACULATE_MONTH_SALARY";
                    command.CommandType = CommandType.StoredProcedure;

                    OracleParameter outParameter = new OracleParameter();
                    outParameter.ParameterName = "rec";
                    outParameter.Direction = ParameterDirection.Output;
                    outParameter.OracleDbType = OracleDbType.RefCursor;
                    command.Parameters.Add(outParameter);

                    OracleParameter inParameter = new OracleParameter();
                    inParameter.ParameterName = "in_Month";
                    inParameter.Value = month;
                    command.Parameters.Add(inParameter);

                    await command.ExecuteNonQueryAsync();

                    OracleRefCursor refCursor = (OracleRefCursor)outParameter.Value;

                    using (OracleDataReader reader = await Task.Run(() => refCursor.GetDataReader()))
                    {
                        while (await reader.ReadAsync())
                        {
                            MonthlySalaryStatisticsViewModels salary = new MonthlySalaryStatisticsViewModels();
                            salary.StaffId = reader.GetString(0);
                            salary.TotalHour = reader.GetDecimal(1);
                            salary.TotalBenefit = reader.GetDecimal(2);
                            salary.Salary = reader.GetDecimal(3);
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
