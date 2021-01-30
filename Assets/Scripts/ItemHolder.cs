using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ItemHolder : MonoBehaviour
{
    private bool holdingItem;
	private string itemDescription;
	private string itemName;
	private AudioClip itemSound;
	private Sprite itemSprite;
	private AudioSource audioSource;

	[SerializeField] private SpriteRenderer spriteRend;
	[SerializeField] private UnityEngine.UI.Text itemText;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void ChangeHeldItem(string newHeldItem)
    {
        itemName = newHeldItem;
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Item"))
		{
			if (Input.GetButtonDown("Jump"))
			{
				if(holdingItem)
				{
					ClearHand();
				}
				else
				{
					PickUpItem(collision.GetComponent<ItemChanger>());
				}
			}
		}
	}

	private void ClearHand()
	{
		holdingItem = false;

		itemName = null;
		itemSprite = null;
		itemDescription = null;
		itemSound = null;

		spriteRend.sprite = null;
		itemText.text = null;
	}

	private void PickUpItem(ItemChanger item)
	{
		holdingItem = true;

		itemName = item.itemName;
		itemSprite = item.itemSprite;
		itemDescription = item.itemDescription;
		itemSound = item.itemSound;

		audioSource.PlayOneShot(itemSound);
		spriteRend.sprite = itemSprite;
		itemText.text = itemDescription;
	}
}
