using System;
using System.Collections.Generic;
using System.Linq;

namespace Queue;

public static class Solution
{
    public static int GetIslandsCount(int[][] grid)
    {
        if (grid == null)
            throw new ArgumentNullException(nameof(grid));

        if (grid.Length == 0 || grid[0].Length == 0)
            return 0;

        int rows = grid.Length;
        int cols = grid[0].Length;

        if (grid.Any(row => row.Length != cols))
            throw new ArgumentException("Grid must be rectangular.");

        bool[,] visited = new bool[rows, cols];
        int count = 0;
        int[][] directions = new int[][]
        {
            new[] {1, 0}, 
            new[] {-1, 0}, 
            new[] {0, 1},  
            new[] {0, -1}  
        };

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 1 && !visited[r, c])
                {
                    count++;
                    Queue<(int, int)> q = new();
                    q.Enqueue((r, c));
                    visited[r, c] = true;

                    while (q.Count > 0)
                    {
                        var (cr, cc) = q.Dequeue();
                        foreach (var dir in directions)
                        {
                            int nr = cr + dir[0];
                            int nc = cc + dir[1];
                            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols &&
                                grid[nr][nc] == 1 && !visited[nr, nc])
                            {
                                visited[nr, nc] = true;
                                q.Enqueue((nr, nc));
                            }
                        }
                    }
                }
            }
        }

        return count;
    }

    public static int GetMinimumKnightMoves(char[][] chessboard)
    {
        if (chessboard == null)
            throw new ArgumentNullException(nameof(chessboard));

        if (chessboard.Length == 0 || chessboard[0].Length == 0)
            return -1;

        int rows = chessboard.Length;
        int cols = chessboard[0].Length;

        // Проверка на прямоугольность
        if (chessboard.Any(row => row.Length != cols))
            throw new ArgumentException("Chessboard must be rectangular.");

        (int r, int c)? start = null, dest = null;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (chessboard[r][c] == 'K') start = (r, c);
                if (chessboard[r][c] == 'D') dest = (r, c);
            }
        }

        if (start == null || dest == null)
            return -1;

        var moves = new (int, int)[]
        {
            (2, 1), (2, -1), (-2, 1), (-2, -1),
            (1, 2), (1, -2), (-1, 2), (-1, -2)
        };

        bool[,] visited = new bool[rows, cols];
        Queue<(int r, int c, int dist)> q = new();
        q.Enqueue((start.Value.r, start.Value.c, 0));
        visited[start.Value.r, start.Value.c] = true;

        while (q.Count > 0)
        {
            var (cr, cc, dist) = q.Dequeue();

            if (cr == dest.Value.r && cc == dest.Value.c)
                return dist;

            foreach (var (dr, dc) in moves)
            {
                int nr = cr + dr, nc = cc + dc;
                if (nr >= 0 && nr < rows && nc >= 0 && nc < cols &&
                    !visited[nr, nc] && chessboard[nr][nc] != 'O')
                {
                    visited[nr, nc] = true;
                    q.Enqueue((nr, nc, dist + 1));
                }
            }
        }

        return -1;
    }
}