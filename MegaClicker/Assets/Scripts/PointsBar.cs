using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsBar : MonoBehaviour
{
    public GameManager GameManager => GameManager.Instance;
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
            if (float.IsNaN(bar.fillAmount))
                bar.fillAmount = 0;
            var b = (float)GameManager.PointsCurrentLevel / GameManager.MaxPoints;
            bar.fillAmount = Mathf.Abs(Mathf.Lerp(bar.fillAmount, b, 5f * Time.deltaTime));

            text.text = GameManager.PointsCurrentLevel.ToString();
        }
    }
}
