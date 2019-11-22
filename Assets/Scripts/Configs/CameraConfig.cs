using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Config/CameraConfig")]
    public class CameraConfig : ScriptableObject
    {
        [Header("Screen shake")]
        public float shakeGeneralMagnitude = 1f;
        public float deathShakeDuration = .3f;

    }
}
