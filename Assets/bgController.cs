using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgController : MonoBehaviour
{
    private Color[] colors =
    {
        new Color(1.0f, 242.0f/255.0f, 0.0f),
        new Color(74.0f/255.0f, 0.0f, 109.0f/255.0f)
    };

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = colors[PlayerPrefs.GetInt("SelectedCharacter")];
    }
}
