using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ItemHolder : MonoBehaviour
{
    public bool holdingItem = false;
	private string itemDescription;
	public string itemName = ""; // <= IS PUBLIC NOW!
	private AudioClip itemSound;
	private Sprite itemSprite;
	private AudioSource audioSource;

	private Collider2D collision;

	[SerializeField] private SpriteRenderer spriteRend;
	[SerializeField] private UnityEngine.UI.Text itemText;

	private Transform spriteTrans;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		spriteTrans = spriteRend.GetComponent<Transform>();
	}

	private void Update()
	{
		if (!collision)
			return;

		if (!collision.CompareTag("Item"))
			return;

		if (Input.GetButtonDown("Jump"))
		{
			var itemChanger = collision.GetComponent<ItemChanger>();

			if (itemName != "" && !itemChanger.itemName.Equals(itemName))
				return;

			if (itemChanger.isTake)
			{
				if (itemChanger.itemName.Equals(itemName))
				{
					// Yes sagettiaa :_DDD
				}
				else return;
			}


			if (holdingItem)
			{
				ClearHand();
				itemChanger.ToggleVisibility(true);
				itemChanger.isTake = false;
			}
			else
			{
				PickUpItem(itemChanger);
				itemChanger.ToggleVisibility(false);
				itemChanger.isTake = true;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		this.collision = collision;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		this.collision = null;
	}
	
	public void ClearHand()
	{
		holdingItem = false;

		itemName = "";
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
		spriteTrans.localScale = item.transform.localScale * (1/.3f);
		itemText.text = itemDescription;
	}
}
