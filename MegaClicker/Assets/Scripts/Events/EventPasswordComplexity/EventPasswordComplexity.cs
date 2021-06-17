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
        WikiText = "Поздравляем! Вас взломали…"
        + "\n  Чтобы не потерять ваши данные, вы должны срочно его поменять. Но, к сожалению, просто натыкать “12345678”, не поможет. Если вдруг вы станете целью недобросовестных людей, с таким паролем ваша защита продержится меньше секунды. Пароль – это как ворота замка, с плохими воротами замок не защитить. Но к счастью хороший пароль сделать не сложно, поэтому каждый может позволить себе самые крепкие ворота."
      
      + "\n\n Основные критерии хорошего пароля:"
        + "\n   1) Длина пароля – 12 символов"
        + "\n   2) Наличие цифр"
        + "\n   3) Наличие латинских букв разного регистра (A-a, B-b, C-c)"
        + "\n   4) Наличие спецсимволов (!@#$%^&()-_+=;:,./?\\|`~[]{}.)";

        WikiName = "Сложность пароля";

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
