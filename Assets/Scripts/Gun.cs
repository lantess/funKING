﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 15f;

    private Vector3 target;
    public GameObject crosshair;
    public GameObject bulletStart;
    public GameObject ammoBar;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);
        Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();

        fire(direction, rotationZ);
    }


    private void fire(Vector2 direction, float rotationZ)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammoBar.GetComponent<AmmoBarController>().Has())
            {
                GameObject b = Instantiate(bullet) as GameObject;
                b.transform.position = bulletStart.transform.position;
                b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                ammoBar.GetComponent<AmmoBarController>().Remove();
            }
        }

    }
}
