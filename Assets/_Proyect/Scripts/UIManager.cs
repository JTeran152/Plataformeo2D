using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Contadores")]
    [SerializeField] private TMP_Text textCoins;
    [SerializeField] private TMP_Text textRaspberries;

    private int coins;
    private int raspberries;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin()
    {
        coins++;
        textCoins.text = coins.ToString();
    }

    public void AddRaspberry()
    {
        raspberries++;
        textRaspberries.text = raspberries.ToString();
    }
}
