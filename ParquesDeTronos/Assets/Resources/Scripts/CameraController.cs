using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float angular_velocity;
    Vector3 m_EulerAngleVelocity;
    bool stopRotation = false;
    float timer = 0f;
    public float rotationDuration = 7f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, angular_velocity, 0);
    }

    void FixedUpdate()
    {
        if (!stopRotation)
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
            timer += Time.fixedDeltaTime;
            if (timer >= rotationDuration)
            {
                stopRotation = true;
                Debug.Log("Rotation stopped after " + rotationDuration + " seconds.");
            }
        }
    }
}

