using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 8f;
    [SerializeField] private Rigidbody2D rb; // Reference for enemy's rigidBody

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(transform.position.x + (transform.localScale.x / 2) * playerRbRef.localScale.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * transform.localScale.x, rb.velocity.y);
    }
}
