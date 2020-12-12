using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBarController : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float y = -0.47f,
                    offset = -0.05f;
    private int maxAmmo = 20;
    private Stack<GameObject> ammos;

    // Start is called before the first frame update
    void Start()
    {
        ammos = new Stack<GameObject>();
        for(int i = 0; i < maxAmmo; i++)
        {
            Add();
        }
    }

    public void Add()
    {
        if (ammos.Count == maxAmmo)
            return;
        ammos.Push(Instantiate(bulletPrefab, new Vector3(0.0f,y,0.0f), Quaternion.identity));
        ammos.Peek().transform.parent = this.transform;
        ammos.Peek().transform.localPosition = new Vector3(0.0f, y, 0.0f);
        y -= offset;
    }

    public void Remove()
    {
        if (ammos.Count > 0)
        {
            Destroy(ammos.Pop());
            y += offset;
        }
    }

    public bool Has()
    {
        return ammos.Count > 0;
    }
}
