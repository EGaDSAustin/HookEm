using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public const string kGameObjectName = "GameManager";

    public static GameObject gameObject;
    public static bool gameManagerExists = false;

    static GameManager ()
    {
        gameObject = GameObject.Find(kGameObjectName);
        if (gameObject == null)
        {
            Debug.LogError("GameManager.GameManager: Game object, \"" + kGameObjectName + "\" not found. Ensure scene has a dev GameManager present");
        }
    }
}