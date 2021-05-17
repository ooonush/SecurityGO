using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VirusEvent : MonoSingleton<VirusEvent>
{
    GameManager gameManager => MonoSingleton<GameManager>.Instance;
    Device[] devices => MonoSingleton<GameManager>.Instance.Devices;

    public int ClickCountToStop;
    public int DeviceIndex;
    public GameObject Virus;

    public bool IsActive = false;
    public UnityAction OnEndVirusEvent;

    private void Start()
    {
        gameManager.Virus.SetActive(false);
        OnEndVirusEvent += StopVirusEvent;
    }

    void ClickDevice()
    {
        if (ClickCountToStop <= 0)
            OnEndVirusEvent();
        Debug.Log("Click");
        ClickCountToStop--;
    }

    public void StopVirusEvent()
    {
        Debug.Log("End");
        IsActive = false;
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