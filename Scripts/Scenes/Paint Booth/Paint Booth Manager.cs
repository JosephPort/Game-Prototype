using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PaintBoothManager : MonoBehaviour
{
    private SceneLoading sceneLoading;
    private SaveData saveData;
    private ColorChanger colorChanger;

    void Awake()
    {
        sceneLoading = FindObjectOfType<SceneLoading>();
        saveData = FindObjectOfType<SaveHandler>().saveData;
        colorChanger = FindObjectOfType<ColorChanger>();
    }

    void Start(){
        sceneLoading.SceneLoadedIn();
    }

    public void HandleBackPress()
    {
        saveData.vehicles[saveData.selectedIndex].customization.hue = colorChanger.h;
        saveData.vehicles[saveData.selectedIndex].customization.saturation = colorChanger.s;
        saveData.vehicles[saveData.selectedIndex].customization.value = colorChanger.v;

        saveData.vehicles[saveData.selectedIndex].customization.reflectionPower = colorChanger.reflectionPower;

        saveData.Save();

        GameObject sceneLoading = Instantiate(Resources.Load<GameObject>("Loading Panel"), GameObject.Find("Instantiated").transform);
        sceneLoading.GetComponent<SceneLoading>().SceneLoadedOut("Customize");
    }
}
