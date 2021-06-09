using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Device : MonoBehaviour
{
    public int Level;
    public GameObject AttackScreen;

    public int PointsOnClickInFirstLevel;
    public int PointsPerSecInFirstLevel;
    public int SecurityLevelInFirstLevel;

    public int PointsOnClick => GetPointsOnClick(Level != 0 ? Level : 1);
    public int SecurityLevel => GetSecurityLevel(Level != 0 ? Level : 1);
    public int PointsPerSec => GetPointsPerSec(Level != 0 ? Level : 1);

    public int GetPointsOnClick(int level)
    {
        return PointsOnClickInFirstLevel * (level * level);
    }

    public int GetPointsPerSec(int level)
    {
        return PointsPerSecInFirstLevel * (level * level);
    }

    public int GetSecurityLevel(int level)
    {
        var securityLevel = SecurityLevelInFirstLevel + 5 * level;
        return securityLevel > 100 ? 100 : securityLevel;
    }

    [SerializeField] int pointsPrice;
    public int PointsPrice => pointsPrice * Level * Level + pointsPrice;

    [SerializeField] int gemsPrice;
    public int GemsPrice => gemsPrice * Level * Level + gemsPrice;

    public Button DeviceButton;

    void Start()
    {
        AttackScreen.SetActive(false);
        DeviceButton = gameObject.GetComponent<Button>();
        DeviceButton.onClick.AddListener(OnClickDevice);
    }

    void OnClickDevice()
    {
        GameManager.Instance.DeviceInfo.gameObject.SetActive(false);
        if (EventManager.Instance.ActiveDevice != this)
            GameManager.Instance.DeviceInfo.ActivateBar(this);
    }

    private void Update()
    {
        gameObject.GetComponent<Image>().color = Level == 0 ? 
            new Color(0.3f, 0.3f, 0.3f, 0.5f) :
            new Color(255, 255, 255, 1);
    }
}
