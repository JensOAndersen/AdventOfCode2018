using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Utils;

namespace Solutions
{
    public class DayThree : BaseSolution
    {
        string[] input;
        List<Claim> claims = new List<Claim>();

        //constructor is used to set up claims, its useful
        public DayThree(string fileName, string name) : base(fileName, name)
        {
            input = utils.ReadFileAsStringArray();

            foreach (var item in input)
            {
                var curItem = item;
                curItem = curItem.Replace("#", string.Empty);
                curItem = curItem.Replace(" ", string.Empty);

                var baseClaim = curItem.Split(',', 'x', '@', ':');

                claims.Add(new Claim()
                {
                    elfId = int.Parse(baseClaim[0]),
                    x = int.Parse(baseClaim[1]),
                    y = int.Parse(baseClaim[2]),
                    xSize = int.Parse(baseClaim[3]),
                    ySize = int.Parse(baseClaim[4])
                });
            }
        }

        //there should be an easy way to solve this mathematically, buuuuut, i dont have that.
        public override string PartOne()
        {
            int[,] canvas = new int[1000, 1000];

            foreach (var claim in claims)
            {
                int xEnd = claim.x + claim.xSize;
                int yEnd = claim.y + claim.ySize;

                for (int y = claim.y; y < yEnd; y++)
                {
                    for (int x = claim.x; x < xEnd; x++)
                    {
                        canvas[x, y] += 1;
                    }
                }
            }

            int count = 0;
            foreach (int i in canvas)
            {
                if (i > 1)
                {
                    count++;
                }
            }

            return count.ToString();
        }

        public override string PartTwo()
        {
            //the canvas will be a dictionary this time, as the size of the map doesnt matter, and i need quick lookups
            Dictionary<(int x, int y), int> canvas = new Dictionary<(int x, int y), int>();

            //populate the dictionary with values
            foreach (var claim in claims)
            {
                int xEnd = claim.x + claim.xSize;
                int yEnd = claim.y + claim.ySize;

                for (int y = claim.y; y < yEnd; y++)
                {
                    for (int x = claim.x; x < xEnd; x++)
                    {
                        if(!canvas.ContainsKey((x,y)))
                        {
                            canvas.Add((x,y), 1);
                        } else
                        {
                            canvas[(x,y)] += 1;
                        }
                    }
                }
            }

            //the chosen one
            Claim c = new Claim();

            foreach (var claim in claims)
            {
                int xEnd = claim.x + claim.xSize;
                int yEnd = claim.y + claim.ySize;

                bool isAlone = true;
                for (int y = claim.y; y < yEnd; y++)
                {
                    for (int x = claim.x; x < xEnd; x++)
                    {
                        if(canvas[(x,y)] > 1 && isAlone)
                        {
                            isAlone = false;
                        }
                    }
                }

                if (isAlone)
                {
                    c = claim;
                }
            }

            return c.elfId.ToString();
        }
    }

    public struct Claim
    {
        public int elfId;
        public int x;
        public int y;

        public int xSize;
        public int ySize;
    }
}
