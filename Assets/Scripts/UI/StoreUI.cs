using UnityEngine;
using System.Collections.Generic;

public class StoreUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cardsContainer;
    [SerializeField] private GameObject cardDisplayPrefab;
    
    private StoreManager storeManager;

    void Start()
    {
        storeManager = FindFirstObjectByType<StoreManager>();
        
        if (storeManager != null)
        {
            // Subscribe to updates
            storeManager.OnShopUpdated += UpdateStoreUI;
            
            // Initial update
            UpdateStoreUI();
        }
        else
        {
            Debug.LogError("StoreUI: Could not find StoreManager in the scene.");
        }
    }

    void OnDestroy()
    {
        if (storeManager != null)
        {
            storeManager.OnShopUpdated -= UpdateStoreUI;
        }
    }

    public void UpdateStoreUI()
    {
        if (storeManager == null || cardsContainer == null || cardDisplayPrefab == null) return;

        // Clean up existing card slots
        // Note: Destroying and re-instantiating might be expensive if done frequently. 
        // For a simple shop, it's acceptable. For optimization, object pooling is recommended.
        foreach (Transform child in cardsContainer)
        {
            Destroy(child.gameObject);
        }

        // Spawn new card slots
        List<CardData> cards = storeManager.cardsInStore;
        for (int i = 0; i < cards.Count; i++)
        {
            GameObject obj = Instantiate(cardDisplayPrefab, cardsContainer);
            CardDisplay display = obj.GetComponent<CardDisplay>();
            if (display != null)
            {
                display.Setup(cards[i], i, storeManager);
            }
        }
    }
}
