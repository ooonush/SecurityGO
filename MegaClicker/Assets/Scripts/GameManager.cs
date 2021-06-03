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
            var sum = 1;
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
            foreach (var device in BoughtDevices())
                sum += device.PointsPerSecond;
            return sum;
        }
    }

    public Text GemsOnEndEventText;

    public int Level;
    public int Gems;
    public Text GemsText;
    public Text LevelText;
    public int MaxPoints => (int)(Level*16*Mathf.Pow(1.13f, Level));
    public int maxPoints;

    void Start()
    {
        GemsText.text = Gems.ToString();
        GemsOnEndEventText.text = "";
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

    public IEnumerator AddGems(int gems)
    {
        if (gems > 0)
            GemsOnEndEventText.text = "+" + gems;
        else
            GemsOnEndEventText.text = "-" + gems;
        Gems += gems;
        if (Gems < 0)
            Gems = 0;
        GemsText.text = Gems.ToString();
        yield return new WaitForSeconds(1);
        GemsOnEndEventText.text = "";
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