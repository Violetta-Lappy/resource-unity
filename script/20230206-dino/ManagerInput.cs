using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInput : MonoBehaviour
{
    public static ManagerInput Instance;
    [SerializeField] ComponentMovement m_componentMovement;
    [SerializeField] ComponentAnimatorAOC m_animatorPlayer;

    bool isInputEnter;
    bool isInputReleased;

    bool isUsingTouchInput;

    private void Awake()
    {
        if (ManagerInput.Instance != null && ManagerInput.Instance != this) GameObject.Destroy(this.gameObject);

        ManagerInput.Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        //Input checks
        if (Input.touchCount > 0) 
        {
            Touch currentTouch = Input.GetTouch(0);

            if (currentTouch.phase == TouchPhase.Began)
            {
                isInputEnter = true;
            }
            if (currentTouch.phase == TouchPhase.Ended)
            {
                isInputReleased = true;
            }

            isUsingTouchInput = true; 
        }
        else if (Input.touchCount == 0 && isUsingTouchInput == true) { isInputReleased = true; isUsingTouchInput = false; }

        if (isUsingTouchInput == false)
        {
            if (Input.GetKeyDown(KeyCode.Space)) { isInputEnter = true; }
            else if (Input.GetKeyUp(KeyCode.Space)) { isInputReleased = true; }
        }

        //Dino jump
        if (isInputEnter == true)
        {
            if (ManagerGame.Instance.isGameEnd == false)
            {
                if (ManagerGame.Instance.isPlayerStart == false) { ManagerGame.Instance.EventPlayerStart(); }
                else
                {
                    m_componentMovement.SetIsJumping(true);
                    m_animatorPlayer.PlayAnimationForce(ENUM_ANIMATION_STATE_TYPE.JUMPUP);
                }
            }
            else if (ManagerGame.Instance.isGameEnd == true) ManagerGame.Instance.EventGameReset();
        }
        else if (isInputReleased == true) m_componentMovement.SetIsJumping(false);

        //Pause & Unpause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ManagerGame.Instance.isGameEnd == false)
            {
                if (ManagerGame.Instance.isGamePaused == false) ManagerGame.Instance.EventPause();
                else ManagerGame.Instance.EventUnpause();
            }
            else ManagerGame.Instance.EventGameReset();
        }

        //Reset Input this frame
        isInputEnter = false;
        isInputReleased = false;
    }

    void EventJumpInputEnter()
    {
        if (ManagerGame.Instance.isGameEnd == false)
        {
            if (ManagerGame.Instance.isPlayerStart == false) { ManagerGame.Instance.EventPlayerStart(); }
            else
            {
                m_componentMovement.SetIsJumping(true);
                m_animatorPlayer.PlayAnimationForce(ENUM_ANIMATION_STATE_TYPE.JUMPUP);
            }
        }
        else if (ManagerGame.Instance.isGameEnd == true) ManagerGame.Instance.EventGameReset();
    }

    void EventJumpInputRelease()
    {
        m_componentMovement.SetIsJumping(false);
    }
}
