using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : SingletonBlank<ControllerPlayer> {
    [SerializeField] private Transform m_pivot01;
    [SerializeField] private Transform m_pivot02;
    [SerializeField] private Transform[] sz_m_object;

    [SerializeField] private Transform m_currentPivot;

    [SerializeField] private Transform m_controlHub;
    [SerializeField] private Transform m_feverSaw;

    [SerializeField] private Transform m_groundCheckTransform;

    [SerializeField] private Transform m_possibleNextPlatform;

    [SerializeField] private bool isSafeLand;

    [SerializeField] private float f_rotationSpeed = 120.0f; //def: 120.0f
    [SerializeField] private float f_forwardSpeed = 5.0f; //def: 5.0f
    [SerializeField] private Vector3 vec3_currentEulerAngles;
    [SerializeField] private float f_yRotation = -1.0f;

    [SerializeField] private bool isRotateRight = false;
    [SerializeField] private bool isFever = false;

    [SerializeField] private float f_sawRotationSpeed = 240.0f; //def: 240.0f

    private void Start() => SetRotationStatusToRight(true);

    private void Update() {
        if (isFever) MoveForwardFever();
        else {
            RotateTransform(m_currentPivot, f_rotationSpeed);
            OnRotationStatus();
        }
        
        UpdateControlType();
        UpdateUnusedControllerPos();
    }

    private void FixedUpdate() => UpdateCameraType();

    public void SetRootPosition(Vector3 _position) { 
        this.transform.position = _position;
        m_controlHub.position = _position;
        if(isRotateRight) m_pivot01.position = _position;
        else if (isRotateRight == false) m_pivot02.position = _position;
        m_feverSaw.position = _position;
    }

    public bool IsSafeLand() { return isSafeLand; }
    public bool IsFeverMode() { return isFever; }
    public void SetStatusFeverMode(bool _status) { 
        isFever = _status;
        if (isFever) AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_GAME_TYPE.SAW_POWER_UP);
    }

    public void ResetStartPosition() { }

    public void SetSafeStatus(bool _status) => isSafeLand = _status;

    public bool IsRotateRight() { return isRotateRight; }
    public void SetRotationStatusToRight(bool _status) {
        isRotateRight = _status;
        if (isRotateRight) SetRotationPivot(m_pivot01);
        else if (isRotateRight == false) SetRotationPivot(m_pivot02);

        UpdateObjectParent();        
    }

    public void SetRotationPivot(Transform _transform) => m_currentPivot = _transform;

    public void ResetObjectParent() {
        m_pivot01.parent = m_controlHub;
        m_pivot02.parent = m_controlHub;
        foreach (Transform item in sz_m_object) item.parent = m_controlHub;
    }

    public void SetObjectParent(Transform[] _transforms, Transform _targetParent) {
        foreach (Transform item in _transforms)
            item.parent = _targetParent;
    }

    public void SetPossibleControllerParentToPlatform(Transform _transform) => m_possibleNextPlatform = _transform;
    public void SetControllerParentToPlatform() => this.transform.parent = m_possibleNextPlatform;
    public void ResetControllerParentToPlatform() => this.transform.parent = null;

    public void UpdateObjectParent() {
        ResetObjectParent();
        if (isRotateRight) {
            SetObjectParent(sz_m_object, m_pivot01);
            m_pivot02.parent = sz_m_object[2];

            m_groundCheckTransform.position = new Vector3(m_pivot02.position.x, -1, m_pivot02.position.z);
            m_groundCheckTransform.parent = m_pivot02;
        }
        else if (isRotateRight == false) {
            SetObjectParent(sz_m_object, m_pivot02);
            m_pivot01.parent = sz_m_object[0];

            m_groundCheckTransform.position = new Vector3(m_pivot01.position.x, -1, m_pivot01.position.z);
            m_groundCheckTransform.parent = m_pivot01;
        }
    }

    private void RotateTransform(Transform _target, float _rotationSpeed) {
        if (Mathf.Abs(vec3_currentEulerAngles.y) > 360) vec3_currentEulerAngles = Vector3.zero; //safe-check-overflow
        vec3_currentEulerAngles += new Vector3(0, f_yRotation, 0) * Time.deltaTime * _rotationSpeed;
        _target.localEulerAngles = vec3_currentEulerAngles;
    }

    private void MoveForwardFever() => m_feverSaw.position += m_feverSaw.forward * Time.deltaTime * f_forwardSpeed;
    public void RotateFever() {
        if (Mathf.Abs(vec3_currentEulerAngles.y) > 360) vec3_currentEulerAngles = Vector3.zero; //safe-check-overflow
        vec3_currentEulerAngles += new Vector3(0, 1.0f, 0) * Time.deltaTime * f_sawRotationSpeed;
        m_feverSaw.localEulerAngles = vec3_currentEulerAngles;
    }

    public void UpdateControlType() {
        if (isFever) {
            m_feverSaw.gameObject.SetActive(true);
            m_controlHub.gameObject.SetActive(false);
            ResetControllerParentToPlatform();
        }
        else {
            m_feverSaw.gameObject.SetActive(false);
            m_controlHub.gameObject.SetActive(true);
        }
    }

    private void UpdateCameraType() {
        if (isFever) {
            ComponentAutoPosition.Instance.SetTransform(m_feverSaw);
            ComponentCameraFollower.Instance.SetCinemachineCameraFollowTarget(m_feverSaw);
            ComponentCameraFollower.Instance.SetCinemachineCameraLookAtTarget(m_feverSaw);
        }
        
        else if (isFever == false && isRotateRight) {
            ComponentAutoPosition.Instance.SetTransform(m_pivot02);
            ComponentCameraFollower.Instance.SetCinemachineCameraFollowTarget(m_pivot01);
            ComponentCameraFollower.Instance.SetCinemachineCameraLookAtTarget(m_pivot01);
        }

        else if (isFever == false && isRotateRight == false) {
            ComponentAutoPosition.Instance.SetTransform(m_pivot01);
            ComponentCameraFollower.Instance.SetCinemachineCameraFollowTarget(m_pivot02);
            ComponentCameraFollower.Instance.SetCinemachineCameraLookAtTarget(m_pivot02);
        }        
    }

    private void UpdateUnusedControllerPos() {
        if (isFever) m_controlHub.position = m_feverSaw.position;
        else m_feverSaw.position = m_pivot01.position;
    }

    public void OnRotationStatus() {
        if (isRotateRight) {
            f_yRotation = 1.0f;
        }
        else {
            f_yRotation = -1.0f;
        }
    }
}


