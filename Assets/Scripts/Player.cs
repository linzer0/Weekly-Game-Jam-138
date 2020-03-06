using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
        public static Player player;

        public float movementSpeed = 10.0f;
        private Rigidbody2D rigidbody;
        public static bool isAvel = false;
        private float distanceTakeLoot = 1.0f;
        public GameObject secondPart;


        public void ChangeColor()
        {
                var firstMaterial = GetComponent<Renderer>();
                firstMaterial.material.color = new Color(0,0,255);
                var secondMaterial = secondPart.GetComponent<Renderer>();
                secondMaterial.material.color = new Color(255, 0, 0);
        }


        void Start()
        {
                if (isAvel)
                        ChangeColor();
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
                if (isAvel)
                        ChangeColor();
                float move = Input.GetAxis("Horizontal") * movementSpeed;
                rigidbody.velocity = new Vector3(move, rigidbody.velocity.y, 0);
	
                if (Input.GetKeyDown(KeyCode.E))
                {
                        TakeLoot();
                }
        }
}
