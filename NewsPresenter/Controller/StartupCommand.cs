using PureMVC.Patterns;

namespace EtherSoftware.NewsPresenter.Controller
{
    class StartupCommand : MacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            AddSubCommand(typeof(ConfigPrepCommand));
            AddSubCommand(typeof(ViewPrepCommand));
            AddSubCommand(typeof(ControllerPrepCommand));
            AddSubCommand(typeof(ModelPrepCommand));
        }
    }
}
