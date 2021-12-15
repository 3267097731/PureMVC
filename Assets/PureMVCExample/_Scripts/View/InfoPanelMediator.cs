using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelMediator : PureMVC.Patterns.Mediator
{
    public new const string NAME = "InfoPanelMediator";

    public InfoPanelView View;

    public GameObject bagItem;

    public InfoPanelMediator(object viewComponent) : base(NAME, viewComponent)
    {
        View = ((GameObject)ViewComponent).GetComponent<InfoPanelView>();

        View.Close.onClick.AddListener(delegate ()
        {
            SendNotification(MyFacade.CLOSEINFOPANEL);
        });
        View.Use.onClick.AddListener(delegate ()
        {
            SendNotification(MyFacade.USEGOODS);
        });
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case MyFacade.INFOPANEL_OPENUI:
                {
                    View.gameObject.SetActive(true);
                    bagItem = notification.Body as GameObject;
                }
                break;
            case MyFacade.REFRESH_INFOPANEL_DATA:
                {
                    InfoPanelProxy goodDescribePanelProxy = Facade.RetrieveProxy(InfoPanelProxy.NAME) as InfoPanelProxy;
                    View.Icon.sprite = Resources.Load<Sprite>("_Sprites/" + goodDescribePanelProxy.InfoData.IconName);
                    View.Content.text = goodDescribePanelProxy.InfoData.Content;
                }
                break;
            case MyFacade.INFOPANEL_CLOSEUI:
                {
                    View.gameObject.SetActive(false);
                }
                break;
        }
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>() { MyFacade.INFOPANEL_OPENUI, MyFacade.REFRESH_INFOPANEL_DATA, MyFacade.INFOPANEL_CLOSEUI };

        return list;
    }
}
