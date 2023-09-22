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
    var region = _locationsView.GetCountriesById();

    var results = _locations.GetById(region);
    if (region == null)
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

    var result = _locations.Insert(inputLocation);

    _locationsView.Transaction(result);
  }


}