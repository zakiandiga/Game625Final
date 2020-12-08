using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private int poolSize;
    [SerializeField] private bool expandable;

    private List<GameObject> freeList;
    private List<GameObject> usedList;

    private void Awake()
    {
        freeList = new List<GameObject>();
        usedList = new List<GameObject>();

        for (int i = 0; i< poolSize; ++i)
        {
            GenerateNewObject();
        }
    }

    //Get obj from the pool
    public GameObject GetObject()
    {
        int totalFree = freeList.Count; //current number in the freeList
        if (freeList.Count == 0 && !expandable) //if there is no item in pool and the pool is not expandable
            return null;
        else if (freeList.Count == 0)
            GenerateNewObject();

        GameObject g = freeList[totalFree - 1]; //get the object 
        freeList.RemoveAt(totalFree - 1); //remove object from the freelist
        usedList.Add(g); //add it to the usedlist

        return g;
    }

    //Return obj back to the pool
    public void ReturnObject (GameObject obj)
    {
        Debug.Assert(usedList.Contains(obj)); //bool check if passed obj !null
        obj.SetActive(false);
        usedList.Remove(obj);
        freeList.Add(obj);
    }

    private void GenerateNewObject()
    {
        GameObject g = Instantiate(prefab);
        g.transform.parent = transform;
        g.SetActive(false);
        freeList.Add(g);
    }
}
