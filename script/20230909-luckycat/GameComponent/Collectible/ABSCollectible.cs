using UnityEngine;

namespace VLGameProject.VLGameComponent {
    public abstract class ABSCollectible : ScriptableObject {
        public CollectibleData m_collectibleData;
        public CollectibleData Get_CollectibleData() { return m_collectibleData; }
        public abstract void Collectible_CollectSuccess();
        public abstract void Collectible_CollectFail();
    }
}
