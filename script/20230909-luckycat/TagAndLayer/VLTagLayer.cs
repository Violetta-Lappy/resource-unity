using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLTagLayer {
    public class VLTagLayer : MonoBehaviour {
        public List<SOTag> list_m_tag;
        public List<SOLayer> list_m_layer;
        public bool HasTag(string arg_name) { return false; }
        public bool HasLayer(string arg_name) { return false; }
    }
}
