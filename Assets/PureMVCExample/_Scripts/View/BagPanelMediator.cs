using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagPanelMediator : PureMVC.Patterns.Mediator
{
    public new const string NAME = "BagPanelMediator";

    private BagPanelView View;

    private List<GameObject> BagItemLists = new List<GameObject>();

    public BagPanelMediator(object viewComponent) : base(NAME, viewComponent)
    {
        View = ((GameObject) ViewComponent).GetComponent<BagPanelView>();
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case MyFacade.REFRESH_BAGPANEL_UI:
                {
                    if (!View.isActiveAndEnabled)
                    {
                        View.gameObject.SetActive(true);
                    }
                }
                break;
            case MyFacade.REFRESH_BAGPANEL_INFO:
                {
                    BagProxy bagProxy = Facade.RetrieveProxy(BagProxy.NAME) as BagProxy;
                    View.HP.text = bagProxy.HP.ToString();
                    View.MP.text = bagProxy.MP.ToString();
                }
                break;
            case MyFacade.BAGPANEL_RFRESHDATA:
                {

                }
                break;
        }
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>() { MyFacade.REFRESH_BAGPANEL_UI, MyFacade.REFRESH_BAGPANEL_INFO,MyFacade.BAGPANEL_RFRESHDATA };

        return list;
    }
    public void DestroyGameObject(GameObject game)
    {
        for (int i = 0; i < BagItemLists.Count; i++)
        {
            if(game == BagItemLists[i])
            {
                GameObject.Destroy(BagItemLists[i]);
            }
        }
    }

    public void AddItems(GameObject obj)
    {
        BagItemLists.Add(obj);
    }

    public void ClearGameObject()
    {
        for (int i = 0; i < BagItemLists.Count; i++)
        {
            GameObject.Destroy(BagItemLists[i].gameObject);
        }
    }

    public void AddButtonOnClickEvent()
    {
        for (int i = 0; i < BagItemLists.Count; i++)
        {
            int tempIndex = i;
            BagItemLists[i].GetComponent<Button>().onClick.AddListener(delegate ()
            {
                SendNotification(MyFacade.BUTTONONCLICK, BagItemLists[tempIndex]);
            });
        }
    }

    public GameObject BonusItem(int index)
    {
        return BagItemLists[index];
    }
    public GameObject InstanceBonusItem()
    {
        return GameObjectUtility.Instance.CreateGameObject(View.BagItemTemplate, View.Parent);
    }
}
