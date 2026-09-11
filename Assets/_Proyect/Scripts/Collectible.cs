using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        Coin,
        Raspberry
    }

    [Header("Tipo de objeto")]
    [SerializeField] private CollectibleType type;

    [Header("Sonido")]
    [SerializeField] private AudioClip collectClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo reaccionar cuando el jugador toca el objeto.
        if (!collision.transform.root.CompareTag("Player"))
            return;

        // Buscar el AudioSource del Player.
        AudioSource audioSource = collision.GetComponentInParent<AudioSource>();

        if (audioSource != null && collectClip != null)
        {
            audioSource.PlayOneShot(collectClip);
        }

        // Actualizar el contador correspondiente.
        if (type == CollectibleType.Coin)
        {
            UIManager.Instance.AddCoin();
        }
        else if (type == CollectibleType.Raspberry)
        {
            UIManager.Instance.AddRaspberry();
        }

        // Eliminar el objeto recogido.
        Destroy(gameObject);
    }
}   