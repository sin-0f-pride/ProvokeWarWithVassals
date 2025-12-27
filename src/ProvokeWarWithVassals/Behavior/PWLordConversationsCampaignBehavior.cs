using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Party;

namespace ProvokeWarWithVassals.Behavior
{
    //LordConversationsCampaignBehavior
    internal class PWLordConversationsCampaignBehavior : CampaignBehaviorBase
    {
        public PWLordConversationsCampaignBehavior()
        {
            //Empty
        }

        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
        }

        public void OnSessionLaunched(CampaignGameStarter starter)
        {
            AddDialogs(starter);
        }

        protected void AddDialogs(CampaignGameStarter starter)
        {
            if (Settings.Current.EnableModLogic)
            {
                starter.AddPlayerLine("PW_lord_attack_verify", "lord_attack_verify", "lord_attack_verify_continue", "{=hObVTgc7}You heard me. Yield or fight!", new ConversationSentence.OnConditionDelegate(conversation_lord_attack_on_condition), null, 100, null, null);
                starter.AddDialogLine("PW_lord_attack_verify_continue", "lord_attack_verify_continue", "close_window", "{=1r0tDsrR}Attack!", null, new ConversationSentence.OnConsequenceDelegate(conversation_lord_attack_on_consequence), 100, null);
            }
        }

        public bool conversation_lord_attack_on_condition()
        {
            MobileParty encounteredMobileParty = PlayerEncounter.EncounteredMobileParty;
            return encounteredMobileParty != null && Hero.MainHero.MapFaction != null && encounteredMobileParty.LeaderHero.MapFaction != Hero.MainHero.MapFaction && Hero.MainHero.MapFaction.Leader != Hero.MainHero && !FactionManager.IsAtWarAgainstFaction(encounteredMobileParty.LeaderHero.MapFaction, Hero.MainHero.MapFaction);
        }

        private void conversation_lord_attack_on_consequence()
        {
            if (Settings.Current.EnableModLogic)
            {
                MobileParty encounteredMobileParty = PlayerEncounter.EncounteredMobileParty;
                if (encounteredMobileParty != null && !FactionManager.IsAtWarAgainstFaction(Hero.MainHero.MapFaction, encounteredMobileParty.MapFaction))
                {
                    ChangeRelationAction.ApplyPlayerRelation(Hero.OneToOneConversationHero, Settings.Current.RelationLossWithEnemyTargetClan, true, true);
                    ChangeRelationAction.ApplyPlayerRelation(Hero.OneToOneConversationHero.MapFaction.Leader, Settings.Current.RelationLossWithEnemyFactionLeader, true, true);
                    if (Settings.Current.EnableRelationLossWithOwnFactionLeader && Hero.MainHero.MapFaction.Leader != Hero.MainHero)
                    {
                        if (!Settings.Current.RelationshipLossHonorRequirement || Hero.MainHero.MapFaction.Leader.GetTraitLevel(DefaultTraits.Honor) > Settings.Current.HonorLevel)
                        {
                            ChangeRelationAction.ApplyPlayerRelation(Hero.MainHero.MapFaction.Leader, Settings.Current.RelationLossWithOwnFactionLeader, true, true);
                        }
                    }
                    if (Settings.Current.EnableRelationLossWithOwnFactionClans)
                    {
                        foreach (Clan clan in Campaign.Current.Clans)
                        {
                            if (clan.MapFaction == Hero.MainHero.MapFaction && clan.MapFaction.Leader != clan.Leader && clan.Leader != Hero.MainHero)
                            {
                                if (!Settings.Current.RelationshipLossHonorRequirement || clan.Leader.GetTraitLevel(DefaultTraits.Honor) > Settings.Current.HonorLevel)
                                {
                                    ChangeRelationAction.ApplyPlayerRelation(clan.Leader, Settings.Current.RelationLossWithOwnFactionClans, true, true);
                                }
                            }
                        }
                    }
                    DeclareWarAction.ApplyByPlayerHostility(Hero.MainHero.MapFaction, encounteredMobileParty.MapFaction);
                }
            }
        }

        public override void SyncData(IDataStore dataStore)
        {
            //Empty
        }
    }
}
