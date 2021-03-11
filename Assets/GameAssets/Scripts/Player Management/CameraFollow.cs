using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;

    private Player target;
    // Start is called before the first frame update
    void Start()
    {
        target = HealthSyatem.Instance.gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.GetPosition(), speed);
    }
}
