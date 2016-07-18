using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace AirlinePlanner
{
  public class CityTest : IDisposable
  {
    public CityTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=airline_planner_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_CitiesEmptyAtFirst()
    {
      int result = City.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueforSameName()
    {
      City firstCity = new City("Paris");
      City secondCity = new City("Paris");

      Assert.Equal(firstCity, secondCity);
    }
    public void Dispose()
    {
      // City.DeleteAll();
    }
  }
}
