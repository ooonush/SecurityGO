using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoSingleton<EventManager>
{
    Device[] devices => MonoSingleton<GameManager>.Instance.Devices;

    //таймер тем меньше чем больше уровень игрока
    UnityAction EventStartTrigger;
    bool IsEventPlaying;
    float EventTimerInSec => 3; // - 0.25f*gameManager.Level*gameManager.Level;

    public Device ActiveDevice;
    public UnityAction ClickOnActiveDeviceTrigger;

    void Start()
    {
        StartCoroutine(EventTriggerCoroutine());
        EventStartTrigger += StartEvent;
        ClickOnActiveDeviceTrigger += ClickOnActiveDevice;
    }

    void StartEvent()
    {
        IsEventPlaying = true;
        ActiveDevice = GetRandomBoughtDevice();
        ActiveDevice.DeviceButton.onClick.AddListener(ClickOnActiveDeviceTrigger);
    }

    public void EndEvent(bool IsWin)
    {
        ActiveDevice.DeviceButton.onClick.RemoveListener(ClickOnActiveDeviceTrigger);
        IsEventPlaying = false;
    }

    void ClickOnActiveDevice()
    {
        //Debug.Log("клик по нужному устройству");
    }

    IEnumerator EventTriggerCoroutine()
    {
        while (true)
            if (!IsEventPlaying)
            {
                yield return new WaitForSeconds(EventTimerInSec);
                EventStartTrigger();
            }
            else yield return new WaitForSeconds(5);
    }

    Device GetRandomBoughtDevice()
    {
        List<Device> boughtDevices = new List<Device>();
        foreach (var device in devices)
            if(device.IsBought)
                boughtDevices.Add(device);

        int randomIndex = (int)Mathf.Round(Random.value * (boughtDevices.Count - 1));
        Device randomDevice = devices[randomIndex];

        return randomDevice;
    }
}