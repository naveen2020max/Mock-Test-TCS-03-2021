using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DealerType { DAMAGEDEAL,HEALER}

[System.Serializable]
public class DealerInfo 
{
    public string name;
    public DealerType DType;
    public string EmegencyText;

}
