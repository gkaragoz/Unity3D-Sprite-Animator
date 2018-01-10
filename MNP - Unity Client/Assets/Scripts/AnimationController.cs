using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	public Sprite []sprites;

	public float frameRate = 0.2f;

	public float nextFrameTime;

	public int currentFrameIndex;

	public SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update() {
		if (Time.time > nextFrameTime) {
			nextFrameTime = Time.time + frameRate;

			if (currentFrameIndex < sprites.Length) {
				spriteRenderer.sprite = sprites [currentFrameIndex++];
			} else {
				currentFrameIndex = 0;
			}
		}
	}

}
