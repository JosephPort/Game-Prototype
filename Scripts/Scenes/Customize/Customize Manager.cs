using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeManager : MonoBehaviour
{
    private SceneLoading sceneLoading;
    private SaveData saveData;

    void Awake(){
        sceneLoading = FindObjectOfType<SceneLoading>();

        saveData = FindObjectOfType<SaveHandler>().saveData;
    }

    void Start(){
        sceneLoading.SceneLoadedIn();
    }

    public void SceneSwitch(string sceneName)
    {
        GameObject sceneLoading = Instantiate(Resources.Load<GameObject>("Loading Panel"), GameObject.Find("Instantiated").transform);
        sceneLoading.GetComponent<SceneLoading>().SceneLoadedOut(sceneName);
    }
}