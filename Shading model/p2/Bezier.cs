using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace p2
{
    public static class Bezier
    {
        public static double Bi3(int i, double x)
        {
            switch(i)
            {
                case 0:
                    return (1 - x) * (1 - x) * (1 - x);
                case 1:
                    return 3 * x * (1 - x) * (1 - x);
                case 2:
                    return 3 * x * x * (1 - x);
                case 3:
                    return x * x * x;
                default: 
                    return 0;
            }
        }
        public static double Bi2(int i, double x)
        {
            switch (i)
            {
                case 0:
                    return (1 - x) * (1 - x);
                case 1:
                    return 2 * x * (1 - x);
                case 2:
                    return x * x;
                default:
                    return 0;
            }
        }
        public static double calculateZuv(double[,] zControl, double u, double v)
        {
            double result = 0;
            for(int i = 0; i < zControl.GetLength(0); i++)
            {
                for(int j = 0; j < zControl.GetLength(1); j++)
                {
                    result += zControl[i, j] * Bi3(i, u) * Bi3(j, v);
                }
            }
            return result;
        }
        public static Vector3 calculateDPu(double[,] zControl,double u, double v)
        {
            Vector3 result = new Vector3();

            result.X = 1;
            result.Y = 0;

            double z = 0;

            for (int i = 0; i < zControl.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < zControl.GetLength(1); j++)
                {
                    z += (zControl[i + 1, j] - zControl[i, j]) * Bi2(i, u) * Bi3(j, v);
                }
            }
            result.Z = (float)z;

            return result;
        }
        public static Vector3 calculateDPv(double[,] zControl, double u, double v)
        {
            Vector3 result = new Vector3();

            result.X = 0;
            result.Y = 1;

            double z = 0;

            for (int i = 0; i < zControl.GetLength(0); i++)
            {
                for (int j = 0; j < zControl.GetLength(1)-1; j++)
                {
                    z += (zControl[i, j+1] - zControl[i, j]) * Bi3(i, u) * Bi2(j, v);
                }
            }
            result.Z = (float)z;

            return result;
        }

    }
}
