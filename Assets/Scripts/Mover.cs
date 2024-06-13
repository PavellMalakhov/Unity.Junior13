using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _moveSpeed;
    private Vector3 _direction;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _direction = new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));

        if (_direction == null)
        {
            return;
        }

        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }
}
