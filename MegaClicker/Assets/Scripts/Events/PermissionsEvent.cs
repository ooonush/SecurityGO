using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermissionsEvent : Event
{
    [SerializeField] Text EventName;
    [SerializeField] List<Button> PermissionButtons;
    [SerializeField] GameObject EventPanel;

    private List<Application> applications = new List<Application>();
    private Application currentApp;
    private int userPermissionCombination;

    void Start()
    {
        EventPanel.SetActive(false);

        Application Camera = new Application("Камера",
        (int)(Permissions.Camera | Permissions.Microphone | Permissions.Memory | Permissions.Flashlight));

        Application FlashLight = new Application("Фонарик",
            (int)Permissions.Flashlight);

        applications.Add(Camera);
        applications.Add(FlashLight);

        StartEventAction += StartPermissionsEvent;

        StartEventAction();
    }

    private void StartPermissionsEvent()
    {
        EventPanel.SetActive(true);

        userPermissionCombination = 0;
        currentApp = applications[UnityEngine.Random.Range(0, applications.Count)];
        EventName.text = currentApp.appName;

        foreach(var btn in PermissionButtons)
        {
            btn.GetComponent<Image>().color = Color.white;
            btn.interactable = true;
        }
    }

    public void EndExampleEvent(bool isWin) 
    {
        EventPanel.SetActive(false);

        Debug.Log("EventEnded");

        base.EndEvent(isWin);
    }

    public void GivePermission(Button btn)
    {
        btn.GetComponent<Image>().color = Color.green;
        btn.interactable = false;

        switch (btn.name)
        {
            case "LocationBtn":
                userPermissionCombination += (int)Permissions.Location;
                break;
            case "CameraBtn":
                userPermissionCombination += (int)Permissions.Camera;
                break;
            case "ContactsBtn":
                userPermissionCombination += (int)Permissions.Contacts;
                break;
            case "MicrophoneBtn":
                userPermissionCombination += (int)Permissions.Microphone;
                break;
            case "MessagesBtn":
                userPermissionCombination += (int)Permissions.Messages;
                break;
            case "MemoryBtn":
                userPermissionCombination += (int)Permissions.Memory;
                break;
            case "FlashBtn":
                userPermissionCombination += (int)Permissions.Flashlight;
                break;
        }

        if (userPermissionCombination == currentApp.permissionsCombination)
        {
            EndExampleEvent(true);
        }

        if (userPermissionCombination > currentApp.permissionsCombination)
        {
            EndExampleEvent(false);
        }

        Debug.Log(userPermissionCombination);
    }
}

public class Application 
{
    public string appName { get; private set; }
    public int permissionsCombination { get; private set; }

    public Application(string name, int combination)
    {
        appName = name;
        permissionsCombination = combination;
    }
}

[Flags]
public enum Permissions
{
    Location = 0x1,
    Camera = 0x2,
    Contacts = 0x4,
    Microphone = 0x8,
    Messages = 0x10,
    Memory = 0x20,
    Flashlight = 0x40
}
