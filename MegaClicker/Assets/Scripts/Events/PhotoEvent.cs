using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoEvent : Event
{
    Photo CurrentPhoto;
    public Photo[] Photos;
    bool isEnding = false;

    void Start()
    {
        Photos = FindObjectsOfType<Photo>();
        foreach (var p in Photos)
            p.gameObject.SetActive(false);

        StartEventAction += StartPhotoEvent;
    }

    void Update()
    {
        if (CurrentPhoto != null && CurrentPhoto.IsCheck && !isEnding)
        {
            isEnding = true;
            StartCoroutine(WaitAndEnd(1));
        }
    }

    void StartPhotoEvent()
    {
        var random = new System.Random();
        CurrentPhoto = Photos[random.Next(0, Photos.Length)];

        CurrentPhoto.gameObject.SetActive(true);
    }

    public void ResetEvent()
    {
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
