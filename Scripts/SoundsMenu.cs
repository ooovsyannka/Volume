using UnityEngine;
using UnityEngine.Audio;

public class SoundsMenu : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string MusicVolume = nameof(MusicVolume);
    private const string EffectsVolume = nameof(EffectsVolume);

    [SerializeField] private AudioMixerGroup _mixerGroup;

    private bool _musicOn = true;
    private float _currentMasterValue = 0;

    public void ToggleMusic(bool enable)
    {
        int minMasterValue = -80;
        _musicOn = enable;

        _mixerGroup.audioMixer.SetFloat(MasterVolume, enable ? _currentMasterValue : minMasterValue);
    }

    public void ChangeMasterVolume(float masterValue)
    {
        _currentMasterValue = ValueToVolume(masterValue);

        if (_musicOn)
            _mixerGroup.audioMixer.SetFloat(MasterVolume, _currentMasterValue);
    }

    public void ChangeMusicVolume(float musicValue)
    {
        _mixerGroup.audioMixer.SetFloat(MusicVolume, ValueToVolume(musicValue));
    }

    public void ChangeEffectsVolume(float effectsValue)
    {
        _mixerGroup.audioMixer.SetFloat(EffectsVolume, ValueToVolume(effectsValue));
    }

    public float ValueToVolume(float value)
    {
        int coefficient = 20;

        return Mathf.Log10(value) * coefficient;
    }
}
