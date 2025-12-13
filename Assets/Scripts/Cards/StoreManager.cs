using UnityEngine;
using System.Collections.Generic;

public class StoreManager : MonoBehaviour
{
    public int numberOfUniqueCards = 18;
    public int maximumCardsInStore = 5;
    
    public List<CardData> cards;
    public List<CardData> cardsInStore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // cards = new List<CardData>(numberOfUniqueCards);
    }

    /*
    CardData DrawCard()
    {
        return cards[Random.Range(0, numberOfUniqueCards)];
    }*/

    // Update is called once per frame
    void Update()
    {
        /*
        for (var i = 0; i < maximumCardsInStore; i++)
        {
            if(cards[i] == null)
            {
                cards[i] = DrawCard();
            }
        }*/
    }
}
