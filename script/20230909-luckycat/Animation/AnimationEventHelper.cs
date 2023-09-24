using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;
using UnityEngine.Events;

namespace VLGameProject.Animation {
    public class AnimationEventHelper : MonoBehaviour {
        public UltEvent OnAnimationEventStart;
        public UltEvent OnAnimationEventActive;
        public UltEvent OnAnimationEventEnd;
        public void AnimationEvent_Start() => OnAnimationEventStart?.Invoke();
        public void AnimationEvent_Active() => OnAnimationEventStart?.Invoke();
        public void AnimationEvent_End() => OnAnimationEventEnd?.Invoke();
    }
}

