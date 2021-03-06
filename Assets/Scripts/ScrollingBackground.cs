﻿using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour 
{
	const float kHeight = 13.5f; //13.666f; // TODO: Don't just have this as a Magic number based on height of sprites
	const string kTextureName = "_MainTex";

	public float m_speed = 1.0f;

	private float m_y = 0.575f; // Setting a default UV Offset to position the Main Menu buttons well when yu open the app
	private Vector2 uvOffset = Vector2.zero;
	private Renderer backgroundImage;

	void Start()
	{
		backgroundImage = GetComponent<Renderer>();
	}

	public void SetSpeed(float speed)
	{
		m_speed = speed;
	}

	void FixedUpdate() 
	{
		float frameSpeed = m_speed/kHeight;
		m_y += frameSpeed * Time.fixedDeltaTime;
		if (m_y > 1.0f) // Wrap around when we get to 1.0f to keep floating precision as accurate as possible!
		{
			m_y -= 1.0f;
		}

		if( backgroundImage.enabled )
		{
			uvOffset = new Vector2(0.0f, m_y);
			backgroundImage.material.SetTextureOffset( kTextureName, uvOffset );
		}
	}
}