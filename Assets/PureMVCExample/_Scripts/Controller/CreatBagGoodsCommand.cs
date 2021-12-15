using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatBagGoodsCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        BagProxy bagItemProxy = Facade.RetrieveProxy(BagProxy.NAME) as BagProxy;

        if(bagItemProxy != null)
        {
            bagItemProxy.CreatBagItem();

            BagPanelMediator mediator = Facade.RetrieveMediator(BagPanelMediator.NAME) as BagPanelMediator;

            GameObject obj = null;

            for (int i = 0; i < bagItemProxy.BagLists.Count; i++)
            {
                //GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("_Prefabs/BagItem"));
                obj = mediator.InstanceBonusItem();
                obj.SetActive(true);

                BagItemView item = obj.GetComponent<BagItemView>();
                if(item != null)
                {
                    item.Init(bagItemProxy.BagLists[i]);
                }
                mediator.AddItems(obj);
            }
            mediator.AddButtonOnClickEvent();

            SendNotification(MyFacade.REFRESH_BAGPANEL_UI);
        }

    }
}
