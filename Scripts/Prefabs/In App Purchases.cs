using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAppPurchases : MonoBehaviour
{
    [SerializeField] private GameObject scrollView;
    void Start()
    {
        LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 1, 0.125f).setOnComplete(() =>
        {
            LeanTween.alphaCanvas(scrollView.GetComponent<CanvasGroup>(), 1, 0.125f);
        });
    }

    public void HandleClosePress()
    {
        LeanTween.alphaCanvas(scrollView.GetComponent<CanvasGroup>(), 0, 0.125f).setOnComplete(() =>
        {
            LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 0, 0.125f).setOnComplete(() =>
            {
                Destroy(gameObject);
            });
        });
    }
}
