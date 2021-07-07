// Rich Mays
// Describes a Card object.

public class Card
{
    private int rank; // rank; 0-12. (-1 is undefined.)  Represents 2 3 4 5 6 7 8 9 T J Q K A
    private int suit; // suit; 0-3.  (-1 is undefined.)  Represents C D H S

    // Default constructor for Card object
    // Initializes rank and suit to undefined values
    public Card()
    {
        rank = -1;
        suit = -1;
    }

    // Converts an int from 0-51 into a card.
    public Card(int newCardID)
    {
        rank = newCardID / 4;
        suit = newCardID % 4;
    }

    // Converts two ints (0-12) and (0-3) into a card.
    public Card(int newRank, int newSuit)
    {
        rank = newRank;
        suit = newSuit;
    }

    // Constructor that calls SetFromStr( newRank ).
    public Card( string newRank )
    {
        suit = -1;
        SetFromStr(newRank);
    }

    // Returns the full name of the card; for example, "Ace of Spades".
    public string Name()
    {
        return (Rank() + string.Empty + Suit().ToString().ToLower());
    }

    // Initializes a card, based on a rank.  The suit remains undefined.
    public void SetFromStr(string newRank)
    {
        if (newRank == string.Empty)
        {
            rank = -1;
            return;
        }
        rank = (10 * (int)((char)newRank[0] - '0')) + (int)((char)newRank[1] - '0') + 0;
    }

    // Converts a card rank into a BJ value.
    // Used when figuring out whether dealer should call or fold to a raise / all-in.
    public int BJValue()
    {
        switch (rank)
        {
            case 12: return 11;
            case 11: return 10;
            case 10: return 10;
            case 9:  return 10;
            default: return( rank + 2 );
        }
    }

    // Converts a card into a BJ value.
    // Used when figuring out whether dealer should call or fold to a raise / all-in.
    public static int BJValue(int newCardID)
    {
        if (newCardID < 36)
        {
            return ((newCardID / 4) + 2);
        }
        if (newCardID < 48)
        {
            return 10;
        }
        return 11;
    }

    // Location of the given card's image
    public string FileName()
    {
        return "cards\\" + Rank() + Suit() + ".jpg";
    }

    // Returns a char representing the card's rank; A K Q J T 9 8 7 6 5 4 3 2
    public char Rank()
    {
        switch (rank)
        {
            case 12: return 'A';
            case 11: return 'K';
            case 10: return 'Q';
            case 9: return 'J';
            case 8: return 'T';
            default: return( (char)( rank + '2' ));
        }
    }

    // Returns a string representing the singular form of the rank name.
    public string RankNameSingular()
    {
        switch (rank)
        {
            case 12: return "Ace";
            case 11: return "King";
            case 10: return "Queen";
            case 9: return "Jack";
            case 8: return "Ten";
            case 7: return "Nine";
            case 6: return "Eight";
            case 5: return "Seven";
            case 4: return "Six";
            case 3: return "Five";
            case 2: return "Four";
            case 1: return "Trey";
            case 0: return "Deuce";
        }
        return "???";
    }

    // Returns a string representing the plural form of the rank name.
    public string RankNamePlural()
    {
        if (rank == 4)
        {
            return "Sixes";
        }
        return RankNameSingular() + "s";
    }

    // Returns the character representing the suit of the card.
    public char Suit()
    {
        switch (suit)
        {
            case 3: return 's';
            case 2: return 'h';
            case 1: return 'd';
            case 0: return 'c';
        }
        return '?';
    }
}
