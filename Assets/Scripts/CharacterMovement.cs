using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	[SerializeField, Range(0.01f, 2f)] private float movementSpeed = 1f;
	[SerializeField, Range(0, 360)] private int angleOffset = 0;

	private Rigidbody2D rb;

	private void Awake()
	{
		rb = this.GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		//this.transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * movementSpeed;
		
		rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * movementSpeed;

		//Not mine, copy-paste ain't no sin :DD
		var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
		var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		//----

	}
}
