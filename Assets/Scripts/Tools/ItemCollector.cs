using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int _coins=0;
    public TextMeshProUGUI CoinsText;
    //[SerializeField] private AudioSource CoinCollectSound;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Coin")){
            Destroy(other.gameObject);
            _coins++;
            CoinsText.text=""+_coins;
            //CoinCollectSound.Play();
            AudioManager.Instance.PlaySFX("Coin");
        }
    }
}
