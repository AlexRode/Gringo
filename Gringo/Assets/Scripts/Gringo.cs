using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gringo : MonoBehaviour
{
    public Sprite[] cardFaces;
   
    public GameObject CardPrefab;


    public static string[] suits = new string[] { "C", "E", "O", "P" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    
    public List<string> deck;

    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayCards()
    {
      //  foreach (List<string> list in bottoms)
        //{
          //  list.Clear();
        //}

        deck = GenerateDeck();
        Shuffle(deck);

        //test the cards in the deck:
        foreach (string card in deck)
        {
            print(card);
        }
       
        //StartCoroutine(SolitaireDeal());
        //SortDeckIntoTrips();
        GringoDeal();
    }

    public static List<string> GenerateDeck() {
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(s + v);
            }
        }
        return newDeck;
    }

    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }


    void GringoDeal()
    {
        float yOffset = 0;
        float zOffset = 0.3f;
        foreach (string card in deck) { 
        
            GameObject newCard = Instantiate(CardPrefab,new Vector3( transform.position.x, transform.position.y + yOffset, transform.position.z + zOffset), Quaternion.identity);
            newCard.name = card;
            newCard.GetComponent<Selectable>().faceUp = true;

            yOffset = yOffset + -0.3f;
            zOffset = zOffset + 0.03f;
        }

    }
  


}
