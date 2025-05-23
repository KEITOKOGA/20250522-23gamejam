using UnityEngine;

public class PlayerFocus : MonoBehaviour
{
    private LineRenderer _lr;

    private void Start()
    {
        _lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _lr.SetPosition(0, transform.up * 500 + transform.position);
        _lr.SetPosition(1, transform.position);
    }
}
