using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoEvent : Event
{
    Photo CurrentPhoto;
    public Photo[] Photos;
    bool isEnding = false;

    void Start()
    {
        Photos = FindObjectsOfType<Photo>();
        foreach (var p in Photos)
            p.ResetPhoto();

        StartEventAction += StartPhotoEvent;
    }

    void Update()
    {
        if (CurrentPhoto != null && CurrentPhoto.IsCheck && !isEnding)
            StartCoroutine(WaitAndEnd());
    }

    void StartPhotoEvent()
    {
        var random = new System.Random();
        CurrentPhoto = Photos[random.Next(0, Photos.Length)];

        CurrentPhoto.gameObject.SetActive(true);

        foreach (var e in CurrentPhoto.Elements)
            e.UnCheck();

    }

    public void ResetEvent()
    {
        isEnding = false;
        CurrentPhoto.ResetPhoto();
        CurrentPhoto.gameObject.SetActive(false);
        CurrentPhoto = null;
    }

    IEnumerator WaitAndEnd()
    {
        isEnding = true;
        yield return new WaitForSeconds(1);
        ResetEvent();
        this.EndEvent(true);
    }
}