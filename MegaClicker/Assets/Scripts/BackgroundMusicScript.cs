using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    private AudioSource musicSource;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        musicSource.PlayDelayed(1.5f);
    }
}
