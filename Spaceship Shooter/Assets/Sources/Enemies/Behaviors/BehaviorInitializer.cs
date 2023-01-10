using UnityEngine;

public class BehaviorInitializer : MonoBehaviour
{
    public static BehaviorInitializer Instance { get; private set; }

    [Header("Straight Line Movement Behavior Attributes")]
    [SerializeField] private float _maxAngleDifference = 30f;
    [SerializeField] private float _lifeTime = 1f;

    [Header("Staying And Shooting Behavior Attributes")]
    [SerializeField] private Vector3 _shootPointOffset;
    [SerializeField] private float _shootCd;
    [SerializeField] private Rocket _rocketPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitializeBehavior(Enemy enemy)
    {
        if (enemy.CompareTag("Follow"))
        {
            enemy.SetBehavior(new FollowingBehavior(enemy));
        }
        else if (enemy.CompareTag("StraightLine"))
        {
            enemy.SetBehavior(new StraightLineMovementBehavior(enemy, _maxAngleDifference, _lifeTime));
        }
        else if (enemy.CompareTag("StayAndShoot"))
        {
            enemy.SetBehavior(new StayAndShootBehavior(enemy, _shootPointOffset, _shootCd, _rocketPrefab));
        }
        else
        {
            enemy.SetBehavior(null);
        }
    }
}
