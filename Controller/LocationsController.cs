using BasicConnectivity.Views;

namespace BasicConnectivity.Controllers;

public class LocationsController
{

  private Locations _locations;

  private LocationsView _locationsView;

  public LocationsController(Locations locations, LocationsView locationsView)
  {
    _locations = locations;
    _locationsView = locationsView;
  }

  public void GetAll()
  {
    var results = _locations.GetAll();
    if (!results.Any())
    {
      Console.WriteLine("No data found");
    }
    else
    {
      _locationsView.List(results, "locations");
    }
  }

  public void GetById()
  {
    var locations = _locationsView.GetCountriesById();

    var results = _locations.GetById(locations);
    if (locations == null)
    {
      Console.WriteLine("No data found");
    }
    else
    {
      _locationsView.Single(results, "regions");
    }
  }

  public void Insert()
  {
    Locations inputLocation = null;
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        inputLocation = _locationsView.InsertInput();
        if (string.IsNullOrEmpty(inputLocation.StreetAddress))
        {
          Console.WriteLine("Locations name cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    var result = _locations.Insert(inputLocation);

    _locationsView.Transaction(result);
  }

  public void Update()
  {
    var locations = new Locations();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        locations = _locationsView.UpdateLocations();
        if (string.IsNullOrEmpty(locations.StreetAddress))
        {
          Console.WriteLine("Locations name cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    var result = _locations.Update(locations);
    _locationsView.Transaction(result);
  }

  public void Delete()
  {
    var locations = new Locations();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        locations = _locationsView.Delete();
        if (string.IsNullOrEmpty(locations.StreetAddress))
        {
          Console.WriteLine("Locations name cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    var result = _locations.Delete(locations);
    _locationsView.Transaction(result);
  }


}