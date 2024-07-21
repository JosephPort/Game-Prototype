using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMover : MonoBehaviour
{
    public float dampingSpeed = 10f; 
    public float speed = 1f; // Assign a default speed value
    private Vector2 targetPosition;
    private RectTransform rectTransform;

    void Start()
    {
        // Initialize RectTransform and target position
        rectTransform = GetComponent<RectTransform>();
        targetPosition = rectTransform.anchoredPosition;
    }

    void LateUpdate()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchDeltaPosition = touch.deltaPosition;

            targetPosition += new Vector2(touchDeltaPosition.x * speed * 0.002f, touchDeltaPosition.y * speed * 0.002f);
        }

        // Smoothly move the UI element to the target position
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, Time.deltaTime * dampingSpeed);
    }
}