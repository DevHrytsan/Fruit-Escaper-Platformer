using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpawnPoints
{
    public Transform spawnPoint;
    public GameObject spawnedPickup;
    public bool IsSpawned;
}

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform SpawnPoint;

    public List<GameObject> spawnedEntities;
    [Header("SpawnedPickups")]
    public List<GameObject> spawningPickups;

    public List<SpawnPoints> spawnPointsOfpickup;

    public int maxFruits = 5;
    public int currentFruits = 0;

    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Respawn();

    }


    // Update is called once per frame
    public void AddEntity(GameObject entity)
    {
        spawnedEntities.Add(entity);
    }
    public void DeleteEntity(GameObject entity)
    {
        spawnedEntities.Remove(entity);
        Destroy(entity);
    }
    public void AddFruit()
    {
        currentFruits++;
        currentFruits = Mathf.Clamp(currentFruits, 0, maxFruits);
    }
    public void RemoveFruitsCounter()
    {
        currentFruits = 0;
        currentFruits = Mathf.Clamp(currentFruits, 0, maxFruits);
    }


    public void Respawn()
    {
        for (int i = 0; i < spawnedEntities.Count; i++)
        {
            Destroy(spawnedEntities[i]);
        }
        spawnedEntities.Clear();
        Regenerate();
        RemoveFruitsCounter();
        player.position = SpawnPoint.position;
    }

    public void Regenerate()
    {
        for (int i = 0; i < spawnPointsOfpickup.Count; i++)
        {
            if (spawnPointsOfpickup[i].IsSpawned == true)
            {
                Destroy(spawnPointsOfpickup[i].spawnedPickup);
                spawnPointsOfpickup[i].IsSpawned = false;
            }

        }

        for (int i = 0; i < maxFruits; i++)
        {
            pickupInitialize();
   
        }

    }

    public bool pickupInitialize()
    {
        int randomPosition = Random.Range(0, spawnPointsOfpickup.Count);

        if (spawnPointsOfpickup[randomPosition].IsSpawned == false)
        {
            int random = Random.Range(0, spawningPickups.Count);
            spawnPointsOfpickup[randomPosition].spawnedPickup = Instantiate(spawningPickups[random], spawnPointsOfpickup[randomPosition].spawnPoint);
            spawnPointsOfpickup[randomPosition].IsSpawned = true;
            return true;
        }
        else
        {
            pickupInitialize();
        }

        return false;
    }

}
