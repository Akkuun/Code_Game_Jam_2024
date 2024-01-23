using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;
    public float rayDist;
    private bool movingRight = true;
    public Transform groundDetect;

    private bool shouldChangeDirection = false;

    private void Update()
    {
        if (shouldChangeDirection)
        {
            ChangeDirection();
            shouldChangeDirection = false;
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundcheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);

        if (!groundcheck.collider)
        {
            shouldChangeDirection = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemie"))
        {
            shouldChangeDirection = true;
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("Player touché");
            // Appeler fonction pour faire baisser la vie du joueur
        }
        else if (other.CompareTag("Invocation"))
        {
            Debug.Log("Invocation touché");
            Destroy(gameObject);
        }
    }

    private void ChangeDirection()
    {
        if (movingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }
}
