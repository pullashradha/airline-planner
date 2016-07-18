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
    public Flight (string Name, string DepartureCity, string ArrivalCity, DateTime? DepartureTime, DateTime? ArrivalTime, string Status, int ID = 0)
    {
      _id = Id;
      _name = Name;
      _departureCity = DepartureCity;
      _arrivalCity = ArrivalCity;
      _departureTime = DepartureTime;
      _arrivalTime = ArrivalTime;
      _status = Status;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _string;
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
      SqlConnection conn =
    }
  }
}
