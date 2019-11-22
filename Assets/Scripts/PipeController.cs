using System.Collections;
using System.Collections.Generic;
using Configs;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private Transform pipeHolder;

    private PipeGeneratorConfig generatorConfig;
    
    private readonly List<PipeSegment> livePipeSegments = new List<PipeSegment>();
    private bool isActive;
    private GeneralConfig generalConfig;

    private int pipeNumber;

    private float currentSpeed;

    public void Init()
    {
        generatorConfig = Root.ConfigManager.PipeGeneratorConfig;
        generalConfig = Root.ConfigManager.GeneralConfig;
        Root.Player.Input.OnDirectionPressed += DirectionPressed;
        Root.UIManager.OnScreenDirectionPressed += DirectionPressed;
    }

    public void SetActive(bool isActive)
    {
        this.isActive = isActive;

        if (isActive)
        {
            SetPipeRotation(Quaternion.identity);
            pipeNumber = 0;
            
            for (int i = livePipeSegments.Count - 1; i >= 0; i--)
            {
                PipeSegment pipeSegment = livePipeSegments[i];
                livePipeSegments.RemoveAt(i);
                SimplePool.Despawn(pipeSegment.gameObject);
            }
            
            currentSpeed = generatorConfig.pipeMoveSpeedStart;
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

        currentSpeed += Time.deltaTime / generatorConfig.pipeSpeedChangeDurationSec;
        
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
            PipeSegment selectedPipePrefab;
            bool inBetweenEmptyPipe = firstPipe || livePipeSegments[livePipeSegments.Count - 1].HasObstacles;  
            if (pipeNumber <= generatorConfig.startEmptyPipes || inBetweenEmptyPipe)
            {
                selectedPipePrefab = generatorConfig.emptyPipe;
                
            }
            else
            {
                selectedPipePrefab = generatorConfig.pipes[Random.Range(0, generatorConfig.pipes.Length)];
            }
            
            GameObject newPipe = SimplePool.Spawn(selectedPipePrefab.gameObject, Vector3.zero, Quaternion.identity, pipeHolder);
            PipeSegment newPipeSegment = newPipe.GetComponent<PipeSegment>();
            livePipeSegments.Add(newPipeSegment);
            if (firstPipe)
            {
                newPipe.transform.position = new Vector3(0,0 , generatorConfig.pipeDisappearZ);
            }

            //INIT THE PIPE
            newPipeSegment.Init();
            newPipe.transform.localRotation = Quaternion.Euler(0,0, newPipeSegment.StartRotationZ);
            pipeNumber++;
        }

        Vector3 firstPipePosition = Vector3.zero;
        for (int i = 0; i < livePipeSegments.Count; i++)
        {
            PipeSegment pipeSegment = livePipeSegments[i];

            if (pipeSegment.ObstaclesVisible == false && i <= generatorConfig.obstaclesApperPipeIndex)
            {
                pipeSegment.ShowObstacles();
            }
            
            if (i == 0)
            {
                float moveDelta = -1 * Time.deltaTime * currentSpeed;
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
