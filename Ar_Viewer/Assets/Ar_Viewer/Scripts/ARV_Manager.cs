using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARV_Manager : MonoBehaviour
{
    List<MeshRenderer> meshes = new List<MeshRenderer>();
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer[] _meshes = GetComponentsInChildren<MeshRenderer>();
        if(_meshes.Length > 0)
        {
            for (int i = 1; i < _meshes.Length; i++)
            {
                if (_meshes[i].gameObject.transform.parent != gameObject.transform) continue;
                if (meshes.Count > 0)
                    _meshes[i].gameObject.SetActive(false);
                meshes.Add(_meshes[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 100, 100));
        if (GUILayout.Button("Next Mesh"))
        {
            if(meshes.Count > 0)
            {
                if (index + 1 == meshes.Count)
                    ActivateMesh(0);
                else
                    ActivateMesh(index + 1);
            }
        }
        GUILayout.EndArea();
    }

    void ActivateMesh(int _index)
    {
        meshes[index].gameObject.SetActive(false);
        index = _index;
        meshes[index].gameObject.SetActive(true);
    }
}
