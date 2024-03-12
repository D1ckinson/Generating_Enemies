using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update() =>
        transform.Translate(_speed * Time.deltaTime * transform.forward);
}
