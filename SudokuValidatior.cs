// https://leetcode.com/problems/valid-sudoku/

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        HashSet<char> seen = new HashSet<char>();

        // Validate columns
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (seen.Contains(board[i][j]))
                {
                    return false;
                }
                else if (board[i][j] != '.')
                {
                    seen.Add(board[i][j]);
                }
            }
            seen.Clear();
        }
        // Validate rows
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (seen.Contains(board[j][i]))
                {
                    return false;
                }
                else if (board[j][i] != '.')
                {
                    seen.Add(board[j][i]);
                }
            }
            seen.Clear();
        }
        // Validate Squares
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        var c = board[(i * 3) + x][(j * 3) + y];
                        if (seen.Contains(c))
                        {
                            return false;
                        }
                        else if (c != '.')
                        {
                            seen.Add(board[(i * 3) + x][(j * 3) + y]);
                        }
                    }
                }
                seen.Clear();
            }
        }
        return true;
    }
}