using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	[SerializeField, Range(0, 360)] private int angleOffset = 0;
	void Update()
    {
		var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
		var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
