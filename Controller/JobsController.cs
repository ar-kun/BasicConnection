using BasicConnectivity.Views;

namespace BasicConnectivity.Controllers;

public class JobsController
{
  private Jobs _jobs;

  private JobsView _jobsView;

  public JobsController(Jobs jobs, JobsView jobsView)
  {
    _jobs = jobs;
    _jobsView = jobsView;
  }

  public void GetAll()
  {
    var results = _jobs.GetAll();
    if (!results.Any())
    {
      Console.WriteLine("No data found");
    }
    else
    {
      _jobsView.List(results, "jobs");
    }
  }
}