using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//modified from individual in class assignment 1
[System.Serializable]
public class ItemPoolManager : MonoBehaviour
{
    public GameObject item;

    public int maxItems;

    Queue<GameObject> itemQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        BuildItemPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildItemPool()
    {
        for (int i = 0; i < maxItems; i++)
        {
            GameObject tempItem = Instantiate(item, new Vector3(Random.Range(0f,20f), Random.Range(0f,20f), 0.0f), Quaternion.identity);
            tempItem.SetActive(false);
            itemQueue.Enqueue(tempItem);
        }
    }

    public GameObject GetItem()
    {
        GameObject tempItem;
        //if Queue is not empty
        if (!QueueIsEmpty())
        {
            tempItem = itemQueue.Dequeue();
            tempItem.SetActive(true);
        }
        else
        {
            tempItem = MonoBehaviour.Instantiate(item, new Vector3(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), 0.0f), Quaternion.identity);
            maxItems += 1;
        }
        return tempItem;
    }

    public void ResetItem(GameObject item)
    {
        //Move position back to pool
        item.transform.position = new Vector3(Random.Range(0f, 20f), Random.Range(0f, 20f), 0.0f);
        //Deactivate it since its back in pool
        item.SetActive(false);
        //Actually queue it back into the pool
        itemQueue.Enqueue(item);
    }

    //function to return item pool size
    public int ItemPoolSize()
    {
        return itemQueue.Count;
    }
    public bool QueueIsEmpty()
    {
        return ItemPoolSize() == 0;
    }

}
