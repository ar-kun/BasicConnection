using BasicConnectivity.Views;

namespace BasicConnectivity.Controllers;

public class EmployeesController
{
  private Employees _employees;
  private EmployeesView _employeesView;

  public EmployeesController(Employees employees, EmployeesView employeesView)
  {
    _employees = employees;
    _employeesView = employeesView;
  }

  public void GetAll()
  {
    var results = _employees.GetAll();
    if (!results.Any())
    {
      Console.WriteLine("No data found");
    }
    else
    {
      _employeesView.List(results, "employees");
    }
  }

  public void Insert()
  {
    Employees inputEmployee = null;
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        inputEmployee = _employeesView.InsertInput();
        if (string.IsNullOrEmpty(inputEmployee.FirstName))
        {
          Console.WriteLine("First name cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _employees.Insert(inputEmployee);

    _employeesView.Transaction(result);
  }
}