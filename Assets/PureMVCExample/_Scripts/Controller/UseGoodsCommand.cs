using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGoodsCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        BagProxy bagProxy = Facade.RetrieveProxy(BagProxy.NAME) as BagProxy;

        InfoPanelProxy infoPanelProxy = Facade.RetrieveProxy(InfoPanelProxy.NAME) as InfoPanelProxy;

        BagPanelMediator mediator = Facade.RetrieveMediator(BagPanelMediator.NAME) as BagPanelMediator;
        InfoPanelMediator infoMediator = Facade.RetrieveMediator(InfoPanelMediator.NAME) as InfoPanelMediator;

        if (infoPanelProxy.InfoData.Type == 0)
        {
            bagProxy.AddHP(infoPanelProxy.InfoData.Value);
        }
        else
        {
            bagProxy.AddMP(infoPanelProxy.InfoData.Value);
        }

        bagProxy.DestroyBagItemByIconName(infoPanelProxy.InfoData.IconName);
        mediator.DestroyGameObject(infoMediator.bagItem);

        SendNotification(MyFacade.INFOPANEL_CLOSEUI);
        SendNotification(MyFacade.BAGPANEL_REMOVEDATA);
    }
}
