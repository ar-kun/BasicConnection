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

  public void Insert()
  {
    Jobs inputJob = null;
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        inputJob = _jobsView.InsertInput();
        if (string.IsNullOrEmpty(inputJob.Id))
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
    var result = _jobs.Insert(inputJob);

    _jobsView.Transaction(result);
  }

  public void Update()
  {
    var jobs = new Jobs();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        jobs = _jobsView.UpdateJobs();
        if (string.IsNullOrEmpty(jobs.Id))
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
    var result = _jobs.Update(jobs);

    _jobsView.Transaction(result);
  }

  public void Delete()
  {
    var jobs = new Jobs();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        jobs = _jobsView.Delete();
        if (string.IsNullOrEmpty(jobs.Id))
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
    var result = _jobs.Delete(jobs);

    _jobsView.Transaction(result);
  }
}