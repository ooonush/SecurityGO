using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Event : MonoSingleton<Event>
{
    public UnityAction StartEventAction;

    public string WikiText;
    public string WikiName;

    public bool IsActive => ActiveDevice == null;
    public Device ActiveDevice { get; private set; }

    public void EndEvent(bool isWin)
    {
        EventManager.Instance.EndEvent(isWin);
    }

    public void StartEvent(Device device)
    {
        StartEventAction();
        ActiveDevice = device;
    }

    public IEnumerator WaitAndEnd(int sec, GameObject gameObj)
    {
        yield return new WaitForSeconds(sec);
        gameObj.SetActive(false);
        this.EndEvent(true);
    }
}