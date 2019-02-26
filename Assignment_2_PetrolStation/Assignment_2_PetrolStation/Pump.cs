using System;
using System.Collections.Generic;
using System.Timers;

namespace Assignment_2_PetrolStation
{
     class Pump
    {
        //Pump Properties
        public Vehicle currentVehicle = null;
        private string fuelType;
        private static double litersPerSecond;
        private static List<Vehicle> serviced = new List<Vehicle>();
        private static int servicedamount = Serviced.Count;
        private int iD;
        private static double litersDispensedTotal = 0;
        private static double totalDiesil = 0;
        private static double totalLPG = 0;
        private static double totalUnleaded = 0;
        //Accessors
        public string FuelType { get => fuelType; set => fuelType = value; }
        public static double LitersPerSecond { get => litersPerSecond; set => litersPerSecond = value; }
        internal static List<Vehicle> Serviced { get => serviced; set => serviced = value; }
        public static int Servicedamount { get => servicedamount; set => servicedamount = value; }
        public static double TotalDiesil { get => totalDiesil; set => totalDiesil = value; }
        public static double TotalLPG { get => totalLPG; set => totalLPG = value; }
        public static double TotalUnleaded { get => totalUnleaded; set => totalUnleaded = value; }
        public static double LitersDispensedTotal { get => litersDispensedTotal; set => litersDispensedTotal = value; }
        public int ID { get => iD; set => iD = value; }


        
        public Pump(double lps, int I, string ftp = "")
        {
            FuelType = ftp;
            LitersPerSecond = lps;
            ID = I + 1; 
        } 

        public bool IsAvailable() {
            // returns TRUE if currentVehicle is NULL, meaning available
            // returns FALSE if currentVehicle is NOT NULL, meaning busy
            return currentVehicle == null;
        }
        //Timer runs once vehicle is assigned to the pump to time it and remove it once it has fueled
        public void AssignVehicle(Vehicle v)
        {
            currentVehicle = v;
           v.LitersDispensed = Math.Round(v.LitersDispensed, 2);
            
            Timer timer = new Timer();
            timer.Interval = v.FuelTime;
            timer.AutoReset = false; // don't repeat
            timer.Elapsed += ReleaseVehicle; 
            timer.Enabled = true;
            timer.Start();
        }
        
        //Releases the Vehicle from pump by setting it to null and records the amount of fuel according to the fuel type the vehicle used
        //Adds the vehicle to the list of serviced vehicles and adds the overall amount of fuel to the total counter 
        public void ReleaseVehicle(object sender, ElapsedEventArgs e)
        {
            Vehicle v = currentVehicle;
            if (v.FuelType == "Diesil")
            {
                TotalDiesil = TotalDiesil + v.LitersDispensed;
            }
            if (v.FuelType == "Unleaded")
            {
                TotalUnleaded = TotalUnleaded + v.LitersDispensed;
            }
            if (v.FuelType == "LPG")
            {
                TotalLPG = TotalLPG + v.LitersDispensed;
            }
            Serviced.Add(v);
            LitersDispensedTotal = LitersDispensedTotal+ v.LitersDispensed;
            currentVehicle = null;
           
    }
    }
}
