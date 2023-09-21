using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelicopterMovement : MonoBehaviour
{
    [SerializeField] private GameObject HelicopterCamera;

    [SerializeField] private AudioSource audioBackground;
    [SerializeField] private AudioSource audioHelicopter;

    [SerializeField] private GameObject waypoint;
    [SerializeField] private float speed = 2f;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (anim.GetBool("move"))
            if (Vector2.Distance(waypoint.transform.position, transform.position) > .1f)
                transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * speed);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("move", true);

            audioBackground.Stop();
            audioHelicopter.Play();

            collision.gameObject.GetComponent<Renderer>().enabled = false;
            collision.gameObject.SetActive(false);

            HelicopterCamera.SetActive(true);
        }
    }
}
