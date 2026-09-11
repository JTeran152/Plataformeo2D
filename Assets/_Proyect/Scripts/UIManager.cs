using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Contadores")]
    [SerializeField] private TMP_Text textCoins;
    [SerializeField] private TMP_Text textRaspberries;

    public void UpdateCoins(int amount)
    {
        textCoins.text = amount.ToString();
    }

    public void UpdateRaspberries(int amount)
    {
        textRaspberries.text = amount.ToString();
    }
}
