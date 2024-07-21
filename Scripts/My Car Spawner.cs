using UnityEngine;
using UnityEngine.SceneManagement;

public class MyCarSpawner : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    private SaveData _saveData;

    void Awake()
    {
        _saveData = FindObjectOfType<SaveHandler>().saveData;;
    }

    void Start(){
        if (_saveData.vehicles.Count <= 0)
        {
            Debug.Log("No vehicles to spawn");
            return;
        }

        GameObject spawnedVehicle = Instantiate(Resources.Load<GameObject>($"Vehicles/{_saveData.vehicles[_saveData.selectedIndex].prefabName}"), targetPosition);
        spawnedVehicle.GetComponent<SteelHandler>().steel = _saveData.vehicles[_saveData.selectedIndex];
    }
}
