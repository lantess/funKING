using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetMeBackToMenu : MonoBehaviour
{
    public void onMenuClick()
    {
        SceneManager.LoadScene("CharacterChoosing");
    }
}
