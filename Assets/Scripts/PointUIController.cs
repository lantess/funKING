using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointUIController : MonoBehaviour
{
    public GameObject text;

    void Start()
    {
        Vector2 pvSize = gameObject.GetComponent<RectTransform>().sizeDelta;
        float xsize = pvSize.x / 4,
                ysize = pvSize.y / 8;
        float X = -(pvSize.x - xsize) / 2 + xsize * 0.05f,
            Y = (pvSize.y - ysize) / 2 - ysize * 0.1f;
        RectTransform rt = text.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(xsize, ysize);
        rt.localPosition = new Vector2(X, Y);
        text.GetComponent<Text>().fontSize = (int)(pvSize.y / 30);
    }
}
