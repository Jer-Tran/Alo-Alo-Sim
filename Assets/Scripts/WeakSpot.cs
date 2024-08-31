using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public Player _player;
    public int _rotation;
    public bool _cw;

    // Start is called before the first frame update
    void Start()
    {
        _player = gameObject.GetComponentInParent<Player>();
        _rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DoRotation();
    }

    public void DoRotation()
    {
        float rot = 90 * _rotation;
        if (!_cw) { rot = rot * -1; }
        transform.Rotate(0, rot, 0);
    }

    public void CheckUnseen(Transform other)
    {
        //_player.GetHit();
        Vector3 pos1 = other.position; pos1.y = 0;
        Vector3 pos2 = transform.position; pos2.y = 0;
        float dot = Vector3.Dot(transform.forward, Vector3.Normalize(pos1 - pos2));
        if (dot > 0.5)
        {
            Debug.Log("facing: " + dot);
        }
        else
        {
            Debug.Log("away: " + dot);
        }
    }
}
