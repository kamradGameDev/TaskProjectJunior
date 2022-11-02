using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private float speedMove;
    [SerializeField] private Vector3 vectorTarget;
    [SerializeField] private Rigidbody rb;
    public void StartCube(float speedMove, float distanceToDissapearance)
    {
        this.speedMove = speedMove;
        meshRenderer.material.color = Colors.instance.GetRandomColor();

        /*random rotation angle to get a random direction of the motion vector
        * taking into account the distance to the final goal 
         */
        int randomEulerAngle = TRandom.RandomIndex(0, 360);

        float targetPosX = distanceToDissapearance * Mathf.Cos(GetAngleRadians(randomEulerAngle));
        float targetPosZ = distanceToDissapearance * Mathf.Sin(GetAngleRadians(randomEulerAngle));

        vectorTarget = new Vector3(targetPosX, transform.localPosition.y, targetPosZ);

        Vector3 directionMove = vectorTarget - transform.localPosition;

        transform.rotation = Quaternion.LookRotation(directionMove, Vector3.up);

        gameObject.SetActive(true);

    }

    private float GetAngleRadians(int eulerAngle)
    {
        return eulerAngle * Mathf.Deg2Rad;
    }

    private float GetDistanceToTarget()
    {
        //float distance = Vector3.Distance(transform.localPosition, vectorTarget);
        float distance = Mathf.Sqrt(((transform.localPosition.x - vectorTarget.x) * (transform.localPosition.x - vectorTarget.x)) + 
            ((transform.localPosition.y - vectorTarget.y) * (transform.localPosition.y - vectorTarget.y)) + 
            (transform.localPosition.z - vectorTarget.z) * (transform.localPosition.z - vectorTarget.z));
        return distance;
    }

    private void FixedUpdate()
    {
        //Debug.DrawLine(transform.position, vectorTarget, Color.red);

        rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speedMove);

        if (GetDistanceToTarget() < 0.1f)
            gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        transform.localPosition = new Vector3(0f, 1f, 0f);
        PoolManager.instance.ReturnItemToPooled(PoolManager.instance.Cubes, this);
    }
}
