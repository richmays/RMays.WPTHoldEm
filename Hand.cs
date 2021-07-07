// Rich Mays
// Describes a Hand object.
// Consists of a boolean array of 52 elements; 'true' means the card exists in the hand, 'false' otherwise.
// Also maintains the total numbers of ranks and suits in the hand.

using System;
using System.Text;

public class Hand
{
    private bool[] theHand; // 52 elements; represents a collection of cards in the hand
    private int[] ranks; // total of each rank
    private int[] suits; // total of each suit

    // Default constructor
    public Hand()
    {
        Reset();
    }

    // Clears the hand.  Removes all cards from the hand and resets the totals.
    public void Reset()
    {
        if (theHand == null)
        {
            theHand = new bool[52];
            ranks = new int[13];
            suits = new int[4];
        }
        for (int i = 0; i < 52; i++)
        {
            theHand[i] = false;
        }
        for (int i = 0; i < 13; i++)
        {
            ranks[i] = 0;
        }
        for (int i = 0; i < 4; i++)
        {
            suits[i] = 0;
        }
    }

    // Add the given card to the hand.
    public void AddCard(int card)
    {
        theHand[card] = true;
        ranks[card / 4]++;
        suits[card % 4]++;
    }

    // Remove the given card from the hand.
    public void RemoveCard(int card)
    {
        theHand[card] = false;
        ranks[card / 4]--;
        suits[card % 4]--;
    }

    // Returns the English equivalent of a given hand.
    public static string GetHandValueText( string handValue )
    {
        Card c1 = new Card();
        Card c2 = new Card();
        Card c3 = new Card();
        Card c4 = new Card();
        Card c5 = new Card();

        if (handValue.Length > 1)
        {
            c1.SetFromStr(handValue.Substring(1, 2));
            if (handValue.Length > 3)
            {
                c2.SetFromStr(handValue.Substring(3, 2));
                if (handValue.Length > 5)
                {
                    c3.SetFromStr(handValue.Substring(5, 2));
                    if (handValue.Length > 7)
                    {
                        c4.SetFromStr(handValue.Substring(7, 2));
                        if (handValue.Length > 9)
                        {
                            c5.SetFromStr(handValue.Substring(9, 2));
                        }
                    }
                }
            }
        }

        switch ((char)handValue[0])
        {
            case '9':
                if (c1.Rank() == 'A')
                {
                    return "Royal Flush";
                }
                else
                {
                    return "Straight Flush, " + c1.RankNameSingular() + " high";
                }
            case '8':
                return "Four of a Kind, " + c1.RankNamePlural() + " (kicker " + c2.RankNameSingular() + ")";
            case '7':
                return "Full House, " + c1.RankNamePlural() + " full of " + c2.RankNamePlural();
            case '6':
                return "Flush, " + c1.RankNameSingular() + " high (kickers " + c2.RankNameSingular() + ", " + c3.RankNameSingular() + ", " + c4.RankNameSingular() + ", and " + c5.RankNameSingular() + ")";
            case '5':
                return "Straight, " + c1.RankNameSingular() + " high";
            case '4':
                return "Three of a Kind, " + c1.RankNamePlural() + " (kickers " + c2.RankNameSingular() + " and " + c3.RankNameSingular() + ")";
            case '3':
                return "Two Pair, " + c1.RankNamePlural() + " and " + c2.RankNamePlural() + " (kicker " + c3.RankNameSingular() + ")";
            case '2':
                return "Pair, " + c1.RankNamePlural() + " (kickers " + c2.RankNameSingular() + ", " + c3.RankNameSingular() + ", and " + c4.RankNameSingular() + ")";
            case '1':
                return "High Card, " + c1.RankNameSingular() + " (kickers " + c2.RankNameSingular() + ", " + c3.RankNameSingular() + ", " + c4.RankNameSingular() + ", and " + c5.RankNameSingular() + ")";
            default:
                return "Unknown! (" + handValue + ")";
        }
    }

    // Figures out the hand value, given a seven-card hand.  Returns a string representing the value.
    public string GetHandValue()
    {
        int[] iVal = new int[7];
        int[] iRank = new int[7];
        int iCurrIndex;

        StringBuilder sbToReturn = new StringBuilder();

        bool IsFlush = false;
        bool IsStraight = false;
        int i, j;
        int consec;
        int found;
        int iTopStraight = -1;
        int iFlushSuit = -1;

        // Is there a flush?
        for (i = 0; i < 4; i++)
        {
            if (suits[i] >= 5)
            {
                IsFlush = true;
                iFlushSuit = i;
                break;
            }
        }

        // Is there a straight?
        consec = 0;
        for (i = 12; i >= 0; i--)
        {
            if (ranks[i] >= 1)
            {
                consec++;
                if (consec == 5)
                {
                    IsStraight = true;
                    iTopStraight = i + 4;
                    break;
                }
            }
            else
            {
                consec = 0;
            }
        }
        if (consec == 4)
        {
            if (ranks[12] >= 1)
            {
                IsStraight = true;
                iTopStraight = 3;
            }
        }


        #region 9. Straight Flush
        if (IsStraight && IsFlush)
        {
            i = iFlushSuit;
            // Here's the flush.  Now, follow the procedure for the straight, only do it with these cards.
            consec = 0;
            // Start at the ace and work down.
            for (j = 12; j >= 0; j--)
            {
                if (theHand[(j * 4) + i])
                {
                    consec++;
                    if (consec >= 5)
                    {
                        sbToReturn.Append("9");
                        sbToReturn.Append(Fit(j + 4));
                        return sbToReturn.ToString();
                    }
                }
                else
                {
                    consec = 0;
                }
            }
            // Now, check the ace again.
            if (theHand[(12 * 4) + i])
            {
                consec++;
                if (consec >= 5)
                {
                    return "903";
                }
            }
        }
        #endregion

        #region 6. Flush
        if (IsFlush)
        {
            sbToReturn.Append("6");
            i = iFlushSuit;
            // Here's the flush.  Now, go down and grab each card in the suit.
            // Start at the ace and work down.
            found = 0;
            for (j = 12; j >= 0; j--)
            {
                if (theHand[(j * 4) + i])
                {
                    sbToReturn.Append(Fit(j));
                    found++;
                    if (found >= 5)
                    {
                        return sbToReturn.ToString();
                    }
                }
            }
            return sbToReturn.ToString();
        }

        #endregion

        #region 5. Straight
        if (IsStraight)
        {
            sbToReturn.Append("5");
            sbToReturn.Append(Fit(iTopStraight));
            return sbToReturn.ToString();
        }
        #endregion

        // Extra stuff; shortcut for calculating the hand value.
        //  Keeps track of the groups of pairs / three of a kinds / four of a kinds.
        int iMaxVal = 1;
        for (i = 0; i < 13; i++)
        {
            if (ranks[i] > iMaxVal)
            {
                iMaxVal = ranks[i];
            }
        }
        iCurrIndex = 0;
        for (int iCurrVal = iMaxVal; iCurrVal >= 1; iCurrVal--)
        {
            for (i = 12; i >= 0; i--)
            {
                if (ranks[i] == iCurrVal)
                {
                    iRank[iCurrIndex] = i;
                    iVal[iCurrIndex] = iCurrVal;
                    iCurrIndex++;
                }
            }
        }

        #region 1. High Card
        if (iVal[0] == 1)
        {
            sbToReturn.Append("1");
            sbToReturn.Append(Fit(iRank[0]));
            sbToReturn.Append(Fit(iRank[1]));
            sbToReturn.Append(Fit(iRank[2]));
            sbToReturn.Append(Fit(iRank[3]));
            sbToReturn.Append(Fit(iRank[4]));
            return sbToReturn.ToString();
        }
        #endregion

        #region 2. Pair
        if ((iVal[0] == 2) && (iVal[1] == 1 ))
        {
            sbToReturn.Append("2");
            sbToReturn.Append(Fit(iRank[0]));
            sbToReturn.Append(Fit(iRank[1]));
            sbToReturn.Append(Fit(iRank[2]));
            sbToReturn.Append(Fit(iRank[3]));
            return sbToReturn.ToString();
        }
        #endregion

        #region 3. Two Pair
        if ((iVal[0] == 2) && (iVal[1] == 2))
        {
            sbToReturn.Append("3");
            sbToReturn.Append(Fit(iRank[0]));
            sbToReturn.Append(Fit(iRank[1]));
            if (iVal[2] == 1)
            {
                sbToReturn.Append(Fit(iRank[2]));
            }
            else
            {
                sbToReturn.Append(Fit((iRank[2] > iRank[3]) ? (iRank[2]) : (iRank[3])));
            }
            return sbToReturn.ToString();
        }
        #endregion

        #region 4. Three of a Kind
        if ((iVal[0] == 3) && (iVal[1] == 1))
        {
            sbToReturn.Append("4");
            sbToReturn.Append(Fit(iRank[0]));
            sbToReturn.Append(Fit(iRank[1]));
            sbToReturn.Append(Fit(iRank[2]));
            return sbToReturn.ToString();
        }
        #endregion

        #region 7. Full House
        if ((iVal[0] == 3) && (iVal[1] >= 2))
        {
            sbToReturn.Append("7");
            sbToReturn.Append(Fit(iRank[0]));
            sbToReturn.Append(Fit(iRank[1]));
            return sbToReturn.ToString();
        }
        #endregion

        #region 8. Four of a Kind
        if (iVal[0] == 4)
        {
            sbToReturn.Append("8");
            sbToReturn.Append(Fit(iRank[0]));
            if (iVal[1] == 2)
            {
                sbToReturn.Append(Fit((iRank[1] > iRank[2]) ? iRank[1] : iRank[2]));
            }
            else
            {
                sbToReturn.Append(Fit(iRank[1]));
            }
            return sbToReturn.ToString();
        }
        #endregion

        return string.Empty;
    }

    /*
    // Experimental way of generating hand values; might be modified later.
    public string GetHandValue2()
    {
        bool IsFlush = false;
        bool IsStraight = false;
        int[] ranks;
        int[] suits;
        int i, j, k;
        int consec;
        int found;
        int iTopStraight = -1;
        string strToReturn;
        ranks = new int[13];
        suits = new int[4];
        for (i = 0; i < 13; i++)
        {
            ranks[i] = 0;
        }
        for (i = 0; i < 4; i++)
        {
            suits[i] = 0;
        }

        // Add the cards to the rank / suit totals.
        for (i = 0; i < 52; i++)
        {
            if (theHand[i])
            {
                ranks[i / 4]++;
                suits[i % 4]++;
            }
        }

        // Is there a flush?
        for (i = 0; i < 4; i++)
        {
            if (suits[i] >= 5)
            {
                IsFlush = true;
            }
        }

        // Is there a straight?
        consec = 0;
        for (i = 12; i >= 0; i--)
        {
            if (ranks[i] >= 1)
            {
                consec++;
                if (consec == 5)
                {
                    IsStraight = true;
                    iTopStraight = i + 4;
                }
            }
            else
            {
                consec = 0;
            }
        }
        if( consec == 4 )
        {
            if( ranks[12] >= 1)
            {
                IsStraight = true;
                iTopStraight = 3;
            }
        }

        #region 9. Straight Flush
        if (IsStraight && IsFlush)
        {
            // Find the suit with the flush.
            for( i = 0; i < 4; i++ )
            {
                if (suits[i] >= 5)
                {
                    // Here's the flush.  Now, follow the procedure for the straight, only do it with these cards.
                    consec = 0;
                    // Start at the ace and work down.
                    for (j = 12; j >= 0; j--)
                    {
                        if (theHand[(j * 4) + i])
                        {
                            consec++;
                            if (consec >= 5)
                            {
                                return "9" + Fit(j + 4);
                            }
                        }
                        else
                        {
                            consec = 0;
                        }
                    }
                    // Now, check the ace again.
                    if (theHand[(12 * 4) + i])
                    {
                        consec++;
                        if (consec >= 5)
                        {
                            return "903";
                        }
                    }
                }

            }
        }
        #endregion

        #region 8. Four of a Kind
        for (i = 12; i >= 0; i--)
        {
            if (ranks[i] >= 4)
            {
                // Found the rank; now, find the kicker.
                for( j = 12; j >= 0; j-- )
                {
                    if( j != i )
                    {
                        if (ranks[j] >= 1)
                        {
                            return "8" + Fit(i) + Fit(j);
                        }
                    }
                }
                return "8" + Fit(i);
            }
        }
        #endregion

        #region 7. Full House
        for (i = 12; i >= 0; i--)
        {
            if (ranks[i] >= 3)
            {
                // Found the rank of the '3'; now, find the rank of the '2'.
                for (j = 12; j >= 0; j--)
                {
                    if (j != i)
                    {
                        if (ranks[j] >= 2)
                        {
                            return "7" + Fit(i) + Fit(j);
                        }
                    }
                }
            }
        }
        #endregion

        #region 6. Flush
        if (IsFlush)
        {
            strToReturn = "6";
            // Find the suit with the flush.
            for (i = 0; i < 4; i++)
            {
                if (suits[i] >= 5)
                {
                    // Here's the flush.  Now, go down and grab each card in the suit.
                    // Start at the ace and work down.
                    found = 0;
                    for (j = 12; j >= 0; j--)
                    {
                        if (theHand[(j * 4) + i])
                        {
                            strToReturn = strToReturn + Fit(j);
                            found++;
                            if (found >= 5)
                            {
                                return (strToReturn);
                            }
                        }
                    }
                }
            }
            return (strToReturn);
        }

        #endregion

        #region 5. Straight

        if (IsStraight)
        {
            return ("5" + Fit(iTopStraight));
        }

        #endregion

        #region 4. Three of a Kind
        for (i = 12; i >= 0; i--)
        {
            if (ranks[i] >= 3)
            {
                // Found the rank; now, find the 2 kickers.
                found = 0;
                strToReturn = "4" + Fit(i);
                for (j = 12; j >= 0; j--)
                {
                    if (j != i)
                    {
                        if (ranks[j] >= 1)
                        {
                            found++;
                            strToReturn += Fit(j);
                            if (found >= 2)
                            {
                                return strToReturn;
                            }
                        }
                    }
                }
                return strToReturn;
            }
        }
        #endregion

        #region 3. Two Pair
        for (i = 12; i >= 0; i--)
        {
            if (ranks[i] >= 2)
            {
                for (j = i - 1; j >= 0; j--)
                {
                    if (ranks[j] >= 2)
                    {
                        for (k = 12; k >= 0; k--)
                        {
                            if ((k != i) && (k != j))
                            {
                                if (ranks[k] >= 1)
                                {
                                    return "3" + Fit(i) + Fit(j) + Fit(k);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 2. Pair
        for (i = 12; i >= 0; i--)
        {
            if (ranks[i] >= 2)
            {
                found = 0;
                strToReturn = "2" + Fit(i);
                for (j = 12; j >= 0; j--)
                {
                    if (j != i)
                    {
                        if (ranks[j] >= 1)
                        {
                            found++;
                            strToReturn += Fit(j);
                            if (found >= 3)
                            {
                                return strToReturn;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 1. High Card
        found = 0;
        strToReturn = "1";
        for (i = 12; i >= 0; i--)
        {
            if (ranks[i] >= 1)
            {
                found++;
                strToReturn += Fit(i);
                if (found >= 5)
                {
                    return strToReturn;
                }
            }
        }
        #endregion

        return string.Empty;
    }
    */

    // Returns the two-character string equivalent of an integer.
    private string Fit(int i)
    {
        StringBuilder sb = new StringBuilder();
        if (i < 10)
        {
            sb.Append('0');
            sb.Append((char)(i + '0'));
        }
        else
        {
            sb.Append('1');
            sb.Append((char)(i + '0' - 10));
        }
        return sb.ToString();
    }

}
