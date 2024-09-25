 class Program
{
    static void Main(string[] args)
    {
        // Creating job instances
        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Manager", "Apple", 2022, 2023);
        
        // This will create a resume instantly
        Resume myResume = new Resume("Allison Rose");
        
        // this will add job title to the resume
        myResume.AddJob(job1);
        myResume.AddJob(job2);
        
        // display resume
        myResume.Display();
    }
}
