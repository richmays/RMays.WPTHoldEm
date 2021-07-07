using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WPTHoldem2
{
    public partial class Form1 : Form
    {
        private Deck d = new Deck();
        private int iBankroll = 300;

        private int iAnte = 5;
        private int iHoleCardsBet = 0;
        private int iFinalHandBet = 0;

        private int iPlayerCard1 = -1;
        private int iPlayerCard2 = -1;
        private int iDealerCard1 = -1;
        private int iDealerCard2 = -1;

        private string sPlayerHand;

        private int iCommCard1;
        private int iCommCard2;
        private int iCommCard3;
        private int iCommCard4;
        private int iCommCard5;

        public Form1()
        {
            InitializeComponent();
            UpdateBankrollLabel();
            GameState2();
        }

        private void AddCardImage(PictureBox pb, int iCard)
        {
            if (iCard == -1)
            {
                pb.Image = null;
                return;
            }
            Card c = new Card(iCard);
            string s = c.FileName();
            IntPtr dummy = new IntPtr();
            try
            {
                Image imgCard = Image.FromFile(s);
                imgCard = imgCard.GetThumbnailImage(105, 147, null, dummy);

                pb.Image = imgCard;
            }
            catch
            {
                pb.Image = null;
            }
        }

        private void ClearMessage()
        {
            txtMessage.Text = string.Empty;
        }

        private void AddMessage( string s )
        {
            txtMessage.Text += s + System.Environment.NewLine;
            txtMessage.Select(txtMessage.Text.Length, 0);
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            ClearMessage();
            d.Reset();
            d.Shuffle(9);
            iPlayerCard1 = d.Pop();
            iDealerCard1 = d.Pop();
            iPlayerCard2 = d.Pop();
            iDealerCard2 = d.Pop();
            AddMessage("Dealing cards [" + GetCardString(iPlayerCard1) + " " + GetCardString(iPlayerCard2) + "]");
            GameState1();

            AddCardImage(pbPlayerCard1, iPlayerCard1);
            AddCardImage(pbPlayerCard2, iPlayerCard2);
            if (iBankroll >= (6 * (int)nudAnte.Value))
            {
                btnRaise.Enabled = true;
            }
            if (iBankroll >= (11 * (int)nudAnte.Value))
            {
                btnAllIn.Enabled = true;
            }
        }

        private void UpdateBankrollLabel()
        {
            int iNewBankroll = iBankroll - (int)(nudAnte.Value) - (int)(nudFinalHand.Value) - (int)(nudHoleCards.Value);
            lblBankroll.Text = "$" + iNewBankroll.ToString();
        }

        #region nudAnte
        private void nudAnte_Update()
        {
            if ((int)nudAnte.Value + (int)nudFinalHand.Value + (int)nudHoleCards.Value <= iBankroll)
            {
                iAnte = (int)nudAnte.Value;
            }
            else
            {
                nudAnte.Value = iAnte;
            }
            UpdateBankrollLabel();
        }

        private void nudAnte_ValueChanged(object sender, EventArgs e)
        {
            nudAnte_Update();
        }

        private void nudAnte_KeyUp(object sender, KeyEventArgs e)
        {
            nudAnte_Update();
        }
        #endregion

        #region nudHoleCards
        private void nudHoleCards_Update()
        {
            if ((int)nudAnte.Value + (int)nudFinalHand.Value + (int)nudHoleCards.Value <= iBankroll)
            {
                iHoleCardsBet = (int)nudHoleCards.Value;
            }
            else
            {
                nudHoleCards.Value = iHoleCardsBet;
            }
            UpdateBankrollLabel();
        }
        private void nudHoleCards_ValueChanged(object sender, EventArgs e)
        {
            nudHoleCards_Update();
        }
        #endregion

        private void nudFinalHand_ValueChanged(object sender, EventArgs e)
        {
            iFinalHandBet = (int)nudFinalHand.Value;
            UpdateBankrollLabel();
        }

        private void UpdateBankroll()
        {
            UpdateBankrollLabel();
            AddMessage("You have $" + iBankroll + ".");
        }

        private void PayHoleCardsBet(string sMessage, int iPayoff)
        {
            AddMessage("Player has " + sMessage + " and wins $" + (iHoleCardsBet * iPayoff) + ".");
            iBankroll += (iHoleCardsBet * iPayoff);
            UpdateBankrollLabel();
        }

        private void HandleHoleCardsBet()
        {
            Card c1 = new Card( iPlayerCard1 );
            Card c2 = new Card( iPlayerCard2 );
            if (iHoleCardsBet == 0)
            {
                return;
            }
            // Two Red Aces, pays 50:1
            if (c1.Rank() == 'A' && c2.Rank() == 'A')
            {
                if ((c1.Suit() == 'd' && c2.Suit() == 'h') || (c1.Suit() == 'h' && c2.Suit() == 'd'))
                {
                    PayHoleCardsBet("2 Red Aces", 50);
                    return;
                }
            }
            // Ace King Suited, pays 25:1
            if (c1.Suit() == c2.Suit())
            {
                if ((c1.Rank() == 'A' && c2.Rank() == 'K') || (c1.Rank() == 'K' && c2.Rank() == 'A'))
                {
                    PayHoleCardsBet("Ace King Suited", 25);
                    return;
                }
            }
            // Pair; pays 20:1, 8:1, 3:1, or 2:1
            if (c1.Rank() == c2.Rank())
            {
                switch (c1.Rank())
                {
                    case 'A': PayHoleCardsBet("a pair of Aces", 20); break;
                    case 'K': PayHoleCardsBet("a pair of Kings", 8); break;
                    case 'Q': PayHoleCardsBet("a pair of Queens", 8); break;
                    case 'J': PayHoleCardsBet("a pair of Jacks", 8); break;
                    case 'T': PayHoleCardsBet("a pair of Tens", 3); break;
                    case '9': PayHoleCardsBet("a pair of Nines", 3); break;
                    case '8': PayHoleCardsBet("a pair of Eights", 3); break;
                    case '7': PayHoleCardsBet("a pair of Sevens", 3); break;
                    case '6': PayHoleCardsBet("a pair of Sixes", 3); break;
                    case '5': PayHoleCardsBet("a pair of Fives", 2); break;
                    case '4': PayHoleCardsBet("a pair of Fours", 2); break;
                    case '3': PayHoleCardsBet("a pair of Threes", 2); break;
                    case '2': PayHoleCardsBet("a pair of Twos", 2); break;
                }
                return;
            }
            // Suited
            if (c1.Suit() == c2.Suit())
            {
                PayHoleCardsBet("two suited cards", 1);
                return;
            }
            iBankroll -= iHoleCardsBet;
        }

        private void GameState1()
        {
            iAnte = (int)nudAnte.Value;
            iHoleCardsBet = (int)nudHoleCards.Value;
            iFinalHandBet = (int)nudFinalHand.Value;
            HandleHoleCardsBet();
            btnDeal.Enabled = false;
            btnFold.Enabled = true;
            btnRaise.Enabled = (iBankroll >= (6 * iAnte));
            btnAllIn.Enabled = (iBankroll >= (11 * iAnte));
            nudAnte.Enabled = false;
            nudHoleCards.Enabled = false;
            nudFinalHand.Enabled = false;

            // Hide the dealer's cards.
            AddCardImage(pbDealerCard1, -1);
            AddCardImage(pbDealerCard2, -1);
            AddCardImage(pbCommCard1, -1);
            AddCardImage(pbCommCard2, -1);
            AddCardImage(pbCommCard3, -1);
            AddCardImage(pbCommCard4, -1);
            AddCardImage(pbCommCard5, -1);
        }

        private void PayFinalHandBet(string sMessage, int iPayoff)
        {
            AddMessage("Player has: " + sMessage + " and wins $" + (iFinalHandBet * iPayoff) + ".");
            iBankroll += (iFinalHandBet * iPayoff );
            UpdateBankrollLabel();
        }

        private void HandleFinalHandBet()
        {
            // Use the variable 'sPlayerHand'
            switch( (char)sPlayerHand[0] )
            {
                case '9':
                    if (sPlayerHand.Substring(1, 2) == "12")
                    {
                        PayFinalHandBet("a Royal Flush", 500); break;
                    }
                    else
                    {
                        PayFinalHandBet("a Straight Flush", 100); break;
                    }
                case '8': PayFinalHandBet("Four of a Kind", 40); break;
                case '7': PayFinalHandBet("a Full House", 8); break;
                case '6': PayFinalHandBet("a Flush", 6); break;
                case '5': PayFinalHandBet("a Straight", 4); break;
                case '4': PayFinalHandBet("Three of a Kind", 2); break;
                default: iBankroll -= iFinalHandBet; break;
            }
        }

        private void GameState2()
        {
            if (iFinalHandBet > 0)
            {
                // Handle the final hand bet.
                HandleFinalHandBet();
            }

            // If the bankroll is too small, remove from the side bets.
            while (iBankroll < (iAnte + iHoleCardsBet + iFinalHandBet))
            {
                if (iHoleCardsBet > 0)
                {
                    iHoleCardsBet--;
                }
                else if (iFinalHandBet > 0)
                {
                    iFinalHandBet--;
                }
                else
                {
                    iAnte--;
                }
            }
            try
            {
                nudAnte.Value = iAnte;
            }
            catch
            {
                iBankroll = 300;
                iAnte = 5;
                nudAnte.Value = 5;
            }
            nudHoleCards.Value = iHoleCardsBet;
            nudFinalHand.Value = iFinalHandBet;
            btnDeal.Enabled = true;
            btnFold.Enabled = false;
            btnRaise.Enabled = false;
            btnAllIn.Enabled = false;
            nudAnte.Enabled = true;
            nudHoleCards.Enabled = true;
            nudFinalHand.Enabled = true;

            UpdateBankroll();

            // Show the dealer's cards.
            AddCardImage(pbDealerCard1, iDealerCard1);
            AddCardImage(pbDealerCard2, iDealerCard2);

            // Does the player need to rebuy?
            if (iBankroll <= 60)
            {
                btnRebuy.Visible = true;
            }
            else
            {
                btnRebuy.Visible = false;
            }
        }

        private string GetCardString(int i)
        {
            return (new Card(i)).Name();
        }
        
        private void btnFold_Click(object sender, EventArgs e)
        {
            AddMessage("You fold.");
            AddMessage("Dealer shows [" + GetCardString(iDealerCard1) + " " + GetCardString(iDealerCard2) + "]");
            iBankroll = iBankroll - (int)nudAnte.Value;
            // Put out the community cards if the player is betting on their final hand.
            if (iFinalHandBet > 0)
            {
                Hand playerHand = new Hand();
                SetCommunityCards();
                GetPlayerHand(playerHand);
                sPlayerHand = playerHand.GetHandValue();
            }
            GameState2();
        }

        private void btnRaise_Click(object sender, EventArgs e)
        {
            AddMessage("You raise.");
            AddMessage("Dealer shows [" + GetCardString(iDealerCard1) + " " + GetCardString(iDealerCard2) + "]");
            int iResult;
            int iDealerCount;
            bool bDealerCalls = false;
            iDealerCount = Card.BJValue(iDealerCard1) + Card.BJValue(iDealerCard2);
            if (iDealerCard1 / 4 == iDealerCard2 / 4)
            {
                AddMessage("Dealer has a pair.");
                bDealerCalls = true;
            }
            else
            {
                AddMessage("Dealer has " + iDealerCount.ToString() + " points.");
                if (iDealerCount < 13)
                {
                    bDealerCalls = false;
                }
                else
                {
                    bDealerCalls = true;
                }
            }
            if (bDealerCalls)
            {
                AddMessage("Dealer calls.");
                iResult = PlayerWins(5);
                if (iResult == 1)
                {
                    iBankroll += (6 * (int)nudAnte.Value);
                }
                else if (iResult == -1)
                {
                    iBankroll -= (6 * (int)nudAnte.Value);
                }
            }
            else
            {
                AddMessage("Dealer folds.");
                iBankroll += (int)nudAnte.Value;
                if (iFinalHandBet > 0)
                {
                    Hand playerHand = new Hand();
                    SetCommunityCards();
                    GetPlayerHand(playerHand);
                    sPlayerHand = playerHand.GetHandValue();
                }
            }
            GameState2();
        }

        private void btnAllIn_Click(object sender, EventArgs e)
        {
            AddMessage("You go all in.");
            AddMessage("Dealer shows [" + GetCardString(iDealerCard1) + " " + GetCardString(iDealerCard2) + "]");
            int iResult;
            int iDealerCount;
            bool bDealerCalls = false;
            iDealerCount = Card.BJValue(iDealerCard1) + Card.BJValue(iDealerCard2);
            if (iDealerCard1 / 4 == iDealerCard2 / 4)
            {
                AddMessage("Dealer has a pair.");
                bDealerCalls = true;
            }
            else
            {
                AddMessage("Dealer has " + iDealerCount.ToString() + " points.");
                if (iDealerCount < 17)
                {
                    bDealerCalls = false;
                }
                else
                {
                    bDealerCalls = true;
                }
            }
            if (bDealerCalls)
            {
                AddMessage("Dealer calls.");
                iResult = PlayerWins(10);
                if (iResult == 1)
                {
                    iBankroll += (11 * (int)nudAnte.Value);
                }
                else if (iResult == -1)
                {
                    iBankroll -= (11 * (int)nudAnte.Value);
                }
            }
            else
            {
                AddMessage("Dealer folds.");
                iBankroll += (int)nudAnte.Value;
                if (iFinalHandBet > 0)
                {
                    Hand playerHand = new Hand();
                    SetCommunityCards();
                    GetPlayerHand(playerHand);
                    sPlayerHand = playerHand.GetHandValue();
                }
            }
            GameState2();
        }

        #region Which player wins?
        private void GetPlayerHand(Hand theHand)
        {
            theHand.AddCard(iPlayerCard1);
            theHand.AddCard(iPlayerCard2);
            theHand.AddCard(iCommCard1);
            theHand.AddCard(iCommCard2);
            theHand.AddCard(iCommCard3);
            theHand.AddCard(iCommCard4);
            theHand.AddCard(iCommCard5);
        }

        private void GetDealerHand(Hand theHand)
        {
            theHand.AddCard(iDealerCard1);
            theHand.AddCard(iDealerCard2);
            theHand.AddCard(iCommCard1);
            theHand.AddCard(iCommCard2);
            theHand.AddCard(iCommCard3);
            theHand.AddCard(iCommCard4);
            theHand.AddCard(iCommCard5);
        }

        private void SetCommunityCards()
        {
            // Pull the community cards from the deck, and show them.
            d.Pop(); // burn card
            iCommCard1 = d.Pop();
            iCommCard2 = d.Pop();
            iCommCard3 = d.Pop();
            d.Pop(); // burn card
            iCommCard4 = d.Pop();
            d.Pop(); // burn card
            iCommCard5 = d.Pop();
            AddCardImage(pbCommCard1, iCommCard1);
            AddCardImage(pbCommCard2, iCommCard2);
            AddCardImage(pbCommCard3, iCommCard3);
            AddCardImage(pbCommCard4, iCommCard4);
            AddCardImage(pbCommCard5, iCommCard5);
            string strToShow = "Dealing community cards [";
            strToShow += GetCardString( iCommCard1 ) + " ";
            strToShow += GetCardString( iCommCard2 ) + " ";
            strToShow += GetCardString( iCommCard3 ) + " ";
            strToShow += GetCardString( iCommCard4 ) + " ";
            strToShow += GetCardString( iCommCard5 ) + "]";
            AddMessage(strToShow);
        }

        private int PlayerWins(int iRaiseAmount)
        {
            Hand playerHand = new Hand();
            Hand dealerHand = new Hand();
            string playerHandValue;
            string dealerHandValue;
            int iResult;

            SetCommunityCards();
            GetPlayerHand( playerHand );
            GetDealerHand( dealerHand );

            playerHandValue = playerHand.GetHandValue();
            dealerHandValue = dealerHand.GetHandValue();

            // Sets the global variable for the player's hand, so it doesn't need to be calculated again.
            // (Used if the player didn't fold.)
            sPlayerHand = playerHandValue;

            AddMessage("Player has: " + Hand.GetHandValueText( playerHandValue) );
            AddMessage("Dealer has: " + Hand.GetHandValueText( dealerHandValue) );

            iResult = String.Compare(playerHandValue, dealerHandValue);
            if (iResult == 1)
            {
                AddMessage("Player wins $" + (iRaiseAmount * iAnte) + ".");
            }
            else if (iResult == -1)
            {
                AddMessage("Dealer wins.");
            }
            else
            {
                AddMessage("Push.");
            }

            // Which hand won?
            return iResult;
        }
        #endregion

        private void btnRebuy_Click(object sender, EventArgs e)
        {
            iBankroll += 60;
            GameState2();
        }

        private void btnEVTable_Click(object sender, EventArgs e)
        {
            EVTable frmEVTable = new EVTable();
            frmEVTable.Visible = true;
        }

    }
}