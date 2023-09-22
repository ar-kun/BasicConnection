namespace BasicConnectivity.Views;

public class HistoriesView : GeneralView
{

  public Histories InsertInput()
  {
    Console.WriteLine("Insert history start date");
    var start_date = Convert.ToDateTime(Console.ReadLine());
    Console.WriteLine("Insert history employee id");
    var employee_id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert history end date");
    var end_date = Convert.ToDateTime(Console.ReadLine());
    Console.WriteLine("Insert history department id");
    var department_id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert history job id");
    var job_id = Console.ReadLine();


    return new Histories
    {
      StartDate = start_date,
      EmployeeId = employee_id,
      EndDate = end_date,
      DepartmentId = department_id,
      JobId = job_id
    };
  }

}
