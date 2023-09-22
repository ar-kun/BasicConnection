namespace BasicConnectivity.Views;

public class LocationsView : GeneralView
{

  public Locations GetCountriesById()
  {
    Console.WriteLine("Insert Countries id");
    var id = Convert.ToInt32(Console.ReadLine());

    return new Locations
    {
      Id = id,
    };
  }

}
