using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SliderVolume : MonoBehaviour
{
    private const int Coefficient = 20;
    private const int MinValueSound = -80;

    [SerializeField] private AudioMixerGroup _mixerGroup;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolue);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolue);
    }

    private void ChangeVolue(float value)
    {
        if (value > 0)
            _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, Mathf.Log10(value) * Coefficient);
        else
            _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, MinValueSound);
    }
}
