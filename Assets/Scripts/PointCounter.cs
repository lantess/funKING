using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter
{
    public static Text pointText;
    private static int points = 0;
    private static int deltaPoints = 0;
    private static int pointsPerBullet = 20;

    public static bool isHit = false;
    public static bool isCorrect = false;

    public static void Add(int x)
    {
        points += x;
        deltaPoints = deltaPoints + x > 0 ?
                        deltaPoints + x : 0;
        try
        {
            if (pointText == null)
                pointText = GameObject.Find("Points").GetComponent<Text>();
            pointText.text = ""+points;
        } catch (Exception e)
        {

        }
    }

    public static int Get()
    {
        return points;
    }

    public static bool HasAmmoToAdd()
    {
        if (deltaPoints > pointsPerBullet)
        {
            deltaPoints -= pointsPerBullet;
            return true;
        }
        return false;
    }

    public static void Reset()
    {
        points = 0;
    }


}
