using BasicConnectivity.Views;

namespace BasicConnectivity.Controllers;

public class HistoriesController
{
  private Histories _histories;
  private HistoriesView _historiesView;

  public HistoriesController(Histories histories, HistoriesView historiesView)
  {
    _histories = histories;
    _historiesView = historiesView;
  }

  public void GetAll()
  {
    var results = _histories.GetAll();
    if (!results.Any())
    {
      Console.WriteLine("No data found");
    }
    else
    {
      _historiesView.List(results, "histories");
    }
  }
}