using UnityEngine;
using UnityEngine.UI;

public class SliderColorChange : MonoBehaviour
{
    public Slider _slider;
    public Image _fillImage;
    public Color _minColor = Color.red;
    public Color _maxColor = Color.green;
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    void Update()
    {
        float normalizedValue = Mathf.InverseLerp(_slider.minValue, _slider.maxValue, _slider.value);
        Color lerpedColor = Color.Lerp(_minColor, _maxColor, normalizedValue);

        // Update the color of the fill image
        _fillImage.color = lerpedColor;
    }
}