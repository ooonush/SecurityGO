using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoSingleton<EventManager>
{
    Device[] devices => MonoSingleton<GameManager>.Instance.Devices;

    public Event CurrentEvent;
    public Event[] Events;

    //таймер тем меньше чем больше уровень игрока
    UnityAction StartEventTrigger;
    bool IsEventPlaying;
    float EventTimerInSec => 3; // - 0.25fgameManager.LevelgameManager.Level;

    public Device ActiveDevice;
    public UnityAction ClickOnActiveDeviceTrigger;

    void Start()
    {
        Events = new Event[] {
            MonoSingleton<PhotoEvent>.Instance,
            MonoSingleton<EventPasswordComplexity>.Instance
        };
        StartCoroutine(EventTriggerCoroutine());
        StartEventTrigger += StartEvent;
        ClickOnActiveDeviceTrigger += ClickOnActiveDevice;
    }

    void StartEvent()
    {
        Debug.Log("клик по нужному устройству");
        IsEventPlaying = true;
        ActiveDevice = GetRandomBoughtDevice();
        ActiveDevice.DeviceButton.onClick.AddListener(ClickOnActiveDeviceTrigger);
        CurrentEvent = GetRandomEvent();
    }

    public void EndEvent(bool IsWin)
    {
        ActiveDevice.DeviceButton.onClick.RemoveListener(ClickOnActiveDeviceTrigger);
        IsEventPlaying = false;
    }

    void ClickOnActiveDevice()
    {
        CurrentEvent.StartEventAction();
        //Debug.Log("клик по нужному устройству");
    }

    IEnumerator EventTriggerCoroutine()
    {
        while (true)
            if (!IsEventPlaying)
            {
                yield return new WaitForSeconds(EventTimerInSec);
                StartEventTrigger();
            }
            else yield return new WaitForSeconds(5);
    }

    Event GetRandomEvent()
    {
        var random = new System.Random();
        return Events[random.Next(0, Events.Length)];
    }

    Device GetRandomBoughtDevice()
    {
        List<Device> boughtDevices = new List<Device>();
        foreach (var device in devices)
            if (device.IsBought)
                boughtDevices.Add(device);

        int randomIndex = (int)Mathf.Round(Random.value * (boughtDevices.Count - 1));
        Device randomDevice = devices[randomIndex];

        return randomDevice;
    }
}