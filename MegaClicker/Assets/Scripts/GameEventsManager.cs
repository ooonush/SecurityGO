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
    public bool EventIsPlaying = false;

    void Start()
    {
        StartCoroutine(EventTriggerCoroutine());
        EventStartTrigger += StartEvent;
    }

    void StartEvent()
    {
        MonoSingleton<VirusEvent>.Instance.StartVirusEvent();
        EventIsPlaying = true;
    }

    public IEnumerator EventTriggerCoroutine()
    {
        while (true)
        {
            if (!EventIsPlaying)
            {
                yield return new WaitForSeconds(EventTimerInSec);
                EventStartTrigger();
            }
            else yield return new WaitForSeconds(5);
        }
    }
}
