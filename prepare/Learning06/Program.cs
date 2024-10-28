using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // Base Class
    public abstract class Goal
    {
        protected string _name;
        protected int _points;
        protected bool _isCompleted;

        public Goal(string name, int points)
        {
            _name = name;
            _points = points;
            _isCompleted = false;
        }

        public abstract void RecordProgress();
        public virtual string DisplayGoal()
        {
            return $"{(_isCompleted ? "[X]" : "[ ]")} {_name} - {_points} points";
        }

        public int Points => _points;
        public bool IsCompleted => _isCompleted;
    }

    // Simple Goal Class
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name, points) { }

        public override void RecordProgress()
        {
            _isCompleted = true; // Mark as completed
        }
    }

    // Eternal Goal Class
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points) { }

        public override void RecordProgress()
        {
            // Points are awarded but the goal remains uncompleted
        }
    }

    // Checklist Goal Class
    public class ChecklistGoal : Goal
    {
        private int _timesCompleted;
        private int _totalRequired;
        private const int BonusPoints = 500;

        public ChecklistGoal(string name, int points, int totalRequired) : base(name, points)
        {
            _totalRequired = totalRequired;
            _timesCompleted = 0;
        }

        public override void RecordProgress()
        {
            if (_timesCompleted < _totalRequired)
            {
                _timesCompleted++;
                if (_timesCompleted == _totalRequired)
                {
                    _isCompleted = true; 
                    // Mark as completed
                    _points += BonusPoints; 
                    // Add bonus points
                }
            }
        }

        public override string DisplayGoal()
        {
            return $"{base.DisplayGoal()} - Completed {_timesCompleted}/{_totalRequired} times";
        }
    }

    // Main Program Class
    public class EternalQuest
    {
        private List<Goal> _goals;
        private int _totalPoints;

        public EternalQuest()
        {
            _goals = new List<Goal>();
            _totalPoints = 0;
        }

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void DisplayGoals()
        {
            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.DisplayGoal());
            }
        }

        public void RecordGoalProgress(string goalName)
        {
            foreach (var goal in _goals)
            {
                if (goal.GetType().Name == goalName)
                {
                    goal.RecordProgress();
                    _totalPoints += goal.Points;
                    Console.WriteLine($"Progress recorded for: {goal.DisplayGoal()}");
                    return;
                }
            }
            Console.WriteLine("Goal not found.");
        }

        public void SaveProgress(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (var goal in _goals)
                {
                    outputFile.WriteLine($"{goal.GetType().Name},{goal.DisplayGoal()}");
                }
                outputFile.WriteLine($"TotalPoints,{_totalPoints}");
            }
        }

        public void LoadProgress(string filename)
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                _goals.Clear();

                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts[0] == "TotalPoints")
                    {
                        _totalPoints = int.Parse(parts[1]);
                    }
                    else
                    {
                        // Here we need to reconstruct the goal based on its type
                        string goalType = parts[0];
                        string goalInfo = parts[1];
                        string[] goalDetails = goalInfo.Split('-');
                        string name = goalDetails[0].Trim();
                        int points = int.Parse(goalDetails[1].Split(' ')[0].Trim());

                        if (goalType == nameof(SimpleGoal))
                        {
                            AddGoal(new SimpleGoal(name, points));
                        }
                        else if (goalType == nameof(EternalGoal))
                        {
                            AddGoal(new EternalGoal(name, points));
                        }
                        else if (goalType == nameof(ChecklistGoal))
                        {
                            int completed = int.Parse(goalDetails[2].Split('/')[0].Trim());
                            int required = int.Parse(goalDetails[2].Split('/')[1].Trim());
                            var checklistGoal = new ChecklistGoal(name, points, required);
                            for (int i = 0; i < completed; i++)
                            {
                                checklistGoal.RecordProgress();
                            }
                            AddGoal(checklistGoal);
                        }
                    }
                }
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"Total Points: {_totalPoints}");
        }

        public static void Main(string[] args)
        {
            EternalQuest quest = new EternalQuest();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Eternal Quest Menu:");
                Console.WriteLine("1. Add Simple Goal");
                Console.WriteLine("2. Add Eternal Goal");
                Console.WriteLine("3. Add Checklist Goal");
                Console.WriteLine("4. Display Goals");
                Console.WriteLine("5. Record Goal Progress");
                Console.WriteLine("6. Save Progress");
                Console.WriteLine("7. Load Progress");
                Console.WriteLine("8. Display Total Points");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter goal name: ");
                        string simpleGoalName = Console.ReadLine();
                        Console.Write("Enter points: ");
                        int simplePoints = int.Parse(Console.ReadLine());
                        quest.AddGoal(new SimpleGoal(simpleGoalName, simplePoints));
                        break;
                    case "2":
                        Console.Write("Enter goal name: ");
                        string eternalGoalName = Console.ReadLine();
                        Console.Write("Enter points: ");
                        int eternalPoints = int.Parse(Console.ReadLine());
                        quest.AddGoal(new EternalGoal(eternalGoalName, eternalPoints));
                        break;
                    case "3":
                        Console.Write("Enter goal name: ");
                        string checklistGoalName = Console.ReadLine();
                        Console.Write("Enter points: ");
                        int checklistPoints = int.Parse(Console.ReadLine());
                        Console.Write("Enter number of times to complete: ");
                        int totalRequired = int.Parse(Console.ReadLine());
                        quest.AddGoal(new ChecklistGoal(checklistGoalName, checklistPoints, totalRequired));
                        break;
                    case "4":
                        quest.DisplayGoals();
                        break;
                    case "5":
                        Console.Write("Enter goal type (SimpleGoal/EternalGoal/ChecklistGoal): ");
                        string goalType = Console.ReadLine();
                        quest.RecordGoalProgress(goalType);
                        break;
                    case "6":
                        Console.Write("Enter filename to save progress: ");
                        string saveFile = Console.ReadLine();
                        quest.SaveProgress(saveFile);
                        break;
                    case "7":
                        Console.Write("Enter filename to load progress: ");
                        string loadFile = Console.ReadLine();
                        quest.LoadProgress(loadFile);
                        break;
                    case "8":
                        quest.DisplayScore();
                        break;
                    case "9":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
