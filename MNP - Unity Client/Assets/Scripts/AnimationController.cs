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
	
	IEnumerator Play() {
		while (currentAnimation != null && Time.time > nextFrameTime) {
			nextFrameTime = Time.time + frameRate;

			if (currentFrameIndex < currentAnimation.sprites.Length) {
				spriteRenderer.sprite = currentAnimation.sprites[currentFrameIndex++];
				if (currentFrameIndex >= currentAnimation.sprites.Length)
					currentFrameIndex = 0;
			}
			yield return new WaitForSeconds(frameRate);
		}
	}

	void OneShot() {
		Stop();
		spriteRenderer.sprite = currentAnimation.sprites[0];
	}

	public void Play(Animation animation) {
		this.currentAnimation = animation;

		if (this.currentAnimation.sprites.Length > 1)
			StartCoroutine(Play());
		else
			OneShot();
	}

	public void Stop() {
		StopAllCoroutines();
	}

	public Animation GetCurrentAnimation() {
		return currentAnimation;
	}
}
