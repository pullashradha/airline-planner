using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AirlinePlanner
{
  public class City
  {
    private int _id;
    private string _name;
    public City (string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }
    public override bool Equals (System.Object otherCity)
    {
      if (!(otherCity is City))
      {
        return false;
      }
      else
      {
        City newCity = (City) otherCity;
        bool idEquality = (this.GetId() == newCity.GetId());
        bool nameEquality = (this.GetName() == newCity.GetName());
        return (idEquality && nameEquality);
      }
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName (string newName)
    {
      _name = newName;
    }
    public static List<City> GetAll()
    {
      List<City> AllCities = new List<City> {};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand ("SELECT * FROM cities;", conn);
      rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        City newCity = new City(cityName, cityId);
        AllCities.Add(newCity);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllCities;
    }
  }
}
