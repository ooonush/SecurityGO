using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PasswordComplexity;

public class EventPasswordComplexity : Event
{
    public GameObject Panel;
    public Text Text;

    private void Start()
    {
        Panel.SetActive(false);

        StartEventAction += StartExampleEvent; 
    }

    public void CheckPassword(string password)
    {
        var complexity = GetComplexity(password);

        if (complexity == Complexity.noPassword)
        {
            Text.text = "������� ������!";
        }
        if (complexity == Complexity.reliable)
        {
            Text.text = string.Format("���������: {0}, ������ ������", complexity);
            EndExampleEvent();
        }
        else
        {
            Text.text = string.Format("���������: {0}, ���������� ���", complexity);
        }
    }

    public void StartExampleEvent()
    {
        Panel.SetActive(true);
    }

    public void EndExampleEvent()
    {
        StartCoroutine(this.WaitAndEnd(2, Panel));
    }

}
