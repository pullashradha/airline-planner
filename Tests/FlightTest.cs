using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace AirlinePlanner
{
  public class FlightTest : IDisposable
  {
    public ExampleTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=airline_planner_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Example.DeleteAll();
    }
  }
}
