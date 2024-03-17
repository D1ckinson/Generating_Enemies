using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _moveDirection;

    private void FixedUpdate() =>
        transform.position += _speed * _moveDirection;

    public void SetMoveDirection(Vector3 direction) =>
        _moveDirection = direction;
}
