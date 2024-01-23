using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    protected bool zInteracted = false;

    protected override void OnCollide(GameObject collidedObject)
    {
        Debug.Log("Collinding with " + collidedObject);
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract(collidedObject);
        }
    }

    protected virtual void OnInteract(GameObject InteractedObject)
    {
        if (!zInteracted)
        {
            zInteracted = true;
            Debug.Log("Interact with " + name);
        }
    }
}
