using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSnapshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoSnapshot();
    }

    public void DoSnapshot()
    {
        Snapshot[] snapshots = gameObject.GetComponentsInChildren<Snapshot>();
        foreach (Snapshot ss in snapshots)
        {
            ss.DoSnapshot();
        }
    }
}
