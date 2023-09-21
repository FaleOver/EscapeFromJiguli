using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 respawnPosition;
    private Vector3 lavaPosition;

    [SerializeField] private AudioSource audioDeath;
    [SerializeField] private AudioSource audioAppear;
    [SerializeField] private GameObject lava;
    [SerializeField] private TextMeshProUGUI count_text;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPosition = transform.position;

        if (SceneManager.GetActiveScene().buildIndex == 2)
            lavaPosition = lava.transform.position;

        ItemCollector.collectedMelons.Clear();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
            Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkp"))
        {
            respawnPosition = collision.transform.position;
            collision.gameObject.GetComponent<Animator>().SetBool("trigger", true);
        }
    }

    private void Die()
    {
        audioDeath.Play();

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void Restart()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
            lava.transform.position = lavaPosition;

        foreach (GameObject melon in ItemCollector.collectedMelons)
        {
            melon.SetActive(true);
        }
        ItemCollector.count_melon -= ItemCollector.collectedMelons.Count;
        count_text.text = "Melons: " + ItemCollector.count_melon;
        ItemCollector.collectedMelons.Clear();

        audioAppear.Play();
        transform.position = respawnPosition;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
