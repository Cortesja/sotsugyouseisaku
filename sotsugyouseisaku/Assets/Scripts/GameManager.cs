using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SpellType spellType_;

    [SerializeField, Header("Prefabs")]
    private SpellCard fireballPrefab_;
    [SerializeField]
    private SpellCard thunderPrefab_;
    [SerializeField]
    private SpellCard waterPrefab_;
    [SerializeField]
    private SpellCard healPrefab_;

    [SerializeField] private LayerMask whatIsGround_, whatIsPlayer_;

    [SerializeField] private Transform player_;

    //Set Distance from player
    [SerializeField] float offsetDistFromPlayer_;
    [SerializeField] float spawnPointRange_;
    bool isAwayFromPlayer_;

    //Set location
    [SerializeField] private Vector3 spawnLocation_;
    bool canSpawn_;

    //SpawnTimer
    [SerializeField] private float spawnCooldown_ = 5f; // Set cooldown between spawns
    private float spawnTimer_;

    private void Awake()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if(playerObj != null)
        {
            player_ =  playerObj.transform;
            Debug.Log("Player found GameManager: " + playerObj);
        }
        else
        {
            Debug.LogError("Player not found! Make sure the Player has the correct tag.");
        }
    }

    private Vector3 RandomizeLocation()
    {
        //Calculate Random point in range
        float randomZ = Random.Range(-spawnPointRange_, spawnPointRange_);
        float randomX = Random.Range(-spawnPointRange_, spawnPointRange_);

        spawnLocation_ = new Vector3(randomX, 0.5f, randomZ); //0.5f is above the ground

        return spawnLocation_;
    }

    private void CheckSpawnLocation()
    {
        float distance = Vector3.Distance(spawnLocation_, player_.position);

        if (distance < offsetDistFromPlayer_)
        {
            spawnLocation_ = Vector3.zero; //reset random location
            RandomizeLocation();
        }
        else
        {
            canSpawn_ = true;
        }
    }

    private void SpawnSpellCard()
    {
        if (canSpawn_)
        {
            SpellCard spawnSpellCard;
            spellType_ = (SpellType)Random.Range(0, (int)SpellType.kNumOfSpells);
            switch (spellType_)
            {
                case SpellType.kFire:
                    spawnSpellCard = Instantiate(fireballPrefab_, spawnLocation_, Quaternion.identity);
                    break;
                case SpellType.kThunder:
                    spawnSpellCard = Instantiate(thunderPrefab_, spawnLocation_, Quaternion.identity);
                    break;
                case SpellType.kWater:
                    spawnSpellCard = Instantiate(waterPrefab_, spawnLocation_, Quaternion.identity);
                    break;
                case SpellType.kHeal:
                    spawnSpellCard = Instantiate(healPrefab_, spawnLocation_, Quaternion.identity);
                    break;
            }

            canSpawn_ = false;
            spawnTimer_ = spawnCooldown_; // Reset the timer after spawning
        }
    }

    private void Update()
    {
        // Countdown spawn timer
        if (!canSpawn_)
        {
            spawnTimer_ -= Time.deltaTime;

            if (spawnTimer_ <= 0f)
            {
                canSpawn_ = true;
                spawnLocation_ = Vector3.zero; //reset random location
                RandomizeLocation();
                CheckSpawnLocation();
                SpawnSpellCard();
            }
        }
    }
}
