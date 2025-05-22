using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class LaserBeamBehaviour : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private int _damage;
    [SerializeField] private float _beforeDurationTime;
    [SerializeField] private float _width;
    [SerializeField] private Transform _laserHit;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _laserSphere;
    public PlayerType PlayerType { get; set; }


    private void Start()
    {
        _laserHit.gameObject.SetActive(false);
        var laserWidth = _laserHit.transform.localScale;
        laserWidth.x = 0;
        _laserHit.transform.localScale = laserWidth;

        _laserSphere.transform.localScale = Vector3.one * _width;
        BeginLaser();
    }

    private void Update()
    {
        Debug.Log(_laserHit.transform.localScale.x);
    }

    private void BeginLaser()
    {
        _laserSphere.DOScale(0, _beforeDurationTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            _laserHit.gameObject.SetActive(true);
            _laserHit.DOScaleX(_width, _duration / 8).SetEase(Ease.Linear).OnComplete(() =>
            {
                _laserHit.DOScaleX(0, _duration / 2).SetDelay(_duration / 8 * 3).SetEase(Ease.Linear)
                    .OnComplete(() => { Destroy(gameObject); });
            });
        });
    }

    public void HitCallBack(Collider2D other)
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