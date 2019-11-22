using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PipeGeneratorConfig", menuName = "Config/PipeGeneratorConfig")]
    public class PipeGeneratorConfig : ScriptableObject
    {
        public PipeSegment emptyPipe;
        public PipeSegment[] pipes;
        
        
        
        public int obstaclesApperPipeIndex = 5;
        public int startEmptyPipes = 5;
        public int maxAlivePipes = 2;
        public float pipeDisappearZ = -20;
        
        [Header("Difficulty")]
        public float pipeMoveSpeedStart = 1f;
        public float pipeMoveSpeedEnd = 1f;
        public float pipeSpeedChangeDurationSec = 60f;
    }
}
