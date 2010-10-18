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
        public static int[][] Power = new int[9][];
        public static void Init()
        {
            for (int i = 0; i < Power.Length; i++)
            {
                Power[i] = new int[9];
            }
            /* Power[0][1] = Power[1][0] = 10;
            Power[2][1] = Power[1][2] = 20;
            Power[3][2] = Power[2][3] = 15;
            Power[4][3] = Power[3][4] = 7;
            Power[0][4] = Power[4][0] = 8;*/
            Power[0][1] = Power[1][0] = 10;
            Power[0][2] = Power[2][0] = 20;
            Power[0][3] = Power[3][0] = 15;
            //Power[1][7] = Power[7][1] = 7;
            Power[1][6] = Power[6][1] = 8;
            Power[2][4] = Power[4][2] = 10;
            Power[2][3] = Power[3][2] = 20;
            Power[3][6] = Power[6][3] = 15;
            Power[3][5] = Power[5][3] = 7;
            Power[4][5] = Power[5][4] = 8;
            Power[4][7] = Power[7][4] = 8;
            Power[5][8] = Power[8][5] = 8;
        }

        //// private static bool f = true;

        public static bool FindWay(int Vertex, int Finish, int[][] Power, List<int> Way, int[] marker, Queue<int> queueOfNeighboringVertexes, Stack<Queue<int>> queueOfLevels)
        {
            //Поиск непомеченых и смежных с текущим узлов
            for (int i = 0; i < Power[Vertex].Length; i++)
            {
                //Является ли текущая смежная вершина узлом?
                if (Power[Vertex][i] != 0)
                {
                    //Является ли смежный узел конечным?
                    if (i == Finish)
                    {
                        return true;
                    }
                    else
                    {
                        //Являеться ли смежный узел помеченым?
                        if (marker[i] == 0)
                        {
                            //Запомнить узел
                            queueOfNeighboringVertexes.Enqueue(i);
                            //пометить узел
                            marker[i] = -1;
                        }
                    }
                }
            }
            return false;
        }

        public static void FindShortWay(int Start, int Finish, int D, int[] []Power, List<int> Way)
        {
            int[] marker = new int[D];
            marker[Start] = -1;
            //очередь для запоминания всех непомеченых и смежных с обрабатываемым узлов
            Queue<int> queueOfNeighboringVertexes = new Queue<int>();
            //очередь для запоминания всех уровней
            Stack<Queue<int>> queueOfLevels = new Stack<Queue<int>>();

            int vert;
            bool finded = false;
            queueOfNeighboringVertexes.Enqueue(Start);

            while (!finded)
            {
                Queue<int> temp = new Queue<int>();
                while (queueOfNeighboringVertexes.Count != 0)
                {
                    temp.Enqueue(queueOfNeighboringVertexes.Dequeue());
                }
                queueOfLevels.Push(temp);
                int length = queueOfLevels.Peek().Count;
                for (int i = 0; i < length; i++)
                {
                   vert =  queueOfLevels.Peek().ElementAt(i);
                   if (FindWay(vert, Finish, Power, Way, marker, queueOfNeighboringVertexes, queueOfLevels))
                   {
                       finded = true;
                       break;
                   }
                }
            }
            //добавить конец пути в список узлов пути
            Way.Add(Finish);
            int tempFinish = Finish;
            while (queueOfLevels.Count != 0)
            {
                queueOfNeighboringVertexes = queueOfLevels.Pop();
                while(queueOfNeighboringVertexes.Count !=0 )
                {
                    int[] tempmarker = new int[D];
                    vert = queueOfNeighboringVertexes.Dequeue();
                    if (FindWay(vert, tempFinish, Power, Way, tempmarker, queueOfNeighboringVertexes, queueOfLevels))
                    {
                        Way.Add(vert);
                        tempFinish = vert;
                        break;
                    }
                }
            }
            Way.Reverse();
        }
    }
}
