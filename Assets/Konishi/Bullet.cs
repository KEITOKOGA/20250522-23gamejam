using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float lifetime = 5f;
    [SerializeField] GameObject player = default;
    // Start is called before the first frame update
    void Start()
    {
        var direction = player.transform.up;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * speed);
        Destroy(this.gameObject,lifetime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerArea")
        {
            Destroy(this.gameObject);
        }
    }
}
