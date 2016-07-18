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
    [Fact]
    public void Test_Save_SavesCitiesToDatabase()
    {
      City newCity = new City("Paris");
      newCity.Save();
      Assert.Equal(1, City.GetAll().Count);
    }
    [Fact]
    public void Test_Save_SavesCitiesToDatabase2()
    {
      City newCity = new City("Paris");
      newCity.Save();

      List<City> allCities = new List<City>{newCity};
      List<City> results = City.GetAll();

      Assert.Equal(allCities, results);
    }
    public void Dispose()
    {
      City.DeleteAll();
    }
  }
}
