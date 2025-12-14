using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManger : MonoBehaviour
{
    [SerializeField] private Tilemap gameTilemap;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject prefabToSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    // Update is called once per frame
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
}
