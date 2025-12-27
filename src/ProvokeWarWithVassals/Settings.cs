using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using TaleWorlds.Localization;

namespace ProvokeWarWithVassals
{
    public class Settings : AttributeGlobalSettings<Settings>
    {
        private const string HeadingEnableModLogic = "{=!!}Enable Mod Logic";

        public override string Id => "ProvokeWarWithVassals_v1";
        public override string DisplayName => new TextObject("{=!!}Provoke War With Vassals").ToString();
        public override string FolderName => "ProvokeWarWithVassals";
        public override string FormatType => "json2";

        [SettingPropertyBool(HeadingEnableModLogic, IsToggle = true, Order = 0, RequireRestart = true, HintText = "{=!!}Enables the mod logic. Requires game restart to remove dialogue option if disabled. Default is Enabled.")]
        [SettingPropertyGroup(HeadingEnableModLogic, GroupOrder = 1)]
        public bool EnableModLogic { get; set; } = true;

        [SettingPropertyBool("{=!!}Enable Relation Loss With Own Faction Leader", Order = 1, RequireRestart = false, HintText = "{=!!}Enables relation loss with your faction leader. Default is Disabled.")]
        [SettingPropertyGroup(HeadingEnableModLogic, GroupOrder = 1)]
        public bool EnableRelationLossWithOwnFactionLeader { get; set; } = false;

        [SettingPropertyInteger("{=!!}Relation Loss With Own Faction Leader", -100, -1, Order = 2, RequireRestart = false, HintText = "{=!!}The amount of relation loss with your faction leader. Default is -10.")]
        [SettingPropertyGroup(HeadingEnableModLogic, GroupOrder = 1)]
        public int RelationLossWithOwnFactionLeader { get; set; } = -10;

        [SettingPropertyBool("{=!!}Enable Relation Loss With Own Faction Clans", Order = 3, RequireRestart = false, HintText = "{=!!}Enables relation loss with your faction's clans. Default is Disabled.")]
        [SettingPropertyGroup(HeadingEnableModLogic, GroupOrder = 1)]
        public bool EnableRelationLossWithOwnFactionClans { get; set; } = false;

        [SettingPropertyInteger("{=!!}Relation Loss With Own Faction Clans", -100, -1, Order = 4, RequireRestart = false, HintText = "{=!!}The amount of relation loss with your faction's clans. Default is -10.")]
        [SettingPropertyGroup(HeadingEnableModLogic, GroupOrder = 1)]
        public int RelationLossWithOwnFactionClans { get; set; } = -10;

        [SettingPropertyBool("{=!!}Relationship Loss Honor Requirement", Order = 5, RequireRestart = false, HintText = "{=!!}Enables an exception to relation loss for own faction clans whose leader has an honor level at or below the selected value. Default is Disabled.")]
        [SettingPropertyGroup(HeadingEnableModLogic, GroupOrder = 1)]
        public bool RelationshipLossHonorRequirement { get; set; } = false;

        [SettingPropertyInteger("{=!!}Honor Level", -2, 2, Order = 6, RequireRestart = false, HintText = "{=!!}A clan leader in your faction at or below the selected value will not have a lower opinion of you for provoking a war against another faction's vassals. Default is -1.")]
        [SettingPropertyGroup(HeadingEnableModLogic, GroupOrder = 1)]
        public int HonorLevel { get; set; } = -1;

        [SettingPropertyInteger("{=!!}Relation Loss With Enemy Faction Leader", -100, -1, Order = 7, RequireRestart = false, HintText = "{=!!}The amount of relation loss with the enemy faction leader. Default is -10.")]
        [SettingPropertyGroup(HeadingEnableModLogic, GroupOrder = 1)]
        public int RelationLossWithEnemyFactionLeader { get; set; } = -10;

        public static Settings Current => Instance!;
    }
}
