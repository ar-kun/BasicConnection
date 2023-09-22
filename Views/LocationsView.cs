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

  public Locations InsertInput()
  {
    Console.WriteLine("Insert location id");
    var id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert location street address");
    var street_address = Console.ReadLine();
    Console.WriteLine("Insert location postal code");
    var postal_code = Console.ReadLine();
    Console.WriteLine("Insert location city");
    var city = Console.ReadLine();
    Console.WriteLine("Insert location state province");
    var state_province = Console.ReadLine();
    Console.WriteLine("Insert location country id");
    var country_id = Console.ReadLine();

    return new Locations
    {
      Id = id,
      StreetAddress = street_address,
      PostalCode = postal_code,
      City = city,
      StateProvince = state_province,
      CountryId = country_id
    };
  }

}
