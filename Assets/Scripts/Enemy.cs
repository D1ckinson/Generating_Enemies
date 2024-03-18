using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
        transform.LookAt(_target);
    }

    public void SetTarget(Transform target) =>
        _target = target;
}
