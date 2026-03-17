using System;
using System.Collections.Generic;
using System.Text;

namespace HWcs
{
    internal class SuperCoolClass
    {
        private int[,] SuspiciousArray;
        private double wtfisthat;
        private int[] indicies = new int[50];

        public int this[int i] 
        {
            get 
            {
                int temp = 0;
                for (int k = 0; k < 5; k++)
                {
                    temp += SuspiciousArray[k, i];
                }

                return temp;
            }
        }

        public double MegaValue 
        {
            get 
            {
                long sumofsqrts = 0;
                int ttlElements = SuspiciousArray.Length;

                for (int i = 0; i < SuspiciousArray.GetLength(0); i++) 
                {
                    for (int j = 0; j < SuspiciousArray.GetLength(1); j++) 
                    {
                        int val =   SuspiciousArray[j, i];
                        sumofsqrts += (long)val * val;  
                    }
                }

                return sumofsqrts;
            }
        }

        public SuperCoolClass(int[,] Data) 
        {
            SuspiciousArray = new int[5, 5];
            SuspiciousArray = Data;
        }
    }
}
