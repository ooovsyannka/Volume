using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SliderVolume : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(delegate { ChangeVolue(); });
    }

    public void ChangeVolue()
    {
        _mixerGroup.audioMixer.SetFloat(_slider.name, Mathf.Log10(_slider.value) * 20);
    }
}
