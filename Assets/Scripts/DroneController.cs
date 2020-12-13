using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public GameObject target;
    public float speed = 2.0f;
    public float angle;
    public float rotSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        Vector3 vec = target.transform.position - this.transform.position;
        angle = Mathf.Atan2(vec.x, vec.y);
        rotSpeed = Random.Range(15.0f, 90.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += Time.deltaTime * speed * Mathf.Sin(angle);
        pos.y += Time.deltaTime * speed * Mathf.Cos(angle);
        transform.position = pos;
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z += Time.deltaTime * rotSpeed;
        transform.rotation = Quaternion.Euler(rot);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Drone")
        {
            return;
        }
        //TODO: Glitch na zniszczenie
        GameObject.Destroy(this.gameObject);
    }
}
