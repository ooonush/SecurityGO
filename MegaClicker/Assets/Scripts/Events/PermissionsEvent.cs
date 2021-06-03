using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermissionsEvent : Event
{
    [SerializeField] Text EventName;
    [SerializeField] Button[] PermissionButtons;
    [SerializeField] GameObject PermissionButtonsPanel;
    [SerializeField] GameObject EventPanel;

    private List<Application> applications = new List<Application>();
    private Application currentApp;
    private int userPermissionCombination;

    bool isEnding;

    void Start()
    {
        EventPanel.SetActive(false);
        PermissionButtons = PermissionButtonsPanel.gameObject.GetComponentsInChildren<Button>();
        Application Camera = new Application("������",
        (int)(Permissions.Camera | Permissions.Microphone | Permissions.Memory | Permissions.Flashlight));

        Application FlashLight = new Application("�������",
            (int)Permissions.Flashlight);

        applications.Add(Camera);
        applications.Add(FlashLight);

        StartEventAction += StartPermissionsEvent;
    }

    private void StartPermissionsEvent()
    {
        EventPanel.SetActive(true);
        isEnding = false;
        userPermissionCombination = 0;
        currentApp = applications[UnityEngine.Random.Range(0, applications.Count)];
        EventName.text = currentApp.appName;

        foreach(var btn in PermissionButtons)
        {
            btn.GetComponent<Image>().color = Color.white;
            btn.interactable = true;
        }
    }

    IEnumerator WaitAndEnd()
    {
        isEnding = true;
        yield return new WaitForSeconds(1);
        EventPanel.SetActive(false);
        this.EndEvent(true);
    }

    public void EndExampleEvent(bool isWin) 
    {
        StartCoroutine(WaitAndEnd());
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

        if (!isEnding)
        {
            if (userPermissionCombination == currentApp.permissionsCombination)
            {
                EndExampleEvent(true);
            }

            if (userPermissionCombination > currentApp.permissionsCombination)
            {
                EndExampleEvent(false);
            }
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
