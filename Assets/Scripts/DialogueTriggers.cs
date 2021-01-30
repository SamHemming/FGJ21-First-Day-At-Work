using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggers : MonoBehaviour
{
    public bool ballCarry;
    public GameObject ballText;
    void Start()
    {
        ballText.SetActive(false);
        ballCarry = false;
    }


    private void OnTriggerEnter2D(Collider2D player)
    {
        print("lol");
        if (player.CompareTag("Player") && (!ballCarry))
        {
            ballText.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.CompareTag("Player") && (Input.GetKey(KeyCode.Space)))
        {
            ballText.SetActive(false);
            ballCarry = true;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            ballText.SetActive(false);
        }
    }
}
