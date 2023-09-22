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
    var countries = _countriesView.GetCountriesById();

    var results = _countries.GetById(countries);
    if (countries == null)
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
          Console.WriteLine("Countries name cannot be empty");
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

  public void Update()
  {
    var countries = new Countries();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        countries = _countriesView.UpdateCountries();
        if (string.IsNullOrEmpty(countries.Name))
        {
          Console.WriteLine("Countries name cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    var result = _countries.Update(countries);
    _countriesView.Transaction(result);
  }

  public void Delete()
  {
    var countries = new Countries();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        countries = _countriesView.Delete();
        if (countries == null)
        {
          Console.WriteLine("Region not found");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    var result = _countries.Delete(countries);
    _countriesView.Transaction(result);
  }

}