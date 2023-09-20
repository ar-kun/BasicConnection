using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace BasicConnectivity;

public class Program
{
  private static void Main()
  {
    // Jobs
    /*var jobs = new Jobs();

    var getAllRegion = jobs.GetAll();
    if (getAllRegion.Count > 0)
    {
      foreach (var region1 in getAllRegion)
      {
        Console.WriteLine($"Id: {region1.Id}, Name: {region1.Title}, Min Salary: {region1.MinSalary}, Max Salary: {region1.MaxSalary}");
      }
    }
    else
    {
      Console.WriteLine("No data found");
    }

    var gelJobById = jobs.GetById("UI");
    if (gelJobById != null)
    {
      Console.WriteLine($"Id: {gelJobById.Id}, Name: {gelJobById.Title}, Min Salary: {gelJobById.MinSalary}, Max Salary: {gelJobById.MaxSalary}");
    }
    else
    {
      Console.WriteLine("No data found");
    }

    var insertResult = jobs.Insert("ML", "Machine Learning", 220333, 223300);
    int.TryParse(insertResult, out int result);
    if (result > 0)
    {
      Console.WriteLine("Insert Success");
    }
    else
    {
      Console.WriteLine("Insert Failed");
      Console.WriteLine(insertResult);
    }

    var updateResult = jobs.Update("ML", "Machine Learning Specialist", 200000, 223300);
    int.TryParse(updateResult, out int result);
    if (result > 0)
    {
      Console.WriteLine("Update Success");
    }
    else
    {
      Console.WriteLine("Update Failed");
      Console.WriteLine(updateResult);
    }

    var deleteResult = jobs.Delete("ML");
    int.TryParse(deleteResult, out int result);
    if (result > 0)
    {
      Console.WriteLine("Delete Success");
    }
    else
    {
      Console.WriteLine("Delete Failed");
      Console.WriteLine(deleteResult);
    }

    */

    // Regions

    // var region = new Region();

    // var getAllRegion = region.GetAll();

    // if (getAllRegion.Count > 0)
    // {
    //   foreach (var region1 in getAllRegion)
    //   {
    //     Console.WriteLine($"Id: {region1.Id}, Name: {region1.Name}");
    //   }
    // }
    // else
    // {
    //   Console.WriteLine("No data found");
    // }

    // Countries
    var countries = new Countries();

    var getAllCountries = countries.GetAll();

    if (getAllCountries.Count > 0)
    {
      foreach (var country in getAllCountries)
      {
        Console.WriteLine($"Id: {country.Id}, Name: {country.Name}");
      }
    }
    else
    {
      Console.WriteLine("No data found");
    }
  }


}