using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Device : MonoBehaviour
{
    public int Level;

    public int PointsOnClickInFirstLevel;
    public int PointsPerSecInFirstLevel;
    public int SecurityLevelInFirstLevel;

    public int PointsOnClick => GetPointsOnClick(Level);
    public int SecurityLevel => GetSecurityLevel(Level);
    public int PointsPerSecond => GetPointsPerSec(Level);

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

    int pointsPrice;
    public int PointsPrice => (int)(pointsPrice * Level * 0.5);

    int gemsPrice;
    public int GemsPrice => (int)(gemsPrice * Level * 0.5);

    public Button DeviceButton;

    void Start()
    {
        DeviceButton = gameObject.GetComponent<Button>();
    }

    private void Update()
    {
        
    }
}
