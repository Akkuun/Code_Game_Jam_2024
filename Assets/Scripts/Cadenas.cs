using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


public class Cadenas : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;
    public GameObject circle3;
    public GameObject cam;
    
    void Update()
    {
        
    }
    public void Activate(int soul){

        switch (soul){
            case 1:
                circle1.SetActive(true);
            break;
            case 2:
                circle2.SetActive(true);
            break;
            case 3:
                circle3.SetActive(true);
            break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           if (circle1.activeSelf && circle2.activeSelf && circle3.activeSelf){
                open();
           }
        }
    }
    private void open(){

    }    
}
