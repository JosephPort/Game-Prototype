using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Slider hSlider;
    [SerializeField] private Slider sSlider;
    [SerializeField] private Slider vSlider;
    
    public float h, s, v;
    public float reflectionPower;
    private Material material;

    // Start is called before the first frame update
    void Awake()
    {
        material =  Resources.Load<Material>("Materials/Hero/Hero Main");

        Color.RGBToHSV(material.color, out h, out s, out v);

        hSlider.value = h;
        sSlider.value = s;
        vSlider.value = v;

        Color.RGBToHSV(material.GetColor("_ReflectColor"), out _, out _, out reflectionPower);
    }

    void Start(){
        SceneLoading sceneLoading = FindObjectOfType<SceneLoading>();

        sceneLoading.SceneLoadedIn();
    }

    public void AdjustSliderHue()
    {
        h = hSlider.value;
        material.color = Color.HSVToRGB(hSlider.value, s, v);
    }

    public void AdjustSliderSaturation()
    {
        s = sSlider.value;
        material.color = Color.HSVToRGB(h, sSlider.value, v);
    }

    public void AdjustSliderValue()
    {
        v = vSlider.value;
        material.color = Color.HSVToRGB(h, s, vSlider.value);
    }

    public void PressMatte(){
        SetReflectionColor(0.0f);
    }

    public void PressMetallic(){
        SetReflectionColor(0.15f);
    }

    private void SetReflectionColor(float reflectionPower){
        this.reflectionPower = reflectionPower;
        
        material.SetColor("_ReflectColor", Color.HSVToRGB(
            0, 
            0,
            reflectionPower
        ));
    }
}
