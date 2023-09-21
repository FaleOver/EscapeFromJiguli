using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI count_text;
    [SerializeField] private AudioSource audioPickup;

    static public List<GameObject> collectedMelons = new();
    static public int count_melon = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            audioPickup.Play();
            collectedMelons.Add(collision.gameObject);
            Debug.Log(collectedMelons.Count);

            collision.gameObject.GetComponent<Animator>().SetTrigger("collect");
            count_melon++;
            count_text.text = "Melons: " + count_melon;
        }
    }
}
