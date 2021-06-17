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

    public void CheckAnswer(bool isSpam)
    {
        if (isSpam == actualMessage.isSpam)
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

        WikiName = "Спам сообщения";

        WikiText = "    Пользователи интернета часто сталкиваются с таким явлениям как “Спам рассылка”. Это такая массовая рассылка сообщений пользователям, не давшим согласия на их получение. Такая рассылка может содержать навязчивую рекламу для продвижения какого-либо товара, распространения информации, а может использоваться и для кражи данных."
               + "\n    В этой мини-игре необходимо блокировать спам и пропускать сообщения нейтрального характера, нажимая на соответствующие кнопки.Нужно набрать требуемое количество правильных выборов для успешного для вас окончания атаки, в этом случае вы получите кристаллики, иначе потеряете их.Количество сообщений ограничено.";

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
        button1.enabled = false;
        button2.enabled = false;
        StartCoroutine(WaitAndEnd(1));
    }

    public IEnumerator WaitAndEnd(int sec)
    {
        yield return new WaitForSeconds(sec);
        ResetEvent();
        EndEvent(isWin);
    }

    public void ResetEvent()
    {
        Panel.SetActive(false);

        isWin = false;
        queueMessages = CreateQueue.GetQueueMessages();
        countOfRightAnswers = 0;
        CorrectAnswerCount.text = "0 / 0";

        button1.enabled = true;
        button2.enabled = true;
    }
}
