using System;
using UnityEngine.Audio;
using UnityEngine.UI;

[Serializable]
public class SoundVolumeSliderSettingsData
{
    public Slider VolumeSlider;
    public Text VolumeText;
    public string VolumeParamNameInMixer;
    private AudioMixer _mixer;

    public void SliderValueChanged(float param)
    {
        _mixer.SetFloat(VolumeParamNameInMixer, param);
        VolumeText.text = param.ToString("F0");
    }

    public void Init(AudioMixer mixer)
    {
        _mixer = mixer;
        _mixer.GetFloat(VolumeParamNameInMixer, out var currentBgVolume);
        
        VolumeText.text = currentBgVolume.ToString("F0");
        
        VolumeSlider.value = currentBgVolume;
        VolumeSlider.onValueChanged.AddListener(SliderValueChanged);
    }
}