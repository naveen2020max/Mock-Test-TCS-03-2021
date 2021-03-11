using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : CareTaker
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            HealthSyatem.Instance.HealPlayer(1, info);
        }
    }

}
