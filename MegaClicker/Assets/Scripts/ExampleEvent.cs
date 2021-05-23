

// Изучите класс Event... Плиз не надо ничо трогать :D
public class EventExample : Event //Как надо писать новое событие. наследуете интерфейс и реализуете его
{
    private void Start()
    {
        StartEventAction += StartExampleEvent; //подписка на то что событие началось

        //Если нужно проверить работоспособность кода вызываете это
        StartEventAction(); //Она срабатывает в 8 строчке
    }

    public void StartExampleEvent()
    {
        //Здесь начинаете писать код для ивента
    }

    public void EndExampleEvent(bool isWin) //isWin - выиграл игрок или проиграл
    {
        //Пишите что должно произойти в конце (скрыть менюшку...)

        //И в конце вызываете это
        base.EndEvent(isWin);
    }
}