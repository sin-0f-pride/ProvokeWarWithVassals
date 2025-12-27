using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

using ProvokeWarWithVassals.Behavior;


namespace ProvokeWarWithVassals
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            InformationManager.DisplayMessage(new InformationMessage(new TextObject("{=cFl3761Q}Provoke War With Vassals loaded").ToString(), Color.FromUint(0x00E67E22)));
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