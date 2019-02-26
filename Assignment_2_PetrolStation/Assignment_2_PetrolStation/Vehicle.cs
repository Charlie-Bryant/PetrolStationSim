using System;
using System.Timers;

namespace Assignment_2_PetrolStation
{

    // a parent class that links all the attributes to child classes
    class Vehicle
    {
        //Vehicle Properties  
        protected string fuelType;
        protected int tankSize;
        protected double fuelInTank;
        protected double fuelTime;
        protected static int nextCarID = 0;
        private int _carID = nextCarID++;
        private static int vehicleCounterHold;
        private static int vehiclesUnservicedHold;
        private static int vehiclesUnserviced;
        private static int vehicleCounter;
        private string vehicleType;
        protected double litersDispensed;
        private int pumpUsed;
        protected static string[] FList = new string[] { "Diesil", "LPG", "Unleaded" };
        protected static Timer timer = new Timer();

        // Accessors 
        public int CarID { get => _carID;}
        public string FuelType { get => fuelType;}
        public double Tanksize { get => tankSize;}
        public double FuelTime { get => fuelTime; set => fuelTime = value; }
        public double LitersDispensed { get => litersDispensed; set => litersDispensed = value;}
        public int PumpUsed { get => pumpUsed; set => pumpUsed = value;}
        public string VehicleType { get => vehicleType; set => vehicleType = value;}
        public static int VehicleCounterHold { get => vehicleCounterHold; set => vehicleCounterHold = value; }
        public static int VehiclesUnservicedHold { get => vehiclesUnservicedHold; set => vehiclesUnservicedHold = value;}
        public static int VehiclesUnserviced { get => vehiclesUnserviced; set => vehiclesUnserviced = value;}
        public static int VehicleCounter { get => vehicleCounter; set => vehicleCounter = value;}



        //This method removes the vehicle from the queue when the timer runs out, if it is successful it will increment the timer by +1
        public void RemoveVehicle(object sender, ElapsedEventArgs e)
        {
        
            if (Data.vehicles.Remove(this))
            {
                VehiclesUnservicedHold = VehiclesUnserviced++;
                
            }
            
        }
        
        

    }

    class Car : Vehicle
    {
        public Car()
        {
            //Generates a random number to use to dictate the fuel type
            int Type = RandomGenerator.RandomFTCAR();
            //Uses the randomly generated int to randomly select a fuel type that fits the vehicles specification
            fuelType = FList[Type];
            tankSize = 40;
            fuelTime = ((tankSize- fuelInTank)/1.5) *100;
            //generates a random fuel amount already in the tank
            fuelInTank = RandomGenerator.RandFuel(tankSize);
            VehicleType = "Car"; 
            litersDispensed = tankSize-fuelInTank;
            //timer for queue waiting runs remove vehicle after 10 seconds after creation
            timer.Interval = 3000;
            timer.Elapsed += RemoveVehicle;
            timer.Enabled = true;
            timer.Start();
        }
        

    }

    class Van : Vehicle
    {
        public Van()
        {
            int Type = RandomGenerator.RandomFTVAN();
            fuelType = FList[Type];
            tankSize = 80;
            fuelTime = ((tankSize - fuelInTank) / 1.5) * 100; 
            fuelInTank = RandomGenerator.RandFuel(tankSize);
            VehicleType = "Van";
            litersDispensed = tankSize-fuelInTank; 
            timer.Interval = 3000;
            timer.Elapsed += RemoveVehicle;
            timer.Enabled = true;
            timer.Start();
        }
        
    }

    class HGV : Vehicle
    {
        public HGV()
        {
           
            fuelType = "Diesil";
            tankSize = 150;
            fuelInTank = RandomGenerator.RandFuel(tankSize);
            fuelTime = ((tankSize - fuelInTank) / 1.5) * 100;
            VehicleType = "HGV";
            litersDispensed = tankSize-fuelInTank;
            timer.Interval =3000;
            timer.Elapsed += RemoveVehicle;
            timer.Enabled = true;
            timer.Start();
        }
        
    }
    
}





 
