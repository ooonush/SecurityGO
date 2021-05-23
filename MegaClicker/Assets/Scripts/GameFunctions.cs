using System.Collections;
using UnityEngine;

public static class GameFunctions
{
    private static IEnumerator WaitAndDestroy(int sec, GameObject gameObject)
    {
        yield return new WaitForSeconds(sec);
        MonoBehaviour.Destroy(gameObject);
    }
}