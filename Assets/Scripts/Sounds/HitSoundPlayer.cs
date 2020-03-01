using UnityEngine;

public class HitSoundPlayer : MonoBehaviour
{
    public AudioClip Clip;

    public void PlaySound()
    {
        SFXManager.Instance.Play(Clip, transform.position);
    }
}
