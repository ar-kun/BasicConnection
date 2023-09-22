namespace BasicConnectivity.Views;

public class CountriesView : GeneralView
{
  public Countries GetCountriesById()
  {
    Console.WriteLine("Insert Countries id");
    var id = Console.ReadLine();

    return new Countries
    {
      Id = id,
    };
  }

  public Countries InsertInput()
  {
    Console.WriteLine("Insert region id");
    var id = Console.ReadLine();
    Console.WriteLine("Insert region name");
    var name = Console.ReadLine();
    Console.WriteLine("Insert region id");
    var region_id = Convert.ToInt32(Console.ReadLine());

    return new Countries
    {
      Id = id,
      Name = name,
      Region_id = region_id
    };
  }

  public Countries UpdateCountries()
  {
    Console.WriteLine("Insert region id");
    var id = Console.ReadLine();
    Console.WriteLine("Insert region name");
    var name = Console.ReadLine();
    Console.WriteLine("Insert region id");
    var region_id = Convert.ToInt32(Console.ReadLine());

    return new Countries
    {
      Id = id,
      Name = name,
      Region_id = region_id
    };
  }

}
