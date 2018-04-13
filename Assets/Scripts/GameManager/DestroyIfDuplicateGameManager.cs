using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfDuplicateGameManager : MonoBehaviour
{
    void Awake ()
    {
        if (gameObject.name != GameManager.kGameObjectName)
        {
            Debug.LogError("DestroyIfDuplicateGameManager.Awake: Placed on incorrectly named object", this);
        }

        if (GameManager.gameManagerExists)
        {
            Debug.Log("DestroyIfDuplicateGameManager.Awake: Duplicate game manager found", GameManager.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("DestroyIfDuplicateGameManager.Awake: GameManager found and set", GameManager.gameObject);
            GameManager.gameManagerExists = true;
            Destroy(this);
        }
    }
}
