using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnAwake : MonoBehaviour
{
    [SerializeField] private int sceneBuildIndex;

    void Awake ()
    {
        SceneManager.LoadScene(sceneBuildIndex);
        Destroy(this);
    }
}
