using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform tubeTransform;

    private GeneralConfig generalConfig;

    public void Init(PlayerInput playerInput)
    {
        playerInput.OnDirectionPressed += DirectionPressed;

        generalConfig = Root.ConfigManager.GeneralConfig;
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

        float rotation = generalConfig.tubeRotationSpeed * Time.deltaTime * mult;
        tubeTransform.Rotate(Vector3.forward, rotation);
    }
}
