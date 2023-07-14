using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CombineMeshes : MonoBehaviour
{
    private void Start()
    {
        MeshFilter[] _mesh_Filters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] _combine = new CombineInstance[_mesh_Filters.Length];

        Vector3 _start_Pos = transform.position;
        Quaternion _start_Rot = transform.rotation;
        
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        
        for (int i = 0; i < _mesh_Filters.Length; i++)
        {
            _combine[i].mesh = _mesh_Filters[i].sharedMesh;
            _combine[i].transform = _mesh_Filters[i].transform.localToWorldMatrix;
            _mesh_Filters[i].gameObject.SetActive(false);
        }
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(_combine);
        transform.gameObject.SetActive(true);

        transform.position = _start_Pos;
        transform.rotation = _start_Rot;
    }
    
}
