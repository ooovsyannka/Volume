using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundsMenu : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string MusicVolume = nameof(MusicVolume);
    private const string EffectsVolume = nameof(EffectsVolume);

    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private Slider _masterSlider;

    private bool _musicOn = true;
    private float _currentMasterValue = 0;

    private void Start()
    {
        _masterSlider.onValueChanged.AddListener(delegate { ChangeMasterVolume(); });
    }

    public void ToggleMusic(bool enable)
    {
        int minMasterValue = -80;
        _musicOn = enable;

        _mixerGroup.audioMixer.SetFloat(MasterVolume, enable ? _currentMasterValue : minMasterValue);
    }

    public void ChangeMasterVolume()
    {
        _currentMasterValue = ConvertValueToVolume(_masterSlider.value);

        if (_musicOn)
            _mixerGroup.audioMixer.SetFloat(MasterVolume, _currentMasterValue);
    }

    public float ConvertValueToVolume(float value)
    {
        int coefficient = 20;

        return Mathf.Log10(value) * coefficient;
    }
}
