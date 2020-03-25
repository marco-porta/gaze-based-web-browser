using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectEyeBrowser
{
    public partial class Keyboard : UserControl
    {

        private int focusPosition;
        private int shiftStatus;
        private bool urlChanging;
        private bool favoriteSaving;
        private bool writing;
        private Gecko.GeckoWebBrowser browser;
        private Color disabledColor;
        private Color enabledColor = Color.DeepSkyBlue;
        private FavoritesPanel favoritesPanel;

        public Keyboard()
        {
            InitializeComponent();
            focusPosition = 0;
            shiftStatus = 0;
            urlChanging = false;
            favoriteSaving = false;
            writing = true;
            disabledColor = shiftButton.BackColor;
        }

        private void ChangeCase(object sender, EventArgs e)
        {
            if (shiftStatus != 0)
            {
                this.zButton.Text = "Z";
                this.xButton.Text = "X";
                this.cButton.Text = "C";
                this.vButton.Text = "V";
                this.bButton.Text = "B";
                this.nButton.Text = "N";
                this.mButton.Text = "M";
                this.aButton.Text = "A";
                this.sButton.Text = "S";
                this.dButton.Text = "D";
                this.fButton.Text = "F";
                this.gButton.Text = "G";
                this.hButton.Text = "H";
                this.jButton.Text = "J";
                this.kButton.Text = "K";
                this.lButton.Text = "L";
                this.qButton.Text = "Q";
                this.wButton.Text = "W";
                this.eButton.Text = "E";
                this.rButton.Text = "R";
                this.tButton.Text = "T";
                this.yButton.Text = "Y";
                this.uButton.Text = "U";
                this.iButton.Text = "I";
                this.oButton.Text = "O";
                this.pButton.Text = "P";
                this.oneButton.Text = "!";
                this.twoButton.Text = "\"";
                this.threeButton.Text = "£";
                this.fourButton.Text = "$";
                this.fiveButton.Text = "%";
                this.sixButton.Text = "&&";
                this.sevenButton.Text = "/";
                this.eightButton.Text = "(";
                this.nineButton.Text = ")";
                this.zeroButton.Text = "=";
                this.commaButton.Text = ";";
                this.dotButton.Text = ":";
                this.barButton.Text = "_";
                this.òButton.Text = "ç";
                this.àButton.Text = "°";
                this.ùButton.Text = "§";
                this.lowerButton.Text = ">";
                this.èButton.Text = "é";
                this.plusButton.Text = "*";
                this.apostropheButton.Text = "?";
                this.ìButton.Text = "€";
                this.backslashButton.Text = "|";
            }
            else
            {
                this.zButton.Text = "z";
                this.xButton.Text = "x";
                this.cButton.Text = "c";
                this.vButton.Text = "v";
                this.bButton.Text = "b";
                this.nButton.Text = "n";
                this.mButton.Text = "m";
                this.aButton.Text = "a";
                this.sButton.Text = "s";
                this.dButton.Text = "d";
                this.fButton.Text = "f";
                this.gButton.Text = "g";
                this.hButton.Text = "h";
                this.jButton.Text = "j";
                this.kButton.Text = "k";
                this.lButton.Text = "l";
                this.qButton.Text = "q";
                this.wButton.Text = "w";
                this.eButton.Text = "e";
                this.rButton.Text = "r";
                this.tButton.Text = "t";
                this.yButton.Text = "y";
                this.uButton.Text = "u";
                this.iButton.Text = "i";
                this.oButton.Text = "o";
                this.pButton.Text = "p";
                this.oneButton.Text = "1";
                this.twoButton.Text = "2";
                this.threeButton.Text = "3";
                this.fourButton.Text = "4";
                this.fiveButton.Text = "5";
                this.sixButton.Text = "6";
                this.sevenButton.Text = "7";
                this.eightButton.Text = "8";
                this.nineButton.Text = "9";
                this.zeroButton.Text = "0";
                this.commaButton.Text = ",";
                this.dotButton.Text = ".";
                this.barButton.Text = "-";
                this.òButton.Text = "ò";
                this.àButton.Text = "à";
                this.ùButton.Text = "ù";
                this.lowerButton.Text = "<";
                this.èButton.Text = "è";
                this.plusButton.Text = "+";
                this.apostropheButton.Text = "'";
                this.ìButton.Text = "ì";
                this.backslashButton.Text = "\\";
            }

            if (shiftStatus == 0)
            {
                shiftButton.BackColor = disabledColor;
                capsLockButton.BackColor = disabledColor;
            }
            else if (shiftStatus == 1)
            {
                shiftButton.BackColor = enabledColor;
                capsLockButton.BackColor = disabledColor;
            }
            else if (shiftStatus == 2)
            {
                shiftButton.BackColor = disabledColor;
                capsLockButton.BackColor = enabledColor;
            }

            if (this.Visible)
            {
                inputBox.Focus();
                inputBox.SelectionStart = focusPosition;
                inputBox.SelectionLength = 0;
            }
        }

        private void ActivateShift(object sender, EventArgs e)
        {
            if (shiftStatus == 1)
            {
                shiftStatus = 0;
                ChangeCase(null, null);
            }
            else
            {
                shiftStatus = 1;
                ChangeCase(null, null);
            }
        }

        private void ActivateCapsLock(object sender, EventArgs e)
        {
            if (shiftStatus == 2)
            {
                shiftStatus = 0;
                ChangeCase(null, null);
            }
            else
            {
                shiftStatus = 2;
                ChangeCase(null, null);
            }
        }

        private void HideTextBoxContent(object sender, EventArgs e)
        {
            if (!inputBox.UseSystemPasswordChar)
            {
                inputBox.UseSystemPasswordChar = true;
                hideButton.BackColor = enabledColor;
            }
            else
            {
                inputBox.UseSystemPasswordChar = false;
                hideButton.BackColor = disabledColor;
            }
            inputBox.Focus();
            inputBox.SelectionStart = focusPosition;
            inputBox.SelectionLength = 0;
        }

        private void AddCharacter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text.Equals("&&"))
            {
                inputBox.Text = inputBox.Text.Insert(focusPosition, button.Text.Remove(1));
            }
            else
            {
                inputBox.Text = inputBox.Text.Insert(focusPosition, button.Text);
            }
            focusPosition++;
            if (shiftStatus == 1)
            {
                shiftStatus = 0;
                ChangeCase(null, null);
            }
            inputBox.Focus();
            inputBox.SelectionStart = focusPosition;
            inputBox.SelectionLength = 0;
        }

        private void PressDelete(object sender, EventArgs e)
        {
            if (focusPosition != inputBox.Text.Length)
            {
                inputBox.Text = inputBox.Text.Remove(focusPosition, 1);
            }
            inputBox.Focus();
            inputBox.SelectionStart = focusPosition;
            inputBox.SelectionLength = 0;
        }

        private void PressBackspace(object sender, EventArgs e)
        {
            if (focusPosition != 0)
            {
                inputBox.Text = inputBox.Text.Remove(focusPosition - 1, 1);
                focusPosition--;
            }
            inputBox.Focus();
            inputBox.SelectionStart = focusPosition;
            inputBox.SelectionLength = 0;
        }

        private void AcceptInput(object sender, EventArgs e)
        {
            writing = false;
            if (favoriteSaving)
            {
                favoritesPanel.WriteFavoriteName(inputBox.Text);
                favoriteSaving = false;
                CloseKeyboard(null, null);
            }
            else
            {
                if (urlChanging)
                {
                    browser.Navigate(inputBox.Text);
                }
                else
                {
                    browser.Focus();
                    for (int i = 0; i < 50; i++)
                    {
                        SendKeys.Send("{BACKSPACE}");
                        SendKeys.Send("{DELETE}");
                    }
                    browser.Focus();
                    SendKeys.Send(inputBox.Text.Replace("+", "{+}").Replace("^", "{^}").Replace("%", "{%}").Replace("(", "{(}").Replace(")", "{)}").Replace("[", "{[}").Replace("]", "{]}"));                     
                }
                CloseKeyboard(null, null);
            }
            writing = true;
        }

        private void CloseKeyboard(object sender, EventArgs e)
        {
            this.Visible = false;
            if (favoriteSaving)
            {
                favoritesPanel.WriteFavoriteName(String.Empty);
            }
            favoriteSaving = false;
            inputBox.Clear();
            focusPosition = 0;
            shiftStatus = 0;
            ChangeCase(null, null);
            if (inputBox.UseSystemPasswordChar)
            {
                HideTextBoxContent(null, null);
            }
        }

        private void UpdatePosition(object sender, MouseEventArgs e)
        {
            focusPosition = inputBox.SelectionStart;
            inputBox.SelectionStart = focusPosition;
            inputBox.SelectionLength = 0;
        }

        public void OpenKeyboardForFavorites()
        {
            favoriteSaving = true;
            this.Visible = true;
            this.BringToFront();
        }

        public bool Navigation { set { urlChanging = value; } }
        public bool Writing { get { return writing; } }
        public Gecko.GeckoWebBrowser Browser { set { browser = value; } }
        public FavoritesPanel Favorites { set { favoritesPanel = value; } }

    }
}