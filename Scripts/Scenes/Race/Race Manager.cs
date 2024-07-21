using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    SceneLoading sceneLoading;

    void Awake()
    {
        sceneLoading = FindObjectOfType<SceneLoading>();
    }

    void Start()
    {
        sceneLoading.SceneLoadedIn();
    }

    public void HandleBackPress(){
        GameObject sceneLoading = Instantiate(Resources.Load<GameObject>("Loading Panel"), GameObject.Find("Instantiated").transform);
        sceneLoading.GetComponent<SceneLoading>().SceneLoadedOut("Main");
    }
}
