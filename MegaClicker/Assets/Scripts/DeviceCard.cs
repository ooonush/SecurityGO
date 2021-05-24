using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceCard : MonoBehaviour
{
    public Device Device => MonoSingleton<GameManager>.Instance.Devices[DeviceIndex];
    public int DeviceIndex;
    [SerializeField] List<GameObject> characteristics;

    void Start()
    {
        SetCharacteristicTexts();
    }

    public void SetCharacteristicTexts()
    {
        if (MonoSingleton<GameManager>.Instance != null)
        {
            characteristics[0].GetComponent<Text>().text = Device.PointsPerSecond.ToString();
            characteristics[1].GetComponent<Text>().text = Device.SecurityLevel.ToString();
            characteristics[2].GetComponent<Text>().text = Device.PasswordSecurityLevel.ToString();
            characteristics[3].GetComponent<Text>().text = Device.PointsOnClick.ToString();
        }
    }
}