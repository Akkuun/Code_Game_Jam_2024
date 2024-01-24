using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSoul : MonoBehaviour
{

    public int type = 0;

    void SaveBigSoul()
    {
        PlayerMovement.BigSoulsArray[type] = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject door = GameObject.FindGameObjectWithTag("FinalDoor");
            if (door != null)
            {
                door.GetComponent<FinalDoorScript>().ActivateSoul(type);
            }
                SaveBigSoul();
            Destroy(gameObject);
        }
    }
}
