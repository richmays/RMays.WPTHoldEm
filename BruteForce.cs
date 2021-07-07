using System;
using System.Collections.Generic;
using System.Text;

namespace WPTHoldem2
{
    struct SolvingResults
    {
        long iHands;
        long[,] arrTotal;
        long[,] arrRaiseWin;
        long[,] arrAllInWin;
    }

    class BruteForce
    {
        private SolvingResults SolveGivenDeckAndPlayerHand(Deck d, int iPlayerCard1, int iPlayerCard2)
        {
            Hand hPlayerHand = new Hand();
            Hand hDealerHand = new Hand();
            int iDealerCard1, iDealerCard2;
            int iCardX, iCardY;
            int iBJCount;
            int[] iCommCard = new int[5];
            int iResult;
            bool bIsPair;

            iDealerCard1 = d.Pop();
            iDealerCard2 = d.Pop();
            for (int i = 0; i < 5; i++)
            {
                iCommCard[i] = d.Pop();
                hPlayerHand.AddCard(iCommCard[i]);
                hDealerHand.AddCard(iCommCard[i]);
            }
            hPlayerHand.AddCard(iPlayerCard1);
            hPlayerHand.AddCard(iPlayerCard2);
            hDealerHand.AddCard(iDealerCard1);
            hDealerHand.AddCard(iDealerCard2);

            //            lblStatus.Text = (new Card(iPlayerCard1)).Rank() + "" + (new Card(iPlayerCard2)).Rank();
            if (iPlayerCard1 % 4 == iPlayerCard2 % 4) // if they're suited ...
            {
                //                lblStatus.Text += "s";
                iCardX = iPlayerCard2 / 4;
                iCardY = iPlayerCard1 / 4;
            }
            else
            {
                iCardX = iPlayerCard1 / 4;
                iCardY = iPlayerCard2 / 4;
            }
            arrTotal[iCardX, iCardY]++;
            iHands++;
            // See who wins.
            iBJCount = Card.BJValue(iDealerCard1) + Card.BJValue(iDealerCard2);
            bIsPair = (iDealerCard1 / 4 == iDealerCard2 / 4);
            if ((iBJCount < 13) && !bIsPair)
            {
                arrRaiseWin[iCardX, iCardY]++;
                arrAllInWin[iCardX, iCardY]++;
                return;
            }

            // Calls a raise.
            iResult = string.Compare(hPlayerHand.GetHandValue(), hDealerHand.GetHandValue());
            if (iResult == -1) // Player lost.
            {
                arrRaiseWin[iCardX, iCardY] -= 6;
            }
            else if (iResult == 1) // Player won.
            {
                arrRaiseWin[iCardX, iCardY] += 6;
            }

            if ((iBJCount >= 17) || bIsPair) // 17
            {
                // Calls an all-in.
                // No need to run this line; we know what 'iResult' is already.
                //iResult = string.Compare(hPlayerHand.GetHandValue(), hDealerHand.GetHandValue());
                if (iResult == -1) // Player lost.
                {
                    arrAllInWin[iCardX, iCardY] -= 11;
                }
                else if (iResult == 1) // Player won.
                {
                    arrAllInWin[iCardX, iCardY] += 11;
                }
            }
            else
            {
                arrAllInWin[iCardX, iCardY]++;
            }
        }
    
    }
}
