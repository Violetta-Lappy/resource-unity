using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentObstacle : MonoBehaviour {
    [SerializeField] private bool isPaint = false;
    [SerializeField] private MeshRenderer m_renderer;
    [SerializeField] private Material m_material;
    [SerializeField] private Material m_materialNotPaint;

    private void Start() {        
        SetMaterial(m_materialNotPaint);
        SetScale(0.5f);

        if (ManagerGameValue.Instance == null) {
            Debug.Log("No ManagerGameLevel in this scene");
            return; 
        }
        ManagerGameValue.Instance.AddToObstacleList(this);
        ManagerGameValue.Instance.IncreaseObstacleLeft(); 
    }    

    public bool IsPaint() { return isPaint; }
    
    public void SetObstacleStatus(bool _status) { 
        isPaint = _status;        
        OnObstacleStatus();
    }

    public void SetMaterial(Material _material) => m_renderer.material = _material;
    public void SetScale(float _value) => m_renderer.transform.localScale = new Vector3(_value, _value, _value);

    private void OnObstacleStatus() {
        if (isPaint) {
            ManagerGameValue.Instance.IncreaseScore();
            ManagerGameValue.Instance.IncreaseCombo();
            ManagerGameValue.Instance.DecreaseObstacleLeft();            
            SetMaterial(m_material);
            SetScale(0.3f);

            VFXManager.Instance.SpawnVFX(ENUM_VFX_TYPE.OBSTACLE_DESTROY, this.transform.position);
            AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_GAME_TYPE.OBSTACLE_SUCCESS_PAINT);
        }
        else { 
            ManagerGameValue.Instance.IncreaseObstacleLeft();
            SetMaterial(m_materialNotPaint);
            SetScale(0.5f);

            VFXManager.Instance.SpawnVFX(ENUM_VFX_TYPE.OBSTACLE_RESTORE, this.transform.position);
            AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_GAME_TYPE.OBSTACLE_FAIL_PAINT);
        }
    }
}
