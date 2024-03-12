using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectPrefab;
    [SerializeField] private float _delay;

    private float _triggerTime;
    private float _maxAngle = 360;
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
            Instantiate(_gameObjectPrefab, GetSpawnPoint(), CalculateQuaternion());
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

    private Quaternion CalculateQuaternion()
    {
        float angle = Random.Range(0, _maxAngle);
        Quaternion quaternion = Quaternion.Euler(0, angle, 0);

        return quaternion;
    }
}
