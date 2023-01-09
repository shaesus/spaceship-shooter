using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private float _xInput;
    private float _yInput;

    private Vector3 _movement;

    private Rigidbody _rb => Player.Instance.PlayerRb;

    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        _yInput = Input.GetAxis("Vertical");

        _movement = new Vector3(_xInput, 0, _yInput);

        CheckBounds();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * (_moveSpeed * Time.fixedDeltaTime));
    }

    private void CheckBounds()
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
