using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        GameObject obj = GameObjectUtility.Instance.CreateGameObject("_Prefabs/BagPanel");

        Facade.RegisterMediator(new BagPanelMediator(obj));

        SendNotification(MyFacade.CREATBAGGOODS);
    }
}
