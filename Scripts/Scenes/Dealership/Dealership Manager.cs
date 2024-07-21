using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DealershipManager : MonoBehaviour
{
    [SerializeField] private GameObject notEnoughResourcesPrefab;
    [SerializeField] private Image dealerIndex;
    private GameObject currentVehicleInstance;
    private List<Image> indexImages = new List<Image>();
    private SaveData data;    
    private string[] prefabNames = new string[] 
    { 
        "CT5", 
        "CT5", 
        "CT5", 
        "CT5",
        "CT5",
        "CT5"
    };
    private int currentCarIndex;

    void Awake()
    {
        data = FindObjectOfType<SaveHandler>().saveData;
        
        float totalWidth = (prefabNames.Length - 1) * 25;
        for (int i = 0; i < prefabNames.Length; i++)
        {
            Image newCar = Instantiate(dealerIndex, GameObject.Find("Index Images").transform);
            RectTransform rt = newCar.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(i * 25 - totalWidth / 2, 0);
            indexImages.Add(newCar);
        }

        currentCarIndex = 0;
        indexImages[currentCarIndex].transform.localScale = new Vector2(1.35f, 1.35f);

        LoadVehicle(prefabNames[currentCarIndex]);
    }

    void Start(){        
        SceneLoading sceneLoading = FindObjectOfType<SceneLoading>();

        sceneLoading.SceneLoadedIn();
    }

    private void LoadVehicle(string prefabName)
    {
        if (currentVehicleInstance != null)
        {
            Destroy(currentVehicleInstance);
        }

        GameObject vehiclePrefab = Resources.Load<GameObject>($"Vehicles/{prefabName}");

        if (vehiclePrefab != null)
        {
            currentVehicleInstance = Instantiate(vehiclePrefab, GameObject.Find("Car Target Spawn").transform);

            currentVehicleInstance.GetComponent<SteelHandler>().steel = new Steel(prefabNames[currentCarIndex]);
        }
    }

    public void RightPress()
    {
        LeanTween.scale(indexImages[currentCarIndex].gameObject, new Vector2(1, 1), 0.1F);

        if (currentCarIndex < prefabNames.Length - 1)
        {
            currentCarIndex++;
        }
        else
        {
            currentCarIndex = 0;
        }

        LeanTween.scale(indexImages[currentCarIndex].gameObject, new Vector2(1.35f, 1.35f), 0.1F);
        LoadVehicle(prefabNames[currentCarIndex]);
    }

    public void LeftPress()
    {
        LeanTween.scale(indexImages[currentCarIndex].gameObject, new Vector2(1, 1), 0.1F);

        if (currentCarIndex > 0)
        {
            currentCarIndex--;
        }
        else
        {
            currentCarIndex = prefabNames.Length - 1;
        }

        LeanTween.scale(indexImages[currentCarIndex].gameObject, new Vector2(1.35f, 1.35f), 0.1F);
        LoadVehicle("CT5");
    }

    public void HandleBackPress()
    {
        GameObject sceneLoading = Instantiate(Resources.Load<GameObject>("Loading Panel"), GameObject.Find("Instantiated").transform);
        sceneLoading.GetComponent<SceneLoading>().SceneLoadedOut("Main");
    }

    public void HandleCashPurchase()
    {
        if (data.cashEarned - data.cashSpent >= 30000)
        {
            data.cashSpent += 30000;

            SuccessfulPurchase();

            return;
        }
    }

    public void HandleGoldPurchase()
    {
        if (data.goldEarned - data.goldSpent >= 30)
        {
            data.goldSpent += 30;

            SuccessfulPurchase();
            
            return;
        }
    }

    private void SuccessfulPurchase(){
        data.vehicles.Add(new Steel(prefabNames[currentCarIndex]));
        data.selectedIndex = data.vehicles.Count - 1;
        data.Save();

        GameObject sceneLoading = Instantiate(Resources.Load<GameObject>("Loading Panel"), GameObject.Find("Instantiated").transform);
        sceneLoading.GetComponent<SceneLoading>().SceneLoadedOut("Main");
    }
}