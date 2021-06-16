using UnityEngine;

public class WikiButton : MonoBehaviour
{
    public void OnClick(Wiki wiki)
    {
        wiki.gameObject.SetActive(!wiki.gameObject.activeInHierarchy);
    }
}
