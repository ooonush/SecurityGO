using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyDeviceCard : MonoBehaviour
{
    public Device CurrentDevice => GameManager.Instance.Devices[DeviceIndex];
    public int DeviceIndex;
    public Text PointsPerSecText;
    public Text PointsOnClickText;
    public Text SecurityLevelText;

    void Start()
    {
        SetBuyDeviceCard();
    }

    void SetBuyDeviceCard()
    {
        PointsOnClickText.text = "+" + (CurrentDevice.GetPointsOnClick(CurrentDevice.Level + 1)
            - CurrentDevice.GetPointsOnClick(CurrentDevice.Level))
            .ToString();

        PointsPerSecText.text = "+" + (CurrentDevice.GetPointsOnClick(CurrentDevice.Level + 1)
            - CurrentDevice.GetPointsOnClick(CurrentDevice.Level))
            .ToString();

        SecurityLevelText.text = "+" + (CurrentDevice.GetSecurityLevel(CurrentDevice.Level + 1)
            - CurrentDevice.GetSecurityLevel(CurrentDevice.Level))
            .ToString();
    }

    public void DeviceLevelUPByPoints()
    {
        if (GameManager.Instance.Points > CurrentDevice.PointsPrice)
            CurrentDevice.Level++;
        SetBuyDeviceCard();
    }

    public void DeviceLevelUPByGems()
    {
        if (GameManager.Instance.Gems > CurrentDevice.GemsPrice)
            CurrentDevice.Level++;
        SetBuyDeviceCard();
    }
}
