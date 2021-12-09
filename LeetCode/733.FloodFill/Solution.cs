// 733. Flood Fill
// https://leetcode.com/problems/flood-fill/

public class Solution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        int m = image.Length;
        int n = image[0].Length;
        int currentColor = image[sr][sc];
        Dfs(image, sr, sc, m, n, newColor, currentColor);
        return image;
    }

    private void Dfs(int[][] image, int c, int r, int m, int n, int newColor, int currentColor)
    {
        // imageの幅を超えた場合は何もしない
        if (c < 0 || m - 1 < c || r < 0 || n - 1 < r) return;

        // すでにnewColorの場合は何もしない
        if (image[c][r] == newColor) return;

        // スタートポジションと同じ色の場合はnewColorに変えて、上下左右のマスで再帰的に実行する
        if (image[c][r] == currentColor)
        {
            image[c][r] = newColor;
            Dfs(image, c + 1, r, m, n, newColor, currentColor);
            Dfs(image, c - 1, r, m, n, newColor, currentColor);
            Dfs(image, c, r - 1, m, n, newColor, currentColor);
            Dfs(image, c, r + 1, m, n, newColor, currentColor);
        }
    }
}
