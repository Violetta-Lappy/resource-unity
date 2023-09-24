using UnityEngine;

namespace VLGameProject.VLLocalization {

    public enum ENUMLocalizationContext {
        K_None = 0,
        K_Hello,
        K_Greet,
        K_GameProjectName,
        K_GameProjectCopyright,
        K_GameProjectVersion,                
        K_MainMenuPressAnyKey,
        K_MainMenuStartGame,
        K_MainMenuLoadGame,
        K_MainMenuStorySelect,
        K_MainMenuChapterSelect,
        K_MainMenuMissionSelect,        
        K_MainMenuGallery,
        K_MainMenuOption,        
        K_MainMenuAchievement,
        K_MainMenuCredit,
        K_MainMenuExitToOs,
        K_OptionDisplayMode,
        K_OptionDisplayResolution,
        K_OptionDisplayAspectRatio,
        K_OptionDisplayRefreshRate,
        K_OptionDisplayScreenOrientation,
        K_OptionGraphicMultiCoreRender,
        K_OptionGraphicMSAA,
        K_OptionGraphicFSAA,
        K_OptionGraphicModelTextureDetail,
        K_OptionGraphicGroundTextureDetail,
        K_OptionGraphicShadowDetail,
        K_OptionGraphicShaderDetail,
        K_OptionGraphicParticleDetail,
        K_OptionGraphicTextureFilteringMode,
        K_OptionAudioMixerMaster,
        K_OptionAudioMixerBgm,
        K_OptionAudioMixerSfx,
        K_OptionAudioMixerSfxGui,
        K_OptionAudioMixerSfxGame,
        K_OptionAudioMixerVoice,
        K_OptionLocalizationLanguageSelect,
        K_OptionMouseSensitivity,
        K_OptionMouseDotPerInch_DPS,
        K_GameplayObjective,
        K_GameplayGoal,
        K_GameplayMission,
        K_GameplayTimeLimit,
        K_GameplayCombo,
        K_GameplayEnemyCount,
        K_GameplayEnemyRemain,
        K_GameplayStatHealth,
        K_GameplayStatMana,
        K_GameplayStatStamina,
        K_GameplayValueHealth,
        K_GameplayValueMana,
        K_GameplayValueStamina,
        K_GameplayCurrencyCoin,        
        K_GameplayCurrencyPenny,        
        K_GameplayCurrencyDime,        
        K_GameplayCurrencyCrystal,        
        K_GameplayCurrencyCrystalSpecial,        
        K_GameplayCurrencyTicket,        
        K_GameplayCurrencyTicketBronze,        
        K_GameplayCurrencyTicketSilver,        
        K_GameplayCurrencyTicketGold,        
    }

    public abstract class ABSSOLocalizationContext : ScriptableObject {
        public abstract ENUMLocalizationContext Get_LocalizationContext();
    }

    [CreateAssetMenu(fileName = "New Example", menuName = "VLGameProject/LocalizationContext/New Example")]
    public class LocalizationContext_Example : ABSSOLocalizationContext {
        public override ENUMLocalizationContext Get_LocalizationContext() {
            return ENUMLocalizationContext.K_None;
        }
    }
}
