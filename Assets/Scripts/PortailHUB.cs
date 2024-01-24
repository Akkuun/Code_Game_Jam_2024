using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortailHUB : MonoBehaviour
{
    private bool ok = false;
    public int destination;


  
    void Start()
    {
        
    }

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && ok)
        {
            if (destination == 1)
            {
                SceneManager.LoadScene("Thi-Desert");
            }
            else if( destination == 2)
            {
                SceneManager.LoadScene("Thi-Glace");
            }
            else if (destination ==3)
            {
                SceneManager.LoadScene("Thi-Forest");
            }
            else if (destination == 0)
            {
                SceneManager.LoadScene("HUB");
            }
            
           

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            ok = true;
        

       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ok = false;
    }
}
