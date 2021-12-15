using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagProxy : PureMVC.Patterns.Proxy
{
    public List<BagModel> BagLists = new List<BagModel>();

    public int HP = 100;

    public int MP = 100;

    public new const string NAME = "BagProxy";

    private static string[] BAGITEM_NAME = new string[] {
        "小血瓶" ,"稍微小血瓶","中血瓶","稍微大血瓶","大血瓶",
        "小蓝瓶" , "稍微小蓝瓶", "中蓝瓶", "稍微大蓝瓶", "大蓝瓶"
    };
    private static int[] BAGITEM_VALUE = new int[] {
        100,125,150,175,200, 100, 125, 150, 175, 200 
    };
    private static string[] BAGITEM_DESCRIBE = new string[] {
        "小血瓶 使用能回复100血量" ,"稍微小血瓶 使用能回复125血量",
        "中血瓶 使用能回复150血量","稍微大血瓶 使用能回复175血量",
        "大血瓶 使用能回复200血量","小蓝瓶 使用能回复100蓝量" ,
        "稍微小蓝瓶 使用能回复125蓝量", "中蓝瓶 使用能回复150蓝量",
        "稍微大蓝瓶 使用能回复175蓝量", "大蓝瓶 使用能回复200蓝量"
    };
    private static string[] BAGITEM_ICON = new string[] {
        "101" ,"102","103","104","105","201" ,"202", "203","204", "205"
    };

    private static int[] BAGITEM_TYPE = new int[] {
        0,0,0,0,0,1,1,1,1,1
    };

    public BagProxy(string proxyName) : base(proxyName)
    {

    }
    public void AddHP(int value)
    {
        HP += value;

        SendNotification(MyFacade.REFRESH_BAGPANEL_INFO);
    }
    public void AddMP(int value)
    {
        MP += value;

        SendNotification(MyFacade.REFRESH_BAGPANEL_INFO);
    }
    public void DestroyBagItemByIconName(string iconName)
    {
        for (int i = 0; i < BagLists.Count; i++)
        {
            if(BagLists[i].Icon == iconName)
            {
                BagLists.Remove(BagLists[i]);
            }
        }
        SendNotification(MyFacade.BAGPANEL_RFRESHDATA);
    }

    public void CreatBagItem()
    {
        for (int i = 0; i < BAGITEM_NAME.Length; i++)
        {
            string name = BAGITEM_NAME[i];
            int value = BAGITEM_VALUE[i];
            string describe = BAGITEM_DESCRIBE[i];
            string icon = BAGITEM_ICON[i];
            int type = BAGITEM_TYPE[i];
            BagModel model = new BagModel(name, value, describe,icon, type);
            BagLists.Add(model);
        }

        SendNotification(MyFacade.REFRESH_BAGPANEL_INFO);
    }
}
