using UnityEngine;

[System.Serializable]
public class Animation {
    public Enums.Direction direction;
    public Sprite[] sprites;
}

[System.Serializable]
public class AnimationEntity {
    public Enums.AnimationState animationState;
    public Animation [] animations;

    public Animation GetAnimation(Enums.Direction direction) {
        foreach (var animation in animations) {
            if (animation.direction == direction) {
                return animation;
            }
        }
        Debug.LogError("Animation direction not found!");
        return animations[0];
    }
}