using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PipeGeneratorConfig", menuName = "Config/PipeGeneratorConfig")]
    public class PipeGeneratorConfig : ScriptableObject
    {
        public PipeSegment emptyPipe;
        public PipeSegment[] pipes;
        
        public int startEmptyPipes = 5;
        public int maxAlivePipes = 2;
        public float pipeMoveSpeed = 1f;
        public float pipeDisappearZ = -20;
    }
}
