using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostPhotoButton : MonoBehaviour
{
    public PostAccess Access;
    public Button Button;
    public PostPhotoEvent postPhotoEvent => MonoSingleton<PostPhotoEvent>.Instance;

    private void Start()
    {
        Button = gameObject.GetComponent<Button>();
        Button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (!MonoSingleton<PostPhotoEvent>.Instance.isEnding)
        {
            var PhotoAccess = postPhotoEvent.CurrentPhoto.Access;
            if (PhotoAccess == Access)
                postPhotoEvent.EndPostPhotoEvent(true);
            else
                postPhotoEvent.EndPostPhotoEvent(false);
        }
    }
}