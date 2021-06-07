using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static PasswordComplexity;

public class EventPasswordComplexity : Event
{
    public GameObject Panel;
    public InputField inputField;
    public Button Button;
    public bool isWin = false;

    public void OnClikTest()
    {
        StartExampleEvent();
    }

    public void OnClik()
    {
        Button.enabled = false;

        if (GetComplexity(inputField.text) == Complexity.reliable) isWin = true;

        EndExampleEvent();
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

    public void EndExampleEvent()
    {
        inputField.enabled = false;
        StartCoroutine(WaitAndEnd(2));
    }

    public IEnumerator WaitAndEnd(int sec)
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
