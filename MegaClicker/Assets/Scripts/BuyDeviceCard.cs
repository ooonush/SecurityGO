using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyDeviceCard : MonoBehaviour
{
    public Device CurrentDevice => GameManager.Instance.Devices[DeviceIndex];
    public int DeviceIndex;
    public Text DeviceLevel;
    public Text PointsPerSecText;
    public Text PointsOnClickText;
    public Text SecurityLevelText;

    public Text BuyByPointsText;
    public Text BuyByGemsText;


    private void Update()
    {
        if (CurrentDevice.PointsPrice > GameManager.Instance.Points &&
            CurrentDevice.GemsPrice > GameManager.Instance.Gems)
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
        else
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 1);
    }

    void Start()
    {
        SetBuyDeviceCard();
    }

    void SetBuyDeviceCard()
    {
        PointsOnClickText.text = CurrentDevice.PointsOnClick + "  +" + (CurrentDevice.GetPointsOnClick(CurrentDevice.Level + 1)
            - CurrentDevice.GetPointsOnClick(CurrentDevice.Level))
            .ToString();

        PointsPerSecText.text = CurrentDevice.PointsPerSec + "  +" + (CurrentDevice.GetPointsPerSec(CurrentDevice.Level + 1)
            - CurrentDevice.GetPointsPerSec(CurrentDevice.Level))
            .ToString();

        if (CurrentDevice.SecurityLevel == 100)
            SecurityLevelText.text = "MAX(100)";
        else
            SecurityLevelText.text = CurrentDevice.SecurityLevel + "  +" + (CurrentDevice.GetSecurityLevel(CurrentDevice.Level + 1)
                - CurrentDevice.GetSecurityLevel(CurrentDevice.Level))
                .ToString();

        Debug.Log(CurrentDevice.SecurityLevel);

        DeviceLevel.text = CurrentDevice.Level.ToString();

        GameManager.Instance.SetTexts();

        BuyByPointsText.text = CurrentDevice.PointsPrice.ToString();
        BuyByGemsText.text = CurrentDevice.GemsPrice.ToString();
    }

    public void DeviceLevelUPByPoints()
    {
        if (GameManager.Instance.Points > CurrentDevice.PointsPrice)
        {
            GameManager.Instance.Points -= CurrentDevice.PointsPrice;
            CurrentDevice.Level++;
            SetBuyDeviceCard();
        }
    }

    public void DeviceLevelUPByGems()
    {
        if (GameManager.Instance.Gems > CurrentDevice.GemsPrice)
        {
            GameManager.Instance.Gems -= CurrentDevice.GemsPrice;
            CurrentDevice.Level++;
            SetBuyDeviceCard();
        }
    }
}
