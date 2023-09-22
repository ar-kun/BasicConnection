using BasicConnectivity.Controllers;
using BasicConnectivity.Views;

namespace BasicConnectivity;

public class Program
{
  private static void Main()
  {
    var choice = true;
    while (choice)
    {
      Console.WriteLine("1. Region CRUD");
      Console.WriteLine("2. Countries CRUD");
      Console.WriteLine("3. Locations CRUD");
      Console.WriteLine("4. Jobs CRUD");
      Console.WriteLine("5. Departements CRUD");
      Console.WriteLine("6. Employees CRUD");
      Console.WriteLine("7. Histories CRUD");
      Console.WriteLine("10. Exit");
      Console.Write("Enter your choice: ");
      var input = Console.ReadLine();
      choice = Menu(input);
    }
  }

  public static bool Menu(string input)
  {
    switch (input)
    {
      case "1":
        RegionMenu();
        break;
      case "2":
        CountriesMenu();
        break;
      case "3":
        LocationsMenu();
        break;
      case "4":
        JobsMenu();
        break;
      case "5":
        DepartementsMenu();
        break;
      case "6":
        EmployeesMenu();
        break;
      case "7":
        HistoriesMenu();
        break;
      case "10":
        return false;
      default:
        Console.WriteLine("Invalid choice");
        break;
    }

    return true;
  }

  public static void RegionMenu()
  {
    var region = new Region();
    var regionView = new RegionView();

    var regionController = new RegionController(region, regionView);

    var isLoop = true;
    while (isLoop)
    {
      Console.WriteLine("1. List all regions");
      Console.WriteLine("2. Get region by id");
      Console.WriteLine("3. Insert new region");
      Console.WriteLine("4. Update region");
      Console.WriteLine("5. Delete region");
      Console.WriteLine("10. Back");
      Console.Write("Enter your choice: ");
      var input2 = Console.ReadLine();
      switch (input2)
      {
        case "1":
          regionController.GetAll();
          break;
        case "2":
          regionController.GetById();
          break;
        case "3":
          regionController.Insert();
          break;
        case "4":
          regionController.Update();
          break;
        case "5":
          regionController.Delete();
          break;
        case "10":
          isLoop = false;
          break;
        default:
          Console.WriteLine("Invalid choice");
          break;
      }
    }
  }

  public static void CountriesMenu()
  {
    var country = new Countries();
    var countryView = new CountriesView();

    var countryController = new CountriesController(country, countryView);

    var isLoop = true;
    while (isLoop)
    {
      Console.WriteLine("1. List all countries");
      Console.WriteLine("2. Get country by id");
      Console.WriteLine("3. Insert new country");
      Console.WriteLine("4. Update country");
      Console.WriteLine("5. Delete country");
      Console.WriteLine("10. Back");
      Console.Write("Enter your choice: ");
      var input2 = Console.ReadLine();
      switch (input2)
      {
        case "1":
          countryController.GetAll();
          break;
        case "2":
          countryController.GetById();
          break;
        case "3":
          countryController.Insert();
          break;
        case "4":
          countryController.Update();
          break;
        case "5":
          countryController.Delete();
          break;
        case "10":
          isLoop = false;
          break;
        default:
          Console.WriteLine("Invalid choice");
          break;
      }
    }
  }

  public static void LocationsMenu()
  {
    var location = new Locations();
    var locationView = new LocationsView();

    var locationController = new LocationsController(location, locationView);

    var isLoop = true;
    while (isLoop)
    {
      Console.WriteLine("1. List all locations");
      Console.WriteLine("2. Get location by id");
      Console.WriteLine("3. Insert new location");
      Console.WriteLine("4. Update location");
      Console.WriteLine("5. Delete location");
      Console.WriteLine("10. Back");
      Console.Write("Enter your choice: ");
      var input2 = Console.ReadLine();
      switch (input2)
      {
        case "1":
          locationController.GetAll();
          break;
        case "2":
          locationController.GetById();
          break;
        case "3":
          locationController.Insert();
          break;
        case "4":
          locationController.Update();
          break;
        case "5":
          locationController.Delete();
          break;
        case "10":
          isLoop = false;
          break;
        default:
          Console.WriteLine("Invalid choice");
          break;
      }
    }
  }

  public static void JobsMenu()
  {
    var job = new Jobs();
    var jobView = new JobsView();

    var jobController = new JobsController(job, jobView);

    var isLoop = true;
    while (isLoop)
    {
      Console.WriteLine("1. List all jobs");
      Console.WriteLine("2. Get job by id");
      Console.WriteLine("3. Insert new job");
      Console.WriteLine("4. Update job");
      Console.WriteLine("5. Delete job");
      Console.WriteLine("10. Back");
      Console.Write("Enter your choice: ");
      var input2 = Console.ReadLine();
      switch (input2)
      {
        case "1":
          jobController.GetAll();
          break;
        case "2":
          // jobController.GetById();
          break;
        case "3":
          jobController.Insert();
          break;
        case "4":
          // jobController.Update();
          break;
        case "5":
          // jobController.Delete();
          break;
        case "10":
          isLoop = false;
          break;
        default:
          Console.WriteLine("Invalid choice");
          break;
      }
    }
  }

  public static void DepartementsMenu()
  {
    var departement = new Departements();
    var departementView = new DepartementsView();

    var departementController = new DepartementsController(departement, departementView);

    var isLoop = true;
    while (isLoop)
    {
      Console.WriteLine("1. List all departements");
      Console.WriteLine("2. Get departement by id");
      Console.WriteLine("3. Insert new departement");
      Console.WriteLine("4. Update departement");
      Console.WriteLine("5. Delete departement");
      Console.WriteLine("10. Back");
      Console.Write("Enter your choice: ");
      var input2 = Console.ReadLine();
      switch (input2)
      {
        case "1":
          departementController.GetAll();
          break;
        case "2":
          // departementController.GetById();
          break;
        case "3":
          departementController.Insert();
          break;
        case "4":
          // departementController.Update();
          break;
        case "5":
          // departementController.Delete();
          break;
        case "10":
          isLoop = false;
          break;
        default:
          Console.WriteLine("Invalid choice");
          break;
      }
    }
  }

  public static void EmployeesMenu()
  {
    var employee = new Employees();
    var employeeView = new EmployeesView();

    var employeeController = new EmployeesController(employee, employeeView);

    var isLoop = true;
    while (isLoop)
    {
      Console.WriteLine("1. List all employees");
      Console.WriteLine("2. Get employee by id");
      Console.WriteLine("3. Insert new employee");
      Console.WriteLine("4. Update employee");
      Console.WriteLine("5. Delete employee");
      Console.WriteLine("10. Back");
      Console.Write("Enter your choice: ");
      var input2 = Console.ReadLine();
      switch (input2)
      {
        case "1":
          employeeController.GetAll();
          break;
        case "2":
          // employeeController.GetById();
          break;
        case "3":
          employeeController.Insert();
          break;
        case "4":
          // employeeController.Update();
          break;
        case "5":
          // employeeController.Delete();
          break;
        case "10":
          isLoop = false;
          break;
        default:
          Console.WriteLine("Invalid choice");
          break;
      }
    }
  }

  public static void HistoriesMenu()
  {
    var history = new Histories();
    var historyView = new HistoriesView();

    var historyController = new HistoriesController(history, historyView);

    var isLoop = true;
    while (isLoop)
    {
      Console.WriteLine("1. List all histories");
      Console.WriteLine("2. Get history by id");
      Console.WriteLine("3. Insert new history");
      Console.WriteLine("4. Update history");
      Console.WriteLine("5. Delete history");
      Console.WriteLine("10. Back");
      Console.Write("Enter your choice: ");
      var input2 = Console.ReadLine();
      switch (input2)
      {
        case "1":
          historyController.GetAll();
          break;
        case "2":
          // historyController.GetById();
          break;
        case "3":
          historyController.Insert();
          break;
        case "4":
          // historyController.Update();
          break;
        case "5":
          // historyController.Delete();
          break;
        case "10":
          isLoop = false;
          break;
        default:
          Console.WriteLine("Invalid choice");
          break;
      }
    }
  }
}
