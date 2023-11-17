using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveSelector : MonoBehaviour, ISelector
{
    [SerializeField] public List<Transform> selectables;
    [SerializeField] private float threshold = 0.97f;

    private Transform _selection;
    public void Check(Ray ray)
    {
        _selection = null;

        var closest = 0f;

        for (int i = 0; i < selectables.Count; i++)
        { 
            var vector1 = ray.direction;
            var vector2 = selectables[i].position - ray.origin;

            var lookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);

            if(lookPercentage > threshold && lookPercentage > closest)
            {
                closest = lookPercentage;
                _selection = selectables[i];
            }
        }
    }
    public Transform GetSelection()
    {
       return _selection;
    }
}
