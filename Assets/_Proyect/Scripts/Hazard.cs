using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    [Header("Sonido")]
    [SerializeField] private AudioClip spikeClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.root.CompareTag("Player"))
            return;

        AudioSource audioSource = collision.GetComponent<AudioSource>();

        if (audioSource != null && spikeClip != null)
        {
            audioSource.PlayOneShot(spikeClip);
        }

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}