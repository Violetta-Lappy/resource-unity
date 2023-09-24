using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLGameComponent {
    public class GameComponentItem : GameProgramObject {
        public void Play_ItemStart(ABSItem arg_item) {
            arg_item.Item_Start();
        }
        public void Play_ItemLoop(ABSItem arg_item) {
            arg_item.Item_Loop();
        }
        public void Play_ItemEnd(ABSItem arg_item) {
            arg_item.Item_End();
        }
    }
}

