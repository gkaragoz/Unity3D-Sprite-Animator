using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	public float frameRate = 0.2f;

	private Animation currentAnimation;

	[SerializeField]
	private int currentFrameIndex;
	
	private float nextFrameTime;

	private SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	void FixedUpdate() {
		if (currentAnimation != null) {
			if (Time.time > nextFrameTime) {
				nextFrameTime = Time.time + frameRate;

				if (currentFrameIndex < currentAnimation.sprites.Length) {
					spriteRenderer.sprite = currentAnimation.sprites[currentFrameIndex++];
					if (currentFrameIndex >= currentAnimation.sprites.Length)
						currentFrameIndex = 0;
				}
			}
		}
	}

	public void Play(Animation animation) {
		this.currentAnimation = animation;
	}

	public void Stop() {
		this.currentAnimation = null;
	}
}
