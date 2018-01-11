using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public float speed;

	private AnimationManager animationManager;
	private Rigidbody2D rb2D;
	private Vector2 direction;
	private Enums.Direction lastDirection;

	void Awake() {
		animationManager = GetComponent<AnimationManager>();
		rb2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		direction = new Vector2(horizontal, vertical);

		animationManager.StartAnimation(Enums.AnimationState.Run, GetDirection(direction));
	}

	Enums.Direction GetDirection(Vector2 direction) {
		if (direction.x == 1 && direction.y == 1) {
			lastDirection = Enums.Direction.UpRight;
		}
		if (direction.x == -1 && direction.y == 1) {
			lastDirection = Enums.Direction.UpLeft;
		}
		if (direction.x == 1 && direction.y == -1) {
			lastDirection = Enums.Direction.DownRight;
		}
		if (direction.x == -1 && direction.y == -1) {
			lastDirection = Enums.Direction.DownLeft;
		}
		if (direction == Vector2.right) {
			lastDirection = Enums.Direction.Right;
		}
		if (direction == Vector2.left) {
			lastDirection = Enums.Direction.Left;
		}
		if (direction == Vector2.up) {
			lastDirection = Enums.Direction.Up;
		}
		if (direction == Vector2.down) {
			lastDirection = Enums.Direction.Down;
		}
		return lastDirection;
	} 
}
