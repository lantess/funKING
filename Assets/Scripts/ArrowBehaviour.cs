using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDown();
    }

    private void moveDown()
    {
        Vector3 pos = transform.position;
        pos.y -= Time.deltaTime * speed;
        transform.position = pos;
    }


}
