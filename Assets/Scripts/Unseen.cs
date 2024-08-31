using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unseen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SnapshotUnseen();
    }

    public void SnapshotUnseen()
    {
        var objects = FindObjectsOfType<WeakSpot>();
        foreach (WeakSpot obj in objects)
        {
            obj.CheckUnseen(transform);
        }
    }
}
