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
        WikiText = "�����������! ��� ��������"
        + "\n  ����� �� �������� ���� ������, �� ������ ������ ��� ��������. ��, � ���������, ������ �������� �12345678�, �� �������. ���� ����� �� ������� ����� ���������������� �����, � ����� ������� ���� ������ ����������� ������ �������. ������ � ��� ��� ������ �����, � ������� �������� ����� �� ��������. �� � ������� ������� ������ ������� �� ������, ������� ������ ����� ��������� ���� ����� ������� ������."
      
      + "\n\n �������� �������� �������� ������:"
        + "\n   1) ����� ������ � 12 ��������"
        + "\n   2) ������� ����"
        + "\n   3) ������� ��������� ���� ������� �������� (A-a, B-b, C-c)"
        + "\n   4) ������� ������������ (!@#$%^&()-_+=;:,./?\\|`~[]{}.)";

        WikiName = "��������� ������";

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
