using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareTaker : MonoBehaviour
{
    public float Speed;
    public DealerInfo info;
    protected bool InDangerRange;
    protected Player Target;
    
    public void MoveToPlayer()
    {
        if(Target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.GetPosition2D(), Speed/100);
        }
    }

}
