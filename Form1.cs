using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__Typing_Game
{
    public partial class Form1 : Form
    {
        List<string> words;
        List<Label> fallingWords;
        Random random;
        Stats stats;

        int bestScore = 0;
        int bestTotal = 0;
        int bestMiss = 0;

        public class Stats
        {
            public int Total { get; private set; }
            public int Score { get; private set; }
            public int Missed { get; private set; }
            public int HP { get; private set; }

            private Label totalLabel;
            private Label scoreLabel;
            private Label missedLabel;
            private ProgressBar hpProgressBar;

            public event Action OnGameOver;

            public Stats(Label totalLabel, Label scoreLabel, Label missedLabel, ProgressBar hpProgressBar)
            {
                this.totalLabel = totalLabel;
                this.scoreLabel = scoreLabel;
                this.missedLabel = missedLabel;
                this.hpProgressBar = hpProgressBar;

                Total = 0;
                Score = 0;
                Missed = 0;
                HP = 100;

                UpdateLabels();
                UpdateProgressBar();
            }

            public void IncrementTotal()
            {
                Total++;
                UpdateLabels();
            }

            public void IncrementScore(int wordLength)
            {
                Score += 10 * wordLength;
                UpdateLabels();
            }

            public void IncrementMissed()
            {
                Missed++;
                HP -= 5;

                if (HP < 0)
                    HP = 0;

                UpdateLabels();
                UpdateProgressBar();

                if (HP == 0)
                    OnGameOver?.Invoke();
            }

            private void UpdateLabels()
            {
                totalLabel.Text = $"{Total}";
                scoreLabel.Text = $"{Score}";
                missedLabel.Text = $"{Missed}";
            }

            private void UpdateProgressBar()
            {
                hpProgressBar.Value = HP;
            }

            public void ResetStats()
            {
                Score = 0;
                Total = 0;
                Missed = 0;
                UpdateLabels();
            }
        }

        public Form1()
        {
            InitializeComponent();
            words = new List<string>();
            fallingWords = new List<Label>();
            random = new Random();
            stats = new Stats(pTotal, pScore, pMiss, presentPgBar);
            stats.OnGameOver += HandleGameOver;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = @"..\..\ko.txt";
            if (File.Exists(filePath))
            {
                words = File.ReadAllLines(filePath).ToList();
                timer1.Start();
            }
            else
            {
                MessageBox.Show("파일을 찾을 수 없습니다.");
            }
        }

        private void wordCreationTimer_Tick(object sender, EventArgs e)
        {
            string word = GetRandomWord();
            AddFallingWord(word, grpBoard);

            if (wordCreationTimer.Interval > 2000)
                wordCreationTimer.Interval -= 100;
            if (wordCreationTimer.Interval > 1300)
                wordCreationTimer.Interval -= 50;
            if (wordCreationTimer.Interval > 700)
                wordCreationTimer.Interval -= 15;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = fallingWords.Count - 1; i >= 0; i--)
            {
                Label label = fallingWords[i];
                label.Location = new Point(label.Location.X, label.Location.Y + 15);

                if (label.Location.Y + label.Height > grpBoard.Height)
                {
                    fallingWords.RemoveAt(i);
                    grpBoard.Controls.Remove(label);
                    label.Dispose();
                    stats.IncrementMissed();
                }
            }

            if (timer1.Interval > 900)
                timer1.Interval -= 15;
            if (timer1.Interval > 600)
                timer1.Interval -= 7;
            if (timer1.Interval > 400)
                timer1.Interval -= 5;
            if (timer1.Interval > 250)
                timer1.Interval -= 3;
            if (timer1.Interval > 100)
                timer1.Interval -= 1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var label in fallingWords)
            {
                e.Graphics.DrawString(label.Text, label.Font, Brushes.Black, label.Location);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string enteredWord = textBox1.Text.Trim();
                if (!string.IsNullOrEmpty(enteredWord))
                {
                    RemoveMatchingWord(enteredWord);
                    textBox1.Clear();
                }
            }
        }

        string GetRandomWord()
        {
            if (words.Count == 0)
                return null;
            return words[random.Next(0, words.Count)];
        }

        void AddFallingWord(string word, Control parentControl)
        {
            if (word == null || parentControl == null)
                return;

            Label label = new Label();
            label.Text = word;
            label.AutoSize = true;
            label.Font = new Font("맑은 고딕", 13, FontStyle.Regular);
            label.Location = new Point(random.Next(0, 535 - label.Width), 12);
            parentControl.Controls.Add(label);
            fallingWords.Add(label);

            stats.IncrementTotal();
        }

        void RemoveMatchingWord(string enteredWord)
        {
            for (int i = fallingWords.Count - 1; i >= 0; i--)
            {
                Label label = fallingWords[i];
                if (label.Text == enteredWord)
                {
                    fallingWords.RemoveAt(i);
                    grpBoard.Controls.Remove(label);
                    label.Dispose();

                    stats.IncrementScore(enteredWord.Length);
                    break;
                }
            }
        }

        private void HandleGameOver()
        {
            timer1.Stop();
            wordCreationTimer.Stop();

            foreach (var label in fallingWords)
            {
                grpBoard.Controls.Remove(label);
                label.Dispose();
            }
            fallingWords.Clear();

            Label gameOverLabel = new Label()
            {
                Name = "gameOverLabel",
                Text = "Game Over",
                AutoSize = true,
                Font = new Font("Arial", 32, FontStyle.Bold),
            };

            grpBoard.Controls.Add(gameOverLabel);
            gameOverLabel.Location = new Point(
                (grpBoard.Width - gameOverLabel.Width) / 2,
                (grpBoard.Height - gameOverLabel.Height) / 2);

            UpdateBestScores();
        }

        private void UpdateBestScores()
        {
            int currentScore = stats.Score;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestTotal = stats.Total;
                bestMiss = stats.Missed;

                bScore.Text = bestScore.ToString();
                bTotal.Text = bestTotal.ToString();
                bMiss.Text = bestMiss.ToString();
            }
            if (currentScore == bestScore)
                if (stats.Total > bestTotal)
                {
                    bestScore = currentScore;
                    bestTotal = stats.Total;
                    bestMiss = stats.Missed;

                    bScore.Text = bestScore.ToString();
                    bTotal.Text = bestTotal.ToString();
                    bMiss.Text = bestMiss.ToString();
                }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            wordCreationTimer.Stop();
            DialogResult result = MessageBox.Show("정말 다시 시작하시겠습니까?\n현재 점수는 사라집니다.", "게임 재시작", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                RestartGame();
            else
            {
                timer1.Start();
                wordCreationTimer.Start();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            wordCreationTimer.Stop();
            DialogResult result = MessageBox.Show("게임을 종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
            else
            {
                timer1.Start();
                wordCreationTimer.Start();
            }
        }

        private void RestartGame()
        {
            timer1.Start();
            wordCreationTimer.Start();

            if (grpBoard.Controls.ContainsKey("gameOverLabel"))
                grpBoard.Controls.RemoveByKey("gameOverLabel");

            foreach (var label in fallingWords)
            {
                grpBoard.Controls.Remove(label);
                label.Dispose();
            }
            fallingWords.Clear();

            timer1.Interval = 1000;
            wordCreationTimer.Interval = 3000;
            stats.ResetStats();
            textBox1.Clear();
        }
    }
}
