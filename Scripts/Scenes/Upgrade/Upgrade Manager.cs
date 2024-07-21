using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    SceneLoading sceneLoading;
    public int mainIndex;
    public int subIndex;

    void Awake()
    {
        sceneLoading = FindObjectOfType<SceneLoading>();
    }

    void Start()
    {
        sceneLoading.SceneLoadedIn();
    }

    public void HandleBackPress()
    {
        GameObject sceneLoading = Instantiate(Resources.Load<GameObject>("Loading Panel"), GameObject.Find("Instantiated").transform);
        sceneLoading.GetComponent<SceneLoading>().SceneLoadedOut("Main");
    }
}
