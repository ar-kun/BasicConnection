namespace BasicConnectivity.Views;

public class DepartementsView : GeneralView
{
  public Departements InsertInput()
  {
    Console.WriteLine("Insert department id");
    var id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert department name");
    var name = Console.ReadLine();
    Console.WriteLine("Insert department manager id");
    var manager_id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert department location id");
    var location_id = Convert.ToInt32(Console.ReadLine());

    return new Departements
    {
      Id = id,
      Name = name,
      ManagerId = manager_id,
      LocationId = location_id
    };
  }

}
