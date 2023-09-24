using UnityEngine;

namespace VLGameProject.VLGameComponent {
    public abstract class ABSItem : ScriptableObject {
        public ItemData m_itemData;
        public ItemData Get_ItemData() { return m_itemData; }
        public abstract void Item_Start();
        public abstract void Item_Loop();
        public abstract void Item_End();
    }
}
