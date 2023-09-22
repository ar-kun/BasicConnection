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
    Console.WriteLine("Insert Countries id");
    var id = Console.ReadLine();
    Console.WriteLine("Insert Countries name");
    var name = Console.ReadLine();
    Console.WriteLine("Insert Countries id");
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
    Console.WriteLine("Insert Countries id");
    var id = Console.ReadLine();
    Console.WriteLine("Insert Countries name");
    var name = Console.ReadLine();
    Console.WriteLine("Insert Countries id");
    var region_id = Convert.ToInt32(Console.ReadLine());

    return new Countries
    {
      Id = id,
      Name = name,
      Region_id = region_id
    };
  }

  public Countries Delete()
  {
    Console.WriteLine("Insert Countries id");
    var id = Console.ReadLine();

    return new Countries
    {
      Id = id
    };
  }

}
