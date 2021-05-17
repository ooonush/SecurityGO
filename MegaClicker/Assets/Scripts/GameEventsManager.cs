using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;

public class GameEventsManager : MonoSingleton<GameEventsManager>
{
    GameManager gameManager => MonoSingleton<GameManager>.Instance;
    //таймер тем меньше чем больше уровень игрока
    float EventTimerInSec => 3; // - 0.25f*gameManager.Level*gameManager.Level;

    UnityAction EventStartTrigger;
    public int EventsIsPlayingCount;
    public bool CanIsPlaying => EventsIsPlayingCount <= 3;

    void Start()
    {
        StartCoroutine(EventTriggerCoroutine());
        EventStartTrigger += StartEvent;
    }

    void StartEvent()
    {
        MonoSingleton<VirusEvent>.Instance.StartVirusEvent();
    }

    public IEnumerator EventTriggerCoroutine()
    {
        while (true)
        {
            if (!CanIsPlaying)
            {
                yield return new WaitForSeconds(EventTimerInSec);
                EventStartTrigger();
            }
            else yield return new WaitForSeconds(5);
        }
    }
}
