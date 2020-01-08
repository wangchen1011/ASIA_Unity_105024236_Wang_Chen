using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g : MonoBehaviour
{

    public Transform cam, target;
    public int speed = 3;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.Lerp(cam.position, target.position, 0.5f * Time.deltaTime * speed);
        cam.position = pos;
    }
}
