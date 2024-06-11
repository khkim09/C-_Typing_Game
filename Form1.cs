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

        // Stats 클래스 선언
        public class Stats
        {
            // 데이터 멤버 변수
            public int Total { get; private set; }
            public int Score { get; private set; }
            public int Missed { get; private set; }
            public int HP { get; private set; }

            private Label totalLabel;
            private Label scoreLabel;
            private Label missedLabel;
            private ProgressBar hpProgressBar;

            public event Action OnGameOver;

            public Stats(Label totalLabel, Label scoreLabel, Label missedLabel, ProgressBar hpProgressBar) // 생성자 - 초기값 세팅 (초기화)
            {
                this.totalLabel = totalLabel;
                this.scoreLabel = scoreLabel;
                this.missedLabel = missedLabel;
                this.hpProgressBar = hpProgressBar;

                Total = 0; // 생성된 단어 총 수
                Score = 0; // 점수
                Missed = 0; // 놓친 단어 (산성비) 수
                HP = 100; // 체력 (목숨)

                UpdateLabels();
                UpdateProgressBar();
            }

            // 멤버 함수
            public void IncrementTotal()
            {
                Total++;
                UpdateLabels();
            }

            public void IncrementScore(int wordLength) // 단어 길이 당 10점 추가, 체력 증가
            {
                Score += 10 * wordLength;
                HP += (wordLength / 2);

                if (HP > 100)
                    HP = 100;

                UpdateLabels();
                UpdateProgressBar();
            }

            public void IncrementMissed(int wordLength) // 단어 놓칠 시, 단어 길이 X 4 체력 감소
            {
                Missed++;
                HP -= (4 * wordLength); // 체력 감소

                if (HP < 0)
                    HP = 0;

                UpdateLabels();
                UpdateProgressBar();

                if (HP == 0) // 체력 == 0 : Game Over
                    OnGameOver?.Invoke();
            }

            private void UpdateLabels() // pScore, pTotal, pMiss 갱신
            {
                totalLabel.Text = $"{Total}";
                scoreLabel.Text = $"{Score}";
                missedLabel.Text = $"{Missed}";
            }

            private void UpdateProgressBar() // HP 갱신
            {
                hpProgressBar.Value = HP;
            }

            public void ResetStats() // Restart Game 시 호출
            {
                Score = 0;
                Total = 0;
                Missed = 0;
                UpdateLabels();
            }
        }

        public Form1() // Winform 구성
        {
            InitializeComponent();
            words = new List<string>();
            fallingWords = new List<Label>();
            random = new Random();
            stats = new Stats(pTotal, pScore, pMiss, presentPgBar);
            stats.OnGameOver += HandleGameOver;
        }

        private void Form1_Load(object sender, EventArgs e) // Form Load 시 바로 실행
        {
            string filePath = @"..\..\ko.txt"; // 단어 저장된 txt 파일 load
            if (File.Exists(filePath))
            {
                words = File.ReadAllLines(filePath).ToList(); // List로 저장
                timer1.Start(); // Timer start
                wordCreationTimer.Start();
            }
            else
            {
                MessageBox.Show("파일을 찾을 수 없습니다.");
            }
        }

        private void wordCreationTimer_Tick(object sender, EventArgs e) // 단어 생성 빈도 조절을 위한 Timer
        {
            string word = GetRandomWord(); // 단어 리스트 중 랜덤 추출 생성
            AddFallingWord(word, grpBoard); // 산성비 리스트에 추가

            if (wordCreationTimer.Interval > 2000) // 생성 빈도 조절
                wordCreationTimer.Interval -= 100;
            if (wordCreationTimer.Interval > 1300)
                wordCreationTimer.Interval -= 50;
            if (wordCreationTimer.Interval > 700)
                wordCreationTimer.Interval -= 15;
        }

        private void timer1_Tick(object sender, EventArgs e) // 단어 내려오는 속도 조절을 위한 Timer
        {
            for (int i = fallingWords.Count - 1; i >= 0; i--) // 산성비 리스트 순회
            {
                Label label = fallingWords[i];
                label.Location = new Point(label.Location.X, label.Location.Y + 15); // 산성비 구현

                if (label.Location.Y + label.Height > grpBoard.Height) // 바닥에 닿을 시, IncrementMissed() 호출 (체력 감소)
                {
                    string missedWord = label.Text;
                    fallingWords.RemoveAt(i);
                    grpBoard.Controls.Remove(label);
                    label.Dispose();
                    stats.IncrementMissed(missedWord.Length);
                }
            }

            if (timer1.Interval > 900) // 산성비 속도 조절
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e) // 단어 입력창
        {
            if (e.KeyCode == Keys.Enter) // textBox Enter키 입력 시
            {
                string enteredWord = textBox1.Text.Trim(); // 단어 슬라이싱 후
                if (!string.IsNullOrEmpty(enteredWord))
                {
                    RemoveMatchingWord(enteredWord); // RemoveMatchingWord() 호출 - 일치 단어 제거
                    textBox1.Clear();
                }
            }
        }

        string GetRandomWord() // txt 파일로 읽어온 단어 리스트 중 랜덤 단어 추출
        {
            if (words.Count == 0)
                return null;
            return words[random.Next(0, words.Count)];
        }

        void AddFallingWord(string word, Control parentControl) // 단어 라벨화
        {
            if (word == null || parentControl == null)
                return;

            Label label = new Label();
            label.Text = word;
            label.AutoSize = true;
            label.Font = new Font("맑은 고딕", 13, FontStyle.Regular);
            label.Location = new Point(random.Next(0, 535 - label.Width), 12);
            parentControl.Controls.Add(label); // groupBox(grpBoard)에 추가해 안쪽에서 산성비 생성되도록 구현
            fallingWords.Add(label);

            stats.IncrementTotal(); // 단어 생성 : Total 증가
        }

        void RemoveMatchingWord(string enteredWord) // 단어 일치 시 제거
        {
            for (int i = fallingWords.Count - 1; i >= 0; i--)
            {
                Label label = fallingWords[i];
                if (label.Text == enteredWord)
                {
                    fallingWords.RemoveAt(i);
                    grpBoard.Controls.Remove(label);
                    label.Dispose();

                    stats.IncrementScore(enteredWord.Length); // 점수 증가 (단어 길이 당 10점)
                    break;
                }
            }
        }

        private void HandleGameOver() // Game Over 구현 함수
        {
            timer1.Stop(); // Timer Stop
            wordCreationTimer.Stop();

            foreach (var label in fallingWords) // 모든 산성비 제거 (grpBoard에 나타나는 산성비 없음)
            {
                grpBoard.Controls.Remove(label);
                label.Dispose();
            }
            fallingWords.Clear();

            Label gameOverLabel = new Label() // Game Over 문구 grpBoard 중앙에 출력
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

            UpdateBestScores(); // Game Over 되면, Best Score 갱신
        }

        private void UpdateBestScores() // 최고 점수 갱신 함수
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
            else if (currentScore == bestScore) // 현재 점수 == 기존 최고 점수 일 경우,
            {
                if (stats.Missed < bestMiss) // 놓친 단어 적은 쪽이 최고 점수로 갱신
                {
                    bestScore = currentScore;
                    bestTotal = stats.Total;
                    bestMiss = stats.Missed;

                    bScore.Text = bestScore.ToString();
                    bTotal.Text = bestTotal.ToString();
                    bMiss.Text = bestMiss.ToString();
                }
                else if (stats.Missed == bestMiss) // 놓친 단어 수도 같을 경우,
                {
                    if (stats.Total > bestTotal) // 생성된 단어 (산성비) 수가 많은 쪽이 최고 점수로 갱신
                    {
                        bestScore = currentScore;
                        bestTotal = stats.Total;
                        bestMiss = stats.Missed;

                        bScore.Text = bestScore.ToString();
                        bTotal.Text = bestTotal.ToString();
                        bMiss.Text = bestMiss.ToString();
                    }
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e) // Restart Button 클릭 구현
        {
            timer1.Stop(); // Timer Stop
            wordCreationTimer.Stop();
            DialogResult result = MessageBox.Show("정말 다시 시작하시겠습니까?\n현재 점수는 사라집니다.", "게임 재시작", MessageBoxButtons.YesNo, MessageBoxIcon.Question); // 경고창 생성
            if (result == DialogResult.Yes) // 경고창에서 'Yes' 클릭 시 게임 재시작
                RestartGame();
            else // 'No' 클릭 시 게임 재개
            {
                if (!grpBoard.Controls.ContainsKey("gameOverLabel"))
                {
                    timer1.Start();
                    wordCreationTimer.Start();
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e) // Quit Button 클릭 구현
        {
            timer1.Stop(); // Timer Stop
            wordCreationTimer.Stop();
            DialogResult result = MessageBox.Show("게임을 종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question); // 경고창 생성
            if (result == DialogResult.Yes) // Quit
                this.Close();
            else // 게임 재개
            {
                if (!grpBoard.Controls.ContainsKey("gameOverLabel"))
                {
                    timer1.Start();
                    wordCreationTimer.Start();
                }
            }
        }

        private void RestartGame() // 게임 재시작 함수 구현
        {
            if (grpBoard.Controls.ContainsKey("gameOverLabel")) // grpBoard에 "Game Over"문구 있으면 제거
                grpBoard.Controls.RemoveByKey("gameOverLabel");

            foreach (var label in fallingWords) // 게임 재시작
            {
                grpBoard.Controls.Remove(label);
                label.Dispose();
            }
            fallingWords.Clear();

            timer1.Interval = 1000;
            wordCreationTimer.Interval = 3000;
            stats.ResetStats();
            timer1.Start();
            wordCreationTimer.Start();
            textBox1.Clear();
        }
    }
}