using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement playerScript;
    Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -25){
            playerScript.Respawn(spawnPoint);
        }
    }
}
