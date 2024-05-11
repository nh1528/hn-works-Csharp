namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //randomizer �Ƃ������O�� Random �I�u�W�F�N�g���쐬
        //�����̐����������
        Random randomizer = new Random();

        //���Z���͂����̐����ϐ��ɂ͐��l���i�[�����
        int addend1;
        int addend2;

        //���Z���̏ꍇ�A�����̐����ϐ��ɂ͐��l���i�[�����
        int minuend;
        int subtrahend;

        //��Z�̖��̏ꍇ�A�����̐����ɂ͐��l���i�[�����
        int multiplicand;
        int multiplier;

        //���Z�̖��̏ꍇ�A�����̐����ϐ��ɂ͐��l���i�[�����
        int dividend;
        int divisor;

        //���̐����ϐ��͎c�莞�Ԃ̂���
        int timeLeft;

        //���ׂĂ̖��𖄂߂ăN�C�Y���J�n���ă^�C�}�[���J�n������
        public void StartTheQuiz()
        {
            //�����Z���𖄂߂Ă�
            //�ǉ�����2�̗����𐶐����āA�l��ϐ�'addend1'��'addend2'�ɕۑ������
            //Random �I�u�W�F�N�g�� Next() ���\�b�h���g�p����ꍇ�A51 �����A�܂� 0 ���� 50 �̗������擾����
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //�����_���ɐ������ꂽ�Q�̐��l��ϊ�
            //���x���R���g���[�����ɕ\���ł���悤�ɕ�����ɕϊ�
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //'sum'��NumericUpDown�R���g���[���̖��O
            //���̃X�e�b�v�͂��̒l���[���ł��邱�Ƃ��m�F���A�l��ǉ�����
            sum.Value = 0;

            //�����Z�̖��𖄂߂Ă�
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //�|���Z�̖��𖄂߂Ă�
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //����Z�̖��𖄂߂Ă�
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            //�^�C�}�[�J�n����
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        //�񓚂��`�F�b�N���ă��[�U�[�����ׂĐ������������ǂ������m�F
        //<returns>�������������ꍇ�� true�A�����łȂ��ꍇ�� false�B</returns>
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
                //CheckTheAnswer()��true��Ԃ����ꍇ�A���[�U�[�͐������Ă��邩��
                //�^�C�}�[���~�߂ă��b�Z�[�W�{�b�N�X��\������
                timer1.Stop();
                MessageBox.Show("�S�␳���I", "���߂łƂ��I");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //CheckTheAnswer��false��Ԃ����ꍇ�̓J�E���g�_�E���𑱍s
                //timeLeftLbel�ň�b���炵����Ԃ̐V�����c�莞�Ԃ��X�V���܂�
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";

                if(timeLeft == 5)
                {
                    timeLabel.ForeColor = Color.Red;
                }

            }
            else
            {
                //���[�U�[�̎��Ԃ��Ȃ��Ȃ����ꍇ�́A�^�C�}�[���~��
                //���b�Z�[�W�{�b�N�X�ɓ������L�����ĕ\�������
                timer1.Stop();
                timeLabel.Text = "Time's Up !";
                MessageBox.Show("���Ԑ؂�I", "�c�O�c�I");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }

        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //NumericUpDown �R���g���[���œ����S�̂�I��
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
