using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public Rigidbody PlayerRb { get; private set; }

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
}
