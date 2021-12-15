using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFacade : PureMVC.Patterns.Facade
{
    public const string START_UP = "start_up";
    public const string CREATBAGGOODS = "creatbaggoods";
    public const string INFOPANEL_OPENUI = "infopanel_openui";
    public const string INFOPANEL_CLOSEUI = "infopanel_closeui";
    public const string CLOSEINFOPANEL = "closeinfopanel";
    public const string USEGOODS = "usergoods";
    public const string REFRESH_INFOPANEL_DATA = "refresh_infopanel_data";
    public const string REFRESH_BAGPANEL_UI = "refresh_bagpanel_ui";
    public const string BUTTONONCLICK = "buttononclick";
    public const string REFRESH_BAGPANEL_INFO = "refresh_bagpanel_info";
    public const string BAGPANEL_REMOVEDATA = "bagpanel_removedata";
    public const string BAGPANEL_RFRESHDATA = "bagpanel_refreshdata";
    static MyFacade()
    {
        m_instance = new MyFacade();
    }

    public static MyFacade GetInstance()
    {
        return m_instance as MyFacade;
    }

    public void Launch()
    {
        SendNotification(MyFacade.START_UP);
    }

    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(START_UP, typeof(StartUpCommand));
        RegisterCommand(CREATBAGGOODS, typeof(CreatBagGoodsCommand));
        RegisterCommand(BUTTONONCLICK, typeof(BagItemClickCommand));
        RegisterCommand(CLOSEINFOPANEL, typeof(CloseInfoPanelCommand));
        RegisterCommand(USEGOODS, typeof(UseGoodsCommand));
    }

    protected override void InitializeFacade()
    {
        base.InitializeFacade();
    }

    protected override void InitializeView()
    {
        base.InitializeView();
    }

    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(new BagProxy(BagProxy.NAME));
        RegisterProxy(new InfoPanelProxy(InfoPanelProxy.NAME));
    }
}
