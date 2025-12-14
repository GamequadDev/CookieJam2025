using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class GameManger : MonoBehaviour
{
    [SerializeField] private Tilemap gameTilemap;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject prefabToSpawn;

    [SerializeField] private int coinCount = 0;


    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3Int tilePos = GetMouseTilePosition();
            Debug.Log($"Clicked Tile Position: {tilePos}");

            if (prefabToSpawn != null && gameTilemap != null)
            {
                Vector3 spawnPos = gameTilemap.GetCellCenterWorld(tilePos);
                Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
            }
            else
            {
                if (prefabToSpawn == null) Debug.LogWarning("PrefabToSpawn is not assigned!");
            }
        }
    }

    public Vector3Int GetMouseTilePosition()
    {
        if (gameTilemap == null)
        {
            Debug.LogError("GameTilemap is not assigned in GameManger!");
            return Vector3Int.zero;
        }

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0; 

        return gameTilemap.WorldToCell(mouseWorldPos);
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
    }

    public int GetCoins()
    {
        return coinCount;
    }

    public bool RemoveCoins(int amount)
    {
        if (coinCount < amount)
        {
            return false;
        }
        coinCount -= amount;
        return true;
    }

    // Inventory System
    public List<CardData> deck = new List<CardData>();

    public void AddCard(CardData card)
    {
        if (card == null) return;
        deck.Add(card);
        Debug.Log($"Added card: {card.cardName} to GameManager inventory.");
    }
}
