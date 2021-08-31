using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG{
    public class PlayerController : MonoBehaviour
        {
            // Start is called before the first frame update
            public CharacterStats playerStats;
            private Vector3 m_Movement;
            private Rigidbody m_playerRB;
            private Quaternion m_playerRotation;
            public Camera camera;
            void Awake()
            {
                playerStats = GetComponent<CharacterStats>();
                m_playerRB = GetComponent<Rigidbody>();
            }

            // Update is called once per frame
            void FixedUpdate()
            {
                Vector3 dir = Vector3.zero;
                float Horizontal = Input.GetAxis("Horizontal");
                float Vertical =  Input.GetAxis("Vertical");
                m_Movement.Set(Horizontal,0.0f,Vertical);
                m_Movement.Normalize();
                Vector3 camDirection = camera.transform.rotation * dir;
                Vector3 targetDirection = new Vector3(camDirection.x,0.0f,camDirection.z);
                Vector3 desireForward = Vector3.RotateTowards(
                    transform.forward,
                    m_Movement,
                    playerStats.rotationSpeed * Time.fixedDeltaTime,
                    0
                );
                Quaternion rotation = Quaternion.LookRotation(desireForward);

                m_playerRB.MovePosition(m_playerRB.position + m_Movement * playerStats.velocity * Time.fixedDeltaTime);
                m_playerRB.MoveRotation(rotation);
            }
        }
}

