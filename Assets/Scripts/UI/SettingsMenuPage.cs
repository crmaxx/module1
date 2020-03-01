using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuPage : MonoBehaviour
{
    public GameObject SettingsWindowRoot;
    public GameObject PauseWindowRoot;
    
    public Button SaveButton;
    public AudioMixer Mixer;
    
    public SoundVolumeSliderSettingsData[] SoundVolumeSettings;

    private void Awake()
    {
        foreach (var soundVolumeSetting in SoundVolumeSettings)
            soundVolumeSetting.Init(Mixer);
        
        SaveButton.onClick.AddListener(OnSaveButtonClick);
    }

    private void OnSaveButtonClick()
    {
        SettingsWindowRoot.SetActive(false);
        PauseWindowRoot.SetActive(true);
    }
}
