using UnityEngine;

public class SFXManager : SingletonMonoBehaviour<SFXManager>
{
    public AudioSource[] audioSources;

    public void Play(AudioClip clip, Vector3 position, float delay = 0.0f)
    {
        var freeAudioSource = FindFreeAudioSource();
        freeAudioSource.transform.position = position;
        freeAudioSource.clip = clip;
        freeAudioSource.PlayDelayed(delay);
    }

    private AudioSource FindFreeAudioSource()
    {
        foreach (var audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
                return audioSource;
        }

        Debug.LogError($"Слишком много звуков!");
        return null;
    }
}