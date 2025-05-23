using UnityEngine;

public class BrockMoveController : MonoBehaviour
{
    public float amplitude = 1f;      // è„â∫ÇÃïù
    public float speed = 1f;          // è„â∫ÇÃë¨Ç≥
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector2(0, newY);
    }
}
