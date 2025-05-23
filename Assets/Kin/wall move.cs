using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallmove : MonoBehaviour
{
    public float amplitude = 1.0f;//è„â∫ïù
    public float speed = 1.0f; //à⁄ìÆÇÃë¨Ç≥
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newx = Mathf.Sin( Time.time * speed ) * amplitude;
        transform.position = startPos + new Vector2(newx,0);

    }
}
