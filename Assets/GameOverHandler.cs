using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = ""+PlayerPrefs.GetInt("Points");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onReplayClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void onMenuClick()
    {
        SceneManager.LoadScene("CharacterChoosing");
    }
}
