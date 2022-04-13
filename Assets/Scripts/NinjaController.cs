using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public float velocidad = 10f;
    public float jumpForce = 70;
    

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    //constantes
    private const int RUN = 0;
    private const int JUMP = 1;
    private const int DEATH = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
        sr.flipX = false;
        changeAnimation(RUN);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(JUMP);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            changeAnimation(DEATH);
            Time.timeScale = 0;
        }
    }

    private void changeAnimation (int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
