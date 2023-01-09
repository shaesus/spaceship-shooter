using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    public float MoveSpeed { get { return _moveSpeed; } }

    private EnemyBehavior _behavior;

    private Rigidbody _rb;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (CompareTag("Follow"))
        {
            _behavior = new FollowingBehavior(this, FindObjectOfType<Player>().transform);
        }

        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _behavior.DoBehavior();
    }
}
