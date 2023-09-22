using BasicConnectivity.Views;

namespace BasicConnectivity.Controllers;

public class CountriesController
{
  private Countries _countries;

  private CountriesView _countriesView;

  public CountriesController(Countries countries, CountriesView countriesView)
  {
    _countries = countries;
    _countriesView = countriesView;
  }

  public void GetAll()
  {
    var results = _countries.GetAll();
    if (!results.Any())
    {
      Console.WriteLine("No data found");
    }
    else
    {
      _countriesView.List(results, "countries");
    }
  }

  public void GetById()
  {
    var region = _countriesView.GetCountriesById();

    var results = _countries.GetById(region);
    if (region == null)
    {
      Console.WriteLine("No data found");
    }
    else
    {
      _countriesView.Single(results, "regions");
    }
  }

  public void Insert()
  {
    Countries inputCountry = null;
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        inputCountry = _countriesView.InsertInput();
        if (string.IsNullOrEmpty(inputCountry.Name))
        {
          Console.WriteLine("Region name cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    var result = _countries.Insert(inputCountry);

    _countriesView.Transaction(result);
  }

}