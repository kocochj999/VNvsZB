using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0, -5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(this.transform.position, new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z), 0.2f);
    }
}
