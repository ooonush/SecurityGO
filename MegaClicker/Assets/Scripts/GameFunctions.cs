using System.Collections;
using UnityEngine;

public static class GameFunctions
{
    public static IEnumerator WaitAndDestroy(int sec, GameObject gameObject)
    {
        yield return new WaitForSeconds(sec);
        MonoBehaviour.Destroy(gameObject);
    }
}