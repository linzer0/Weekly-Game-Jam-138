using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
        public float movementSpeed = 10.0f;
        public Transform startPosition, endPosition;
        private Transform currentMarker;

        void Start()
        {
                currentMarker = endPosition;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
                GameObject gameObject = collision.gameObject;
                if (gameObject.tag == "Player")
                {
                        GameManager.Restart();
                }
        }

        void FixedUpdate()
        {
                transform.position = Vector3.MoveTowards(transform.position, currentMarker.position, Time.deltaTime * movementSpeed);
                if (Vector3.Distance(transform.position, currentMarker.position) < 2)
                {
                        if (currentMarker == startPosition)
                                currentMarker = endPosition;
                        else
                                currentMarker = startPosition;
                }
        }
}
