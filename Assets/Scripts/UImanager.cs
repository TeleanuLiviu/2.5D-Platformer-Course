using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    private Text CoinText;
    [SerializeField]
    public Text LivesText;
    // Start is called before the first frame update
   public void UpdateCoinDisplay(int coins)
    {
        CoinText.text = "Coins: " + coins;
    }

    public void UpdateLivesDisplay(int lives)
    {
        LivesText.text = "lives: " + lives;
    }
}
