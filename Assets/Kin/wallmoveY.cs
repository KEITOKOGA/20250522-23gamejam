using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallmoveY : MonoBehaviour
{
    public float amplitude = 1.0f;//上下幅
    public float speed = 1.0f; //移動の速さ
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newx = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector2(0,newx);

    }
}
