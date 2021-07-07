using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WPTHoldem2
{
    // Describes the EVTable form.
    //  This prints a dynamic view of the expected value of any combination of cards
    //  for the 'beat the dealer' bet.
    public partial class EVTable : Form
    {
        string NEWLINE = System.Environment.NewLine + string.Empty;
        int iLeftMargin = 11;
        int iTopMargin = 48;

        int iWidthOffset = 13;
        int iHeightOffset = 12;

        int iLastMouseX;
        int iLastMouseY;

        Graphics g;
        long iHands;
        long[,] arrTotal;
        long[,] arrRaiseWin;
        long[,] arrAllInWin;

        // Constructor; initiated when the window is opened for the first time.
        public EVTable()
        {
            InitializeComponent();
            lblStatus.Text = string.Empty;
            lblStatus2.Text = string.Empty;
            lblStatus3.Text = string.Empty;
            iHands = 0;
            iLastMouseX = -1;
            iLastMouseY = -1;
            arrTotal = new long[13,13];
            arrRaiseWin = new long[13, 13];
            arrAllInWin = new long[13, 13];

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    arrTotal[i, j] = 0;
                    arrRaiseWin[i, j] = 0;
                    arrAllInWin[i, j] = 0;
                }
            }
        }

        // Redraw the EV table
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            g = e.Graphics;

            Image imgGrid = Image.FromFile("cards/grid.gif");
            g.DrawImage(imgGrid, iLeftMargin, iTopMargin);

            string[,] sStringEV = new string[13, 13];
            long iRaiseEV;
            long iAllInEV;
            long iFoldEV;
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (arrTotal[i, j] == 0)
                    {
                        sStringEV[i, j] = "empty";
                    }
                    else
                    {
                        iRaiseEV = arrRaiseWin[i, j];
                        iAllInEV = arrAllInWin[i, j];
                        iFoldEV = arrTotal[i, j] * -1;
                        if ((iRaiseEV > iFoldEV) && (iRaiseEV > iAllInEV))
                        {
                            sStringEV[i, j] = "raise";
                        }
                        else if(( iFoldEV > iRaiseEV ) && ( iFoldEV > iAllInEV ))
                        {
                            sStringEV[i, j] = "fold";
                        }
                        else if ((iAllInEV > iRaiseEV) && (iAllInEV > iFoldEV))
                        {
                            sStringEV[i, j] = "allin";
                        }
                        else if ((iFoldEV == iRaiseEV) && (iFoldEV == iAllInEV))
                        {
                            sStringEV[i, j] = "foldraiseallin";
                        }
                        else if (iRaiseEV == iAllInEV)
                        {
                            sStringEV[i, j] = "raiseallin";
                        }
                        else if (iFoldEV == iRaiseEV)
                        {
                            sStringEV[i, j] = "foldraise";
                        }
                        else if (iFoldEV == iAllInEV)
                        {
                            sStringEV[i, j] = "foldallin";
                        }
                    }
                }
            }
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    PaintCard(sStringEV[i, j], i, j);
                }
            }
            PrintOverallEV();
        }

        // Display a recommended action in the grid at the given location.
        private void PaintCard(string sActionType, int iCard1, int iCard2)
        {
            Image imgSpot = Image.FromFile( "cards/" + sActionType + ".gif" );
            g.DrawImage(imgSpot, iLeftMargin + iWidthOffset + ((12 - iCard1) * 26), iTopMargin + iHeightOffset + ((12 - iCard2) * 17));
        }

        // Not used; this was a brute-force function that tried every combination of seven cards.
        #region DoEveryCombination
        private void DoEveryCombination2()
        {
            int p1, p2;
            int d1, d2;
            int c1, c2, c3, c4, c5;
            Hand hPlayerHand = new Hand();
            Hand hDealerHand = new Hand();
            int iCardX, iCardY;
            int iBJCount;
            int iResult;
            bool bIsPair;
p1 = 51;
//            for (p1 = 0; p1 < 51; p1++)
//            {
                hPlayerHand.AddCard(p1);
p2 = 50;
//                for (p2 = p1 + 1; p2 < 52; p2++)
//                {
                    hPlayerHand.AddCard(p2);
                    if (p1 % 4 == p2 % 4) // if they're suited ...
                    {
                        //                lblStatus.Text += "s";
                        iCardX = p2 / 4;
                        iCardY = p1 / 4;
                    }
                    else
                    {
                        iCardX = p1 / 4;
                        iCardY = p2 / 4;
                    }
                    for (d1 = 0; d1 < 51; d1++)
                    {
                        if(( d1 != p1) && ( d1 != p2 ))
                        {
                            hDealerHand.AddCard(d1);
                            for (d2 = d1 + 1; d2 < 52; d2++)
                            {
                                if ((d2 != p1) && (d2 != p2))
                                {
                                    iBJCount = Card.BJValue(d1) + Card.BJValue(d2);
                                    bIsPair = (d1 / 4 == d2 / 4);
                                    if ((iBJCount < 13) && !bIsPair)
                                    {
                                        // Folding; player wins.
                                        arrTotal[iCardX, iCardY] += 1712304;
                                        iHands += 1712304;
                                        arrRaiseWin[iCardX, iCardY] += 1712304;
                                        arrAllInWin[iCardX, iCardY] += 1712304;
                                    }
                                    else
                                    {
                                        hDealerHand.AddCard(d2);
                                        for (c1 = 0; c1 < 48; c1++)
                                        {
                                            if ((c1 != p1) && (c1 != p2) && (c1 != d1) && (c1 != d2))
                                            {
                                                hPlayerHand.AddCard(c1);
                                                hDealerHand.AddCard(c1);
                                                for (c2 = c1 + 1; c2 < 49; c2++)
                                                {
                                                    if ((c2 != p1) && (c2 != p2) && (c2 != d1) && (c2 != d2))
                                                    {
                                                        hPlayerHand.AddCard(c2);
                                                        hDealerHand.AddCard(c2);
                                                        for (c3 = c2 + 1; c3 < 50; c3++)
                                                        {
                                                            if ((c3 != p1) && (c3 != p2) && (c3 != d1) && (c3 != d2))
                                                            {
                                                                hPlayerHand.AddCard(c3);
                                                                hDealerHand.AddCard(c3);
                                                                for (c4 = c3 + 1; c4 < 51; c4++)
                                                                {
                                                                    if ((c4 != p1) && (c4 != p2) && (c4 != d1) && (c4 != d2))
                                                                    {
                                                                        hPlayerHand.AddCard(c4);
                                                                        hDealerHand.AddCard(c4);
                                                                        for (c5 = c4 + 1; c5 < 52; c5++)
                                                                        {
                                                                            if ((c5 != p1) && (c5 != p2) && (c5 != d1) && (c5 != d2))
                                                                            {
                                                                                hPlayerHand.AddCard(c5);
                                                                                hDealerHand.AddCard(c5);

                                                                                arrTotal[iCardX, iCardY]++;
                                                                                iHands++;

                                                                                /*
                                                                                if ((iBJCount >= 13) || bIsPair)
                                                                                {
                                                                                */
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
                                                                                /*
                                                                                }
                                                                                else
                                                                                {
                                                                                    arrRaiseWin[iCardX, iCardY]++;
                                                                                }
                                                                                */
                                                                                if ((iBJCount >= 17) || bIsPair)
                                                                                {
                                                                                    // Calls an all-in.

                                                                                    // iResult was already set in the previous block.
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

                                                                                hPlayerHand.RemoveCard(c5);
                                                                                hDealerHand.RemoveCard(c5);
                                                                            }
                                                                        }
                                                                        hPlayerHand.RemoveCard(c4);
                                                                        hDealerHand.RemoveCard(c4);
                                                                    }
                                                                }
                                                                hPlayerHand.RemoveCard(c3);
                                                                hDealerHand.RemoveCard(c3);
                                                            }
                                                        }
                                                        hPlayerHand.RemoveCard(c2);
                                                        hDealerHand.RemoveCard(c2);
                                                    }
                                                }
                                                hPlayerHand.RemoveCard(c1);
                                                hDealerHand.RemoveCard(c1);
                                            }
                                        }
                                        hDealerHand.RemoveCard(d2);
                                    }
                                }
                            }
                            hDealerHand.RemoveCard(d1);
                        }
                    }
 //                   hPlayerHand.RemoveCard(p2);
 //               }
 //               hPlayerHand.RemoveCard(p1);
 //           }
                }

                /*
                private void DoEveryCombination()
                {
                    int[] iCards = new int[9];
                    int currCard;
                    bool good = true;
                    bool moved;
                    int iTmp;
                    // Reset the 9 cards.
                    for (int i = 0; i < 9; i++)
                    {
                        iCards[i] = i;
                    }
                    // Now, do combinations.
                    while (good)
                    {
                        if (IsComboGood(iCards))
                        {
                            DoThisCombination(iCards);
                            if (iCards[7] > 49)
                            {
                                int p = 999;
                            }
                        }
                        // Find the next combo.
                        currCard = 8;
                        moved = false;
                        while ((!moved) && (currCard >= 0)) // ## TODO
                        {
                            if (iCards[currCard] < 51)
                            {
                                iCards[currCard]++;
                                moved = true;
                            }
                            else
                            {
                                iCards[currCard] = -1; // changed in later code
                                currCard--;
                            }
                        }
                        if (currCard == -1)
                        {
                            good = false;
                        }
                        else
                        {
                            if (currCard >= 3)
                            {
                                for (iTmp = currCard + 1; iTmp < 9; iTmp++)
                                {
                                    iCards[ iTmp ] = GetNextUnusedInt(iCards, iCards[ iTmp - 1 ] + 1);
                                }
                            }
                            else if (currCard == 2)
                            {
                                iCards[ 3 ] = GetNextUnusedInt( iCards, iCards[ 2 ] + 1);
                            }
                            else if (currCard == 0)
                            {
                                iCards[ 1 ] = GetNextUnusedInt(iCards, iCards[ 0 ] + 1);
                            }
                        }
                    }
                }
                */

        private bool IsComboGood( int[] iCards )
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = i+1; j < 9; j++)
                {
                    if (iCards[i] == iCards[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion DoEveryCombination2

        /*
        private void DoThisCombination( int[] iCards )
        {
            Hand hPlayerHand = new Hand();
            Hand hDealerHand = new Hand();
            int iCardX, iCardY;
            int iBJCount;
            int iResult;

            hPlayerHand.AddCard(iCards[0]);
            hPlayerHand.AddCard(iCards[1]);
            hDealerHand.AddCard(iCards[2]);
            hDealerHand.AddCard(iCards[3]);
            for (int i = 4; i < 9; i++)
            {
                hPlayerHand.AddCard(iCards[i]);
                hDealerHand.AddCard(iCards[i]);
            }

            if (iCards[0] % 4 == iCards[1] % 4) // if they're suited ...
            {
                //                lblStatus.Text += "s";
                iCardX = iCards[1] / 4;
                iCardY = iCards[0] / 4;
            }
            else
            {
                iCardX = iCards[0] / 4;
                iCardY = iCards[1] / 4;
            }
            arrTotal[iCardX, iCardY]++;
            iHands++;
            // See who wins.
            iBJCount = Card.BJValue(iCards[2]) + Card.BJValue(iCards[3]);
            if ((iBJCount >= 13) || (iCards[2] / 4 == iCards[3] / 4))
            {
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
            }
            else
            {
                arrRaiseWin[iCardX, iCardY]++;
            }
            if ((iBJCount >= 17) || (iCards[2] / 4 == iCards[3] / 4))
            {
                // Calls an all-in.
                iResult = string.Compare(hPlayerHand.GetHandValue(), hDealerHand.GetHandValue());
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
        */

        /*
        private int GetNextUnusedInt(int[] iCards, int iMin)
        {
            int i = iMin;
            while( true )
            {
                if (iCards[0] != i && iCards[1] != i && iCards[2] != i && iCards[3] != i && iCards[4] != i && iCards[5] != i && iCards[6] != i && iCards[7] != i && iCards[8] != i)
                {
                    return i;
                }
                i++;
            }
        }
        */

        // Run this combination, given two cards.  This function is run to fill in the holes
        //  in the EV table when they're clicked, or to make the data more precise.
        private void RunOneComboGivenPlayerHand(Deck d, int iPlayerCard1, int iPlayerCard2)
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

        // Takes a deck, and just tries a single simulation, and records the results.
        private void RunOneCombo(Deck d)
        {
            int iPlayerCard1, iPlayerCard2;

            iPlayerCard1 = d.Pop();
            iPlayerCard2 = d.Pop();

            if( iPlayerCard2 > iPlayerCard1 )
            {
                int iTmp = iPlayerCard1;
                iPlayerCard1 = iPlayerCard2;
                iPlayerCard2 = iTmp;
            }
            RunOneComboGivenPlayerHand(d, iPlayerCard1, iPlayerCard2);
        }

        // Show the stats for the currently moused-over table cell.
        private void EVTable_MouseMove(object sender, MouseEventArgs e)
        {
            int iCard1, iCard2;
            iCard1 = 12 - ((e.X - iWidthOffset - iLeftMargin) / 26);
            iCard2 = 12 - ((e.Y - iHeightOffset - iTopMargin) / 17);
            if ((iCard1 <= 12) && (iCard2 <= 12))
            {
                if ((iCard1 >= 0) && (iCard2 >= 0))
                {
                    if ((iCard1 != iLastMouseX) || (iCard2 != iLastMouseY))
                    {
                        HandleMouseMove(iCard1, iCard2);
                    }
                }
            }
        }

        // Run the combo for the selected cell 10,000 times.
        private void EVTable_MouseClick(object sender, MouseEventArgs e)
        {
            HandleMouseClick(10000);
        }

        // Run the combo for the selected cell 100,000 times (counting the single mouseclick above)
        private void EVTable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HandleMouseClick(90000);
        }

        // Figure out the location of the mouse, and what combination of cards this corresponds to
        private void HandleMouseMove( int iCard1, int iCard2 )
        {
            iLastMouseX = iCard1;
            iLastMouseY = iCard2;
            string strStatus = string.Empty;
            string strStatus2 = string.Empty;
            string strStatus3 = string.Empty;
            string strHandShort;
//          Find out which hand it is.
            if (iCard1 > iCard2)
            {
                strHandShort = (new Card(iCard1 * 4)).Rank() + string.Empty + (new Card(iCard2 * 4)).Rank() + "o";
            }
            else
            {
                strHandShort = (new Card(iCard2 * 4)).Rank() + string.Empty + (new Card(iCard1 * 4)).Rank();
                if (iCard1 != iCard2)
                {
                    strHandShort += "s";
                }
            }
            strStatus = string.Empty;
            strStatus += "Hand:" + NEWLINE;
            strStatus += "Times Seen:" + NEWLINE;
            strStatus += "Fold Net $:" + NEWLINE;
            strStatus += "Raise Net $:" + NEWLINE;
            strStatus += "All In Net $:" + NEWLINE;

            strStatus2 = string.Empty;
            strStatus2 += strHandShort + NEWLINE;
            strStatus2 += arrTotal[iCard1, iCard2] + NEWLINE;
            strStatus2 += (-1 * arrTotal[iCard1, iCard2]) + NEWLINE;
            strStatus2 += arrRaiseWin[iCard1, iCard2] + NEWLINE;
            strStatus2 += arrAllInWin[iCard1, iCard2] + NEWLINE;

            strStatus3 = string.Empty;
            strStatus3 += "Expected Value" + NEWLINE;
            strStatus3 += string.Empty + NEWLINE;
            strStatus3 += -1.0d + NEWLINE;
            if (arrTotal[iCard1, iCard2] != 0)
            {
                strStatus3 += ((arrRaiseWin[iCard1, iCard2] * 1.0d) / (arrTotal[iCard1, iCard2] * 1.0d)) + NEWLINE;
                strStatus3 += ((arrAllInWin[iCard1, iCard2] * 1.0d) / (arrTotal[iCard1, iCard2] * 1.0d)) + NEWLINE;
            }

            lblStatus.Text = strStatus;
            lblStatus2.Text = strStatus2;
            lblStatus3.Text = strStatus3;
        }

        // Handles a single mouse click on the EV table
        private void HandleMouseClick( int iTimes )
        {
            if ((iLastMouseX < 0) || (iLastMouseY < 0))
            {
                return;
            }
            DisableButtons();

            int iPlayerCard1;
            int iPlayerCard2;
            if (iLastMouseX < iLastMouseY)
            {
                iPlayerCard1 = iLastMouseX * 4;
                iPlayerCard2 = iLastMouseY * 4;
            }
            else if (iLastMouseX > iLastMouseY)
            {
                iPlayerCard1 = iLastMouseY * 4;
                iPlayerCard2 = (iLastMouseX * 4) + 1;
            }
            else
            {
                iPlayerCard2 = iLastMouseX * 4;
                iPlayerCard1 = iPlayerCard2 + 1;
            }

            Deck d2 = new Deck();
            if (iPlayerCard2 > iPlayerCard1)
            {
                int iTmp = iPlayerCard1;
                iPlayerCard1 = iPlayerCard2;
                iPlayerCard2 = iTmp;
            }
            d2.DestroyCard(iPlayerCard1);
            d2.DestroyCard(iPlayerCard2);
            for (int i = 0; i < iTimes; i++)
            {
                //OLD:
                /*
                d.FullReset();
                d.RemoveCard(iPlayerCard1);
                d.RemoveCard(iPlayerCard2);
                d.Shuffle();
                RunOneComboGivenPlayerHand(d, iPlayerCard1, iPlayerCard2);
                */

                // NEW:
                d2.Reset();
                d2.Shuffle(9);
                RunOneComboGivenPlayerHand(d2, iPlayerCard1, iPlayerCard2);
            }
            lblTotalHands.Text = "Total Hands: " + iHands;
            HandleMouseMove( iLastMouseX, iLastMouseY );
            Invalidate();

            EnableButtons();
        }

        // Turn off the buttons when the program is processing.
        private void DisableButtons()
        {
            btnStart1.Enabled = false;
            btnStart2.Enabled = false;
            btnStart3.Enabled = false;
            btnStart4.Enabled = false;
            btnStart5.Enabled = false;
            btnStart6.Enabled = false;
            btnStart7.Enabled = false;
            btnStart8.Enabled = false;
            btnAll.Enabled = false;
        }

        // Re-enable the buttons after the system has finished processing.
        private void EnableButtons()
        {
            btnStart1.Enabled = true;
            btnStart2.Enabled = true;
            btnStart3.Enabled = true;
            btnStart4.Enabled = true;
            btnStart5.Enabled = true;
            btnStart6.Enabled = true;
            btnStart7.Enabled = true;
            btnStart8.Enabled = true;
            btnAll.Enabled = true;
        }

        // Run the combo 'iTimes' times.
        private void RunCombo(int iTimes)
        {
            DateTime dt = new DateTime();
            TimeSpan ts = new TimeSpan();

            dt = DateTime.Now;

            Deck d2 = new Deck();
            for (int i = 0; i < iTimes; i++)
            {
                d2.Reset();
                d2.Shuffle(9);
                RunOneCombo(d2);
            }
            lblTotalHands.Text = "Total Hands: " + iHands;

            ts = DateTime.Now - dt;
            lblStatus3.Text = " Time: " + ts.TotalSeconds + " seconds";

            Invalidate();
        }

        // Describes the buttons at the top; runs the combo the given number of times.
        #region Buttons
        private void btnStart1_Click(object sender, EventArgs e)
        {
            DisableButtons();
            RunCombo(1);
            EnableButtons();
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            DisableButtons();
            RunCombo(10);
            EnableButtons();
        }

        private void btnStart3_Click(object sender, EventArgs e)
        {
            DisableButtons();
            RunCombo(100);
            EnableButtons();
        }

        private void btnStart4_Click(object sender, EventArgs e)
        {
            DisableButtons();
            RunCombo(1000);
            EnableButtons();

        }

        private void btnStart5_Click(object sender, EventArgs e)
        {
            DisableButtons();
            RunCombo(10000);
            EnableButtons();

        }

        private void btnStart6_Click(object sender, EventArgs e)
        {
            DisableButtons();
            RunCombo(100000);
            EnableButtons();

        }

        private void btnStart7_Click(object sender, EventArgs e)
        {
            DisableButtons();
            RunCombo(1000000);
            EnableButtons();

        }

        private void btnStart8_Click(object sender, EventArgs e)
        {
            DisableButtons();
            RunCombo(10000000);
            EnableButtons();
        }
        #endregion

        private void btnAll_Click(object sender, EventArgs e)
        {
            DisableButtons();
            DoEveryCombination2();
            EnableButtons();
        }

        private void PrintOverallEV()
        {
            Deck d = new Deck();
            d.InitializeOdds();

            // How should I figure out the overall EV?
            // We have a big grid of numbers, so just take each grid value's highest number, then
            // multiply it by the odds of it occurring.
            double dTotal = 0.0;
            double dValueToAdd;
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (arrTotal[i, j] != 0)
                    {
                        dValueToAdd = (Math.Max(Math.Max(arrTotal[i, j] * -1.0, arrRaiseWin[i, j]), arrAllInWin[i, j])) / arrTotal[i, j];
                    }
                    else
                    {
                        dValueToAdd = 0.0;
                    }
                    dValueToAdd *= d.GetOddsForCardCombo(i, j);
                    /*
                    if (i == j)
                    {
                        dValueToAdd /= 221.0;
                    }
                    else if (i > j)
                    {
                        dValueToAdd /= 110.5;
                    }
                    else
                    {
                        dValueToAdd /= 331.5;
                    }
                     * */
                    dTotal += dValueToAdd;
                }
            }

            lblOverallEV.Text = "Overall EV:      " + dTotal;
        }

    }
}
