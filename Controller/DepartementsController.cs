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
}