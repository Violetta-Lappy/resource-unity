using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

namespace VLGameProject.VLGui {
    public class VLGuiEventListener : Singleton<VLGuiEventListener> {
        public UltEvent GuiText_OnTimeCountdown;
        public UltEvent GuiText_OnTimeStopwatch;
        public UltEvent<string> GuiText_OnAudioMixerMaster;
        public UltEvent GuiText_OnAudioMixerBgm;
        public UltEvent GuiText_OnAudioMixerSfx;
        public UltEvent GuiText_OnAudioMixerVoice;
        public void UpdateText_TimeCountdown() => GuiText_OnTimeCountdown?.Invoke();
        public void UpdateText_TimeStopwatch() => GuiText_OnTimeStopwatch?.Invoke();
        public void UpdateText_AudioMixerMaster(string arg_text) => GuiText_OnAudioMixerMaster?.Invoke(arg_text);
        public void UpdateText_AudioMixerBgm() => GuiText_OnAudioMixerBgm?.Invoke();
        public void UpdateText_AudioMixerSfx() => GuiText_OnAudioMixerSfx?.Invoke();
        public void UpdateText_AudioMixerVoice() => GuiText_OnAudioMixerVoice?.Invoke();
    }
}
