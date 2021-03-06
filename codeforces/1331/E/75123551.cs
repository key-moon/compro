// detail: https://codeforces.com/contest/1331/submission/75123551
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;


public static class P
{
    static void Main()
    {
        /*
        Bitmap bitmap = new Bitmap(@"Secret.DESKTOP + \fuck.png");
        var gran = bitmap.Height / 64;
        for (int y = 0; y < 64; y++)
        {
            for (int x = 0; x < 64; x++)
            {
                if (bitmap.GetPixel(x * gran + gran / 2, y * gran + gran / 2).R <= 128) Console.Write('.');
                else Console.Write('#');
            }
            Console.WriteLine();
        }
        */
        string s = @"..........................#.#.######.#..........................
......................#.###.#.#.#..#.#####......................
....................###.#...#...##.#....#..#....................
.................####.#.#.#####....####.#.###.#.................
................##......#.#.....####....#.#.#.##................
..............#..##.#####.###.###.#..#.##...#..#.#..............
.............###..#..#......#.#...####..##.##.##.##.............
...........######.##.##.###.###.###....##..#..#...###...........
..........############....#.....#...#.##..##.##.#..###..........
.........####################.#######..####..##########.........
........################################################........
.......##################################################.......
.......##################################################.......
......####################################################......
.....######################################################.....
.....######################################################.....
....########################################################....
...##########################################################...
.....########################################################...
.......############...#..##############...#.#.#############.....
..##.....#########..#...###############.#.......########........
..####.....#####...##.#...###############.##.##..#.##.......##..
.#######.....#...###..###..###########.#..#...##.........######.
.#########.....#..#..##.##...#########.##.#####..#....#########.
.############.##.###.....###..#######...#..#....###.###########.
.#########.....#...###.###...########.#.#####.#...#..#.########.
############.###.#..#..#...#..######..#..#....##.###...#########
###########...#..#.##.###.###.####.#.###.####..###...#.#########
###########.######.####....#..#.#....#.#..#.####...###.#########
###########.....#..#..###.###...#.#.##.##.#..#...#..#..#########
############.##.####.##.###...#.###.....####.#.######.##########
###########...###..#..#...###.#..###.####..#.###...#...#########
#############.....##.###.##.###.##.....#..##.##..#...#.#########
##############.##.#....#.#....#.#..#.#.##.#...##.##.############
############....####.#.#.#.#.####.##.#..#.###..###...###########
#############.#..#...###...####...#..##....#..##...#############
################...###...#.##.##.##.##..#.###.#..#..############
##################...#.######.....#######...#...################
.################..#....#####.#.###########...#..##############.
.##############################....############################.
.###########################.#..#.#############################.
.#########################.#...################################.
..########################...#...#############################..
..#######..###################.###############################..
...#######.#.################...#####################.#######...
...#######...#...###########..#.###########.#####.#....######...
...#######.#.#.#..#.#...##.#.##..#.#..#.##...##.....#.#######...
....########...##.....#.......##...##......#.#..###.########....
.....#######.#..####.####.###..###....###.#####.#.#########.....
.....##########.#..#..#...#.####.###.##.#.....#...#########.....
......########....##.##.#....#...#.#....###.#...##########......
.......#########.##...#####.##.#.#...#.##...#############.......
.......#########..###..#.#...###...#.###..#...###########.......
........#########...####...###.##.####.####.############........
.........#########.##....#.#......#....#.##############.........
..........############.#.####.##.##.#.##..############..........
...........#############....####....#....############...........
.............####################.#################.............
..............####################################..............
................################################................
.................##############################.................
....................########################....................
......................####################......................
..........................############..........................";
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        Console.WriteLine(s.Split('\n')[h][w] == '.' ? "OUT" : "IN");
    }
}
