using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_PetrolStation
{
    public class RandomGenerator
    {
        public static Random RandGen = new Random();

        public static int RandomFTCAR()
        {
            int RandomFT = RandGen.Next(0, 3);
            return RandomFT;
        }
        public static int RandomFTVAN()
        {
            int RandomFT = RandGen.Next(0, 2);
            return RandomFT;
        }

        public static int RandomV()
        {
            
            int RandomVType = RandGen.Next(1, 4);
            return RandomVType;
        }

        public static double RandomVADD()
        {
            
            double RandomTime = RandGen.Next(1500, 2200);
            return RandomTime;
        }

        public static double RandomFTM()
        {
            
            double RandomF = RandGen.Next(17000, 19000);
            return RandomF;
        }
        
        public static double RandomQTime()
        {
            
            double RandomQ = RandGen.Next(5000, 7000);
            return RandomQ;
        }

        public static double RandFuel(int tankSize)
        {
            double RandF = RandGen.Next(1, (tankSize/4));
            return RandF;
        }
    }
    
        


    
}
