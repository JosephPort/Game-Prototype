using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SteelMainColor : MonoBehaviour
{
    void Start()
    {
        Steel steel = gameObject.GetComponentInParent<SteelHandler>().steel;

        Material heroMaterial = Resources.Load<Material>("Materials/Hero/Hero Main");

        heroMaterial.color = Color.HSVToRGB(
            steel.customization.hue, 
            steel.customization.saturation,
            steel.customization.value
        );

        // Change Reflection Color
        heroMaterial.SetColor("_ReflectColor", Color.HSVToRGB(
            0, 
            0,
            steel.customization.reflectionPower
        ));
    }
}
