using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagItemView : MonoBehaviour
{
    public BagModel itemModel;

    public Image ICON;

    public Button ButtonOn;

    internal void Init(BagModel bagItemModel)
    {
        itemModel = bagItemModel;
        ICON.sprite = Resources.Load<Sprite>("_Sprites/" + itemModel.Icon);
    }
}
