using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }
        //firstClickedはプレーヤーがクリックする最初のLabelコントロールを挿す
        //プレーヤーがまだラベルをクリックしていない場合はnullになる
        Label firstClicked = null;

        //secondClickedはプレーヤーがクリックする2番目のLabelコントロールをさす
        Label secondClicked = null;
       

        //このRandomオブジェクトを使用して、正方形のアイコンをランダムに選択する
        Random random = new Random();

        //Webdingsフォントの中の文字を２回ずつ表示されるように指定する
        List<string> icons = new List<string>()
       {
         "!", "!", "N", "N", ",", ",", "k", "k",
         "b", "b", "v", "v", "w", "w", "z", "z"
        };


        //アイコンのリストから書くアイコンをランダムな正方形に割り当て
        private void AssignIconsToSquares()
        {
            //TableLayoutPanelに16子のラベルがあります。
            //アイコンリストに16子アイコンがあり、
            //アイコンリストからランダムに取得されるようにして
            //書くラベルに追加される
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }

            
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            //タイマーは2つの一致しないアイコンがプレーヤーに表示された後に飲みオンになる
            //そのため、タイマーが実行中の場合はクリックを無視する
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                //クリックしたラベルが黒の場合、プレーヤーはすでに表示されているアイコンをクリックしているから
                //クリックは無視される
                if (clickedLabel.ForeColor == Color.MidnightBlue)
                    return;

                //firstClickedがnullの場合、これはプレーヤーがクリックしたペアの
                //最初のアイコンだから、firstClickedをプレーヤーがクリックしたラベルに設定し
                //その色を黒に変更して返します。
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.MidnightBlue;
                    return;
                }

                //プレーヤーがここまで到達した場合、タイマーは実行されておらず
                //firstClickedはnullではありません
                //したがってこれはプレーヤーがクリックした2番目のアイコンである必要がある
                //色を黒に設定
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.MidnightBlue;

                //プレイヤーが勝ったかを確認する
                CheckForWinner();

                //プレイヤーが2つの一致するアイコンをクリックした場合
                //プレイヤーが別のアイコンをクリックしできるように
                //アイコンを黒のままにしてfirstClickedとsecondClickedをリセット
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                //ここまで到達するとプレイヤーは2つの異なるアイコンをクリックしたため
                //タイマーが始まり4分の3秒待ってからアイコンを非表示にする
                timer1.Start();

            }
        }

        //このタイマーは一致しない２つのアイコンをクリックすると開始する
        //4分の3秒をカウントし、その後自動的にオフになり
        //両方のアイコンが非表示になる
        private void timer1_Tick(object sender, EventArgs e)
        {           

            //タイマーを止める
            timer1.Stop();

            //両方のアイコンを隠す
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            //firstClickedとSecondClickedをリセットして次回ラベルがクリックされたとき
            //プログラムがそれが最初のクリックであることを認識できるようにする
            firstClicked = null;
            secondClicked = null;


        }

        //すべてのアイコンの前背景と背景色を比較して
        //アイコンが一致しているかを確認
        //すべてのアイコンが一致した場合プレイヤーの勝ち
        private void CheckForWinner()
        {
            //TableLayoutPanelないのすべてのラベルを調べて
            //それぞれのアイコンが一致するかどうかを確認
           foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }



            //ループが戻らなかった場合、一致しない青痕が見つからなかったということは
            //ユーザーが勝ったことを意味するのでメッセージを表示してフォームを閉じる
            MessageBox.Show("すべてのアイコンがそろいました！", "おめでとう！");
            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
