using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusEvent : MonoSingleton<VirusEvent>
{
    GameEventsManager eventsManager => MonoSingleton<GameEventsManager>.Instance;
    GameManager gameManager => MonoSingleton<GameManager>.Instance;
    Device[] devices => MonoSingleton<GameManager>.Instance.Devices;

    public int ClickCountToStop;
    public int DeviceIndex;
    public GameObject Virus;

    public bool IsActive = false;

    private void Start()
    {
        gameManager.Virus.SetActive(false);
    }

    void ClickDevice()
    {
        if (ClickCountToStop <= 0)
            EndVirusEvent();
        Debug.Log("Click");
        ClickCountToStop--;
        
    }

    public void EndVirusEvent()
    {
        IsActive = false;
        eventsManager.EventIsPlaying = false;
        gameManager.Virus.SetActive(false);
    }

    public void StartVirusEvent()
    {
        Debug.Log("Start");
        IsActive = true;
        ClickCountToStop = 10;
        DeviceIndex = GetRandomDeviceIndex();
        devices[DeviceIndex].DeviceButton.onClick.AddListener(ClickDevice);
        gameManager.Virus.SetActive(true);
        gameManager.Virus.transform.position = devices[DeviceIndex].transform.position;
    }

    public int GetRandomDeviceIndex()
    {
        List<int> boughtDevicesIndex = new List<int>();
        for (int i = 0; i < devices.Length; i++)
            if (devices[i].IsBought)
                boughtDevicesIndex.Add(i);
        Debug.Log(boughtDevicesIndex.Count);
        int randomIndex = (int)Mathf.Round(Random.value * (boughtDevicesIndex.Count - 1));

        return boughtDevicesIndex[randomIndex];
    }
}