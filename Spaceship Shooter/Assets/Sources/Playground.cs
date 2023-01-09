using UnityEngine;

public class Playground : MonoBehaviour
{
    public static Playground Instance { get; private set; }

    public float MaxX { get; private set; }
    public float MaxY { get; private set; }

    private Vector3 _center;
    private Vector3 _bounds;

    private float _camOrthSize => Camera.main.orthographicSize;
    private float _aspectRatio => Camera.main.aspect;

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

        MaxY = _camOrthSize;
        MaxX = MaxY * _aspectRatio;

        _center = Vector3.zero;
        _bounds = new Vector3(MaxX, 0.01f, MaxY) * 2;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_center, _bounds);
    }
}
