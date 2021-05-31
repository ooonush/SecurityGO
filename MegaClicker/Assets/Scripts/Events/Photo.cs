using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    public GameObject[] Elements;

    public bool IsCheck;

    private void Start()
    {
        Elements = GetComponentsInChildren<Button>().Select(button => button.gameObject).ToArray();
    }

    public void ResetPhoto()
    {
        foreach (var e in Elements)
            e.SetActive(true);
    }

    private void Update()
    {
        IsCheck = true;
        if (Elements != null)
        {
            foreach (var e in Elements)
                if (e.activeInHierarchy)
                    IsCheck = false;
        }
        else IsCheck = false;
    }
}
