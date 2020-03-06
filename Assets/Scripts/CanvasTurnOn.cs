using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTurnOn : MonoBehaviour
{
        public Canvas canvas;
        public GameObject panel;

        void OnTriggerEnter2D(Collider2D coll)
        {
                panel.SetActive(true);
        }

        void OnTriggerExit2D(Collider2D coll)
        {
                panel.SetActive(false);
        }
}
