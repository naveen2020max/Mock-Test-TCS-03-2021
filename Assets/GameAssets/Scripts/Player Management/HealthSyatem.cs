using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthSyatem : MonoBehaviour
{
    //singleton
    public static HealthSyatem Instance;

    public Text HealthText;
    public Text EmegencyText;

    private int Level=1;

    // player health 
    public int Health { get; private set; } = 100;
    public bool InDanger { get; set; }

    //delegates dealdamage and heal player
    public Action<int,DealerInfo> DealDamage;
    public Action<int,DealerInfo> HealPlayer;

    private void Awake()
    {
        //implement singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Twoo healthsyatem instance excite");
            Destroy(gameObject);
        }

        //subscribe to takeDamage and heal functions
        DealDamage += TakeDamage;
        HealPlayer += Heal;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EmegencyText.enabled = true;

        //if (InDanger)
        //{
        //}else
        //    EmegencyText.enabled = false;

    }

    //dealdamage to player
    private void TakeDamage(int _value,DealerInfo _info)
    {
        Health -= _value;
        EmegencyText.color = Color.red;

        EmegencyText.text = _info.EmegencyText;
        UpdateHealthVisual();
        if (Health < 0)
        {
            //dead
            Level++;
            dead();
        }
        //Debug.Log(_info.EmegencyText + Health);
    }

    //heal player
    private void Heal(int _value,DealerInfo _info)
    {
        Health += _value;
        EmegencyText.color = Color.green;
        EmegencyText.text = _info.EmegencyText;

        if (Health >= 100)
            Health = 100;
        UpdateHealthVisual();
    }

    private void UpdateHealthVisual()
    {
        HealthText.text = Health.ToString();
    }

    void dead()
    {
        GetComponent<Player>().SetPosition(WorldPlaces.Instance.PoliceStation.position);
        Health = 100;
        switch (Level)
        {
            case 2:GetComponent<Player>().speed = 1.5f;
                EmegencyText.text = "You have came back to life and Received extra speed";
                //Debug.Log(Level);
                break;
            case 3:
                GetComponent<Player>().speed = 2f;
                EmegencyText.text = "You have came back to life and Received extra speed";
                //Debug.Log(Level);
                break;
            case 4:
                GetComponent<Player>().speed = 3f;
                EmegencyText.text = "You have came back to life and Received extra speed";
                //Debug.Log(Level);
                break;
            default:
                break;
        }
        UpdateHealthVisual();

    }
}
