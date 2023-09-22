using System.Data.SqlClient;
using Dapper;

namespace BasicConnectivity;

public class Locations
{
  public int Id { get; set; }
  public string StreetAddress { get; set; }
  public string PostalCode { get; set; }

  public string City { get; set; }
  public string StateProvince { get; set; }
  public string CountryId { get; set; }

  private readonly string connectionString = "Server=ARKUN;Database=db_hr_dts;Trusted_Connection=True; Timeout=30;";

  public override string ToString()
  {
    return $"{Id} - {StreetAddress} - {PostalCode} - {City} - {StateProvince} - {CountryId}";
  }

  // GET ALL: Region
  public List<Locations> GetAll()
  {
    var locations = new List<Locations>();

    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "SELECT * FROM locations";

    try
    {
      connection.Open();

      using var reader = command.ExecuteReader();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          locations.Add(new Locations
          {
            Id = reader.GetInt32(0),
            StreetAddress = reader.GetString(1),
            PostalCode = reader.GetString(2),
            City = reader.GetString(3),
            StateProvince = reader.GetString(4),
            CountryId = reader.GetString(5)
          });
        }
        reader.Close();
        connection.Close();

        return locations;
      }
      reader.Close();
      connection.Close();

      return new List<Locations>();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    return new List<Locations>();
  }

  // GET BY ID: Region
  public Locations GetById(Locations locations)
  {
    using var connection = new SqlConnection(connectionString);

    var sql = "SELECT * FROM locations WHERE id = @id";

    return connection.QueryFirstOrDefault<Locations>(sql, new { Id });
  }

  // INSERT: Region
  public string Insert(Locations locations)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "INSERT INTO locations VALUES (@id, @street_address, @postal_code, @city, @state_province, @country_id);";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", locations.Id));
      command.Parameters.Add(new SqlParameter("@street_address", locations.StreetAddress));
      command.Parameters.Add(new SqlParameter("@postal_code", locations.PostalCode));
      command.Parameters.Add(new SqlParameter("@city", locations.City));
      command.Parameters.Add(new SqlParameter("@state_province", locations.StateProvince));
      command.Parameters.Add(new SqlParameter("@country_id", locations.CountryId));

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
  public string Update(string id, string street_address, string postal_code, string city, string state_province, string country_id)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "UPDATE locations SET street_address = @street_address, postal_code = @postal_code, city = @city, state_province = @state_province, country_id = @country_id WHERE id = @id";

    try
    {
      command.Parameters.Add(new SqlParameter("@id", id));
      command.Parameters.Add(new SqlParameter("@street_address", street_address));
      command.Parameters.Add(new SqlParameter("@postal_code", postal_code));
      command.Parameters.Add(new SqlParameter("@city", city));
      command.Parameters.Add(new SqlParameter("@state_province", state_province));
      command.Parameters.Add(new SqlParameter("@country_id", country_id));

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
  public string Delete(string id)
  {
    using var connection = new SqlConnection(connectionString);
    using var command = new SqlCommand();

    command.Connection = connection;
    command.CommandText = "DELETE FROM locations WHERE id = @id";

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
