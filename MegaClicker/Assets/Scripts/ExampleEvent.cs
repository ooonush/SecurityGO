

// ������� ����� Event... ���� �� ���� ���� ������� :D
public class EventExample : Event, IEvent //��� ���� ������ ����� �������. ���������� ��������� � ���������� ���
{
    private void Start()
    {
        StartEventAction += StartEvent; //�������� �� �� ��� ������� ��������

        //���� ����� ��������� ����������������� ���� ��������� ���
        StartEventAction(); //��� ����������� � 8 �������
    }

    public void StartEvent()
    {
        //����� ��������� ������ ��� ��� ������
    }

    public void EndEvent(bool isWin) //isWin - ������� ����� ��� ��������
    {
        //������ ��� ������ ��������� � ����� (������ �������...)

        //� � ����� ��������� ���
        End(isWin);
    }
}