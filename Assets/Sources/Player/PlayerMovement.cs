using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private float _xInput;
    private float _yInput;

    private Vector3 _movementDirection;

    private Rigidbody Rb => Player.Instance.PlayerRb;

    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        _yInput = Input.GetAxis("Vertical");

        _movementDirection = new Vector3(_xInput, 0, _yInput);

        KeepInBounds();
    }

    private void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + _movementDirection * (_moveSpeed * Time.fixedDeltaTime));
    }

    private void KeepInBounds()
    {
        if (transform.position.x > Playground.Instance.MaxX)
        {
            transform.position = new Vector3(Playground.Instance.MaxX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -Playground.Instance.MaxX)
        {
            transform.position = new Vector3(-Playground.Instance.MaxX, transform.position.y, transform.position.z);
        }

        if (transform.position.z > Playground.Instance.MaxY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Playground.Instance.MaxY);
        }
        else if (transform.position.z < -Playground.Instance.MaxY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -Playground.Instance.MaxY);
        }
    }
}
