using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement playerScript;
    [SerializeField] UIManager ui;
    private int laps = 0;
    Vector3 spawnPoint;
    // Start is called before the first frame update
    public void handlePlayerLap()
    {
        laps += 1;
        playerScript.Respawn(spawnPoint);
        ui.UpdateScore(laps);
    }
    
    void Start(){
        spawnPoint = player.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update(){
        if (player.transform.position.y < -25){
            playerScript.Respawn(spawnPoint);
        }
    }
}
