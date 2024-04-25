using System;

namespace CountingIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            char[,] islands = new char[4, 4] {
                {'1', '1', '0', '1'},
                {'1', '0', '0', '0'},
                {'1', '0', '1', '1'},
                {'1', '0', '1', '0'}};


            int islandResult = solution.CountIslands(islands);
            Console.WriteLine("Number of islands: " + islandResult);
        }
    }

    public class Solution
    {
        public int CountIslands(char[,] grid)
        {
            int islandCount = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == '1')
                    {
                        DepthFirstSearch(grid, i, j);
                        islandCount++;
                    }
                }
            }

            return islandCount;
        }

        private void DepthFirstSearch(char[,] grid, int i, int j)
        {
            // Check for out of bounds, if so, return
            if (i < 0 || i >= grid.GetLength(0) || j < 0 || j >= grid.GetLength(1) || grid[i,j] == '0')
            {
                return;
            }

            // Mark current location as visited
            grid[i, j] = '0';

            // Check left
            DepthFirstSearch(grid, i, j - 1);

            // Check right
            DepthFirstSearch(grid, i, j + 1);

            // Check up
            DepthFirstSearch(grid, i + 1, j);

            // Check Down
            DepthFirstSearch(grid, i - 1, j);
        }
    }
}
