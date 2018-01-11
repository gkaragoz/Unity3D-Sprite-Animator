using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AnimationController))]
public class AnimationManager : MonoBehaviour {
    public string INFO_CURRENT_ANIMATION = "UNKNOWN";
    public AnimationEntity[] animationEntities;

    private Animation selectedAnimation;
    private AnimationController animationController;

    void Awake() {
        animationController = GetComponent<AnimationController>();
    }

    void Start() {
        StartAnimation(Enums.AnimationState.Idle, Enums.Direction.Down);
    }

    public void StartAnimation(Enums.AnimationState animationState, Enums.Direction direction) {
        foreach (AnimationEntity animationEntity in animationEntities) {
            if (animationEntity.animationState == animationState) {
                selectedAnimation = animationEntity.GetAnimation(direction);
                INFO_CURRENT_ANIMATION = animationEntity.animationState + " " + selectedAnimation.direction;
            }
        }

        animationController.Play(selectedAnimation);
        Debug.Log("Animation played: " + INFO_CURRENT_ANIMATION);
    }

    public void StopAnimation() {
        animationController.Stop();
        Debug.Log("Animation stopped: " + INFO_CURRENT_ANIMATION);
    }
}