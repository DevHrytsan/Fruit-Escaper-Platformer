using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody2D player;
    public Vector2 maxDynamicDistance = new Vector2(5f,5f);
    public float smoothness = 10f;
    private Vector3 targetWantedFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetWantedFollow = player.transform.position + (transform.up * player.velocity.normalized.y * maxDynamicDistance.y) + (transform.right * player.velocity.normalized.x * maxDynamicDistance.x);
        
        transform.position = Vector3.Lerp(transform.position, targetWantedFollow, Time.deltaTime * smoothness);
    }
}
