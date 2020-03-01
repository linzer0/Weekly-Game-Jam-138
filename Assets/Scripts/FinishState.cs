using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishState : MonoBehaviour
{
        void OnCollisionEnter2D(Collision2D collision)
        {
                GameObject gameObject = collision.gameObject;
                if (gameObject.tag == "Player")
                {
                        int lootCount = GameObject.FindGameObjectsWithTag("Loot").Length;
                        if (lootCount == 0)
                                GameManager.NextLevel();
                }
        }
}