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

  public void Update()
  {
    var departements = new Departements();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        departements = _departementsView.UpdateDepartements();
        if (string.IsNullOrEmpty(departements.Name))
        {
          Console.WriteLine("Departements name cannot be empty");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    var result = _departements.Update(departements);
    _departementsView.Transaction(result);
  }

  public void Delete()
  {
    var departements = new Departements();
    var isTrue = true;
    while (isTrue)
    {
      try
      {
        departements = _departementsView.Delete();
        if (departements == null)
        {
          Console.WriteLine("Departements not found");
          continue;
        }
        isTrue = false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    var result = _departements.Delete(departements);
    _departementsView.Transaction(result);

  }
}

// var departement = _departementsView.Delete();

//     if (departement == null)
//     {
//       Console.WriteLine("No data found");
//     }
//     else
// {
//   var result = _departements.Delete(departement);
//   _departementsView.Transaction(result);
// }