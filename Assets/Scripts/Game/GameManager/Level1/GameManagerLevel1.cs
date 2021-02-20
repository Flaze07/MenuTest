using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLevel1 : MonoBehaviour
{
    public GameObject[] pressurePlateRoom1;
    public GameObject[] pressurePlateRoom2;

    private bool[][] pressurePlateState;
    public int currRoom; //only public for testing, don't forget to change it later

    public GameObject player;

    //level1 stuff
    public GameObject doorClosedRoom1;
    public Transform spawnPosition;

    //level2 stuff
    public GameObject gap;
    public GameObject gapCollision;
    public GameObject doorClosedRoom2;
    public GameObject doorOpenRoom2;

    //level 3 stuff
    

    void Start()
    {
        //currRoom = 1; //commented only for testing purposes
        pressurePlateState = new bool[2][];
        pressurePlateState[0] = new bool[1];
        pressurePlateState[1] = new bool[2];
        for(int i = 0; i < pressurePlateState.Length; ++i) {
            for(int j = 0; j < pressurePlateState[i].Length; ++j) {
                pressurePlateState[i][j] = false;
            }
        }
        player.transform.position = spawnPosition.position;
    }

    void Update() {
        GameObject checkSpawner;
        GameObject checkEnemy;
        switch(currRoom) {
        case 1:
            checkSpawner = GameObject.FindWithTag("EnemySpawner1");
            checkEnemy = GameObject.FindWithTag("Enemy");
            if(checkSpawner == null && checkEnemy == null && pressurePlateState[0][0]) {
                doorClosedRoom1.SetActive(false);
                currRoom += 1;
            }
            /*
            if(roomClear[0] && pressurePlateState[0][0]) {
                doorOpen[currRoom-1].SetActive(true);
                doorClosed[currRoom-1].SetActive(false);
                pressurePlateRoom1[currRoom-1].GetComponent<Animator>().SetBool("isPressed", false);
                currRoom += 1;
            }*/             
            break;   
        case 2:
            if(pressurePlateState[1][0] && pressurePlateState[1][1]) {
                gap.SetActive(true);
                gapCollision.SetActive(false);
            }
            checkSpawner = GameObject.FindWithTag("EnemySpawner2");
            checkEnemy = GameObject.FindWithTag("Enemy");
            if(checkSpawner == null && checkEnemy == null) {
                doorClosedRoom2.SetActive(false);
                doorOpenRoom2.SetActive(true);
            }
            break;
        }
    }

    public void SetPressurePlateState(int index, bool state) {
        if(currRoom == 1) {
            pressurePlateState[0][index] = state;
        } else if(currRoom == 2) {
            pressurePlateState[1][index] = state;
        }
    }
}
