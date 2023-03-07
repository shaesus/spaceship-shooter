using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public event Action ScoreUpdated;

    public int Score { get; private set; }

    private void Awake()
    {
        Enemy.EnemyDied += IncrementScore;
    }

    private void IncrementScore()
    {
        Score++;
        ScoreUpdated?.Invoke();
    }
}
