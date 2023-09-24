using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentAutoPosition : SingletonBlank<ComponentAutoPosition>
{
    [SerializeField] private Transform m_transformToAuto;
    private void LateUpdate() {
        if (m_transformToAuto == null) return; //early-exit, safe-check
        this.transform.position = m_transformToAuto.position; 
    }
    public void SetTransform(Transform _transform) => m_transformToAuto = _transform;
}
