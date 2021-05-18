

// ������� ����� Event... ���� �� ���� ���� ������� :D
public class EventExample : Event, IEvent //��� ���� ������ ����� �������. ���������� ��������� � ���������� ���
{
    private void Start()
    {
        StartEventAction += StartExampleEvent; //�������� �� �� ��� ������� ��������

        //���� ����� ��������� ����������������� ���� ��������� ���
        StartEventAction(); //��� ����������� � 8 �������
    }

    public void StartExampleEvent()
    {
        //����� ��������� ������ ��� ��� ������
    }

    public void EndExampleEvent(bool isWin) //isWin - ������� ����� ��� ��������
    {
        //������ ��� ������ ��������� � ����� (������ �������...)

        //� � ����� ��������� ���
        base.EndEvent(isWin);
    }
}