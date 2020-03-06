using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{

        public bool doorIsOpen = false;
        public Transform newPosition;
        void FixedUpdate()
        {
                if (doorIsOpen)
                        transform.position = Vector3.MoveTowards(transform.position, newPosition.position, Time.deltaTime * 7);

        }
}
