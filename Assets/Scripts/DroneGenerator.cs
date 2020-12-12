using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneGenerator : MonoBehaviour
{
    private const int Xborder = 9,
                        Yborder = 5;
    public float delay = 10.0f;
    private float delta = 0.0f;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delta < delay)
            delta += Time.deltaTime;
        else
        {
            delta = 0.0f;
            float x = Random.Range(0, 2) == 0 ? 
                Random.Range(-Xborder - 2, -2) : 
                Random.Range(3, Xborder + 3);
            float y = x < -9 || x > 9 ?
                        Random.Range(-Yborder + 3, Yborder + 2) :
                        Yborder + 2;
            Instantiate(prefab, new Vector3(x, y, 0.0f), Quaternion.identity);
        }
    }


}
