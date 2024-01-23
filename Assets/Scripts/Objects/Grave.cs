using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : InteractableObject
{
    public GameObject enemyPrefab;

    protected override void OnInteract(GameObject InteractedObject)
    {
        if (!zInteracted)
        {
            GameObject o = Instantiate(enemyPrefab, new Vector3(transform.position.x + InteractedObject.transform.localScale.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
            o.transform.localScale *= InteractedObject.transform.localScale.x < 0 ? -1 : 1;
            Debug.Log(o.transform.localScale);
            base.OnInteract(InteractedObject); // Appel à la classe parent
            Destroy(gameObject);
        }
    }
}
