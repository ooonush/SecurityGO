using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostPhotoButton : MonoBehaviour
{
    public PostAccess Access;
    public Button Button;

    private void Start()
    {
        Button = gameObject.GetComponent<Button>();
        Button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        var PhotoAccess = MonoSingleton<PostPhotoEvent>.Instance.CurrentPhoto.Access;
        if (PhotoAccess == Access)
            MonoSingleton<PostPhotoEvent>.Instance.CurrentPhoto.IsCheck = true;
    }
}