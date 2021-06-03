using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoElement : MonoBehaviour
{
    public bool IsCheck;

    public void UnCheck()
    {
        IsCheck = false;
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void Check()
    {
        IsCheck = true;
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 1);
    }
}