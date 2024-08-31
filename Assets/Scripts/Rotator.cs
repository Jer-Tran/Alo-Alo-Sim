using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public int _rotation;
    public bool _cw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoRotation(); // Testing only
    }

    public void DoRotation()
    {
        float rot = 90 * _rotation;
        if (!_cw) { rot = rot * -1; }
        transform.Rotate(0, rot, 0);
    }

    public void ResetRotation()
    {

    }
}
