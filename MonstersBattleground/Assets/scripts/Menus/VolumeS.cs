using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeS : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _Musicslider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }
    public void SetMusicVolume()
    {
        float volume = _Musicslider.value;
        _audioMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadVolume()
    {
       _Musicslider.value = PlayerPrefs.GetFloat("musicVolume");

        SetMusicVolume();
    }
}
