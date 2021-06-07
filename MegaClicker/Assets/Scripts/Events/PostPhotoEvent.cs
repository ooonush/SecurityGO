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
    public PostPhoto CurrentPhoto;
    public PostPhoto[] Photos;
    public bool isEnding = false;
    public PostPhotoButton[] AccessButtons;

    public GameObject Panel;

    void Start()
    {
        Photos = FindObjectsOfType<PostPhoto>();

        AccessButtons = Panel.GetComponentsInChildren<PostPhotoButton>();
        Panel.SetActive(false);
        foreach (var p in Photos)
            p.gameObject.SetActive(false);

        StartEventAction += StartPostPhotoEvent;
    }

    void StartPostPhotoEvent()
    {
        Panel.SetActive(true);

        var random = new System.Random();
        CurrentPhoto = Photos[random.Next(0, Photos.Length)];

        CurrentPhoto.gameObject.SetActive(true);
    }

    public void EndPostPhotoEvent(bool isWin)
    {
        StartCoroutine(WaitAndEnd(isWin));
    }

    public void ResetEvent()
    {
        isEnding = false;
        CurrentPhoto.gameObject.SetActive(false);
        CurrentPhoto = null;
        Panel.SetActive(false);
    }

    IEnumerator WaitAndEnd(bool isWin)
    {
        isEnding = true;
        yield return new WaitForSeconds(1);
        ResetEvent();
        this.EndEvent(isWin);
    }
}