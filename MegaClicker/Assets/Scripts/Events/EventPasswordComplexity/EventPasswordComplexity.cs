using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static PasswordComplexity;

public class EventPasswordComplexity : Event
{
    public bool isEnding = false;
    public GameObject Panel;
    public Text OutputText;
    public Text InputText;
    public InputField inputField;

    public void OnClik()
    {
        StartExampleEvent();
    }

    private void Start()
    {
        Panel.SetActive(false);

        StartEventAction += StartExampleEvent; 
    }

    public void CheckPassword(string password)
    {
        if (!isEnding)
        {
            var complexity = GetComplexity(password);

            if (complexity == Complexity.noPassword)
            {
                OutputText.text = "¬ведите пароль!";
            }
            else if (complexity == Complexity.reliable)
            {
                OutputText.text = string.Format("—ложность: {0}, пароль изменЄн", complexity);
                EndExampleEvent();
            }
            else
            {
                OutputText.text = string.Format("—ложность: {0}, попробуйте ещЄ", complexity);
            }
        }
    }

    public void StartExampleEvent()
    {
        inputField.enabled = true;
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
    }

    public void ResetEvent()
    {
        OutputText.text = "¬ведите пароль!";
        InputText.text = "";
    }
}
