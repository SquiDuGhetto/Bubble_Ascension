
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    [Header("----------Audio Clip----------")]
    public AudioClip Jump;
    public AudioClip Death;
    public AudioClip Shoot; 
    public AudioClip Sword;
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
