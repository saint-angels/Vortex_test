using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private Transform pipeHolder;
    [SerializeField] private PipeSegment pipeSegmentPrefab;

    [SerializeField] private float pipeDissappearZ = 0;
    
    private PipeGeneratorConfig generatorConfig;
    
    private readonly List<PipeSegment> livePipeSegments = new List<PipeSegment>();
    
    public void Init()
    {
        generatorConfig = Root.ConfigManager.PipeGeneratorConfig;
        
//        SimplePool.Preload(pipeSegmentPrefab.gameObject, generatorConfig.maxAlivePipes);
    }

    void Update()
    {

        for (int i = livePipeSegments.Count - 1; i >= 0; i--)
        {
            PipeSegment pipeSegment = livePipeSegments[i];
            if (pipeSegment.transform.localPosition.z <= pipeDissappearZ)
            {
                livePipeSegments.RemoveAt(i);
                SimplePool.Despawn(pipeSegment.gameObject);
            }
        }
        
        
        while (livePipeSegments.Count < generatorConfig.maxAlivePipes)
        {
            GameObject newPipe = SimplePool.Spawn(pipeSegmentPrefab.gameObject, Vector3.zero, Quaternion.identity, pipeHolder);
            PipeSegment newPipeSegment = newPipe.GetComponent<PipeSegment>();
            livePipeSegments.Add(newPipeSegment);
            print(newPipeSegment.transform.parent);
            newPipeSegment.Init();
        }

        float firstPipeOffset = 0;
        for (int i = 0; i < livePipeSegments.Count; i++)
        {
            PipeSegment pipeSegment = livePipeSegments[i];
            
            
            if (i == 0)
            {
                float moveDelta = -1 * Time.deltaTime * generatorConfig.pipeMoveSpeed;
                pipeSegment.transform.localPosition += new Vector3(0, 0, moveDelta);
                firstPipeOffset = pipeSegment.transform.localPosition.z;
            }
            else
            {
                float offset = firstPipeOffset + i * pipeSegment.Length;
                pipeSegment.transform.localPosition = new Vector3(0,0, offset);
            }
        }
    }
}
