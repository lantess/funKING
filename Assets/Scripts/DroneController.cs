﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public GameObject target;
    public float speed = 2.0f;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 vec = target.transform.position - this.transform.position;
        angle = Mathf.Atan2(vec.x, vec.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += Time.deltaTime * speed * Mathf.Sin(angle);
        pos.y += Time.deltaTime * speed * Mathf.Cos(angle);
        transform.position = pos;
    }
}