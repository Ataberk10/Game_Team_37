using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameVsComputer
{
    public partial class Form1 : Form
    {
        enum AlgorithmType { Minimax, AlphaBeta }

        int gameBank = 0;
        int playerScore = 0;
        int computerScore = 0;
        int currentNumber = 0;
        int maxDepth = 4;
        bool isPlayerTurn = true;
        bool gameEnded = false;

        AlgorithmType selectedAlgorithm;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            LoadComboBoxes();
        }
        private void LoadComboBoxes()
        {
            cmbAlgorithm.Items.AddRange(new string[] { "Minimax", "Alpha-Beta" });
            cmbStartPlayer.Items.AddRange(new string[] { "Player", "Computer" });

            cmbAlgorithm.SelectedIndex = 0;      // varsayılan olarak Minimax seçili gelsin
            cmbStartPlayer.SelectedIndex = 0;    // varsayılan olarak Player seçili gelsin
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtStartNumber.Text, out int num) && num >= 8 && num <= 18)
            {
                currentNumber = num;
                gameBank = 0;
                playerScore = 0;
                computerScore = 0;
                gameEnded = false;

                isPlayerTurn = cmbStartPlayer.SelectedItem.ToString() == "Player";
                selectedAlgorithm = cmbAlgorithm.SelectedIndex == 0 ? AlgorithmType.Minimax : AlgorithmType.AlphaBeta;

                EnableGameControls(isPlayerTurn);
                UpdateUI();

                if (!isPlayerTurn)
                {
                    await Task.Delay(300);
                    await ComputerTurn(); // async hale getirildi
                }
            }
            else
            {
                MessageBox.Show("Please enter a number between 8 and 18.");
            }
        }

        private async void MultiplyAndPlay(int multiplier)
        {
            if (gameEnded || !isPlayerTurn) return;

            currentNumber *= multiplier;

            if (currentNumber % 2 == 0) playerScore--;
            else playerScore++;

            if (currentNumber % 10 == 0 || currentNumber % 10 == 5) gameBank++;

            CheckGameEnd();
            UpdateUI();

            if (!gameEnded)
            {
                isPlayerTurn = false;
                EnableGameControls(false);
                await Task.Delay(300);
                await ComputerTurn();
            }
        }

        private async Task ComputerTurn()
        {
            await Task.Delay(300);

            if (gameEnded) return;

            Stopwatch stopwatch = Stopwatch.StartNew();
            int bestMultiplier = 2;
            int bestValue = int.MinValue;

            foreach (int mult in new int[] { 2, 3, 4 })
            {
                GameState next = new GameState(currentNumber * mult, playerScore, computerScore, gameBank);
                next.ApplyRules(mult, false);

                int value = selectedAlgorithm == AlgorithmType.Minimax
                    ? Minimax(next, maxDepth - 1, false)
                    : AlphaBeta(next, maxDepth - 1, int.MinValue, int.MaxValue, false);

                if (value > bestValue)
                {
                    bestValue = value;
                    bestMultiplier = mult;
                }
            }
            stopwatch.Stop();

            currentNumber *= bestMultiplier;
            if (currentNumber % 2 == 0) computerScore--;
            else computerScore++;

            if (currentNumber % 10 == 0 || currentNumber % 10 == 5) gameBank++;

            CheckGameEnd();
            UpdateUI();

            if (!gameEnded)
            {
                isPlayerTurn = true;
                EnableGameControls(true);
            }
        }

        private void CheckGameEnd()
        {
            if (currentNumber >= 1200)
            {
                gameEnded = true;
                if (isPlayerTurn) playerScore += gameBank;
                else computerScore += gameBank;

                EnableGameControls(false);

                string result = playerScore > computerScore ? "🎉 Player wins!" :
                                computerScore > playerScore ? "🤖 Computer wins!" : "🤝 It's a draw!";
                MessageBox.Show($"Game Over!\nPlayer: {playerScore}\nComputer: {computerScore}\n{result}");
            }
        }

        private void EnableGameControls(bool enable)
        {
            btnMult2.Enabled = btnMult3.Enabled = btnMult4.Enabled = enable && isPlayerTurn;
        }

        private void UpdateUI()
        {
            lblCurrentNumber.Text = $"Current Number: {currentNumber}";
            lblScores.Text = $"Player: {playerScore} | Computer: {computerScore} | Bank: {gameBank}";
            EnableGameControls(!gameEnded);
        }

        private int Evaluate(GameState state)
        {
            return (state.ComputerScore - state.PlayerScore) + state.Bank;
        }

        private int Minimax(GameState state, int depth, bool maximizing)
        {
            if (depth == 0 || state.CurrentNumber >= 1200)
                return Evaluate(state);

            int best = maximizing ? int.MinValue : int.MaxValue;
            foreach (int mult in new int[] { 2, 3, 4 })
            {
                GameState child = state.Clone();
                child.CurrentNumber *= mult;
                child.ApplyRules(mult, maximizing);
                int val = Minimax(child, depth - 1, !maximizing);
                best = maximizing ? Math.Max(best, val) : Math.Min(best, val);
            }
            return best;
        }

        private int AlphaBeta(GameState state, int depth, int alpha, int beta, bool maximizing)
        {
            if (depth == 0 || state.CurrentNumber >= 1200)
                return Evaluate(state);

            foreach (int mult in new int[] { 2, 3, 4 })
            {
                GameState child = state.Clone();
                child.CurrentNumber *= mult;
                child.ApplyRules(mult, maximizing);
                int val = AlphaBeta(child, depth - 1, alpha, beta, !maximizing);

                if (maximizing)
                {
                    alpha = Math.Max(alpha, val);
                    if (alpha >= beta) break;
                }
                else
                {
                    beta = Math.Min(beta, val);
                    if (beta <= alpha) break;
                }
            }
            return maximizing ? alpha : beta;
        }

        private void btnMult2_Click(object sender, EventArgs e) => MultiplyAndPlay(2);
        private void btnMult3_Click(object sender, EventArgs e) => MultiplyAndPlay(3);
        private void btnMult4_Click(object sender, EventArgs e) => MultiplyAndPlay(4);

    }

    public class GameState
    {
        public int CurrentNumber;
        public int PlayerScore;
        public int ComputerScore;
        public int Bank;

        public GameState Parent;
        public List<GameState> Children = new List<GameState>();
        public int LastMove;
        public int Depth;

        public GameState(int num, int pScore, int cScore, int bank, GameState parent = null, int lastMove = 0, int depth = 0)
        {
            CurrentNumber = num;
            PlayerScore = pScore;
            ComputerScore = cScore;
            Bank = bank;
            Parent = parent;
            LastMove = lastMove;
            Depth = depth;
        }

        public void ApplyRules(int multiplier, bool isPlayer)
        {
            if (CurrentNumber % 2 == 0)
            {
                if (isPlayer) PlayerScore--;
                else ComputerScore--;
            }
            else
            {
                if (isPlayer) PlayerScore++;
                else ComputerScore++;
            }

            if (CurrentNumber % 10 == 0 || CurrentNumber % 10 == 5)
                Bank++;
        }

        public GameState Clone()
        {
            return new GameState(CurrentNumber, PlayerScore, ComputerScore, Bank, Parent, LastMove, Depth);
        }

        public void GenerateChildren(bool isPlayer)
        {
            foreach (int multiplier in new[] { 2, 3, 4 })
            {
                GameState child = Clone();
                child.CurrentNumber *= multiplier;
                child.ApplyRules(multiplier, isPlayer);
                child.Parent = this;
                child.LastMove = multiplier;
                child.Depth = this.Depth + 1;
                this.Children.Add(child);
            }
        }
    }
    }
