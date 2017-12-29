// detail: https://codeforces.com/contest/908/submission/33780177
﻿using System; 
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] HW = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[][] maze = new bool[HW[0]][];
        int[] start = new int[2];
        int[] end = new int[2];

        string[] replace = { "0123", "0132", "0213", "0231", "0312", "0321", "1023", "1032", "1203", "1230", "1302", "1320", "2013", "2031", "2103", "2130", "2301", "2310", "3012", "3021", "3102", "3120", "3201", "3210" };
        for (int i = 0; i < HW[0]; i++)
        {
            string s = Console.ReadLine();
            maze[i] = new bool[HW[1]];
            for (int j = 0; j < HW[1]; j++)
            {
                if (s[j] == 'S') start = new int[] { i, j };
                if (s[j] == 'E') end = new int[] { i, j };
                maze[i][j] = s[j] != '#';
            }
        }
        string move = Console.ReadLine();
        int res = 0;
        for (int i = 0; i < replace.Length; i++)
        {
            char[] repMove = move.Select(x => replace[i][x - '0']).ToArray();
            int[] place = new int[] {start[0], start[1]};
            bool reach = false;
            foreach (var movec in repMove)
            {
                switch (movec)
                {
                    case '0':
                    place[0]++;
                    break;
                    case '1':
                    place[1]++;
                    break;
                    case '2':
                    place[0]--;
                    break;
                    case '3':
                    place[1]--;
                    break;
                }
                if (place[0] < 0 || place[1] < 0 || place[0] >= HW[0] || place[1] >= HW[1] || !maze[place[0]][place[1]])
                {
                    break;
                }
                if (place[0] == end[0] && place[1] == end[1])
                {
                    reach = true;
                    break;
                }
            }
            if (reach) res++;
        }
        Console.WriteLine(res);
    }
}