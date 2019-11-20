using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private Transform pipeHolder;
    [SerializeField] private PipeSegment pipeSegmentPrefab;
    
    private PipeGeneratorConfig generatorConfig;
    
    private readonly List<PipeSegment> livePipeSegments = new List<PipeSegment>();
    private bool isActive;
    private GeneralConfig generalConfig;

    
    public void Init()
    {
        generatorConfig = Root.ConfigManager.PipeGeneratorConfig;
        generalConfig = Root.ConfigManager.GeneralConfig;
        Root.Player.Input.OnDirectionPressed += DirectionPressed;
        isActive = false;
    }

    public void SetActive(bool isActive)
    {
        this.isActive = isActive;

        if (isActive)
        {
            SetPipeRotation(Quaternion.identity);
        }
    }
    
    private void DirectionPressed(PlayerInput.Direction direction)
    {
        float mult = 0;
        switch (direction)
        {
            case PlayerInput.Direction.LEFT:
                mult = 1;
                break;
            case PlayerInput.Direction.RIGHT:
                mult = -1;
                break;
        }
        
        float deltaRotation = generalConfig.tubeRotationSpeed * Time.deltaTime * mult;
        float newRotation = pipeHolder.rotation.eulerAngles.z + deltaRotation;
        SetPipeRotation(Quaternion.Euler(0,0,newRotation));
    }

    private void SetPipeRotation(Quaternion rotation)
    {
        pipeHolder.rotation = rotation;
    }

    void Update()
    {
        if (isActive == false)
        {
            return;
        }
        
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
            newPipe.transform.localRotation = Quaternion.identity;
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
