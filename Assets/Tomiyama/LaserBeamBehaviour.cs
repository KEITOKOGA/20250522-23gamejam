using System.Collections;
using UnityEngine;

public class LaserBeamBehaviour : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private int _damage;
    [SerializeField] private float _beforeDurationTime;
    [SerializeField] private float _width;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _laser;
    [SerializeField] private Transform _laserSphere;
    public PlayerType PlayerType { get; set; }


    private void Start()
    {
        _laser.gameObject.SetActive(false);
        StartCoroutine(BeginLaser());
    }

    private IEnumerator BeginLaser()
    {
        var currentTime = 0f;
        while (currentTime < _beforeDurationTime)
        {
            yield return null;
            currentTime += Time.deltaTime;
            var scale = _laserSphere.localScale;
            scale.x -= _width / _beforeDurationTime * Time.deltaTime / 2;
            scale.y -= _width / _beforeDurationTime * Time.deltaTime / 2;
            _laserSphere.localScale = scale;
        }

        _laser.gameObject.SetActive(true);

        // 発射から徐々に細くなる
        currentTime = 0f;
        yield return new WaitForSeconds(_duration / 2);
        while (currentTime < _duration / 2)
        {
            yield return null;
            currentTime += Time.deltaTime;
            var scale = _laser.localScale;
            scale.x -= _width / _duration * Time.deltaTime;
            _laser.localScale = scale;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<IAttackable>(out var component))
        {
            if (other.gameObject.CompareTag("PlayerA") && PlayerType == PlayerType.B ||
                other.gameObject.CompareTag("PlayerB") && PlayerType == PlayerType.A)
            {
                component.Damage(_damage);
            }
        }
    }
}

public enum LaserType
{
    Red,
    Blue,
    Green,
    Yellow,
}