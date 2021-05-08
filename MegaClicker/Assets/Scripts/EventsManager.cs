using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;

public class EventsManager : MonoSingleton<EventsManager>
{
    GameManager gameManager => MonoSingleton<GameManager>.Instance;
    //таймер тем меньше чем больше уровень игрока
    float EventTimer => 3; // - 0.25f*gameManager.Level*gameManager.Level;

    UnityAction EventStartTrigger;
    public bool EventIsPlaying = false;

    void Start()
    {
        StartCoroutine(EventTimerCoroutine());
        EventStartTrigger += StartEvent;
    }

    void StartEvent()
    {
        EventIsPlaying = true;
    }

    public IEnumerator EventTimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(EventTimer);
            if (!EventIsPlaying)
                EventStartTrigger();
        }
    }
}
