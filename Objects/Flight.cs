using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AirlinePlanner
{
  public class Flight
  {
    private int _id;
    private string _name;
    private string _departureCity;
    private string _arrivalCity;
    private DateTime? _departureTime;
    private DateTime? _arrivalTime;
    private string _status;
    public Flight (string Name, string DepartureCity, string ArrivalCity, DateTime? DepartureTime, DateTime? ArrivalTime, string Status, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _departureCity = DepartureCity;
      _arrivalCity = ArrivalCity;
      _departureTime = DepartureTime;
      _arrivalTime = ArrivalTime;
      _status = Status;
    }
    public override bool Equals (System.Object otherFlight)
    {
      if (otherFlight is Flight)
      {
        Flight newFlight = (Flight) otherFlight;
        bool flightIdEquality = (this.GetId() == newFlight.GetId());
        bool flightNameEquality = (this.GetName() == newFlight.GetName());
        bool departureCityEquality = (this.GetDepartureCity() == newFlight.GetDepartureCity());
        bool arrivalCityEquality = (this.GetArrivalCity() == newFlight.GetArrivalCity());
        bool departureTimeEquality = (this.GetDepartureTime() == newFlight.GetDepartureTime());
        bool arrivalTimeEquality = (this.GetArrivalTime() == newFlight.GetArrivalTime());
        bool flightStatusEquality = (this.GetStatus() == newFlight.GetStatus());
        return (flightNameEquality && departureCityEquality && arrivalCityEquality && departureTimeEquality && arrivalTimeEquality && flightStatusEquality);
      }
      else
      {
        return false;
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
    public string GetDepartureCity()
    {
      return _departureCity;
    }
    public void SetDepartureCity (string newDepartureCity)
    {
      _departureCity = newDepartureCity;
    }
    public string GetArrivalCity()
    {
      return _arrivalCity;
    }
    public void SetArrivalCity (string newArrivalCity)
    {
      _arrivalCity = newArrivalCity;
    }
    public DateTime? GetDepartureTime()
    {
      return _departureTime;
    }
    public void SetDepartureTime (DateTime? newDepartureTime)
    {
      _departureTime = newDepartureTime;
    }
    public DateTime? GetArrivalTime()
    {
      return _arrivalTime;
    }
    public void SetArrivalTime (DateTime? newArrivalTime)
    {
      _arrivalTime = newArrivalTime;
    }
    public string GetStatus()
    {
      return _status;
    }
    public void SetStatus (string newStatus)
    {
      _status = newStatus;
    }
    public static List<Flight> GetAll()
    {
      List<Flight> allFlights = new List<Flight> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM flights;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int flightId = rdr.GetInt32(0);
        string flightName = rdr.GetString(1);
        string departureCity = rdr.GetString(2);
        string arrivalCity = rdr.GetString(3);
        DateTime? departureTime = rdr.GetDateTime(4);
        DateTime? arrivalTime = rdr.GetDateTime(5);
        string flightStatus = rdr.GetString(6);
        Flight newFlight = new Flight (flightName, departureCity, arrivalCity, departureTime, arrivalTime, flightStatus, flightId);
        allFlights.Add(newFlight);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allFlights;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("INSERT INTO flights (name, departure_city, arrival_city, departure_time, arrival_time, status) OUTPUT INSERTED.id VALUES (@FlightName, @FlightDepartureCity, @FlightArrivalCity, @FlightDepartureTime, @FlightArrivalTime, @FlightStatus);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@FlightName";
      nameParameter.Value = this.GetName();

      SqlParameter departureCityParameter = new SqlParameter();
      departureCityParameter.ParameterName = "@FlightDepartureCity";
      departureCityParameter.Value = this.GetDepartureCity();

      SqlParameter arrivalCityParameter = new SqlParameter();
      arrivalCityParameter.ParameterName = "@FlightArrivalCity";
      arrivalCityParameter.Value = this.GetArrivalTime();

      SqlParameter departureTimeParameter = new SqlParameter();
      departureTimeParameter.ParameterName = "@FlightDepartureTime";
      departureTimeParameter.Value = this.GetDepartureTime();
    }

  }
}
