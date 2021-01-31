using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer))]
public class ItemChanger : MonoBehaviour
{
	public string itemName;
	[TextArea] public string itemDescription;
	public Sprite itemSprite;
	public AudioClip itemSound;
	private SpriteRenderer rend;

	public bool isTake;

	private void Awake()
	{
		rend = GetComponent<SpriteRenderer>();
	}

	public void ToggleVisibility(bool b)
	{
		rend.color = b ? Color.white : Color.black;
	}
}
