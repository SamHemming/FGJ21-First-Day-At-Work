using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChanger : MonoBehaviour
{
    public string newHeldItem;
    public string thisItem;
    public ItemHolder playerItemHolder;
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
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if(Input.GetKey(KeyCode.Space) && player.CompareTag("Player"))
        {
            playerItemHolder.ChangeHeldItem(thisItem);
        }
    }


}
