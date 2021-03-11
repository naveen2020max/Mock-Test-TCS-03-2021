using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : CareTaker
{
    public float patrolSpeed;
    public Transform CheckPoint1, CheckPoint2;
    private bool CPReached;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InDangerRange)
        {
            Debug.Log("chase");
            MoveToPlayer();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, CPReached ? CheckPoint1.position : CheckPoint2.position, patrolSpeed / 100);
            if (Vector2.Distance(transform.position, CheckPoint1.position) < 0.5f)
                CPReached = false;
            else if (Vector2.Distance(transform.position, CheckPoint2.position) < 0.5f)
                CPReached = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (HealthSyatem.Instance.InDanger)
            {
                Target = collision.GetComponent<Player>();
                InDangerRange = true;
            }
            else
            {
                InDangerRange = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            InDangerRange = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (HealthSyatem.Instance.InDanger)
            {
                Debug.Log("Safed");
                Target.SetPosition(WorldPlaces.Instance.PoliceStation.position);
                HealthSyatem.Instance.HealPlayer(20, info);
            } 
        }
    }
}
