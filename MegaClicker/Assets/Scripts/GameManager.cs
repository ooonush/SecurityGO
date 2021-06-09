using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class GameManager : MonoSingleton<GameManager>
{
    public Device[] Devices;
    public Text PointsInCurrentLevelText;
    public Text PointsText;
    public Text PointsPerSecText;


    //public GameObject Virus;

    public DeviceInfo DeviceInfo;

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
                sum += device.PointsPerSec;
            return sum;
        }
    }

    public Text GemsOnEndEventText;

    [NonSerialized] public int Level = 1;
    public int Gems;
    public Text GemsText;
    public Text LevelText;
    public int MaxPoints => (int)(Level*Level*Mathf.Pow(1.4f, Level) + 50);
    public int maxPoints;

    void Start()
    {
        GemsText.text = Gems.ToString();
        GemsOnEndEventText.text = "";
        SetTexts();
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
        SetTexts();
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
        SetTexts();
        yield return new WaitForSeconds(0.4f);

        IsNewLevelSetting = false;
    }

    Vector2 dPos;

    public Canvas MainCanvas => FindObjectOfType<Canvas>();
    public ParticleSystem TouchParticle;
    private void Update()
    {            
        maxPoints = MaxPoints;
        PointsPerSecText.text = PointsPerSecond.ToString() + $"/min";
    }

    public bool IsNewLevelSetting;

    public void SetTexts()
    {
        LevelText.text = Level.ToString();
        PointsText.text = Points.ToString();
        GemsText.text = Gems.ToString();
    }

    public void AddPoints(int points)
    {
        if (!IsNewLevelSetting)
        {
            PointsCurrentLevel += points;
            Points += points;

            if (PointsCurrentLevel > MaxPoints)
                StartCoroutine(SetNewLevel());
        }
        SetTexts();
    }

    public void AddPointOnClick()
    {
        dPos = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        var touchParticle = Instantiate(TouchParticle, MainCanvas.transform);
        touchParticle.transform.localPosition = (Vector2)Input.mousePosition - dPos;
        
        foreach (var p in FindObjectsOfType<ParticleSystem>())
            if (p.isStopped)
                Destroy(p.gameObject);

        DeviceInfo.gameObject.SetActive(false);
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