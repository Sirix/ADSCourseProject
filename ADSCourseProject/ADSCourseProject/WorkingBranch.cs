using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ADSCourseProject
{

    class WorkingBranch
    {
        public static List<int> Way = new List<int>();
        public static List<int> ShortWay = new List<int>();
        public static int shortWayLength = 100000;
        public static int[][] Power = new int[5][];
        public static void Init()
        {
            for (int i = 0; i < Power.Length; i++)
            {
                Power[i] = new int[5];
            }
            Power[0][1] = Power[1][0] = 10;
            Power[2][1] = Power[1][2] = 20;
            Power[3][2] = Power[2][3] = 15;
            Power[4][3] = Power[3][4] = 7;
            Power[0][4] = Power[4][0] = 8;
        }
        private static bool f = true;
        public static void FindShortWay(int Start, int Finish, int D, int[] []Power, List<int> Way)
        {
            if (f) {
                Way.Add(Start);
                f = false;
            }

            for (int i = 0; i < Power.Length; i++)
            {
                if (i != Start&& i!=0)
                    if (i == Finish)
                    {
                        int k = Power[Start][i] - D;
                        if (k >= 0)
                        {
                            Way.Add(Finish);
                            if (Way.Count < shortWayLength)
                            {
                                ShortWay = new List<int>(Way);
                                shortWayLength = Way.Count;
                                return;
                            };
                        }
                        else
                        {
                            Debug.Write("Channel overload!");
                        }
                    }
                    else
                    {
                        int loop = 0;
                        for (int k = 0; k < Way.Count&& loop==0; k++)
                        {
                            if (i == Way[k]) loop = 1;
                        }
                        if(loop==0) 
                        {
                            var Poweri = Power.Clone() as int[][];
                            Poweri[Start][i] -= D;
                            var Wayi = new List<int>(Way);
                            Wayi.Add(i);
                            FindShortWay(i, Finish, D, Poweri, Wayi);
                        }
                    }
            }
        }
    }
}
