using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoSingleton<GameManager>
{
    public Device[] Devices;
    public Text PointsText;
    public GameObject Virus;

    public int PointsCurrentLevel;
    public int Points;
    public int PointsOnClick
    {
        get
        {
            var sum = 0;
            foreach (var device in Devices)
                if (device.IsBought)
                    sum += device.PointsOnClick;
            return sum;
        }
    }
    public int PointsPerSecond
    {
        get
        {
            var sum = 0;
            foreach (var device in Devices)
                if (device.IsBought)
                    sum += device.PointsPerSecond;
            return sum;
        }
    }

    public int Level;
    public int MaxPoints => Level*5;

    void Start()
    {
        StartCoroutine(AddPointsPerSecond());
    }

    public IEnumerator AddPointsPerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            AddPoints(PointsPerSecond);
        }
    }

    public void AddPoints(int points)
    {
        PointsCurrentLevel += points;
        if (PointsCurrentLevel > MaxPoints)
        {
            Level++;
            PointsCurrentLevel = 0;
        }
        Points += points;
        PointsText.text = Points.ToString();
    }

    public void AddPointOnClick()
    {
        AddPoints(PointsOnClick);
    }
}