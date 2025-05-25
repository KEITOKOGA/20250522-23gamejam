using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject laser;
    [SerializeField] float interval = 1f;
    [SerializeField] private PlayerType _type;

    private CooldownController _cdManager;

    private float _timer;
    void Start()
    {
        _cdManager = FindObjectOfType<CooldownController>();
        _timer = interval;
    }
    void Update()
    {
        _timer += Time.deltaTime;
        var isPressed = (_type == PlayerType.A) ? Input.GetKeyDown(KeyCode.Space) : Input.GetKeyDown(KeyCode.Return);
        if (isPressed && _timer > interval) Shoot();
    }

    private void Shoot()
    {
        _timer = 0;
        var laser = FindAnyObjectByType<TwoPlayerColorController>().GetLaserInfo(_type);
        interval = laser.interval;
        _cdManager.UIStartCooldown(_type, interval);
        var laserPrefab = laser.laserPrefab;
        var bullet = Instantiate(laserPrefab);
        bullet.transform.position = muzzle.transform.position;
        bullet.transform.up = muzzle.transform.up;
        var laserComponent = bullet.GetComponent<LaserBeamBehaviour>();
        laserComponent.PlayerType = _type;
    }
}