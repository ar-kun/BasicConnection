using System.Data.SqlClient;
using Dapper;

namespace BasicConnectivity;

public class Jobs
{
  public string Id { get; set; }
  public string Title { get; set; }
  public int MinSalary { get; set; }
  public int MaxSalary { get; set; }

  private readonly string connectionString = "Server=ARKUN;Database=db_hr_dts;Trusted_Connection=True; Timeout=30;";

  public override string ToString()
  {
    return $"{Id} - {Title} - {MinSalary} - {MaxSalary}";
  }

  // GET ALL: Region
  public List<Jobs> GetAll()
  {
    var jobs = new List<Jobs>();

    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "SELECT * FROM jobs";

    try
    {
      connection.Open();

      using var reader = command.ExecuteReader();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          jobs.Add(new Jobs
          {
            Id = reader.GetString(0),
            Title = reader.GetString(1),
            MinSalary = reader.GetInt32(2),
            MaxSalary = reader.GetInt32(3),
          });
        }
        reader.Close();
        connection.Close();

        return jobs;
      }
      reader.Close();
      connection.Close();

      return new List<Jobs>();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    return new List<Jobs>();
  }

  public Jobs GetById(string id)
  {
    using var connection = new SqlConnection(connectionString);

    var sql = "SELECT * FROM jobs WHERE id = @id";

    return connection.QueryFirstOrDefault<Jobs>(sql, new { id });
  }

  public string Insert(string id, string title, int min_salary, int max_salary)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "INSERT INTO jobs VALUES (@id, @title, @min_salary, @max_salary);";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", id));
      command.Parameters.Add(new SqlParameter("@title", title));
      command.Parameters.Add(new SqlParameter("@min_salary", min_salary));
      command.Parameters.Add(new SqlParameter("@max_salary", max_salary));

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

  public string Update(string id, string title, int min_salary, int max_salary)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "UPDATE jobs SET id = @id, title = @title, min_salary = @min_salary, max_salary = @max_salary WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", id));
      command.Parameters.Add(new SqlParameter("@title", title));
      command.Parameters.Add(new SqlParameter("@min_salary", min_salary));
      command.Parameters.Add(new SqlParameter("@max_salary", max_salary));

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
    command.CommandText = "DELETE FROM jobs WHERE id = @id";

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