using UnityEngine;

public static class BehaviorInitializer
{
    public static void InitializeBehavior(Enemy enemy)
    {
        var playerTransform = Player.Instance.transform;

        if (enemy.CompareTag("Follow"))
        {
            enemy.SetBehavior(new FollowingBehavior(enemy));
        }
        else if (enemy.CompareTag("StraightLine"))
        {
            enemy.SetBehavior(new StraightLineMovementBehavior(enemy, 30f));
        }
        else if (enemy.CompareTag("StayAndShoot"))
        {
            enemy.SetBehavior(new StayAndShootBehavior(enemy));
        }
        else
        {
            enemy.SetBehavior(null);
        }
    }
}
