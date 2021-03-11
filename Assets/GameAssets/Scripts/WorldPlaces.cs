using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPlaces : MonoBehaviour
{
    public static WorldPlaces Instance;

    public Transform PoliceStation;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Two Worldplaces instance exites");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
