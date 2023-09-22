using System.Data.SqlClient;
using Dapper;

namespace BasicConnectivity;

public class Departements
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int LocationId { get; set; }
  public int ManagerId { get; set; }

  private readonly string connectionString = "Server=ARKUN;Database=db_hr_dts;Trusted_Connection=True; Timeout=30;";

  public override string ToString()
  {
    return $"{Id} - {Name} - {LocationId} - {ManagerId}";
  }

  // GET ALL: Region
  public List<Departements> GetAll()
  {
    var departements = new List<Departements>();

    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "SELECT * FROM departements";

    try
    {
      connection.Open();

      using var reader = command.ExecuteReader();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          departements.Add(new Departements
          {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            LocationId = reader.GetInt32(2),
            ManagerId = reader.GetInt32(3),
          });
        }
        reader.Close();
        connection.Close();

        return departements;
      }
      reader.Close();
      connection.Close();

      return new List<Departements>();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    return new List<Departements>();
  }

  public Departements GetById(int id)
  {
    using var connection = new SqlConnection(connectionString);

    var sql = "SELECT * FROM departements WHERE id = @id";

    return connection.QueryFirstOrDefault<Departements>(sql, new { id });
  }

  public string Insert(int id, string name, int location_id, int manager_id)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "INSERT INTO departements VALUES (@id, @name, @location_id, @manager_id);";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", id));
      command.Parameters.Add(new SqlParameter("@name", name));
      command.Parameters.Add(new SqlParameter("@location_id", location_id));
      command.Parameters.Add(new SqlParameter("@manager_id", manager_id));

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

  public string Update(int id, string name, int location_id, int manager_id)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "UPDATE departements SET id = @id, name = @name, location_id = @location_id, manager_id = @manager_id WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", id));
      command.Parameters.Add(new SqlParameter("@name", name));
      command.Parameters.Add(new SqlParameter("@location_id", location_id));
      command.Parameters.Add(new SqlParameter("@manager_id", manager_id));

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
    command.CommandText = "DELETE FROM departements WHERE id = @id";

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