using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagModel : MonoBehaviour
{
    public string Name { get; set; }
    public int Value { get; set; }
    public string Describe { get; set; }
    public string Icon { get; set; }
    public int Type { get; set; }

    public BagModel(string _name,int _value,string _describe,string _icon, int _type)
    {
        Name = _name;
        Value = _value;
        Describe = _describe;
        Icon = _icon;
        Type = _type;
    }
}
