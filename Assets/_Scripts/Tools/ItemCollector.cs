using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int _coins=0;
    public TextMeshProUGUI CoinsText;
    public TextMeshProUGUI HighCoinsText; //Display Coin score in win dialogue popup and you win the level 
    //[SerializeField] private AudioSource CoinCollectSound;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Coin")){
            Destroy(other.gameObject);
            _coins++;
            CoinsText.text=""+_coins;
            //CoinCollectSound.Play();
            showHightScore();
            AudioManager.Instance.PlaySFX("Coin");
        }
    }
    void showHightScore(){
        HighCoinsText.text="COINS: "+_coins;
    }

}
