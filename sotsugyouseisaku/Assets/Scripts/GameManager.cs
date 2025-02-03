using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private SpellType spellType_;

    [SerializeField, Header("Item Prefabs")]
    private SpellCard fireballPrefab_;
    [SerializeField]
    private SpellCard thunderPrefab_;
    [SerializeField]
    private SpellCard waterPrefab_;
    [SerializeField]
    private SpellCard healPrefab_;

    [SerializeField, Header("Enemy Prefabs")]
    private GameObject golemPrefab_;
    [SerializeField]
    private GameObject mimicPrefab_;
    [SerializeField]
    private GameObject batPrefab_;

    [SerializeField] private LayerMask whatIsGround_, whatIsPlayer_;

    [SerializeField] private Transform player_;

    //Set Distance from player
    [SerializeField,Header ("Item Variables")]
    private float offsetDistFromPlayer_;
    [SerializeField] 
    private float itemSpawnPointRange_;
    [SerializeField] 
    private Vector3 itemSpawnLocation_;
    //SpawnTimer
    [SerializeField]
    private float itemSpawnCooldown_ = 5f; // Set cooldown between spawns
    private float itemSpawnTimer_;

    private bool itemCanSpawn_;

    [SerializeField, Header("Enemy Variables")]
    private float enemySpawnPointRange_;
    [SerializeField]
    private Vector3 enemySpawnLocation_;
    [SerializeField]
    private float enemySpawnCooldown_;
    private float enemySpawnTimer_;

    private bool enemyCanSpawn_;
    private int enemyType_; //used to determine enemyType. 

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

    private Vector3 RandomizeItemLocation()
    {
        //Calculate Random point in range
        float randomZ = Random.Range(-itemSpawnPointRange_, itemSpawnPointRange_);
        float randomX = Random.Range(-itemSpawnPointRange_, itemSpawnPointRange_);

        itemSpawnLocation_ = new Vector3(randomX, 0.5f, randomZ); //0.5f is above the ground

        return itemSpawnLocation_;
    }

    private void CheckItemSpawnLocation()
    {
        float distance = Vector3.Distance(itemSpawnLocation_, player_.position);

        if (distance < offsetDistFromPlayer_)
        {
            itemSpawnLocation_ = Vector3.zero; //reset random location
            RandomizeItemLocation();
        }
        else
        {
            itemCanSpawn_ = true;
        }
    }

    private void SpawnSpellCard()
    {
        if (itemCanSpawn_)
        {
            SpellCard spawnSpellCard;
            spellType_ = (SpellType)Random.Range(0, (int)SpellType.kNumOfSpells);
            switch (spellType_)
            {
                case SpellType.kFire:
                    spawnSpellCard = Instantiate(fireballPrefab_, itemSpawnLocation_, Quaternion.identity);
                    break;
                case SpellType.kThunder:
                    spawnSpellCard = Instantiate(thunderPrefab_, itemSpawnLocation_, Quaternion.identity);
                    break;
                case SpellType.kWater:
                    spawnSpellCard = Instantiate(waterPrefab_, itemSpawnLocation_, Quaternion.identity);
                    break;
                case SpellType.kHeal:
                    spawnSpellCard = Instantiate(healPrefab_, itemSpawnLocation_, Quaternion.identity);
                    break;
            }

            itemCanSpawn_ = false;
            itemSpawnTimer_ = itemSpawnCooldown_; // Reset the timer after spawning
        }
    }

    private Vector3 RandomizeEnemyLocation()
    {
        //Calculate Random point in range
        float randomZ = Random.Range(-itemSpawnPointRange_, itemSpawnPointRange_);
        float randomX = Random.Range(-itemSpawnPointRange_, itemSpawnPointRange_);

        itemSpawnLocation_ = new Vector3(randomX, 0.5f, randomZ); //0.5f is above the ground
        return enemySpawnLocation_;
    }

    private void CheckEnemySpawnLocation()
    {
        float distance = Vector3.Distance(enemySpawnLocation_, player_.position);

        if (distance < offsetDistFromPlayer_)
        {
            enemySpawnLocation_ = Vector3.zero; //reset random location
            RandomizeEnemyLocation();
        }
        else
        {
            enemyCanSpawn_ = true;
        }
    }

    private void SpawnEnemy()
    {
        if (enemyCanSpawn_)
        {
            int enemyType = Random.Range(0, 3);
            GameObject enemyObj;
            switch (enemyType)
            {
                case 0:
                    enemyObj = Instantiate(golemPrefab_, itemSpawnLocation_, Quaternion.identity) as GameObject;
                    break;
                case 1:
                    enemyObj = Instantiate(mimicPrefab_, itemSpawnLocation_, Quaternion.identity) as GameObject;
                    break;
                case 2:
                    enemyObj = Instantiate(batPrefab_, itemSpawnLocation_, Quaternion.identity) as GameObject;
                    break;
            }

            enemyCanSpawn_ = false;
            enemySpawnTimer_ = enemySpawnCooldown_; // Reset the timer after spawning
        }
    }

    private void Update()
    {
        if (Player.Instance.GetIsDead())
        {
            SceneManager.LoadScene("GameOverScene");
        }


        // Countdown spawn timer
        if (!itemCanSpawn_)
        {
            itemSpawnTimer_ -= Time.deltaTime;

            if (itemSpawnTimer_ <= 0f)
            {
                itemCanSpawn_ = true;
                itemSpawnLocation_ = Vector3.zero; //reset random location
                RandomizeItemLocation();
                CheckItemSpawnLocation();
                SpawnSpellCard();
            }
        }

        if (!enemyCanSpawn_)
        {
            enemySpawnTimer_ -= Time.deltaTime;

            if(enemySpawnTimer_ <= 0f)
            {
                enemyCanSpawn_ = true;
                enemySpawnLocation_ = Vector3.zero;
                RandomizeEnemyLocation();
                CheckEnemySpawnLocation();
                SpawnEnemy();
            }
        }
    }
}
