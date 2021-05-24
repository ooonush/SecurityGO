using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    public GameObject[] Elements;

    public bool IsCheck
    {
        get
        {
            bool isCheck = true;
            if (Elements != null)
            {
                foreach (var e in Elements)
                    if (e.gameObject.activeInHierarchy)
                        isCheck = false;
            }
            else isCheck = false;
            return isCheck;
        }
    }

    private void Start()
    {
        Elements = GetComponentsInChildren<Button>().Select(button => button.gameObject).ToArray();
    }

    public void Reset()
    {
        foreach (var e in Elements)
            e.SetActive(true);
    }
}
