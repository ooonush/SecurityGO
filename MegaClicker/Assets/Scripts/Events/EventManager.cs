using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoSingleton<EventManager>
{
    Device[] devices => MonoSingleton<GameManager>.Instance.Devices;

    //������ ��� ������ ��� ������ ������� ������
    UnityAction StartEventTrigger;
    bool IsEventPlaying;
    float EventTimerInSec => 3; // - 0.25f*gameManager.Level*gameManager.Level;

    public Device ActiveDevice;
    public UnityAction ClickOnActiveDeviceTrigger;

    void Start()
    {
        StartCoroutine(EventTriggerCoroutine());
        StartEventTrigger += StartEvent;
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
        //Debug.Log("���� �� ������� ����������");
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