using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    public float defaultLength = 50.0f;
    public GameObject dot = null;

    //public Camera Camera { get; private set; } = null;

    private LineRenderer lineRenderer = null;
    public HMDInputModule inputModule = null;

    private void Awake()
    {
        //Camera = GetComponent<Camera>();
        //Camera.enabled = false;

        lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // Use default or distance
        PointerEventData data = inputModule.GetData();

        // If nothing is hit, set do default length
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? defaultLength : data.pointerCurrentRaycast.distance;

        //the default or distance
        //float targetLength = defaultLength;

        //raycast
        RaycastHit hit = CreateRaycast(targetLength);

        // Default
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        // or based on hit
        if (hit.collider != null)
            endPosition = hit.point;


        // Set position of the dot
        dot.transform.position = endPosition;

        // Set linerenderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, length);

        return hit;
    }
}
