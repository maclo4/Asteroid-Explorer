using UnityEngine;

public class SpaceShipAudioController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioSource boosterAudioSource;
    public AudioClip deathExplosionClip, boosterAudioClip;
    private bool boosterEffectIsPlaying;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayDeathExplosionSoundEffect()
    {
        audioSource.PlayOneShot(deathExplosionClip);
    }

    public void PlayBoosterSoundEffect()
    {
        if (boosterEffectIsPlaying) return;
        boosterAudioSource.PlayOneShot(boosterAudioClip);
        boosterEffectIsPlaying = true;
    }
    
    public void StopBoosterSoundEffect()
    {
        boosterAudioSource.Stop();
        boosterEffectIsPlaying = false;
    }
}
