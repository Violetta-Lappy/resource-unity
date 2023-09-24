using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLCamera {
    public class CameraManager : MonoBehaviour {
        [SerializeField] private Transform m_target;
        public void Set_CameraTargetTransform(Transform _transform) => m_target = _transform;
    }
}

