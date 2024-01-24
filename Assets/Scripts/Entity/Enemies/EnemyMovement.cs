using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 8f;
    private float lifetime = 5f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb; // Reference for enemy's rigidBody

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().flipX = true;
        //transform.position = new Vector3(transform.position.x + (transform.localScale.x / 2) * playerRbRef.localScale.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
        rb.velocity = new Vector2(speed * transform.localScale.x, rb.velocity.y);
        if(rb.velocity.x* rb.velocity.x > 0.1f)
        {
            GetComponent<Animator>().SetBool("isMoving", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", true);
        }

        if (rb.velocity.x > 0)
        {
            //GetComponent<SpriteRenderer>().flipX = true;
        }

        if (rb.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
    }
}
