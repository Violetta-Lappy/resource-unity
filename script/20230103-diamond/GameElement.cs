/**
 * author: hoanglongplanner
 * date: Jan 2th 2022
 * des: All logic of game element use in ManagerMatch3
 */

using UnityEngine.EventSystems;

public class GameElement : UnityEngine.MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler {

    /*VARIABLES*/
    public int i32_idX;
    public int i32_idY;

    private UnityEngine.Vector3 vec3_position;    
    public UnityEngine.UI.Image m_uiImage;
    public ENUM_GRID_TYPE enum_gridType = ENUM_GRID_TYPE.OPEN;
    public ENUM_GAMEELEMENT_TYPE enum_gameElementType = ENUM_GAMEELEMENT_TYPE.RED;

    /*FUNCTIONS*/
    public void Setup(int idX, int idY, UnityEngine.Vector3 position, ENUM_GRID_TYPE _gridType, ENUM_GAMEELEMENT_TYPE _gameElementType) {
        i32_idX = idX;
        i32_idY = idY;
        vec3_position = position;
        enum_gridType = _gridType;
        enum_gameElementType = _gameElementType;
        SetGridType(_gridType);
        SetGameElementSprite(_gameElementType);
    }

    public void SetGameElementType(ENUM_GAMEELEMENT_TYPE type) {        
        enum_gameElementType = type;
        SetGameElementSprite(type);
    }

    public void SetGridType(ENUM_GRID_TYPE type) {
        enum_gridType = type;
        if (type == ENUM_GRID_TYPE.CLOSE) m_uiImage.enabled = false;
        this.GetComponent<UnityEngine.UI.Image>().sprite = ManagerMatch3.Instance.m_database.m_sz_gridSprites[(int)type];
    }

    public void SetGameElementSprite(ENUM_GAMEELEMENT_TYPE type) {                
        m_uiImage.sprite = ManagerMatch3.Instance.m_database.m_sz_gameElementSprites[(int)type];
    }

    public void OnPointerEnter(PointerEventData eventData) {        
        if (ManagerMatch3.Instance == null) return; //safe-check, early exit        
        ManagerMatch3.Instance.OnDragGameElementToPosition(this);
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (ManagerMatch3.Instance == null) return; //safe-check, early exit        
        ManagerMatch3.Instance.OnClickGameElement(this);
    }    

    public void OnPointerUp(PointerEventData eventData) {
        if (ManagerMatch3.Instance == null) return; //safe-check, early exit                        
        ManagerMatch3.Instance.OnReleaseGameElement();
    }    
}
