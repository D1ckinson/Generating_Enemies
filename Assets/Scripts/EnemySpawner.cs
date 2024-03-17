using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Enemy _enemy;

    private float _triggerTime;
    private Bounds _bounds;

    private void Start()
    {
        _bounds = GetComponent<MeshFilter>().mesh.bounds;
        _triggerTime = _delay;
    }

    private void Update()
    {
        if (Time.time >= _triggerTime)
        {
            Enemy enemy = _enemy;
            Vector3 direction = GetMoveDirection().normalized;

            enemy = Instantiate(enemy, GetSpawnPoint(), Quaternion.LookRotation(direction));
            enemy.SetMoveDirection(direction);

            _triggerTime = Time.time + _delay;
        }
    }

    private Vector3 GetPointInBounds(Bounds bounds)
    {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        return new(x, y, z);
    }

    private Vector3 GetSpawnPoint() =>
        CorrectSpawnPoint(GetPointInBounds(_bounds));

    private Vector3 CorrectSpawnPoint(Vector3 spawnPoint)
    {
        spawnPoint.Scale(transform.localScale);
        spawnPoint = transform.rotation * spawnPoint;
        spawnPoint += transform.position;

        return spawnPoint;
    }

    private Vector3 GetMoveDirection()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);

        return new(x, 0, z);
    }
}
