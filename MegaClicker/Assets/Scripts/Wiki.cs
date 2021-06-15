using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wiki : MonoBehaviour
{
    public Text WikiText;
    public Text WikiName;

    void Start()
    {
        gameObject.SetActive(false);
    }
}
