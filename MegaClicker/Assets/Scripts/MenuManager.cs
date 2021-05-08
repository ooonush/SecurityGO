using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoSingleton<MenuManager>
{
    public GameObject[] Menus;

    public void ChangeMenu(GameObject menu)
    {
        foreach (var menu1 in Menus)
            menu1.SetActive(false);
        menu.SetActive(true);
    }
}
