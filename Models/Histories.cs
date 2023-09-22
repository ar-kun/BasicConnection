using System.Data.SqlClient;
using Dapper;

namespace BasicConnectivity;

public class Histories
{
  public DateTime StartDate { get; set; }
  public int EmployeeId { get; set; }
  public DateTime EndDate { get; set; }
  public int DepartmentId { get; set; }
  public string JobId { get; set; }

  private readonly string connectionString = "Server=ARKUN;Database=db_hr_dts;Trusted_Connection=True; Timeout=30;";

  public override string ToString()
  {
    return $"{StartDate} - {EmployeeId} - {EndDate} - {DepartmentId} - {JobId}";
  }

  // GET ALL: Region
  public List<Histories> GetAll()
  {
    var histories = new List<Histories>();

    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "SELECT * FROM histories";

    try
    {
      connection.Open();

      using var reader = command.ExecuteReader();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          histories.Add(new Histories
          {
            StartDate = reader.GetDateTime(0),
            EmployeeId = reader.GetInt32(1),
            EndDate = reader.GetDateTime(2),
            DepartmentId = reader.GetInt32(3),
            JobId = reader.GetString(4),
          });
        }
        reader.Close();
        connection.Close();

        return histories;
      }
      reader.Close();
      connection.Close();

      return new List<Histories>();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    return new List<Histories>();
  }

  public Histories GetById(string id)
  {
    using var connection = new SqlConnection(connectionString);

    var sql = "SELECT * FROM histories WHERE id = @id";

    return connection.QueryFirstOrDefault<Histories>(sql, new { id });
  }

  public string Insert(string start_date, string employee_id, string end_date, int department_id, int job_id)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "INSERT INTO histories VALUES (@start_date, @employee_id, @end_date, @department_id, @job_id);";

    try
    {
      command.Parameters.Add(new SqlParameter("@start_date", start_date));
      command.Parameters.Add(new SqlParameter("@employee_id", employee_id));
      command.Parameters.Add(new SqlParameter("@end_date", end_date));
      command.Parameters.Add(new SqlParameter("@department_id", department_id));
      command.Parameters.Add(new SqlParameter("@job_id", job_id));


      connection.Open();
      using var transaction = connection.BeginTransaction();
      try
      {
        command.Transaction = transaction;

        var result = command.ExecuteNonQuery();

        transaction.Commit();
        connection.Close();

        return result.ToString();
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        return $"Error Transaction: {ex.Message}";
      }
    }
    catch (Exception ex)
    {
      return $"Error: {ex.Message}";
    }
  }

  public string Update(string start_date, string employee_id, string end_date, int department_id, int job_id)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "UPDATE histories SET start_date = @start_date, employee_id = @employee_id, end_date = @end_date, department_id = @department_id, job_id = @job_id WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@start_date", start_date));
      command.Parameters.Add(new SqlParameter("@employee_id", employee_id));
      command.Parameters.Add(new SqlParameter("@end_date", end_date));
      command.Parameters.Add(new SqlParameter("@department_id", department_id));
      command.Parameters.Add(new SqlParameter("@job_id", job_id));

      connection.Open();
      using var transaction = connection.BeginTransaction();
      try
      {
        command.Transaction = transaction;

        var result = command.ExecuteNonQuery();

        transaction.Commit();
        connection.Close();

        return result.ToString();
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        return $"Error Transaction: {ex.Message}";
      }
    }
    catch (Exception ex)
    {
      return $"Error: {ex.Message}";
    }

  }

  public string Delete(string id)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "DELETE FROM histories WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", id));

      connection.Open();
      using var transaction = connection.BeginTransaction();
      try
      {
        command.Transaction = transaction;

        var result = command.ExecuteNonQuery();

        transaction.Commit();
        connection.Close();

        return result.ToString();
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        return $"Error Transaction: {ex.Message}";
      }
    }
    catch (Exception ex)
    {
      return $"Error: {ex.Message}";
    }
  }
}