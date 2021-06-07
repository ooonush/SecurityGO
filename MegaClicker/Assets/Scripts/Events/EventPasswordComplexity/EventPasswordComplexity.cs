using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static PasswordComplexity;

public class EventPasswordComplexity : Event
{
    public GameObject Panel;
    public Text Password => inputField.textComponent;
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

        if (GetComplexity(Password.text) == Complexity.reliable) isWin = true;

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
        Panel.SetActive(false);
        ResetEvent();
        EndEvent(isWin);
    }

    public void ResetEvent()
    {
        Password.text = "";
    }
}
