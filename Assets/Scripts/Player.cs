using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

        public float movementSpeed = 10.0f;
        private Rigidbody2D rigidbody;
        private float distanceTakeLoot = 1.0f;

        void Start()
        {
                rigidbody = GetComponent<Rigidbody2D>();
        }

        void TakeLoot()
        {
                GameObject[] lootInLevel = GameObject.FindGameObjectsWithTag("Loot");
                foreach (var x in lootInLevel)
                {
                        if (Vector2.Distance(this.transform.position, x.transform.position) < distanceTakeLoot)
                        {
                                Destroy(x);
                        }
                }
        }

        void FixedUpdate()
        {
                float move = Input.GetAxis("Horizontal") * movementSpeed;
                rigidbody.velocity = new Vector3(move, rigidbody.velocity.y, 0);
	
                if (Input.GetKeyDown(KeyCode.E))
                {
                        TakeLoot();
                }
        }
}
