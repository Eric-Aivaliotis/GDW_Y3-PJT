using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject player;

    public ItemPoolManager itemPoolManager;
    // Start is called before the first frame update
    void Start()
    {
        itemPoolManager = FindObjectOfType<ItemPoolManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.collider.name == "Player")
        {
            itemPoolManager.ResetItem(this.gameObject);
            
        }
    }
}
