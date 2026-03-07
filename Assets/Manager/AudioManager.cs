using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;

    void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void PlayMusic(AudioClip audioClip, bool isLoop = true)
    {
        musicAudioSource.clip = audioClip;
        musicAudioSource.loop = isLoop;
        musicAudioSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        sfxAudioSource.PlayOneShot(audioClip);
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void StopSFX()
    {
        sfxAudioSource.Stop();
    }
}
