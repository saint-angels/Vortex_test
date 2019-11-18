using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private Transform pipeHolder;
    [SerializeField] private PipeSegment pipeSegmentPrefab;
    
    private PipeGeneratorConfig generatorConfig;

    private Vector2 pipeHolderXY;
    
    private readonly List<PipeSegment> livePipeSegments = new List<PipeSegment>();
    
    public void Init()
    {
        pipeHolderXY = pipeHolder.transform.position;
        generatorConfig = Root.ConfigManager.PipeGeneratorConfig;
    }

    void Update()
    {

        for (int i = livePipeSegments.Count - 1; i >= 0; i--)
        {
            PipeSegment pipeSegment = livePipeSegments[i];
            if (pipeSegment.transform.localPosition.z <= generatorConfig.pipeDisappearZ)
            {
                livePipeSegments.RemoveAt(i);
                SimplePool.Despawn(pipeSegment.gameObject);
            }
        }
        
        
        while (livePipeSegments.Count < generatorConfig.maxAlivePipes)
        {
            bool firstPipe = livePipeSegments.Count == 0;
            GameObject newPipe = SimplePool.Spawn(pipeSegmentPrefab.gameObject, Vector3.zero, Quaternion.identity, pipeHolder);
            PipeSegment newPipeSegment = newPipe.GetComponent<PipeSegment>();
            livePipeSegments.Add(newPipeSegment);
            newPipeSegment.Init();
            if (firstPipe)
            {
                newPipe.transform.position = new Vector3(0,0 , generatorConfig.pipeDisappearZ);
            }
        }

        Vector3 firstPipePosition = Vector3.zero;
        for (int i = 0; i < livePipeSegments.Count; i++)
        {
            PipeSegment pipeSegment = livePipeSegments[i];
            
            if (i == 0)
            {
                float moveDelta = -1 * Time.deltaTime * generatorConfig.pipeMoveSpeed;
                pipeSegment.transform.localPosition = new Vector3(0, 0, pipeSegment.transform.localPosition.z + moveDelta);
                firstPipePosition = pipeSegment.transform.localPosition;
            }
            else
            {
                pipeSegment.transform.localPosition = firstPipePosition + new Vector3(0,0, i * pipeSegment.Length);
            }
        }
    }
}
