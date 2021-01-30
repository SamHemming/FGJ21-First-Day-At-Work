using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemChanger : MonoBehaviour
{
	public string itemName;
	[TextArea] public string itemDescription;
	public Sprite itemSprite;
	public AudioClip itemSound;

	/*
	public string newHeldItem;
    public string thisItem;
    public ItemHolder playerItemHolder;
    public GameObject ballText;
    public GameObject deskText;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerItemHolder = player.GetComponent<ItemHolder>();
        }

        if(thisItem == "pöytä")
        {
            deskText.SetActive(true);
            playerItemHolder.holdingItem = true;
        }

        if(thisItem == "pallo")
        {
            ballText.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if(Input.GetKey(KeyCode.Space) && player.CompareTag("Player"))
        {
            playerItemHolder.ChangeHeldItem(thisItem);
            CloseTexts();
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        CloseTexts();
    }

    private void CloseTexts()
    {
        ballText.SetActive(false);
        deskText.SetActive(false);
    }*/
}
