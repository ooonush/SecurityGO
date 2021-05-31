using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoSingleton<GameManager>
{
    public Device[] Devices;
    public Text PointsInCurrentLevelText;
    public Text PointsText;
    public Text PointsPerSecText;

    //public GameObject Virus;

    public int PointsCurrentLevel;
    public int Points;
    public int PointsOnClick
    {
        get
        {
            var sum = 0;
            foreach (var device in BoughtDevices())
                sum += device.PointsOnClick;
            return sum;
        }
    }
    public int PointsPerSecond
    {
        get
        {
            var sum = 0;
            if (Devices != null)
                foreach (var device in Devices)
                    if (device != null && device.Level > 0)
                        sum += device.PointsPerSecond;
            return sum;
        }
    }

    public int Level;
    public Text LevelText;
    public int MaxPoints => (int)(Level*16*Mathf.Pow(1.13f, Level));
    public int maxPoints;

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

    public IEnumerator SetNewLevel()
    {
        IsNewLevelSetting = true;

        PointsCurrentLevel = MaxPoints;
        yield return new WaitForSeconds(0.4f);
        PointsCurrentLevel = 0;
        Level++;
        LevelText.text = Level.ToString();
        yield return new WaitForSeconds(0.4f);

        IsNewLevelSetting = false;
    }

    private void Update()
    {
        maxPoints = MaxPoints;
        PointsPerSecText.text = PointsPerSecond.ToString() + $"/min";
    }

    public bool IsNewLevelSetting;

    public void AddPoints(int points)
    {
        if (!IsNewLevelSetting)
        {
            PointsCurrentLevel += points;
            Points += points;
            PointsInCurrentLevelText.text = Points.ToString();

            if (PointsCurrentLevel > MaxPoints)
                StartCoroutine(SetNewLevel());
        }
        PointsText.text = Points.ToString();
    }

    public void AddPointOnClick()
    {
        AddPoints(PointsOnClick);
    }

    public Device[] BoughtDevices()
    {
        List<Device> boughtDevices = new List<Device>();
        foreach (var device in Devices)
            if (device.Level > 0)
                boughtDevices.Add(device);
        return boughtDevices.ToArray();
    }
}