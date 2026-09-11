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

        // Busca el AudioSource del jugador.
        AudioSource audioSource =
            collision.GetComponentInParent<AudioSource>();

        if (audioSource != null && collectClip != null)
        {
            audioSource.PlayOneShot(collectClip);
        }

        // El GameManager se encarga de actualizar el contador.
        if (type == CollectibleType.Coin)
        {
            GameManager.Instance.AddCoin();
        }
        else if (type == CollectibleType.Raspberry)
        {
            GameManager.Instance.AddRaspberry();
        }

        // Elimina el coleccionable.
        Destroy(gameObject);
    }
}