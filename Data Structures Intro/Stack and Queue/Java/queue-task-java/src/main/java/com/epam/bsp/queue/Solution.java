package com.epam.bsp.queue;

import java.util.LinkedList;
import java.util.Queue;

public class Solution {

    public static int getIslandsCount(int[][] grid) {
        if (grid == null || grid.length == 0) return 0;

        int rows = grid.length, cols = grid[0].length;
        boolean[][] visited = new boolean[rows][cols];
        int count = 0;
        int[][] dirs = {{1,0}, {-1,0}, {0,1}, {0,-1}};

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 1 && !visited[r][c]) {
                    count++;
                    Queue<int[]> q = new LinkedList<>();
                    q.add(new int[]{r, c});
                    visited[r][c] = true;
                    while (!q.isEmpty()) {
                        int[] cell = q.poll();
                        for (int[] d : dirs) {
                            int nr = cell[0] + d[0], nc = cell[1] + d[1];
                            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols &&
                                grid[nr][nc] == 1 && !visited[nr][nc]) {
                                visited[nr][nc] = true;
                                q.add(new int[]{nr, nc});
                            }
                        }
                    }
                }
            }
        }
        return count;
    }

    public static int getMinimumKnightMoves(char[][] chessboard) {
        int n = 8;
        int[][] moves = {
                {2,1}, {1,2}, {-1,2}, {-2,1},
                {-2,-1}, {-1,-2}, {1,-2}, {2,-1}
        };

        int startR = -1, startC = -1, destR = -1, destC = -1;

        for (int r = 0; r < n; r++) {
            for (int c = 0; c < n; c++) {
                if (chessboard[r][c] == 'K') { startR = r; startC = c; }
                else if (chessboard[r][c] == 'D') { destR = r; destC = c; }
            }
        }

        boolean[][] visited = new boolean[n][n];
        Queue<int[]> q = new LinkedList<>();
        q.add(new int[]{startR, startC, 0});
        visited[startR][startC] = true;

        while (!q.isEmpty()) {
            int[] cur = q.poll();
            int r = cur[0], c = cur[1], dist = cur[2];
            if (r == destR && c == destC) return dist;
            for (int[] m : moves) {
                int nr = r + m[0], nc = c + m[1];
                if (nr >= 0 && nr < n && nc >= 0 && nc < n &&
                        !visited[nr][nc] && chessboard[nr][nc] != 'O') {
                    visited[nr][nc] = true;
                    q.add(new int[]{nr, nc, dist + 1});
                }
            }
        }

        return -1; // should never happen as per problem guarantee
    }
}
