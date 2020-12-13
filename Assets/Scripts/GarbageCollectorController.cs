using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollectorController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag!="GarbageCollector")
            Destroy(collision.gameObject);
    }
}
