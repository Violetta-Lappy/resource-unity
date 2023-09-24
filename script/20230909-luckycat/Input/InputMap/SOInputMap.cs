using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VLGameProject.VLInput {
    [CreateAssetMenu(fileName = "New GameInputPreset-Example", menuName = "VLGameProject/GameInput/New GameInputPreset-Example")]
    public class SOInputMap : ScriptableObject {

        public List<SOABSInputAction> list_m_inputAction;
        public List<SOABSInputAction> Get_listInputAction() { return list_m_inputAction; }
        public void Set_listInputAction(List<SOABSInputAction> arg_list) => list_m_inputAction = arg_list;

        public List<InputContext> list_m_inputContext;
        public List<InputContext> Get_listInputContext() { return list_m_inputContext; }
        public void Set_listInputContext(List<InputContext> arg_list) => list_m_inputContext = arg_list;

        public List<InputContextCombo> list_m_inputContextCombo;
        public List<InputContextCombo> Get_listInputContextCombo() { return list_m_inputContextCombo; }

        [ContextMenu("VLEditor_Reset")]
        private void VLEditor_Reset() {
            //Clear all first
            Get_listInputContext().Clear();
            Get_listInputContextCombo().Clear();

            //Check and remove duplicate
            Set_listInputAction(Get_listInputAction().Distinct().ToList());

            if (Get_listInputAction() != null) {
                foreach (SOABSInputAction action in Get_listInputAction()) {
                    if (action.Get_InputContext() != null) {
                        foreach (InputContext inputContext in action.Get_InputContext()) {
                            Get_listInputContext().Add(inputContext);
                        }
                    }
                    if (action.Get_InputContextCombo() != null) {
                        foreach (InputContextCombo inputContextCombo in action.Get_InputContextCombo()) {
                            Get_listInputContextCombo().Add(inputContextCombo);
                        }
                    }
                }
            }            
        }               
    }
}

