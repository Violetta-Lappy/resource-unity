//Contain all game data for the game to reference
//Using Unity Scriptable Object

[UnityEngine.CreateAssetMenu(menuName = "SO/Database")]
public class SODatabaseGameAsset : UnityEngine.ScriptableObject {
    public UnityEngine.GameObject m_prefab; //empty grid placement
    public UnityEngine.Sprite[] m_sz_gridSprites; //grid sprites
    public UnityEngine.Sprite[] m_sz_gameElementSprites; //gameelement sprites
}
