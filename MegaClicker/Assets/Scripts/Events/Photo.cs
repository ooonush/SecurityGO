using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    public PhotoElement[] Elements;

    public bool IsCheck;

    public void ResetPhoto()
    {
        IsCheck = false;
        Elements = GetComponentsInChildren<PhotoElement>();
        foreach (var e in Elements)
            e.UnCheck();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        IsCheck = true;

        if (Elements != null)
        {
            foreach (var e in Elements)
                if (!e.IsCheck)
                    IsCheck = false;
        }
        else IsCheck = false;
    }
}
