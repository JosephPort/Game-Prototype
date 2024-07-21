using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBarManager : MonoBehaviour
{
    [SerializeField] private GameObject iapPrefab;
    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Image goldLogo;
    private SaveHandler saveObject;

    void Start()
    {
        saveObject = GameObject.FindObjectOfType<SaveHandler>();

        UpdateResources();
    }

    public void HandleIAPPress(){
        if (GameObject.Find("Instantiated").transform.childCount != 0){
            return;
        }

        Instantiate(Resources.Load<GameObject>("In App Purchase"), GameObject.Find("Instantiated").transform);
    }


    public void UpdateResources(){
        int cash = saveObject.saveData.cashEarned - saveObject.saveData.cashSpent;
        int gold = saveObject.saveData.goldEarned - saveObject.saveData.goldSpent;

        cashText.text = cash.ToString();
        goldText.text = gold.ToString();

        RelocateResources();
    }

    private void RelocateResources(){
        cashText.rectTransform.sizeDelta = new Vector2(cashText.preferredWidth, cashText.rectTransform.sizeDelta.y);
        goldText.rectTransform.sizeDelta = new Vector2(goldText.preferredWidth, goldText.rectTransform.sizeDelta.y);
        
        goldLogo.rectTransform.anchoredPosition = new Vector2(-185 - cashText.rectTransform.sizeDelta.x - 15, 0);

        goldText.rectTransform.anchoredPosition = new Vector2(goldLogo.rectTransform.anchoredPosition.x - 35, 0);
    }
}
