using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

public class ComponentCameraFollower : SingletonBlank<ComponentCameraFollower> {    
    public CinemachineVirtualCamera m_cinemachineVirtualCamera;    
    public void SetCinemachineCameraFollowTarget(Transform _target) => m_cinemachineVirtualCamera.Follow = _target;
    public void SetCinemachineCameraLookAtTarget(Transform _target) => m_cinemachineVirtualCamera.LookAt = _target;        
}
