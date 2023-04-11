using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] int speed = 7;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*speed* Time.deltaTime);
    }
}
