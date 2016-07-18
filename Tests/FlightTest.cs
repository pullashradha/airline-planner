using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace AirlinePlanner
{
  public class FlightTest : IDisposable
  {
    public FlightTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=airline_planner_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_Empty_EmptyDatabase()
    {
      int flightList = Flight.GetAll().Count;
      Assert.Equal(0, flightList);
    }
    [Fact]
    public void Test_Equal_EntriesMatch()
    {
      Flight firstFlight = new Flight ("AA321", "Hyderabad", "Dubai", new DateTime(2016, 7, 16, 10, 00, 00), new DateTime(2016, 7, 16, 21, 00, 00), "On Time");
      Flight secondFlight = new Flight ("AA321", "Hyderabad", "Dubai", new DateTime(2016, 7, 16, 10, 00, 00), new DateTime(2016, 7, 16, 21, 00, 00), "On Time");
      Assert.Equal(firstFlight, secondFlight);
    }
    public void Dispose()
    {
      // Flight.DeleteAll();
    }
  }
}
