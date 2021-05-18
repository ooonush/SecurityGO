using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Device : MonoBehaviour
{
    public bool IsBought;

    public int PointsOnClick;
    public int SecurityLevel;
    public int PointsPerSecond;
    public int PasswordSecurityLevel;

    public string Password;

    public Button DeviceButton;

    void Start()
    {
        DeviceButton = gameObject.GetComponent<Button>();
    }

}
