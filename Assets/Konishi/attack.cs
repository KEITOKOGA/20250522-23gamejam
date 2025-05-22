using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] Transform muzzle = default;
    [SerializeField] GameObject laser = default;
    [SerializeField] float interval = 1f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetButton("Fire1") && timer > interval)
        {
            timer = 0;
            GameObject bullet = Instantiate(laser);
            bullet.transform.position = muzzle.transform.position;
            bullet.transform.up = muzzle.transform.up;
        }
    }
}
