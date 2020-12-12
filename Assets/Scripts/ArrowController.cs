﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject border;
    public GameObject _prefab;
    public static float BPM = 125.0f;
    public static float[] borders = { 0.1f, 0.4f, 0.9f, 1.0f };
    public float bitsPerArrow = 4.0f;
    public float Timing { get => BPM / 60.0f / bitsPerArrow; }
    private float deltaTime = 0.0f;
    private Queue<GameObject> arrows_right,
                                arrows_left;
    private KeyCode[] keys; 

    // Start is called before the first frame update
    void Start()
    {
        arrows_right = new Queue<GameObject>();
        arrows_left = new Queue<GameObject>();
        keys = new KeyCode[] { KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow };
    }

    // Update is called once per frame
    void Update()
    {
        createNewArrow();
        removeMissed();
        listenKeys();
        
    }

    private void createNewArrow()
    {
        if (deltaTime < Timing)
            deltaTime += Time.deltaTime;
        else
        {
            deltaTime = 0.0f;
            float r = Random.Range(0, 4);
            arrows_right.Enqueue(Instantiate(_prefab, new Vector3(8.0f, 6.0f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f * r)));
            arrows_left.Enqueue(Instantiate(_prefab, new Vector3(-8.0f, 6.0f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f * r)));
        }
    }

    private void removeMissed()
    {
        if (arrows_right.Count > 0)
        {
            if (arrows_right.Peek().transform.position.y < border.transform.position.y - border.transform.localScale.y)
            {
                GameObject.Destroy(arrows_right.Dequeue());
                GameObject.Destroy(arrows_left.Dequeue());
            }
        }
    }

    private void listenKeys()
    {
        for(int i = 0; i <keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]))
            {
                if(arrows_right.Count > 0)
                {
                    GameObject arr = arrows_right.Dequeue();
                    if (compare(arr, i))
                    {
                        float prec = border.transform.position.y - arr.transform.position.y;
                        Debug.Log("Precyzja: " + prec);
                    }
                    else
                    {
                        Debug.Log("Zła strzałka.");
                    }
                    GameObject.Destroy(arr);
                    GameObject.Destroy(arrows_left.Dequeue());
                }
                else
                {
                    Debug.Log("No arrow");
                }
            }
        }
    }

    private bool compare(GameObject arr, int key)
    {
        return arr.transform.rotation.eulerAngles.z == 90.0f * key;
    }
}
