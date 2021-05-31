using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Device : MonoBehaviour
{
    public int Level;

    public int PointsOnClick;
    public int SecurityLevel;
    public int PointsPerSecond;

    public Button DeviceButton;

    void Start()
    {
        DeviceButton = gameObject.GetComponent<Button>();
    }

}
