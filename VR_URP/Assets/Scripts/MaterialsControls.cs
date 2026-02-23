using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class MaterialsControls : MonoBehaviour
{
    public Slider smoothnessSlider;
    public UnityEngine.UI.Text smoothnessText;
    public Slider normalSlider;
    public UnityEngine.UI.Text normalText;
    public Slider occlusionSlider;
    public UnityEngine.UI.Text occlusionText;

    public List<Renderer> renderers = new List<Renderer>();

    private void Start()
    {
        smoothnessSlider.value = 1f;
        normalSlider.value = 1f;
        occlusionSlider.value = 1f;
    }

    private float _smoothness;
    private float _normal;
    private float _occlusion;

    public float Smoothness
    {
        get => _smoothness;
        set
        {
            SetFloatProperty("_Smoothness", value);
            smoothnessText.text = value.ToString("F2");
        }
    }

    public float Normal
    {
        get => _normal;
        set
        {
            SetFloatProperty("_BumpScale", value);
            normalText.text = value.ToString("F2");
        }
    }

    public float Occlusion
    {
        get => _occlusion;
        set
        {
            SetFloatProperty("_OcclusionStrength", value);
            occlusionText.text = value.ToString("F1");
        }
    }

    private void SetFloatProperty(string name, float value)
    {
        for (int i = 0; i < renderers.Count; i++)
        {
            renderers.ElementAt(i).material.SetFloat(name, value);
        }
    }
}