﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseCharacterScript : MonoBehaviour
{

    private readonly string selectedCharacter = "SelectedCharacter";


    public void setMaleChar()
    {
        PlayerPrefs.SetInt(selectedCharacter, 0);
        Debug.Log("ADAM JEST GENIALNY" + PlayerPrefs.GetInt(selectedCharacter));
        SceneManager.LoadScene("GameScene");
    }
    public void setFemaleChar()
    {
        PlayerPrefs.SetInt(selectedCharacter, 1);
        Debug.Log("MARCIN JEST GENIALNY" + PlayerPrefs.GetInt(selectedCharacter));
        SceneManager.LoadScene("GameScene");
    }

    public void showCredits()
    {
        Debug.Log("CREDIT SCORE PAGE!");
        SceneManager.LoadScene("Credits");
    }



}
