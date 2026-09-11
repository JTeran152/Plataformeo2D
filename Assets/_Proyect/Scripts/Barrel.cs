using UnityEngine;

public class Barrel : MonoBehaviour
{
    [Header("Interacción")]
    [SerializeField] private float knockbackForce = 3f;

    [Header("Sonido")]
    [SerializeField] private AudioClip barrelClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.root.CompareTag("Player"))
            return;

        Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
        AudioSource audioSource = collision.GetComponent<AudioSource>();

        if (audioSource != null && barrelClip != null)
        {
            audioSource.PlayOneShot(barrelClip);
        }

        if (playerRb != null)
        {
            Vector2 knockbackDir =
                (playerRb.position - (Vector2)transform.position).normalized;

            playerRb.linearVelocity = Vector2.zero;
            playerRb.AddForce(
                knockbackDir * knockbackForce,
                ForceMode2D.Impulse
            );
        }

        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

        foreach (BoxCollider2D col in colliders)
        {
            col.enabled = false;
        }

        Animator animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.enabled = true;
        }

        Destroy(gameObject, 0.5f);
    }
}