using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoSingleton<MenuManager>
{
    Menu[] Menus;
    public Menu Main;
    public Menu Shop;

    private void Start()
    {
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
