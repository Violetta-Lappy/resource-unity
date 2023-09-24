using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLGui {
    public class GuiPage : MonoBehaviour {
        public SOABSGuiPageType m_soGuiPage;
        public bool IsGuiPage(ENUMGuiPage _type) { return m_soGuiPage.IsGuiPageType(_type); }
        public ENUMGuiPage Get_GuiPage() { return m_soGuiPage.Get_GuiPageType(); }
        public bool Is_GuiPage_Active() { return this.gameObject.activeInHierarchy; }
        public void Set_Status_GuiPage_Active(bool _status) => this.gameObject.SetActive(_status);
    }
}

