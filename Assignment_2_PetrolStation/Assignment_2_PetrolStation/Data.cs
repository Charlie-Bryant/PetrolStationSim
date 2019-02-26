using System.Collections.Generic;
using System.Timers;

namespace Assignment_2_PetrolStation
{
    class Data
    {
        //Data Properties 
        private static Timer timer;
        public static List<Vehicle> vehicles;
        public static List<Pump> pumps;


        //Method to Initialise both Pumps and Vehicles
        public static void Initialise() {
            InitialisePumps();
            InitialiseVehicles();
        }



        private static void InitialiseVehicles()
        {
            vehicles = new List<Vehicle>();
            vehicles.Capacity = 4;

            // https://msdn.microsoft.com/en-us/library/system.timers.timer(v=vs.71).aspx
            timer = new Timer();
            timer.Interval = (1500);
            timer.AutoReset = true; // keep repeating every 1.5 seconds
            timer.Elapsed += CreateVehicle;
            timer.Enabled = true;
            timer.Start();
        }

        private static void CreateVehicle(object sender, ElapsedEventArgs e)
        {
            short RandVADD = (short)RandomGenerator.RandomVADD();
            timer.Interval = RandVADD;
            

            
            int vType = RandomGenerator.RandomV();
           
            double ftm = RandomGenerator.RandomFTM();
        
       
            Vehicle v = null;
            if (vType == 1)
            {
                v = new Car();
                Vehicle.VehicleCounterHold = Vehicle.VehicleCounter++;
            }
            else if (vType == 2)
            {
                v = new Van();
                Vehicle.VehicleCounterHold = Vehicle.VehicleCounter++;

            }
            else if (vType == 3)
            {
                v = new HGV();    
                Vehicle.VehicleCounterHold = Vehicle.VehicleCounter++;

            }

            if (vehicles.Count <=4 )
            {
                vehicles.Add(v);
                
                 
            }
          
        }
        private static void InitialisePumps()
        {
            pumps = new List<Pump>();

            Pump p;

            for (int i = 0; i < 9; i++)
            {
                p = new Pump(1.5, i);
                pumps.Add(p);
            }
        }
        public static void AssignVehicleToPump()
        {
            Vehicle v;
            Pump p;
              
            if (vehicles.Count == 0) { return; }

            for (int i = 0; i < 3; i++)
            {
                p = pumps[i];
                if (pumps[3*i].IsAvailable())
                {
                    if (pumps[3 * i + 1].IsAvailable())
                    {
                        if (pumps[3 * i + 2].IsAvailable())
                        {
                            v = vehicles[0];
                            vehicles.RemoveAt(0);
                            pumps[3 * i + 2].AssignVehicle(v);
                            v.PumpUsed =  (3 * i + 2)+1;
                            break;
                        }
                        else
                        {
                            v = vehicles[0];
                            vehicles.RemoveAt(0);
                            pumps[3 * i + 1].AssignVehicle(v);
                            v.PumpUsed = (3 * i + 1)+1;
                            break;
                        }
                    }
                    else
                    {
                        v = vehicles[0];
                        vehicles.RemoveAt(0);
                        pumps[3 * i].AssignVehicle(v);
                        v.PumpUsed = (3 * i)+1;
                        break;
                    }
                  
                }
                else
                {
                 
                }
                

                if (vehicles.Count == 0) { break; }

            }
        }
    }
}

