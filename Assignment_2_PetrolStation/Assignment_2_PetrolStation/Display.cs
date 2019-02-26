using System;
namespace Assignment_2_PetrolStation
{
    public class Display
    {

        //Draws the Vehicle queue and prints out the vehicles in the queue list and displays the ID, Fueltype and Vehicle Type
        public static void DrawVehicles()
        {
            Vehicle v;

            Console.WriteLine("Vehicles Queue:");


            for (int i = 0; i < Data.vehicles.Count; i++) //loops through each vehicle in the queue list
            {
                v = Data.vehicles[i];

                Console.Write("#{0} Fuel Type: {1} | Vehicle Type: {2} ||", v.CarID, v.FuelType, v.VehicleType);
            }

        }

        public static void DrawPumps() //method for printing pumps
        {
            Pump p;

            Console.WriteLine("Pumps Status:");

            for (int i = 0; i < 9; i++) //prints out 9 pumps 
            {

                p = Data.pumps[i];

                Console.Write("#{0} ", p.ID);
                if (p.IsAvailable()) 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("FREE");
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("BUSY");
                    Console.ResetColor();
                }
                Console.Write(" | ");
                // will print Free in green if pump is free and Busy in red if pump is busy

                if (i % 3 == 2) { Console.WriteLine(); }
                // every 3 pumps the pump list will start a new line arranging the pumps in 3x3 

            }
            Vehicle j;

            // Rounds the calculations of each presented value
            double TotalSales = (Pump.LitersDispensedTotal * 1.23);
            double Commision = (TotalSales * 0.01);
            Commision = Math.Round(Commision, 2);
            TotalSales = Math.Round(TotalSales, 2);
            Pump.LitersDispensedTotal = Math.Round(Pump.LitersDispensedTotal, 2);
            Pump.TotalDiesil = Math.Round(Pump.TotalDiesil, 2);
            Pump.TotalLPG = Math.Round(Pump.TotalLPG, 2);
            Pump.TotalUnleaded = Math.Round(Pump.TotalUnleaded, 2);

            //Prints the Counters needed
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Counters:");
            Console.WriteLine();
            Console.WriteLine("Vehicles Serviced:{0}", Pump.Serviced.Count);
            Console.WriteLine("Vehicles Left Before Service:{0}", Vehicle.VehiclesUnservicedHold);
            Console.WriteLine();
            Console.WriteLine("Total Fuel Dispensed:{0}", Pump.LitersDispensedTotal);
            Console.WriteLine();
            Console.WriteLine("Total Unleaded Dispensed:{0}", Pump.TotalUnleaded);
            Console.WriteLine("Total Diesil Dispensed:{0}", Pump.TotalDiesil);
            Console.WriteLine("Total LPG Dispensed:{0}", Pump.TotalLPG);
            Console.WriteLine();
            Console.WriteLine("Total Sales: £{0}", TotalSales);
            Console.WriteLine("Total Commision (1%): £{0}", Commision);
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Transaction List:");
            Console.WriteLine();
            Console.ResetColor();


            for (int i = 0; i < Pump.Serviced.Count; i++)
            {
                // ONLY TOP 5
                {
                    j = Pump.Serviced[i];
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("#{0} Vehicle Type: {1} | Number of Liters:{2} | Pump Number:{3} ", j.CarID + 1, j.VehicleType, j.LitersDispensed, j.PumpUsed);
                    Console.ResetColor();


                }
                // PRINT TO TEXT FILE = ALL
            }
        }

    }
}

 