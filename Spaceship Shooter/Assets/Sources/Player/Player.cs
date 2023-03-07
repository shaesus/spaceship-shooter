using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IDamagable
{
    public static Player Instance { get; private set; }

    public event Action PlayerDie;

    public Rigidbody PlayerRb { get; private set; }

    [SerializeField] private int _maxHitsCount = 3;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        PlayerRb = GetComponent<Rigidbody>();
    }

    public void TakeDamage()
    {
        _maxHitsCount--;
        Debug.Log("Player took damage!");

        if (_maxHitsCount <= 0)
        {
            PlayerDie?.Invoke();
            Debug.Log("Player died!");
        }
    }
}
