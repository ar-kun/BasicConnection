using System.Data.SqlClient;
using Dapper;

namespace BasicConnectivity;

public class Countries
{
  public string Id { get; set; }
  public string Name { get; set; }

  public int Region_id { get; set; }

  private readonly string connectionString = "Server=ARKUN;Database=db_hr_dts;Trusted_Connection=True; Timeout=30;";

  public override string ToString()
  {
    return $"{Id} - {Name} - {Region_id}";
  }
  // GET ALL: Region
  public List<Countries> GetAll()
  {
    var countries = new List<Countries>();

    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "SELECT * FROM countries";

    try
    {
      connection.Open();

      using var reader = command.ExecuteReader();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          countries.Add(new Countries
          {
            Id = reader.GetString(0),
            Name = reader.GetString(1),
            Region_id = reader.GetInt32(2)
          });
        }
        reader.Close();
        connection.Close();

        return countries;
      }
      reader.Close();
      connection.Close();

      return new List<Countries>();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    return new List<Countries>();
  }

  // GET BY ID: Region
  public Countries GetById(Countries countries)
  {
    using var connection = new SqlConnection(connectionString);

    var sql = "SELECT * FROM countries WHERE id = @id";

    return connection.QueryFirstOrDefault<Countries>(sql, new { Id });
  }

  // INSERT: Region
  public string Insert(Countries countries)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "INSERT INTO countries VALUES (@name);";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", countries.Id));
      command.Parameters.Add(new SqlParameter("@name", countries.Name));
      command.Parameters.Add(new SqlParameter("@region_id", countries.Region_id));

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
  public string Update(Countries countries)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "UPDATE countries SET name = @name, region_id = @region_id WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", countries.Id));
      command.Parameters.Add(new SqlParameter("@name", countries.Name));
      command.Parameters.Add(new SqlParameter("@region_id", countries.Region_id));

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
  public string Delete(Countries countries)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "DELETE FROM countries WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", countries.Id));

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
