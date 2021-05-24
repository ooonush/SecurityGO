using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Event : MonoSingleton<Event>
{
    public UnityAction StartEventAction;
    public UnityAction<bool> EndEventAction;

    public bool IsActive => ActiveDevice == null;
    public Device ActiveDevice { get; private set; }

    public void EndEvent(bool isWin)
    {
        ActiveDevice = null;
        if (EndEventAction != null)
            EndEventAction(isWin);
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