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

  public void Insert()
  {
    Histories inputHistory = null;
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        inputHistory = _historiesView.InsertInput();
        if (string.IsNullOrEmpty(inputHistory.JobId))
        {
          Console.WriteLine("Job id cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
    var result = _histories.Insert(inputHistory);

    _historiesView.Transaction(result);
  }
}