using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUpgradeHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] subUpgradePanels;
    [SerializeField] private GameObject buttonsGroup;
    private UpgradeManager upgradeManager;

    void Awake()
    {
        upgradeManager = FindObjectOfType<UpgradeManager>();
    }

    void OnEnable()
    {
        LeanTween.moveY(buttonsGroup, 0, 0.125f);
    }

    public void HandleMainUpgradePress(int index)
    {
        upgradeManager.mainIndex = index;

        LeanTween.moveY(buttonsGroup, -450, 0.125f).setOnComplete(() =>
        {
            subUpgradePanels[index].SetActive(true);
            gameObject.SetActive(false);
        });
    }
}