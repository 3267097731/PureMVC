using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelProxy : PureMVC.Patterns.Proxy
{
    public new const string NAME = "InfoPanelProxy";

    public InfoPanelModel InfoData;

    public InfoPanelProxy(string name) : base(name, null)
    {
        InfoData = new InfoPanelModel();
    }

    public void ChangeGoodDescribeData(BagModel data)
    {
        //GoodDescribeData = data;
        InfoData.Content = data.Describe;
        InfoData.IconName = data.Icon;
        InfoData.Value = data.Value;
        InfoData.Type = data.Type;

        SendNotification(MyFacade.REFRESH_INFOPANEL_DATA);
    }
}
