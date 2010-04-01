using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using EtherSoftware.NewsPresenter.View;
using EtherSoftware.NewsPresenter.Persistence;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.Controller
{
    public class StartupCommand : MacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            AddSubCommand(typeof(ConfigPrepCommand));
            AddSubCommand(typeof(ModelPrepCommand));
        }
    }
}
