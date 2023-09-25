using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject player, Marker;
    public float speed = 1;
    public bool snap;

    public Camera cam;

    private Vector3 screenPos, worldPosition;
    public float dist;

    private Vector3 mid, quart, eighth;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Position of pointer
        screenPos = Input.mousePosition;
        screenPos.z = dist;

        worldPosition = cam.ScreenToWorldPoint(screenPos);
        //RaycastHit hit;

        Marker.transform.position = worldPosition;

        //move cam in between where mouse is and player
        mid = new Vector3((player.transform.position.x + Marker.transform.position.x) / 2, 0, (player.transform.position.z + Marker.transform.position.z) / 2);
        quart = new Vector3((player.transform.position.x + mid.x) / 2, 0, (player.transform.position.z + mid.z) / 2);
        eighth = new Vector3((player.transform.position.x + quart.x) / 2, 0, (player.transform.position.z + quart.z) / 2);

        transform.position = Vector3.Slerp(transform.position, eighth, speed * Time.deltaTime);
    }
}
