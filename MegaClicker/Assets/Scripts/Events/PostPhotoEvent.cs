using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PostAccess
{
    All,
    Friends,
    Me
}

public class PostPhotoEvent : Event
{
    public GameObject AccessButtonsBar;
    public PostPhoto CurrentPhoto;
    public PostPhoto[] Photos;
    public bool isEnding = false;
    public PostPhotoButton[] AccessButtons;

    void Start()
    {
        Photos = FindObjectsOfType<PostPhoto>();
        foreach (var p in Photos)
            p.gameObject.SetActive(false);

        AccessButtonsBar.SetActive(false);
        AccessButtons = AccessButtonsBar.GetComponentsInChildren<PostPhotoButton>();

        StartEventAction += StartPostPhotoEvent;
    }

    void StartPostPhotoEvent()
    {
        var random = new System.Random();
        CurrentPhoto = Photos[random.Next(0, Photos.Length)];

        AccessButtonsBar.SetActive(true);
        CurrentPhoto.gameObject.SetActive(true);
    }

    public void EndPostPhotoEvent(bool isWin)
    {
        StartCoroutine(WaitAndEnd(isWin));
    }

    public void ResetEvent()
    {
        AccessButtonsBar.SetActive(false);
        isEnding = false;
        CurrentPhoto.gameObject.SetActive(false);
        CurrentPhoto = null;
    }

    IEnumerator WaitAndEnd(bool isWin)
    {
        isEnding = true;
        yield return new WaitForSeconds(1);
        ResetEvent();
        this.EndEvent(isWin);
    }
}