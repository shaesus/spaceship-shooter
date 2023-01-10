using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Object SpawnPrefab(Object prefab, Vector3 position, Quaternion rotation)
    {
        return Instantiate(prefab, position, rotation);
    }

    public static Quaternion CalculateRotation(Vector3 _direction)
    {
        var angle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, angle, 0);
    }

    public static void DestroyGO(GameObject obj)
    {
        Destroy(obj);
    }
}
