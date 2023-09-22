using System.Data.SqlClient;
using Dapper;

namespace BasicConnectivity;

public class Employees
{
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
  public string PhoneNumber { get; set; }
  public DateTime HireDate { get; set; }
  public int Salary { get; set; }
  public decimal ComissionPct { get; set; }
  public int ManagerId { get; set; }
  public string JobId { get; set; }
  public int DepartmentId { get; set; }

  private readonly string connectionString = "Server=ARKUN;Database=db_hr_dts;Trusted_Connection=True; Timeout=30;";

  public override string ToString()
  {
    return $"{Id} - {FirstName} - {LastName} - {Email} - {PhoneNumber} - {HireDate} - {Salary} - {ComissionPct} - {ManagerId} - {JobId} - {DepartmentId}";
  }

  // GET ALL: Region
  public List<Employees> GetAll()
  {
    var employees = new List<Employees>();

    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "SELECT * FROM employees";

    try
    {
      connection.Open();

      using var reader = command.ExecuteReader();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          employees.Add(new Employees
          {
            Id = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            LastName = reader.GetString(2),
            Email = reader.GetString(3),
            PhoneNumber = reader.GetString(4),
            HireDate = reader.GetDateTime(5),
            Salary = reader.GetInt32(6),
            ComissionPct = reader.GetDecimal(7),
            ManagerId = reader.GetInt32(8),
            JobId = reader.GetString(9),
            DepartmentId = reader.GetInt32(10),

          });
        }
        reader.Close();
        connection.Close();

        return employees;
      }
      reader.Close();
      connection.Close();

      return new List<Employees>();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    return new List<Employees>();
  }

  public Employees GetById(int id)
  {
    using var connection = new SqlConnection(connectionString);

    var sql = "SELECT * FROM employees WHERE id = @id";

    return connection.QueryFirstOrDefault<Employees>(sql, new { id });
  }

  public string Insert(Employees employees)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "INSERT INTO employees VALUES (@id, @first_name, @last_name, @email, @hire_date, @salary, @manager_id, @job_id, @department_id)";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", employees.Id));
      command.Parameters.Add(new SqlParameter("@first_name", employees.FirstName));
      command.Parameters.Add(new SqlParameter("@last_name", employees.LastName));
      command.Parameters.Add(new SqlParameter("@email", employees.Email));
      command.Parameters.Add(new SqlParameter("@phone_number", employees.PhoneNumber));
      command.Parameters.Add(new SqlParameter("@hire_date", employees.HireDate));
      command.Parameters.Add(new SqlParameter("@salary", employees.Salary));
      command.Parameters.Add(new SqlParameter("@commission_pct", employees.ComissionPct));
      command.Parameters.Add(new SqlParameter("@manager_id", employees.ManagerId));
      command.Parameters.Add(new SqlParameter("@job_id", employees.JobId));
      command.Parameters.Add(new SqlParameter("@department_id", employees.DepartmentId));

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

  public string Update(int id, string first_name, string last_name, string email, string hire_date, string salary, int manager_id, int job_id, int department_id)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "UPDATE employees SET id = @id, first_name = @first_name, last_name = @last_name, email = @email, salary = @salary";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", id));
      command.Parameters.Add(new SqlParameter("@first_name", first_name));
      command.Parameters.Add(new SqlParameter("@last_name", last_name));
      command.Parameters.Add(new SqlParameter("@email", email));
      command.Parameters.Add(new SqlParameter("@hire_date", hire_date));
      command.Parameters.Add(new SqlParameter("@salary", salary));
      command.Parameters.Add(new SqlParameter("@manager_id", manager_id));
      command.Parameters.Add(new SqlParameter("@job_id", job_id));
      command.Parameters.Add(new SqlParameter("@department_id", department_id));

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

  public string Delete(int id)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "DELETE FROM employees WHERE id = @id";

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