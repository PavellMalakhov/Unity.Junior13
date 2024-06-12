using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionZ = Input.GetAxis("Vertical");

        if (directionZ == 0 && directionX == 0)
        {
            return;
        }

        float distanceX = _moveSpeed * directionX * Time.deltaTime;
        float distanceZ = _moveSpeed * directionZ * Time.deltaTime;

        transform.Translate(distanceX * Vector3.right);
        transform.Translate(distanceZ * Vector3.forward);
    }
}
