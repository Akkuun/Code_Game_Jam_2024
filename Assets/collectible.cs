using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("toto");
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


}
