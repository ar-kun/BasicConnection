
namespace BasicConnectivity.Views;

public class EmployeesView : GeneralView
{

  public Employees InsertInput()
  {
    Console.WriteLine("Insert employee id");
    var id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert employee first name");
    var first_name = Console.ReadLine();
    Console.WriteLine("Insert employee last name");
    var last_name = Console.ReadLine();
    Console.WriteLine("Insert employee email");
    var email = Console.ReadLine();
    Console.WriteLine("Insert employee phone number");
    var phone_number = Console.ReadLine();
    Console.WriteLine("Insert employee hire date");
    var hire_date = Convert.ToDateTime(Console.ReadLine());
    Console.WriteLine("Insert employee job id");
    var job_id = Console.ReadLine();
    Console.WriteLine("Insert employee salary");
    var salary = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert employee commission pct");
    var commission_pct = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert employee manager id");
    var manager_id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert employee department id");
    var department_id = Convert.ToInt32(Console.ReadLine());

    return new Employees
    {
      Id = id,
      FirstName = first_name,
      LastName = last_name,
      Email = email,
      PhoneNumber = phone_number,
      HireDate = hire_date,
      JobId = job_id,
      Salary = salary,
      ComissionPct = commission_pct,
      ManagerId = manager_id,
      DepartmentId = department_id
    };
  }

}
