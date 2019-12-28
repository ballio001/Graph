using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    [Range(10, 100)]
    public int resolution;
    Transform[] points;

    void Awake()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0;
        position.z = 0;
        points = new Transform[resolution];

        for (int i = 0; i < points.Length - 1; i++)
        {
            Transform point = Instantiate(pointPrefab);

            position.x = ((i + 0.5f) * step - 1f);
            position.y = position.x * position.x * position.x;

            point.localPosition = position;
            point.localScale = scale;

            point.SetParent(transform, false);
            points[i] = point;
            Debug.Log(points[i]);
            Debug.Log(resolution);
        }
    }
    void Update( )
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            point.localPosition = position;

        }
    }
}
