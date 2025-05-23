using UnityEngine;

public class BrockMoveController : MonoBehaviour
{
    public float amplitude = 1f;      // �㉺�̕�
    public float speed = 1f;          // �㉺�̑���
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        float newY = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector2(0, newY);
    }
}
