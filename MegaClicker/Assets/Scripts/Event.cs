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
        EndEventAction(isWin);
    }

    public void StartEvent(Device device)
    {
        StartEventAction();
        ActiveDevice = device;
    }
}

interface IEvent
{
    public void EndEvent(bool isWin);
    public void StartExampleEvent();
}