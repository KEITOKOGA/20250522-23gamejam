using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject laser;
    [SerializeField] float interval = 1f;
    [SerializeField] private PlayerType _type;

    private float _timer;
    void Start()
    {
        _timer = interval;
    }
    void Update()
    {
        _timer += Time.deltaTime;
        var isPressed = (_type == PlayerType.A) ? Input.GetKeyDown(KeyCode.Space) : Input.GetKeyDown(KeyCode.RightShift);
        if (isPressed && _timer > interval) Shoot();
    }

    private void Shoot()
    {
        _timer = 0;
        var laserType = FindAnyObjectByType<TwoPlayerColorController>().GetLaserPrefab(_type);
        var bullet = Instantiate(laserType);
        bullet.transform.position = muzzle.transform.position;
        bullet.transform.up = muzzle.transform.up;
        var laserComponent = bullet.GetComponent<LaserBeamBehaviour>();
        laserComponent.PlayerType = _type;
    }
}