using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float jumpForce = 50;
    bool is_ground;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        is_ground = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_ground == true)
        {
            Jump();
        }
    }

    public void Jump()
    {
        is_ground = false;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("suelo"))
        {
            is_ground = true;

        }
    }

}
