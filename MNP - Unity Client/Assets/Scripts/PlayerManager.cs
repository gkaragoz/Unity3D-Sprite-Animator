using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public float speed;
	public Enums.Direction currentDirection;

	private AnimationManager animationManager;
	private Rigidbody2D rb2D;
	private Vector2 directionVector;

	void Awake() {
		animationManager = GetComponent<AnimationManager>();
		rb2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		directionVector = new Vector2(horizontal, vertical);

		if (directionVector != Vector2.zero)
			animationManager.StartAnimation(Enums.AnimationState.Run, GetDirection(directionVector));
		else
			animationManager.StartAnimation(Enums.AnimationState.Idle, currentDirection);
	}

	Enums.Direction GetDirection(Vector2 direction) {
		if (direction.x == 1 && direction.y == 1) {
			currentDirection = Enums.Direction.UpRight;
		}
		if (direction.x == -1 && direction.y == 1) {
			currentDirection = Enums.Direction.UpLeft;
		}
		if (direction.x == 1 && direction.y == -1) {
			currentDirection = Enums.Direction.DownRight;
		}
		if (direction.x == -1 && direction.y == -1) {
			currentDirection = Enums.Direction.DownLeft;
		}
		if (direction == Vector2.right) {
			currentDirection = Enums.Direction.Right;
		}
		if (direction == Vector2.left) {
			currentDirection = Enums.Direction.Left;
		}
		if (direction == Vector2.up) {
			currentDirection = Enums.Direction.Up;
		}
		if (direction == Vector2.down) {
			currentDirection = Enums.Direction.Down;
		}
		return currentDirection;
	} 
}
