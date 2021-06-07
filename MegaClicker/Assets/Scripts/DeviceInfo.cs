using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceInfo : MonoBehaviour
{
    public Device CurrentDevice;
    public Text PointsPerSecText;
    public Text PointsOnClickText;
    public Text SecurityLevelText;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ActivateBar(Device device)
    {
        gameObject.SetActive(true);
        PointsOnClickText.text = device.PointsOnClick.ToString();
        PointsPerSecText.text = device.PointsPerSec.ToString();
        SecurityLevelText.text = device.SecurityLevel.ToString();
    }
}
