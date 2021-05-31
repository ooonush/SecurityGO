using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoSingleton<EventManager>
{
    Device[] devices => GameManager.Instance.Devices;

    public Event CurrentEvent = null;
    public Event[] Events;

    //таймер тем меньше чем больше уровень игрока
    UnityAction StartEventTrigger;
    bool IsEventPlaying;
    float EventTimerInSec => 3; // - 0.25fgameManager.LevelgameManager.Level;

    public Device ActiveDevice = null;
    public UnityAction ClickOnActiveDeviceTrigger;

    void Start()
    {
        Events = new Event[] {
            //MonoSingleton<PhotoEvent>.Instance,
            //MonoSingleton<EventPasswordComplexity>.Instance,
            MonoSingleton<PostPhotoEvent>.Instance
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
        ActiveDevice = null;
        CurrentEvent = null;

        Debug.Log("End");
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
        var boughtDevices =  GameManager.Instance.BoughtDevices();

        int randomIndex = (int)Mathf.Round(Random.value * (boughtDevices.Length - 1));
        Device randomDevice = devices[randomIndex];

        return randomDevice;
    }
}