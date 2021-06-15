using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSpamMessages : Event
{
    public Text Message, CorrectAnswerCount;
    public Button button1, button2;
    public GameObject Panel;

    private bool isWin = false;
    private Queue<Message> queueMessages;
    private Message actualMessage;
    private int countOfRightAnswers;
    private const int needRightAnswers = 3;


    public void OnClikTest() => StartExampleEvent();
    public void ClickYes() => OnClick(true);
    public void ClickNo() => OnClick(false);

    public void OnClick(bool answer)
    {
        CheckAnswer(answer);
    }

    public void CheckAnswer(bool playerSelection)
    {
        if (playerSelection == actualMessage.isSpam)
        {
            countOfRightAnswers++;
        }
        else if (countOfRightAnswers != 0 ) countOfRightAnswers--;

        CorrectAnswerCount.text = string.Format("{0} / {1}", countOfRightAnswers, needRightAnswers);

        if (countOfRightAnswers >= needRightAnswers)
        {
            isWin = true;
            EndExampleEvent();
            return;
        }

        if (queueMessages.Count != 0)
        {
            actualMessage = queueMessages.Dequeue();
        }
        else EndExampleEvent();

        Message.text = actualMessage.text;
    }

    private void Start()
    {
        Panel.SetActive(false);
        queueMessages = CreateQueue.GetQueueMessages();

        StartEventAction += StartExampleEvent;
    }

    public void StartExampleEvent()
    {
        Panel.SetActive(true);

        actualMessage = queueMessages.Dequeue();
        Message.text = actualMessage.text;
        countOfRightAnswers = 0;
    }

    public void EndExampleEvent()
    {
        Message.enabled = false;
        button1.enabled = false;
        button2.enabled = false;
        StartCoroutine(WaitAndEnd(2));
    }

    public IEnumerator WaitAndEnd(int sec)
    {
        yield return new WaitForSeconds(sec);
        Panel.SetActive(false);
        ResetEvent();
        EndEvent(isWin);
    }

    public void ResetEvent()
    {
        isWin = false;
        queueMessages = CreateQueue.GetQueueMessages();
        countOfRightAnswers = 0;
        CorrectAnswerCount.text = "0 / 0";

        Message.enabled = true;
        button1.enabled = true;
        button2.enabled = true;
    }
}
