using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_VFX_TYPE {
    OBSTACLE_DESTROY,
    OBSTACLE_RESTORE
}

public class VFXManager : SingletonBlank<VFXManager> {

    [SerializeField] private GameObject[] sz_m_vfxObj;       
    public void SpawnVFX(ENUM_VFX_TYPE _type, Vector3 _position) => DestroyObject(Instantiate(sz_m_vfxObj[(int)_type], _position, Quaternion.identity));
    private void DestroyObject(GameObject _gameObject, float _time = 5.0f) => Destroy(_gameObject, _time);
}
