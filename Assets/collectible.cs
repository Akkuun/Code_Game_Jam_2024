using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class collectible : MonoBehaviour
{

    public static event Action onCollected;
    // Start is called before the first frame update
    void Update()
    {
        //transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            //Debug.Log("on rentre");
            Destroy(transform.parent.gameObject);
            onCollected?.Invoke();
        }
    }



}
