public class MenuManager : MonoSingleton<MenuManager>
{
    Menu[] Menus;
    public Menu Main;
    public Menu Shop;

    private void Start()
    {
        Main.WikiName = "Главный экран";
        Shop.WikiName = "Магазин";

        Main.WikiText = "Это “Главный экран”. Кликая по экрану, вы зарабатываете монеты. Количество этих монет зависит от характеристик ваших устройств, которые вы можете посмотреть, кликнув по интересующему вас устройству. Там же вы можете перейти во вкладку “Улучшение устройств”, кликнув по кнопке “Улучшить”.";
        Shop.WikiText = "Здесь вы можете улучшить необходимое устройство. Уровень безопасности устройства влияет на то сколько кристалликов вы потеряете в случае провала отбития атаки.";

        Menus = FindObjectsOfType<Menu>();
        ChangeMenu(Main);
    }

    public void ChangeMenu(Menu menu)
    {
        foreach (var menu1 in Menus)
            menu1.gameObject.SetActive(false);

        if (menu == Shop)
            foreach (var e in FindObjectsOfType<BuyDeviceCard>())
                e.SetBuyDeviceCardNewText();

        menu.gameObject.SetActive(true);
        GameManager.Instance.Wiki.WikiText.text = menu.WikiText;
        GameManager.Instance.Wiki.WikiName.text = menu.WikiName;
    }
}