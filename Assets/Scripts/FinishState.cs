using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishState : MonoBehaviour
{
        void OnTriggerEnter2D(Collider2D collider)
        {
                GameObject gameObject = collider.gameObject;
                if (gameObject.tag == "Player")
                {
                        int lootCount = GameObject.FindGameObjectsWithTag("Loot").Length;
                        if (lootCount == 0)
                                GameManager.NextLevel();
                }
        }
}