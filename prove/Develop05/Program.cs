using System;

class MindfulnessActivity {
     
    protected int _duration;  
    protected string _activityName; 

    // Constructor to initialize fields
    public MindfulnessActivity(string name, int duration) {
        _activityName = name;
        _duration = duration;
    }

    public virtual void StartActivity() {
        Console.WriteLine($"Starting {_activityName} for {_duration} seconds.");
        
        DisplayLoadingAnimation();
    }

    public virtual void EndActivity() {
        Console.WriteLine($"Ending {_activityName}. Well done!");
        
    }

    
    protected void DisplayLoadingAnimation() {
        Console.Write("Loading");
        for (int i = 0; i < 5; i++) {
            System.Threading.Thread.Sleep(500); 
            Console.Write(".");
        }
        Console.WriteLine();
    }
}

class BreathingActivity : MindfulnessActivity {
    public BreathingActivity(int duration) : base("Breathing Activity", duration) { }

    public override void StartActivity() {
        base.StartActivity();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");

        int cycles = _duration / 4; 

        for (int i = 0; i < cycles; i++) {
            Console.WriteLine($"Cycle {i + 1}: Breathe in for 2 seconds...");
            System.Threading.Thread.Sleep(2000); 
            Console.WriteLine($"Cycle {i + 1}: Breathe out for 2 seconds...");
            System.Threading.Thread.Sleep(2000); 
        }

        
        int remainingTime = _duration % 4;
        if (remainingTime > 0) {
            Console.WriteLine($"Final stretch: Breathe in for {remainingTime} seconds...");
            System.Threading.Thread.Sleep(remainingTime * 1000); 
        }
    }
}

class ReflectionActivity : MindfulnessActivity {
    public ReflectionActivity(int duration) : base("Reflection Activity", duration) { }

    public override void StartActivity() {
        base.StartActivity();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");

        string[] questions = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need."
        };

        int cycles = _duration / questions.Length; 

        foreach (var question in questions) {
            Console.WriteLine(question);
            System.Threading.Thread.Sleep(cycles * 1000); 
        }

        int remainingTime = _duration % questions.Length;
        if (remainingTime > 0) {
            Console.WriteLine("You can take a moment to reflect on your own.");
            System.Threading.Thread.Sleep(remainingTime * 1000); 
        }
    }
}

class ListingActivity : MindfulnessActivity {
    public ListingActivity(int duration) : base("Listing Activity", duration) { }

    public override void StartActivity() {
        base.StartActivity();
        Console.WriteLine("This activity will help you reflect on the good things in your life by listing them.");

        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?"
        };

        int cycles = _duration / prompts.Length; 

        foreach (var prompt in prompts) {
            Console.WriteLine(prompt);
            System.Threading.Thread.Sleep(cycles * 1000); 
        }

        int remainingTime = _duration % prompts.Length;
        if (remainingTime > 0) {
            Console.WriteLine("Take a moment to think about your answers.");
            System.Threading.Thread.Sleep(remainingTime * 1000); 
        }
    }
}

// Example usage
class Program {
    static void Main(string[] args) {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        Console.Write("Enter the number of your choice: ");
        string input = Console.ReadLine();

        Console.Write("Enter the duration for the activity in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        MindfulnessActivity activity;

        switch (input) {
            case "1":
                activity = new BreathingActivity(duration);
                break;
            case "2":
                activity = new ReflectionActivity(duration);
                break;
            case "3":
                activity = new ListingActivity(duration);
                break;
            default:
                Console.WriteLine("Invalid choice. Please select a valid activity.");
                return;
        }

        activity.StartActivity();
        // Simulate the activity duration with a delay
        System.Threading.Thread.Sleep(duration * 1000);
        activity.EndActivity();
    }
}
