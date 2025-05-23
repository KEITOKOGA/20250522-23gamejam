using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float Speed;
    [SerializeField] private PlayerType type;

    private float _h;
    private float _v;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (type == PlayerType.A)
        {
            _h = Input.GetAxisRaw("Horizontal");
            _v = Input.GetAxisRaw("Vertical");
        }
        else
        {
            _h = Input.GetAxisRaw("Horizontal2");
            _v = Input.GetAxisRaw("Vertical2");
        }
    }

    private void FixedUpdate()
    {
        var input = (Vector2.right * _h + Vector2.up * _v).normalized;
        var velocity = input * Speed;
        rb.AddForce(velocity);

        if (_h != 0 || _v != 0)
        {
            transform.up = input.normalized;
        }
    }
}
