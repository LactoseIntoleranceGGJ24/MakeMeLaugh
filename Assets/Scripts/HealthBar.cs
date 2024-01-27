using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector2 _offset;

    void Update()
    {
        if (_player != null)
        {
            transform.position = _player.position + (Vector3)_offset;
        }
    }
}