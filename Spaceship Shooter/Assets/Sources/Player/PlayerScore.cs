using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public event Action OnScoreUpdated;

    public int Score { get; private set; }

    private void Awake()
    {
        Enemy.OnEnemyDie += IncrementScore;
    }

    private void IncrementScore()
    {
        Score++;
        OnScoreUpdated?.Invoke();
    }
}
