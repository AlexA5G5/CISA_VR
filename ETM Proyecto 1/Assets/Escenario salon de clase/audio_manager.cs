using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySoundUI()
    {
        audioSource.Play();
    }
}
