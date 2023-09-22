using System.Data.SqlClient;
using Dapper;

namespace BasicConnectivity;

public class Region
{
  public int Id { get; set; }
  public string Name { get; set; }

  private readonly string connectionString = "Server=ARKUN;Database=db_hr_dts;Trusted_Connection=True; Timeout=30;";

  public override string ToString()
  {
    return $"{Id} - {Name}";
  }

  // GET ALL: Region
  public List<Region> GetAll()
  {
    var regions = new List<Region>();

    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "SELECT * FROM regions";

    try
    {
      connection.Open();

      using var reader = command.ExecuteReader();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          regions.Add(new Region
          {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1)
          });
        }
        reader.Close();
        connection.Close();

        return regions;
      }
      reader.Close();
      connection.Close();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    return new List<Region>();
  }

  // GET BY ID: Region
  public Region GetById(Region region)
  {
    using var connection = new SqlConnection(connectionString);

    var sql = "SELECT * FROM regions WHERE id = @id";

    return connection.QueryFirstOrDefault<Region>(sql, new { region.Id });
  }

  // INSERT: Region
  public string Insert(Region region)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "INSERT INTO regions VALUES (@name);";

    try
    {
      command.Parameters.Add(new SqlParameter("@name", region.Name));

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

  // UPDATE: Region
  public string Update(Region region)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "UPDATE regions SET name = @name WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", region.Id));
      command.Parameters.Add(new SqlParameter("@name", region.Name));

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

  // DELETE: Region
  public string Delete(Region region)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "DELETE FROM regions WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", region.Id));

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
