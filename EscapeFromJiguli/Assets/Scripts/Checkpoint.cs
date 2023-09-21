using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private AudioSource audioCheckp;

    private bool activ = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (!activ)
            {
                audioCheckp.Play();
                activ = true;
                ItemCollector.collectedMelons.Clear();
            }
    }
}
