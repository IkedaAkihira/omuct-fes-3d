using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDispenser : MonoBehaviour
{

    // 1P, 2P を表すオブジェクトをフィールドにもつ
    // メソッドで空いてるのを取得する
    // 1P, 2P の入力を Update で更新

    public class PlayerControllerInternal
    {
        public bool beingUsed;
        private Gamepad gamepad;

        public PlayerControllerInternal()
        {
            this.gamepad = null;
            this.beingUsed = false;
        }

        public void SetGamePad(Gamepad gamepad)
        {
            this.gamepad = gamepad;
        }

        public Vector2 GetMoveValue()
        {
            if (gamepad is null) return Vector2.zero;
            return gamepad.leftStick.ReadValue();
        }

        public Vector2 GetCameraValue()
        {
            if (gamepad is null) return Vector2.zero;
            return gamepad.rightStick.ReadValue();
        }

        public bool GetUseItemValue()
        {
            if (gamepad is null) return false;
            return gamepad.leftShoulder.isPressed;
        }

        public bool GetAttack1Value()
        {
            if (gamepad is null) return false;
            return gamepad.rightShoulder.isPressed;
        }

        public bool GetJumpValue()
        {
            if (gamepad is null) return false;
            return gamepad.buttonSouth.isPressed;
        }
    }

    private static PlayerControllerInternal player0 = new PlayerControllerInternal();
    private static PlayerControllerInternal player1 = new PlayerControllerInternal();

    public PlayerController GetController(int playerid)
    {
        if (playerid == 0 && !(player0 is null) && !player0.beingUsed) return new PlayerController(player0);
        if (playerid == 1 && !(player1 is null) && !player1.beingUsed) return new PlayerController(player1);
        Debug.LogWarning("PlayerController GetController() returned null");
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int gamepadCount = Gamepad.all.Count;
        player0.SetGamePad(gamepadCount >= 1 ? Gamepad.all[0] : null);
        player1.SetGamePad(gamepadCount >= 2 ? Gamepad.all[1] : null);
    }


}
