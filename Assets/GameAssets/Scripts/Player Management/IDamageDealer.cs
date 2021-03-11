using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageDealer : IDealer
{
    void DealDamage(int v, DealerInfo info);
}

public interface IHealer : IDealer
{
    void Heal(int v,DealerInfo info);
}

public interface IDealer
{
    DealerInfo dealerInfo { get; }
}
