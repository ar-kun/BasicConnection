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
}