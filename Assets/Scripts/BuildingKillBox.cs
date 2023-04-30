using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingKillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(AIController building in GameManager.instance.ais)
        {
            if(collision.gameObject == building.gameObject)
            {
                collision.gameObject.GetComponent<BuildingPawn>().Die();
            }
        }
    }
}
