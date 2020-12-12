using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter
{
    public static Text pointText;
    private static int points = 0;

    public static void Add(int x)
    {
        points += x;
        try
        {
            if (pointText == null)
                pointText = GameObject.Find("Points").GetComponent<Text>();
            pointText.text = "Punkty: " + points;
        } catch (Exception e)
        {

        }
    }

    public static int Get()
    {
        return points;
    }

    public static void Reset()
    {
        points = 0;
    }


}
