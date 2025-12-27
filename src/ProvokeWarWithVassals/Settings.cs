using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.Common;

namespace ProvokeWarWithVassals
{
    public class Settings : AttributeGlobalSettings<Settings>
    {
        public Settings()
        {
            //Rmpty
        }
        private bool _enableModLogic = true;

        private bool _enableRelationLossWithOwnFactionLeader = false;
        private int _relationLossWithOwnFactionLeader = -10;

        private bool _enableRelationLossWithOwnFactionClans = false;
        private int _relationLossWithOwnFactionClans = -10;

        private bool _relationshipLossHonorRequirement = false;
        private int _honorLevel = -1;

        public override string Id => "ProvokeWarWithVassals_v1";

        public override string DisplayName => "Provoke War With Vassals";

        public override string FolderName => "ProvokeWarWithVassals";

        public override string FormatType => "json2";

        [SettingPropertyBool("{=!}Enable Mod Logic", Order = 0, RequireRestart = true, HintText = "{=!}Enables the mod logic. Requires game restart to remove dialogue option if disabled. Default is Enabled.")]
        public bool EnableModLogic
        {
            get => _enableModLogic;
            set
            {
                if (_enableModLogic != value)
                {
                    _enableModLogic = value;
                    OnPropertyChanged(nameof(EnableModLogic));
                }
            }
        }

        [SettingPropertyBool("{=!}Enable Relation Loss With Own Faction Leader", Order = 1, RequireRestart = false, HintText = "{=!}Enables relation loss with your faction leader. Default is Disabled.")]
        public bool EnableRelationLossWithOwnFactionLeader
        {
            get => _enableRelationLossWithOwnFactionLeader;
            set
            {
                if (_enableRelationLossWithOwnFactionLeader != value)
                {
                    _enableRelationLossWithOwnFactionLeader = value;
                    OnPropertyChanged(nameof(EnableRelationLossWithOwnFactionLeader));
                }
            }
        }

        [SettingPropertyInteger("{=!}Relation Loss With Own Faction Leader", -100, -1, Order = 2, RequireRestart = false, HintText = "{=!}The amount of relation loss with your faction leader. Default is -10.")]
        public int RelationLossWithOwnFactionLeader
        {
            get => _relationLossWithOwnFactionLeader;
            set
            {
                if (_relationLossWithOwnFactionLeader != value)
                {
                    _relationLossWithOwnFactionLeader = value;
                    OnPropertyChanged(nameof(RelationLossWithOwnFactionLeader));
                }
            }
        }

        [SettingPropertyBool("{=!}Enable Relation Loss With Own Faction Clans", Order = 3, RequireRestart = false, HintText = "{=!}Enables relation loss with your faction's clans. Default is Disabled.")]
        public bool EnableRelationLossWithOwnFactionClans
        {
            get => _enableRelationLossWithOwnFactionClans;
            set
            {
                if (_enableRelationLossWithOwnFactionClans != value)
                {
                    _enableRelationLossWithOwnFactionClans = value;
                    OnPropertyChanged(nameof(EnableRelationLossWithOwnFactionClans));
                }
            }
        }

        [SettingPropertyInteger("{=!}Relation Loss With Own Faction Clans", -100, -1, Order = 4, RequireRestart = false, HintText = "{=!}The amount of relation loss with your faction's clans. Default is -10.")]
        public int RelationLossWithOwnFactionClans
        {
            get => _relationLossWithOwnFactionClans;
            set
            {
                if (_relationLossWithOwnFactionClans != value)
                {
                    _relationLossWithOwnFactionClans = value;
                    OnPropertyChanged(nameof(RelationLossWithOwnFactionClans));
                }
            }
        }

        [SettingPropertyBool("{=!}Relationship Loss Honor Requirement", Order = 5, RequireRestart = false, HintText = "{=!}Enables an exception to relation loss for clans whose leader has an honor level at or below the selected value. Default is Disabled.")]
        public bool RelationshipLossHonorRequirement
        {
            get => _relationshipLossHonorRequirement;
            set
            {
                if (_relationshipLossHonorRequirement != value)
                {
                    _relationshipLossHonorRequirement = value;
                    OnPropertyChanged(nameof(RelationshipLossHonorRequirement));
                }
            }
        }

        [SettingPropertyInteger("{=!}Honor Level", -2, 2, Order = 6, RequireRestart = false, HintText = "{=!}A clan leader in your faction at or below the selected value will not have a lower opinion of you for provoking a war against another faction's vassals. Default is -1.")]
        public int HonorLevel
        {
            get => _honorLevel;
            set
            {
                if (_honorLevel != value)
                {
                    _honorLevel = value;
                    OnPropertyChanged(nameof(HonorLevel));
                }
            }
        }
        public static Settings Current
        {
            get => Settings.Instance!;
        }
    }
}
