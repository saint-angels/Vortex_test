using DG.Tweening;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "AnimationConfig", menuName = "Config/AnimationConfig")]
    public class AnimationConfig : ScriptableObject
    {
        public Ease obstacleAppearenceEase = Ease.OutQuart;
        public float obstacleAppearenceDuration = .3f;
    }
}
