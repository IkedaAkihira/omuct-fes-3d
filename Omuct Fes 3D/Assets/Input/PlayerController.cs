using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{

    private PlayerDispenser.PlayerControllerInternal core;

    public PlayerController(PlayerDispenser.PlayerControllerInternal core)
    {
        this.core = core;
        this.core.beingUsed = true;
    }

    ~PlayerController()
    {
        this.core.beingUsed = false;
    }

    public Vector2 GetMoveValue()
    {
        return core.GetMoveValue();
    }

    public Vector2 GetCameraValue()
    {
        return core.GetCameraValue();
    }

}
