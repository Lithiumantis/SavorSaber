using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Kill : MonoBehaviour {

    public string type = "Default";
    public GameObject drop;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KillMonster(string monsterName, Vector3 currentPos)
    {
        //Debug.Log("Monster Killed");
        //Debug.Log("Monster name: " + monsterName);

        //Find all spawners
        GameObject[] Spawners = GameObject.FindGameObjectsWithTag("Spawner");
        //Get closest spawner so that it stays in the correct room
        GameObject foundSpawner = findClosestSpawner(Spawners, currentPos);
        //Get enemy type to respawn
        GameObject deadEnemy = GameObject.Find(monsterName);
        //Notify Respawn() that there is an enemy of type deadEnemy to respawn
        foundSpawner.GetComponent<Respawn>().enemyMonster = deadEnemy;
        foundSpawner.GetComponent<Respawn>().isDead = true;
        GameObject dropA = Instantiate(drop, this.transform.position, Quaternion.identity);
        GameObject dropB = Instantiate(drop, this.transform.position, Quaternion.identity);
    }

    //Helper function to find closest spawner
    GameObject findClosestSpawner(GameObject[] spawners, Vector3 pos)
    {
        float minDist = 0f;
        float currDist = 0f;
        bool inUse = false;
        GameObject closestSpawner = null;

        foreach (GameObject spawner in spawners)
        {
            currDist = Vector3.Distance(spawner.transform.position, pos);
            inUse = spawner.GetComponent<Respawn>().isDead;

            if (!inUse && (currDist < minDist || closestSpawner == null))
            {
                minDist = currDist;
                closestSpawner = spawner;
            }
        }

        return closestSpawner;
    }
}
