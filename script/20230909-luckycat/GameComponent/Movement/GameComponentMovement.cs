using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameComponentMovement : MonoBehaviour {
    public Vector3 vec3_movDir;

    public float f_speed = 2.0f;
    public void Set_Speed(float arg_speed) => f_speed = arg_speed;
    public float Get_Speed() { return f_speed; }

    [Header("Movement-Status")]
    public bool isMoveUp = false;
    public bool isMoveDown = false;
    public bool isMoveLeft = false;
    public bool isMoveRight = false;

    public bool IsMoveUp() { return isMoveUp; }
    public GameComponentMovement Set_IsMoveUp(bool arg_status) {
        isMoveUp = arg_status;
        return this;
    }
    public bool IsMoveDown() { return isMoveDown; }
    public GameComponentMovement Set_IsMoveDown(bool arg_status) {
        isMoveDown = arg_status;
        return this;
    }
    public bool IsMoveLeft() { return isMoveLeft; }
    public GameComponentMovement Set_IsMoveLeft(bool arg_status) {
        isMoveLeft = arg_status;
        return this;
    }
    public bool IsMoveRight() { return isMoveRight; }
    public GameComponentMovement Set_IsMoveRight(bool arg_status) {
        isMoveRight = arg_status;
        return this;
    }

    private void Update() => Movement_Update();

    public void Movement_Reset() {
        Set_IsMoveUp(false);
        Set_IsMoveDown(false);
        Set_IsMoveLeft(false);
        Set_IsMoveRight(false);
    }

    public void MoveUp() => Set_IsMoveUp(true);
    public void MoveDown() => Set_IsMoveDown(true);
    public void MoveLeft() => Set_IsMoveLeft(true);
    public void MoveRight() => Set_IsMoveRight(true);

    public void Movement_Update() {
        float moveX = 0.0f;
        float moveY = 0.0f;

        if (isMoveUp)
            moveY = 1.0f;
        if (isMoveDown)
            moveY = -1.0f;
        if (isMoveLeft)
            moveX = -1.0f;
        if (isMoveRight)
            moveX = 1.0f;

        vec3_movDir = new Vector3(moveX, moveY).normalized;

        this.transform.position += vec3_movDir * Get_Speed() * Time.deltaTime; //Update-and-set-transform
    }
}
