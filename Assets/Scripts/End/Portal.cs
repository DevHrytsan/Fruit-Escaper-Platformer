using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject EndScreen;
    public SpriteRenderer portalRenderer;
    public Color deactivePortal = Color.red;
    public Color activePortal = Color.blue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentFruits == GameManager.instance.maxFruits)
        {
            portalRenderer.color = activePortal;
        }
        else
        {
            portalRenderer.color = deactivePortal;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance.currentFruits != GameManager.instance.maxFruits) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            EndScreen.SetActive(true);
        }
    }
}
