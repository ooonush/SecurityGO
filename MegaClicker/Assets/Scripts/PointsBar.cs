using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsBar : MonoBehaviour
{
    public GameManager GameManager => MonoSingleton<GameManager>.Instance;
    private Image bar;
    private Text text;

    void Start()
    {
        bar = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (GameManager != null)
        {
            bar.fillAmount = (float)GameManager.PointsCurrentLevel / GameManager.MaxPoints;
            text.text = GameManager.PointsCurrentLevel.ToString();
        }
    }
}
