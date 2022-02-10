using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int bulki = 0;
    [SerializeField] private Text bulkaText;
    [SerializeField] private AudioSource collectionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bulka"))
        {
            collectionSound.Play();
            Destroy(collision.gameObject);
            bulki++;
            bulkaText.text = "BUŁKI: " + bulki;
        }
    }
}