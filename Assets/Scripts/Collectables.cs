using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerLevel playerLevel = other.GetComponent<PlayerLevel>();

        if(playerLevel != null && gameObject.tag == "LevelUp")
        {
            playerLevel.LevelUpCollected();
            gameObject.SetActive(false);
        }
        if(gameObject.tag == "key")
        {
            Debug.Log("key collected");
            gameObject.SetActive(false);
        }
        
    }
    
}
