using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ButtonSound : MonoBehaviour
{
    private Button _button;

    [SerializeField] private AudioSource _sound;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(PlaySound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlaySound);
    }

    private void PlaySound()
    {
        _sound.PlayOneShot(_sound.clip);
    }
}
