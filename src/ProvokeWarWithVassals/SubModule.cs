using HarmonyLib;
using ProvokeWarWithVassals.Behavior;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;


namespace ProvokeWarWithVassals
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            new Harmony("mod.bannerlord.provokewarwithvassals").PatchAll();
        }

        protected override void OnGameStart(Game game, IGameStarter starterObject)
        {
            base.OnGameStart(game, starterObject);
            if (game.GameType is Campaign && starterObject is CampaignGameStarter starter)
            {
                starter.AddBehavior(new PWLordConversationsCampaignBehavior());
            }
        }
    }
}