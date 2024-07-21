using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubUpgradeHandler : MonoBehaviour
{
    [SerializeField] GameObject purchasePanel;
    [SerializeField] GameObject buttonsGroup;
    [SerializeField] GameObject mainUpgradePanel;
    private UpgradeManager upgradeManager;

    void Awake()
    {
        upgradeManager = FindObjectOfType<UpgradeManager>();
    }

    void OnEnable()
    {
        LeanTween.moveY(buttonsGroup, 0, 0.125f);
    }

    public void HandleSubUpgradePress(int index)
    {
        upgradeManager.subIndex = index;

        LeanTween.moveY(buttonsGroup, -450, 0.125f).setOnComplete(() =>
        {
            purchasePanel.SetActive(true);
            gameObject.SetActive(false);
        });
    }

    public void HandleBackPress()
    {
        LeanTween.moveY(buttonsGroup, -450, 0.125f).setOnComplete(() =>
        {
            gameObject.SetActive(false);
            mainUpgradePanel.SetActive(true);
        });
    }
}
