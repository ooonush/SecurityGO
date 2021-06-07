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

    public int PointsOnClick => GetPointsOnClick(Level);
    public int SecurityLevel => GetSecurityLevel(Level);
    public int PointsPerSec => GetPointsPerSec(Level);

    public int GetPointsOnClick(int level)
    {
        return (int)(PointsOnClickInFirstLevel * level * 2 * level);
    }

    public int GetPointsPerSec(int level)
    {
        return (int)(PointsOnClickInFirstLevel * level * 2 * level);
    }

    public int GetSecurityLevel(int level)
    {
        return (int)(PointsOnClickInFirstLevel * level * 2 * level);
    }

    [SerializeField] int pointsPrice;
    public int PointsPrice => (int)(pointsPrice * Level * Level * 3);

    [SerializeField] int gemsPrice;
    public int GemsPrice => (int)(gemsPrice * Level * Level * 3);

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
            new Color(255, 255, 255, 0.4f) :
            new Color(255, 255, 255, 1);
    }
}
