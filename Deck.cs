// Rich Mays
// Describes a Deck (collection of Cards)

using System;

public class Deck
{
    private static Random r;
    private int[] theDeck;
    private double[,] theOdds;
    private int cardsLeft;
    private int TotalCards;

    // Initializes the deck; sets a new random seed, then resets the deck.
    public Deck()
    {
        r = new Random();
        TotalCards = 52;
        FullReset();
    }

    // Use a Knuth shuffle to randomize the deck's order.
    /*
    public void Shuffle()
    {
        Shuffle(52);
    }
    */

    // Use a Knuth shuffle to randomize the deck's order.
    public void Shuffle(int CardsToShuffle)
    {
        int iTmp;
        int iNewSpot;

        for (int i = TotalCards - 1; i > (TotalCards - CardsToShuffle); i--)
        {
            //iNewSpot = i + r.Next(cardsLeft - i);
            iNewSpot = r.Next(i);
            iTmp = theDeck[i];
            theDeck[i] = theDeck[iNewSpot];
            theDeck[iNewSpot] = iTmp;
        }
    }

    // Re-initialize the deck.  Puts the deck in order of aces, kings, queens, etc, down to deuces.
    public void FullReset()
    {
        if (theDeck == null)
        {
            theDeck = new int[52];
        }
        Reset();
        for (int i = 0; i < cardsLeft; i++)
        {
            theDeck[i] = i;
        }

        //DestroyCard(51);
        //DestroyCard(50);
        //InitializeOdds();

        //RemoveCard(50);
        //RemoveCard(51);
        //RemoveCard(46);
        //RemoveCard(47);
        //RemoveCard(42);
        //RemoveCard(43);
    }

    // Resets the deck size to 52.
    public void Reset()
    {
        cardsLeft = TotalCards;
    }

    // Return the top card from the deck, and decrement the deck size, effectively taking the top card
    //  off of the deck.  ('Pop' in a stack data structure)
    public int Pop()
    {
        if (cardsLeft > 0)
        {
            cardsLeft--;
            return theDeck[cardsLeft];
        }
        return -1;
    }

    public void InitializeOdds()
    {
        int[,] theOddsTotal = new int[13,13];
        if (theOdds == null)
        {
            theOdds = new double[13,13];
        }
        int iTotalCombos = 0;
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                theOddsTotal[i, j] = 0;
            }
        }
        for (int Card1 = 0; Card1 < TotalCards - 1; Card1++)
        {
            for (int Card2 = Card1 + 1; Card2 < TotalCards; Card2++)
            {
                iTotalCombos++;
                // Are they suited?
                if (theDeck[Card1] % 4 == theDeck[Card2] % 4)
                {
                    theOddsTotal[theDeck[Card1] / 4, theDeck[Card2] / 4]++;
                }
                else
                {
                    theOddsTotal[theDeck[Card2] / 4, theDeck[Card1] / 4]++;
                }
            }
        }
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                theOdds[i, j] = (theOddsTotal[i, j] * 1.0) / (iTotalCombos * 1.0);
            }
        }
    }
    public double GetOddsForCardCombo(int i, int j)
    {
        return theOdds[i, j];
    }

    // Take the card from the deck and rip it up.
    // Resetting the deck won't restore this card.
    public void DestroyCard(int iCard)
    {
        RemoveCard(iCard);
        TotalCards--;
    }

    // Pulls the given card out of the deck.
    public void RemoveCard(int iCard)
    {
        int iTmp;
        // Check the beginning spot.
        /*
        if (theDeck[iCard] == iCard)
        {
            iTmp = theDeck[iCard];
            theDeck[iCard] = theDeck[cardsLeft - 1];
            theDeck[cardsLeft - 1] = iTmp;
            cardsLeft--;
            return;
        }
        */
        for (int i = 0; i < cardsLeft; i++)
        {
            if (theDeck[i] == iCard)
            {
                iTmp = theDeck[i];
                theDeck[i] = theDeck[cardsLeft - 1];
                theDeck[cardsLeft - 1] = iTmp;
                cardsLeft--;
                return;
            }
        }
    }

}
