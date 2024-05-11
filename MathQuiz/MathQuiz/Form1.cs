namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //randomizer という名前の Random オブジェクトを作成
        //乱数の生成をするよ
        Random randomizer = new Random();

        //加算問題はこれらの整数変数には数値が格納される
        int addend1;
        int addend2;

        //減算問題の場合、これらの整数変数には数値が格納される
        int minuend;
        int subtrahend;

        //乗算の問題の場合、これらの整数には数値が格納される
        int multiplicand;
        int multiplier;

        //除算の問題の場合、これらの整数変数には数値が格納される
        int dividend;
        int divisor;

        //この整数変数は残り時間のこと
        int timeLeft;

        //すべての問題を埋めてクイズを開始してタイマーを開始させる
        public void StartTheQuiz()
        {
            //足し算問題を埋めてね
            //追加する2つの乱数を生成して、値を変数'addend1'と'addend2'に保存するよ
            //Random オブジェクトで Next() メソッドを使用する場合、51 未満、つまり 0 から 50 の乱数が取得され
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //ランダムに生成された２つの数値を変換
            //ラベルコントロール内に表示できるように文字列に変換
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //'sum'はNumericUpDownコントロールの名前
            //このステップはその値がゼロであることを確認し、値を追加する
            sum.Value = 0;

            //引き算の問題を埋めてね
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //掛け算の問題を埋めてね
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //割り算の問題を埋めてね
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            //タイマー開始する
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        //回答をチェックしてユーザーがすべて正しかったかどうかを確認
        //<returns>答えが正しい場合は true、そうでない場合は false。</returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }




        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void DividedRightLabel_Click(object sender, EventArgs e)
        {

        }

        private void TimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //CheckTheAnswer()がtrueを返した場合、ユーザーは正解しているから
                //タイマーを止めてメッセージボックスを表示する
                timer1.Stop();
                MessageBox.Show("全問正解！", "おめでとう！");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //CheckTheAnswerがfalseを返した場合はカウントダウンを続行
                //timeLeftLbelで一秒減らした状態の新しい残り時間を更新します
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";

                if(timeLeft == 5)
                {
                    timeLabel.ForeColor = Color.Red;
                }

            }
            else
            {
                //ユーザーの時間がなくなった場合は、タイマーを停止し
                //メッセージボックスに答えを記入して表示するよ
                timer1.Stop();
                timeLabel.Text = "Time's Up !";
                MessageBox.Show("時間切れ！", "残念…！");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }

        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //NumericUpDown コントロールで答え全体を選択
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
