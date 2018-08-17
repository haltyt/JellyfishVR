using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMove : MonoBehaviour
{

    public float speed = 0.5f;
    public float scale = 1f;
    public float velocity = 0.5f;
    public GameObject target;
    public float timeToMove = 10.0f;
    float t;

    void Update()
    {
        t += Time.deltaTime / timeToMove;
        Vector3 position = transform.position;
        Vector3 targetPosition = Vector3.Lerp(position, target.transform.position, t);
        Vector3 direction = target.transform.position - position;
        //Quaternion toRotation = Quaternion.FromToRotation(target.transform.forward * Quaternion.AngleAxis(90f, new Vector3(1,0,0)), direction);
        Quaternion toRotation = Quaternion.FromToRotation(target.transform.forward, direction);
        //Quaternion toRotation = Quaternion.LookRotation(direction);
        Quaternion rotation = transform.rotation;
        //transform.rotation = Quaternion.Lerp(rotation, toRotation, t);
        position.x += MoveForward(direction.x);
        position.y += MoveForward(direction.y);
        position.z += MoveForward(direction.z);

        transform.position = position;
    }

    float MoveForward(float degree)
    {
        // move forward
        return (-Mathf.Sin(Mathf.PI * Time.time * speed) * scale + velocity) * degree / 10000f;
    }
}