using System;
using Unity.VisualScripting;

public static class ScoreManager
{
    private static int Score = 0;
    private static int Combo = 0 ;

    public static int GetScore()
    {
        return Score;
    }

    public static void AddScore(int addedScore)
    {
        if (addedScore == 300 || addedScore == 100)
        {
            Combo += 1;
        }
        else
        {
            Combo = 0;
        }

        Score += addedScore + (int)Math.Round(addedScore * 1.5 * Combo);
    }
}
