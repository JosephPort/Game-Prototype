using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GarageCameraController : MonoBehaviour
{
    [SerializeField] private GameObject equipped;
    [SerializeField] private GameObject select;

    private FLCameraController cameraController;
    public Transform[] spawnTargets;
    public Transform[] cameraTargets;
    private int selectedPositon;
    private int selectedGarageIndex;
    private SaveData saveData;

    private GameObject vehicleInstance;

    void Awake(){
        saveData = FindObjectOfType<SaveHandler>().saveData;

        cameraController = FindObjectOfType<FLCameraController>();
    }

    void Start(){
        SceneLoading sceneLoading = FindObjectOfType<SceneLoading>();
        sceneLoading.SceneLoadedIn();

        selectedGarageIndex = saveData.selectedIndex;
        CheckEquipped();

        SpawnVehicle(selectedGarageIndex, selectedPositon);
    }

    private void SpawnVehicle(int gIndex, int tIndex){
        if (vehicleInstance != null){
            Destroy(vehicleInstance);
        }

        vehicleInstance = Instantiate(Resources.Load<GameObject>($"Vehicles/{saveData.vehicles[gIndex].prefabName}"), spawnTargets[tIndex]);
        vehicleInstance.GetComponent<SteelHandler>().steel = saveData.vehicles[gIndex];
    }

    public void SelectVehicle(){
        saveData.selectedIndex = selectedGarageIndex;
        saveData.Save();

        GameObject sceneLoading = Instantiate(Resources.Load<GameObject>("Loading Panel"), GameObject.Find("Instantiated").transform);
        sceneLoading.GetComponent<SceneLoading>().SceneLoadedOut("Main");
    }
    public void RotateRight()
    {
        if (selectedPositon < 3){
            selectedPositon++;
        }
        else {
            selectedPositon = 0;
        }

        if (selectedGarageIndex < saveData.vehicles.Count - 1){
            selectedGarageIndex++;
        }
        else {
            selectedGarageIndex = 0;
        }

        CheckEquipped();

        SpawnVehicle(selectedGarageIndex, selectedPositon);

        cameraController.SwitchLockedPosition(cameraTargets[selectedPositon]);
    }

    public void RotateLeft(){
        if (selectedPositon > 0){
            selectedPositon--;
        }
        else {
            selectedPositon = 3;
        }

        if (selectedGarageIndex > 0){
            selectedGarageIndex--;
        }
        else {
            selectedGarageIndex = saveData.vehicles.Count - 1;
        }

        CheckEquipped();

        SpawnVehicle(selectedGarageIndex, selectedPositon);

        cameraController.SwitchLockedPosition(cameraTargets[selectedPositon]);
    
    }

    private void CheckEquipped()
    {
        if (saveData.selectedIndex == selectedGarageIndex)
        {
            equipped.SetActive(true);
            select.SetActive(false);
        }
        else
        {
            equipped.SetActive(false);
            select.SetActive(true);
        }
    
    }

    public void HandleBackPress(){
        GameObject sceneLoading = Instantiate(Resources.Load<GameObject>("Loading Panel"), GameObject.Find("Instantiated").transform);
        sceneLoading.GetComponent<SceneLoading>().SceneLoadedOut("Main");
    }
}
