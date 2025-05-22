using System;
using UnityEngine;

public class LaserHit : MonoBehaviour
{
    LaserBeamBehaviour _laserBeam;

    private void Start()
    {
        _laserBeam = transform.parent.GetComponentInParent<LaserBeamBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _laserBeam.HitCallBack(other);
    }
}