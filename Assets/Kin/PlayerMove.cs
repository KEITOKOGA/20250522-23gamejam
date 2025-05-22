using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float Speed;    
    [SerializeField] private float rotateSpeed;
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
            var addV = 0;
            if (Input.GetKey(KeyCode.Keypad5)) addV--;
            else if (Input.GetKey(KeyCode.Keypad8)) addV++;
            _v = addV;
            
            var addH = 0;
            if (Input.GetKey(KeyCode.Keypad4)) addH--;
            else if (Input.GetKey(KeyCode.Keypad6)) addH++;
            _h = addH;
        }
    }

    private void FixedUpdate()
    {
        var input = (Vector2.right * _h + Vector2.up * _v).normalized;
        var velocity = input * Speed;
        rb.AddForce(velocity);

        if (_h != 0 || _v != 0)
        {
            transform.up = input.normalized * rotateSpeed;
        }
    }

}
public enum PlayerType
{
    A,
    B,
}


