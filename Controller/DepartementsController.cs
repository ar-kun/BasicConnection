using BasicConnectivity.Views;

namespace BasicConnectivity.Controllers;

public class DepartementsController
{
  private Departements _departements;
  private DepartementsView _departementsView;

  public DepartementsController(Departements departements, DepartementsView departementsView)
  {
    _departements = departements;
    _departementsView = departementsView;
  }

  public void GetAll()
  {
    var results = _departements.GetAll();
    if (!results.Any())
    {
      Console.WriteLine("No data found");
    }
    else
    {
      _departementsView.List(results, "departements");
    }
  }

  public void Insert()
  {
    Departements inputJob = null;
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        inputJob = _departementsView.InsertInput();
        if (string.IsNullOrEmpty(inputJob.Name))
        {
          Console.WriteLine("Job title cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _departements.Insert(inputJob);

    _departementsView.Transaction(result);
  }
}