using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLGui {
    public class GuiPopulate : MonoBehaviour {
        [SerializeField] private GuiManager m_guiManager;
        [SerializeField] private ENUM_GUIELEMENT_POPULATE enum_type;
        [SerializeField] private GameObject m_prefab;
        [SerializeField] private List<GameObject> list_m_populateItem;
        public void Set_GuiManager(GuiManager _guiManager) => m_guiManager = _guiManager;
        public bool Is_GuiPopulate_Type(ENUM_GUIELEMENT_POPULATE _type) { return _type == enum_type; }
        public ENUM_GUIELEMENT_POPULATE Get_GuiPopulate_Type() { return enum_type; }
        public void Setup() => Create_GuiPopulate_Item();
        public void Create_GuiPopulate_Item(int arg_numOfItem = 0, string arg_data = "") {
            GameObject temp = new GameObject();
            temp.transform.SetParent(this.transform);
            list_m_populateItem.Add(temp);
        }
        public void Clear_GuiPopulate_List() => list_m_populateItem.Clear();
    }

    public class GuiPopulateItem {
        //Create GuiPopulateItem for GuiPopulate able to do something
        public GameObject m_referencePrefab;
    }
}
