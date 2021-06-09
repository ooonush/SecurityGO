using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static PasswordComplexity;

public class EventPasswordComplexity : Event
{
    public GameObject Panel;
    public InputField inputField;
    public Button Button;

    public void OnClikTest()
    {
        StartExampleEvent();
    }

    public void ChekPasswordOnClik()
    {
        Button.enabled = false;

        EndExampleEvent(GetComplexity(inputField.text) == Complexity.reliable);
    }

    private void Start()
    {
        Panel.SetActive(false);

        StartEventAction += StartExampleEvent; 
    }

    public void StartExampleEvent()
    {
        inputField.enabled = true;
        Button.enabled = true;
        Panel.SetActive(true);
    }

    public void EndExampleEvent(bool isWin)
    {
        inputField.enabled = false;
        StartCoroutine(WaitAndEnd(1, isWin));
    }

    public IEnumerator WaitAndEnd(int sec, bool isWin)
    {
        yield return new WaitForSeconds(sec);
                ResetEvent();
        Panel.SetActive(false);
        EndEvent(isWin);
    }

    public void ResetEvent()
    {
        inputField.text = "";
    }
}
