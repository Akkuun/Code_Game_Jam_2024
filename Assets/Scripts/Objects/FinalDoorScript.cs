using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorScript : MonoBehaviour
{

    public GameObject fire;
    public GameObject fireOff;
    public GameObject forest;
    public GameObject forestOff;
    public GameObject ice;
    public GameObject iceOff;

    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        ice.SetActive(PlayerMovement.BigSoulsArray[0]);
        fire.SetActive(PlayerMovement.BigSoulsArray[1]);
        forest.SetActive(PlayerMovement.BigSoulsArray[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerMovement.BigSoulsArray[0] && PlayerMovement.BigSoulsArray[1] && PlayerMovement.BigSoulsArray[2])
        {
            //THE END
            Destroy(portal);
            Destroy(fire);
            Destroy(fireOff);
            Destroy(forest);
            Destroy(forestOff);
            Destroy(ice);
            Destroy(iceOff);
        }
    }

    public void ActivateSoul(int i)
    {
        switch(i)
        {
            case 0:
                ice.SetActive(true); break;

            case 1:
                fire.SetActive(true); break;

            case 2:
                forest.SetActive(true); break;
        }
    }
}
