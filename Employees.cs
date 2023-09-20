using System.Data.SqlClient;
using Dapper;

namespace BasicConnectivity;

public class Employees
{
  public int Id { get; set; }
  public string first_name { get; set; }
  public string last_name { get; set; }
  public string email { get; set; }
  public string hire_date { get; set; }
  public string salary { get; set; }
  public int manager_id { get; set; }
  public int job_id { get; set; }
  public int department_id { get; set; }

  private readonly string connectionString = "Server=ARKUN;Database=db_hr_dts;Trusted_Connection=True; Timeout=30;";

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
            first_name = reader.GetString(1),
            last_name = reader.GetString(2),
            email = reader.GetString(3),
            hire_date = reader.GetString(3),
            salary = reader.GetString(3),
            manager_id = reader.GetInt32(3),
            job_id = reader.GetInt32(3),
            department_id = reader.GetInt32(3),

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

  public string Insert(int id, string first_name, string last_name, string email, string hire_date, string salary, int manager_id, int job_id, int department_id)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "INSERT INTO employees VALUES (@id, @first_name, @last_name, @email, @hire_date, @salary, @manager_id, @job_id, @department_id)";

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