using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItemClickCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        InfoPanelMediator goodDescribePanelMediator = Facade.RetrieveMediator(InfoPanelMediator.NAME) as InfoPanelMediator;

        if(goodDescribePanelMediator == null)
        {
            GameObject obj = GameObjectUtility.Instance.CreateGameObject("_Prefabs/InfoPanel");

            Facade.RegisterMediator(new InfoPanelMediator(obj));
        }

        InfoPanelProxy goodDescribePanelProxy = Facade.RetrieveProxy(InfoPanelProxy.NAME) as InfoPanelProxy;

        goodDescribePanelProxy.ChangeGoodDescribeData((notification.Body as GameObject).GetComponent<BagItemView>().itemModel);

        SendNotification(MyFacade.INFOPANEL_OPENUI, notification.Body);
    }
}
