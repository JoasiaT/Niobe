using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [Header("................Audio Sorce ...................")]
    [SerializeField] private AudioSource SFXSource;

    [Header("................Audio Clip ....................")]
    public AudioClip doorSound; // - Dzwienk na otwieranie drzwi   -     Spaceship Door Opening
    public AudioClip boomBox; // Radio w serwerowni    -    Alien Song                   
    public AudioClip collectible; // Dzwiek zbierania kluczy -              Pixel Level Up sound
    public AudioClip floor; // Dzwienk podczas chodzenia -  warunkowany chodzeniem  -    walking with sandals
    public AudioClip vent; //Dzwienk wentylatora - ciagly   -               air vent 2

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
