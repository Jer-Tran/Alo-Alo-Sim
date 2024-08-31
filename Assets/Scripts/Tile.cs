using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool _active;
    public Snapshot _snapshot;
    public Unseen _orb;
    public ParentSnapshot _cube;
    public DeathZone _dZone;
    public Mine _mine;
    public int _direction;
    public Transform _arrow;
    public MeshRenderer _renderer;
    public List<Material> _defaultMat;
    public List<Material> _ignitedMat;
    public List<Material> _mineMat;
    public int _triggerType;
    public bool _forceReset;
    // Some orb reference, optional

    // Start is called before the first frame update
    void Start()
    {
        SetDirection(0);
        _cube.gameObject.SetActive(false);
        _orb.gameObject.SetActive(false);
        _mine.Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        // Just for while debugging
        if (_forceReset)
        {
            SetArrow();
            _forceReset = false;
        }
    }

    public void SetMine()
    {
        // change texture again
    }
    // Would then have to have a ontriggerenter for this script, but could place it in a mine instead

    public void ResolveMine()
    {
        // if mine is still active, wipe party
    }

    public void SetOrb()
    {
        // Prepare orb
    }

    public void SetCube()
    {
        // activate cube
    }

    public void Activate()
    {
        _dZone.Activate();
        _renderer.SetMaterials(_ignitedMat);

        // And then pop the cubes/orbs
        _orb.SnapshotUnseen();
        _cube.DoSnapshot();
        // Something to hide them briefly after popping, probably they disable themself
    }

    public void Deactivate()
    {
        _dZone.Deactivate();
        _renderer.SetMaterials(_defaultMat);
    }

    public void DoSnapshot()
    {
        if (_snapshot != null)
        {
            _snapshot.DoSnapshot();
        }
    }

    public void SetDirection(int dir)
    {
        _direction = dir;
        SetArrow();
    }

    public void ResetDirection()
    {
        _direction = 0;
        SetArrow();
    }

    public int GetDirection()
    {
        return _direction;
    }

    private void SetArrow()
    {
        // Set arrow's rotation on y-axis
        if (_direction == 0)
        {
            _arrow.gameObject.SetActive(false);
        }
        else
        {
            _arrow.gameObject.SetActive(true);
            _arrow.eulerAngles = new Vector3(0, 90 * (_direction - 1), 0);
        }
    }
}
