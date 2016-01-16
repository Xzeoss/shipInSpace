using UnityEngine;
using System.Collections;

public class ColumnLaser : MonoBehaviour {

	public float yScale;
	public float xScale;

	// Update is called once per frame
	void Update () {
	
		Vector3 scale = transform.localScale;
		if (scale.x > 0.1f)
			scale.x -= xScale * Time.deltaTime;
		if (scale.x < 0.1f)
			scale.x = 0.1f;
		if (scale.x < 0.5f) {
			if (scale.y < 16f)
				scale.y += yScale * Time.deltaTime;
			if (scale.y > 16f)
				scale.y = 16f;
		}

		transform.localScale = scale;

	}
}
