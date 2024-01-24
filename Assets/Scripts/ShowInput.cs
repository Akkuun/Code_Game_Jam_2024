    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ShowInput : MonoBehaviour
{

    public GameObject input;
    private bool collide = false;


    void Start()
    {
        input.SetActive(false);
    }

    void Update()
    {

        
        if (collide && Input.GetKeyDown(KeyCode.E))
        {
           
            input.SetActive(true);
        }

    }

     private void OnTriggerEnter2D(Collider2D other)
     {
        Debug.Log("test");
        collide = true;

     }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collide = false;
        input.SetActive(false);
    }




}
