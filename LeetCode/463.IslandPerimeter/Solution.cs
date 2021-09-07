// 463. Island Perimeter
// https://leetcode.com/problems/island-perimeter/

public class Solution
{
    public int IslandPerimeter(int[][] grid) {
        var (p, q) = getFirstIsland(grid);
        return Dfs(grid, null, p, q, 0);
    }

    // 島のあるセルを見つけるためのメソッド
    private (int, int) getFirstIsland(int[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    return (i, j);
                }
            }
        }
        return (0,0);
    }

    private int Dfs(int[][] grid, int[,] visits, int p, int q, int perimeter)
    {

        int height = grid.Length;
        int width = grid[0].Length;

        int result = perimeter;

        if(visits == null)
        {
            visits = new int[height,width];
        }

        if (p ==  height || q == width)
        {
            return result;
        }

        if (visits[p,q] == 1)
        {
            return result;
        }

        visits[p,q] = 1;

        // 上
        if (p - 1 < 0 || grid[p - 1][q] == 0)
        {
            result++;
        }
        else if (visits[p - 1, q] == 0)
        {
            result = Dfs(grid, visits, p - 1, q, result);
        }

        // 左
        if (q - 1 < 0 || grid[p][q - 1] == 0)
        {
            result++;
        }
        else if (visits[p,q - 1] == 0)
        {
            result = Dfs(grid, visits, p, q - 1, result);
        }

        // 右
        if (q + 1 == width || grid[p][q + 1] == 0)
        {
            result++;
        }
        else if (visits[p,q + 1] == 0)
        {
            result = Dfs(grid, visits, p, q + 1, result);
        }
        // 下
        if (p + 1 == height || grid[p + 1][q] == 0)
        {
            result++;
        }
        else if (visits[p + 1,q] == 0)
        {
            result = Dfs(grid, visits, p + 1, q, result);
        }

        return result;
    }
}
