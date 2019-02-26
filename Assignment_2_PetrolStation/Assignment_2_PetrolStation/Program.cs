using System;
using System.Timers;

namespace Assignment_2_PetrolStation
{
    class Program
    {
		//Starts the program and begins a refresh timer
        static void Main(string[] args)
        {
            Data.Initialise();

            Timer timer = new Timer();
            timer.Interval = 1500;
            timer.AutoReset = true; // repeat every 2.5 seconds
            timer.Elapsed += RunProgramLoop;
            timer.Enabled = true;
            timer.Start();

            Console.ReadLine();
        }
        // Clears the console and redraws the pumpos and queues
        static void RunProgramLoop(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            Display.DrawVehicles();
            Console.WriteLine(); 
            Console.WriteLine();
            Data.AssignVehicleToPump();
            Display.DrawPumps();
        
        }
    }
}
