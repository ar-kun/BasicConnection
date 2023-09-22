namespace BasicConnectivity.Views;

public class JobsView : GeneralView
{

  public Jobs InsertInput()
  {
    Console.WriteLine("Insert job id");
    var id = Console.ReadLine();
    Console.WriteLine("Insert job title");
    var title = Console.ReadLine();
    Console.WriteLine("Insert job min salary");
    var min_salary = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert job max salary");
    var max_salary = Convert.ToInt32(Console.ReadLine());

    return new Jobs
    {
      Id = id,
      Title = title,
      MinSalary = min_salary,
      MaxSalary = max_salary
    };
  }

  public Jobs UpdateJobs()
  {
    Console.WriteLine("Insert job id");
    var id = Console.ReadLine();
    Console.WriteLine("Insert job title");
    var title = Console.ReadLine();
    Console.WriteLine("Insert job min salary");
    var min_salary = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert job max salary");
    var max_salary = Convert.ToInt32(Console.ReadLine());

    return new Jobs
    {
      Id = id,
      Title = title,
      MinSalary = min_salary,
      MaxSalary = max_salary
    };
  }

  public Jobs Delete()
  {
    Console.WriteLine("Insert job id");
    var id = Console.ReadLine();

    return new Jobs
    {
      Id = id
    };
  }

}
