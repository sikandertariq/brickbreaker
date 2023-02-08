using UnityEngine;
public class PlayAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        audioSource.enabled = true;
        audioSource.Play();
    }
}