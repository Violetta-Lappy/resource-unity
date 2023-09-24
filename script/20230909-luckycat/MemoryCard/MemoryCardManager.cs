using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;
using VLGameProject.Tool;
using VLGameProject.VLGameProgram;

namespace VLGameProject.MemoryCard {
    public class MemoryCardManager : GameProgramObject {
        public MemoryCardXml m_memoryCardXml;
        public MemoryCardJson m_memoryCardJson;

        public override void Awake() {
            base.Awake();
            Set_MemoryCardXml(this.gameObject.IsNullAddComponent<MemoryCardXml>(this));
            Set_MemoryCardJson(this.gameObject.IsNullAddComponent<MemoryCardJson>(this));
        }

        public MemoryCardXml Get_MemoryCardXml() { return m_memoryCardXml; }
        public MemoryCardXml Set_MemoryCardXml(MemoryCardXml arg_memoryCardXml) => m_memoryCardXml = arg_memoryCardXml;
        public MemoryCardJson Get_MemoryCardJson() { return m_memoryCardJson; }
        public MemoryCardJson Set_MemoryCardJson(MemoryCardJson arg_memoryCardJson) => m_memoryCardJson = arg_memoryCardJson;
    }
}

