using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsController : MonoBehaviour
{
    public GameObject hero;
    public Sprite hitpointPrefab;

    private int X,
                Y,
                xOffset,
                size;

    private Stack<GameObject> hitpoints;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 pvSize = gameObject.GetComponent<RectTransform>().sizeDelta;
        size = (int)(pvSize.x * 0.025f);
        xOffset = (int)(size * 1.2f);
        X = (int)(pvSize.x / 2 - xOffset - size*3.4);
        Y = (int)(pvSize.y / 2 - xOffset);
        hitpoints = new Stack<GameObject>();
        for(int i = 0; i <  hero.GetComponent<HeroController>().MaxHitPoints; i++)
        {
            hitpoints.Push(CreateHitPoint());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add()
    {
        hitpoints.Push(CreateHitPoint());
    }

    public void Remove()
    {
        Destroy(hitpoints.Pop());
        X += xOffset;
    }

    private GameObject CreateHitPoint()
    {
        GameObject hp = new GameObject();
        hp.name = "HitPoint";
        Image img = hp.AddComponent<Image>();
        img.sprite = hitpointPrefab;
        img.color = new Color(255, 0, 0);
        RectTransform rt = hp.GetComponent<RectTransform>();
        rt.SetParent(transform);
        rt.pivot = new Vector2(0, 1);
        rt.sizeDelta = new Vector2(size, size);
        rt.localPosition = new Vector3(X, Y, 0);
        X -= xOffset;
        return hp;
    }
}
