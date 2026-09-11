using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Interfaz")]
    [SerializeField] private UIManager uiManager;

    private int coins;
    private int raspberries;

    private void Awake()
    {
        // Garantiza que solo exista una instancia del GameManager.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Inicializa los valores mostrados en el HUD.
        uiManager.UpdateCoins(coins);
        uiManager.UpdateRaspberries(raspberries);
    }

    public void AddCoin()
    {
        coins++;
        uiManager.UpdateCoins(coins);
    }

    public void AddRaspberry()
    {
        raspberries++;
        uiManager.UpdateRaspberries(raspberries);
    }
}