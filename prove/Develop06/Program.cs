using System;
using System.Collections.Generic;

// Base class
public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int GetMinutes() => _minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance()} {GetDistanceUnit()}, " +
               $"Speed: {GetSpeed()} {GetSpeedUnit()}, " +
               $"Pace: {GetPace()} min per {GetDistanceUnit().ToLower()}";
    }

    protected virtual string GetDistanceUnit() => "miles";
    protected virtual string GetSpeedUnit() => "mph";
}

// Derived class for Running
public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

    public override double GetPace() => GetDistance() > 0 ? GetMinutes() / GetDistance() : 0;
}

// Derived class for Cycling
public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * GetMinutes()) / 60;

    public override double GetSpeed() => _speed;

    public override double GetPace() => _speed > 0 ? 60 / _speed : 0;
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int _laps; // in laps

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0 * 0.62; // Convert to miles

    public override double GetSpeed() => GetDistance() > 0 ? (GetDistance() / GetMinutes()) * 60 : 0;

    public override double GetPace() => GetDistance() > 0 ? GetMinutes() / GetDistance() : 0;
}

// Main program
class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 4), 45, 12.0),
            new Swimming(new DateTime(2022, 11, 5), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
