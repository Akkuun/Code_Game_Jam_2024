using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    private Rigidbody2D rb;

    public float speed;
    
    private Transform currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB;
    }

    // Update is called once per frame
    void Update()
    {
        // Déplace l'ennemi vers la cible
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed *3 );

        // Vérifie si l'ennemi a atteint la cible, puis change la cible
        if (Vector3.Distance(transform.position, currentPoint.position) < 0.1f)
        {
            ChangerCible();
        }


    }

    void ChangerCible()
    {
        // Change la cible en fonction de la position actuelle
        if (currentPoint == PointA)
        {
            currentPoint = PointB;
        }
        else
        {
            currentPoint = PointA;
        }
    }

   
}
