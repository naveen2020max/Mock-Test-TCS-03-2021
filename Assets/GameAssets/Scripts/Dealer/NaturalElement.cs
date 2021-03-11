using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType { WATER,FIRE,POISON}
public class NaturalElement : MonoBehaviour
{
    public ElementType Type;
    public int DamagePreSecond;
    protected bool Entered;
    protected float EnteredTime;

    [SerializeField]
    protected DealerInfo info;

    public DealerInfo dealerInfo { get { return info; } private set { } }

    

    protected void InsideTheBody()
    {
        if (Entered)
        {
            if (EnteredTime > 2)
            {
                DealDamage(DamagePreSecond,dealerInfo);
                EnteredTime = 0;
            }
            else
                EnteredTime += Time.deltaTime;
        }
    }

    public void DealDamage(int v,DealerInfo _info)
    {
        HealthSyatem.Instance.DealDamage(v,_info);
    }

}
