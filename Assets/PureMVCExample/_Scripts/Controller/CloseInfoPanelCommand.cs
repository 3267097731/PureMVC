using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInfoPanelCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        SendNotification(MyFacade.INFOPANEL_CLOSEUI);
    }
}
