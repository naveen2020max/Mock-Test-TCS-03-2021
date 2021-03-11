using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBody : NaturalElement
{
    public float waveSpeed;

    private Vector2 RandomDir;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InsideTheBody();
        if (Entered)
        {
            player.MovePosition(RandomDir * waveSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Entered = true;
            HealthSyatem.Instance.InDanger = true;
            RandomDir = new Vector2(Random.Range(0f, 1.0f), Random.Range(0f, 1.0f));
            player = collision.GetComponent<Player>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Entered = false;
            HealthSyatem.Instance.InDanger = false;
        }
    }
}
