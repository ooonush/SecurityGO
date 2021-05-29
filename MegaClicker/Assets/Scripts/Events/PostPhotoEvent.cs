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
    bool isEnding = false;
    public PostPhotoButton[] AccessButtons;

    void Start()
    {
        Photos = FindObjectsOfType<PostPhoto>();
        foreach (var p in Photos)
            p.gameObject.SetActive(false);

        AccessButtons = FindObjectsOfType<PostPhotoButton>();
        foreach (var a in AccessButtons)
            a.gameObject.SetActive(false);

        StartEventAction += StartPostPhotoEvent;
    }

    void Update()
    {
        if (CurrentPhoto != null && CurrentPhoto.IsCheck && !isEnding)
        {
            isEnding = true;
            StartCoroutine(WaitAndEnd(1));
        }
    }

    void StartPostPhotoEvent()
    {
        var random = new System.Random();
        CurrentPhoto = Photos[random.Next(0, Photos.Length)];

        CurrentPhoto.gameObject.SetActive(true);

        foreach (var b in AccessButtons)
            b.gameObject.SetActive(true);
    }

    public void ResetEvent()
    {
        foreach (var a in AccessButtons)
            a.gameObject.SetActive(false);

        isEnding = false;
        CurrentPhoto.ResetPhoto();
        CurrentPhoto.gameObject.SetActive(false);
        CurrentPhoto = null;
    }

    IEnumerator WaitAndEnd(int sec)
    {
        yield return new WaitForSeconds(sec);
        ResetEvent();
        this.EndEvent(true);
    }
}