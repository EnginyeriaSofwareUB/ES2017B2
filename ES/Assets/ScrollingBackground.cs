using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
	public float velocidad = 0.1f;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 offset = new Vector2(Time.time * velocidad, 0);

		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}