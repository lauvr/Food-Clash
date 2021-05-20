using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
   public GameObject[] bottomRooms;
   public GameObject[] topRooms;
   public GameObject[] leftRooms;
   public GameObject[] rightRooms;
   public GameObject bossRoom;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss = false;
    public GameObject boss;

    private void Update()
    {
        if(waitTime <= 0 && spawnedBoss == false)
        {
            int lastPosition = rooms.Count - 1;
            GameObject finalRoom = rooms[lastPosition];
            Destroy(rooms[lastPosition]);
            Instantiate(bossRoom, finalRoom.transform.position, bossRoom.transform.rotation);
            Instantiate(boss, rooms[lastPosition].transform.position, Quaternion.identity);
            spawnedBoss = true;
                
            
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
