using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]

public class ToggleSound : MonoBehaviour
{
    [SerializeField] private AudioListener _audioListener;

    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleMusic);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleMusic);
    }

    private void ToggleMusic(bool enable)
    {
        _audioListener.enabled = enable;
    }
}
