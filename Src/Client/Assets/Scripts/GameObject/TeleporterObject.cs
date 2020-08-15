using System.Collections;
using System.Collections.Generic;
using Common.Data;
using Managers;
using Services;
using UnityEngine;

public class TeleporterObject : MonoBehaviour
{
    public int ID;

    private Mesh mesh = null;
	// Use this for initialization
	void Start ()
    {
        this.mesh = GetComponent<MeshFilter>().sharedMesh;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
#if UNITY_EDITOR
    void OnDrawGizmo()
    {
        Gizmos.color=Color.green;
        if (this.mesh!=null)
        {
            Gizmos.DrawWireMesh(this.mesh,this.transform.position+Vector3.up*this.transform.localScale.y*.5f,this.transform.rotation,this.transform.localScale);
        }
        UnityEditor.Handles.color=Color.red;
        UnityEditor.Handles.ArrowHandleCap(0,this.transform.position,this.transform.rotation,1f,EventType.Repaint);
    }
#endif
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("碰撞进入角色");
        PlayerInputController playControl = other.GetComponent<PlayerInputController>();
        if (playControl != null && playControl.isActiveAndEnabled)
        {
            TeleporterDefine td = DataManager.Instance.Teleporters[this.ID];
            if (td == null)
            {
                Debug.LogErrorFormat("Teleporter Object:Character[{0}]Enter Teleporter[{1}] But Teleporter is not existed", playControl.character.Info.Name, this.ID);
                return;
            }
            Debug.LogFormat("Teleporter Object:Character[{0}] Enter Teleporter[{1}][{2}] ", playControl.character.Info.Id, td.ID, td.Name);
            if (td.LinkTo > 0)
            {
                if (DataManager.Instance.Teleporters.ContainsKey(td.LinkTo))
                {
                    MapService.Instance.SendMapTeleport(this.ID);
                }
                else
                {
                    Debug.LogFormat("Teleporter ID[{0}]", td.ID, td.LinkTo);
                }
            }
        }
    }
}
