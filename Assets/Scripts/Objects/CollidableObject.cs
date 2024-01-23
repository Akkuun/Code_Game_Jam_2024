using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    private Collider2D zCollider;
    [SerializeField]
    private ContactFilter2D zFilter;
    private List<Collider2D> zCollidedObjects = new List<Collider2D>(1);

    // Start is called before the first frame update
    protected virtual void Start()
    {
        zCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        zCollider.Overlap(zFilter, zCollidedObjects);
        foreach(var o in zCollidedObjects)
        {
            OnCollide(o.gameObject);
        }
    }

    protected virtual void OnCollide(GameObject collidedObject)
    {
        Debug.Log("Collide with " + collidedObject.name);
    }
}
