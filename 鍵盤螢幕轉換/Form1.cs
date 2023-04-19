using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basic;
using System.Runtime.InteropServices;
namespace 鍵盤螢幕轉換
{
    public partial class Form1 : Form
    {
        enum keys_code : byte
        {
            D1 = 49,
            D2 = 50,
            D3 = 51,
            D4 = 52,
            D5 = 53,
            D6 = 54,
            D7 = 55,
            D8 = 56,
            D9 = 57,
            D0 = 48,

            Numbpad0 = 96,
            Numbpad1 = 97,
            Numbpad2 = 98,
            Numbpad3 = 99,
            Numbpad4 = 100,
            Numbpad5 = 101,
            Numbpad6 = 102,
            Numbpad7 = 103,
            Numbpad8 = 104,
            Numbpad9 = 105,

            ALT = 18,
        }
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        const uint KEYEVENTF_KEYUP = 0x0002;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMyConfig();
            checkBox_設定模式.CheckStateChanged += CheckBox_設定模式_CheckStateChanged;
            textBox_清除號碼.KeyDown += TextBox_清除號碼_KeyDown;
            textBox_清除號碼.TextChanged += TextBox_清除號碼_TextChanged;

            textBox_加1.KeyDown += TextBox_加1_KeyDown;
            textBox_加1.TextChanged += TextBox_加1_TextChanged;
            textBox_加10.KeyDown += TextBox_加10_KeyDown;
            textBox_加10.TextChanged += TextBox_加10_TextChanged;
            textBox_加4.KeyDown += TextBox_加4_KeyDown;
            textBox_加4.TextChanged += TextBox_加4_TextChanged;

            textBox_Num0.KeyDown += TextBox_Num0_KeyDown;
            textBox_Num0.TextChanged += TextBox_Num0_TextChanged;
            textBox_Num1.KeyDown += TextBox_Num1_KeyDown;
            textBox_Num1.TextChanged += TextBox_Num1_TextChanged;
            textBox_Num2.KeyDown += TextBox_Num2_KeyDown;
            textBox_Num2.TextChanged += TextBox_Num2_TextChanged;
            textBox_Num3.KeyDown += TextBox_Num3_KeyDown;
            textBox_Num3.TextChanged += TextBox_Num3_TextChanged;
            textBox_Num4.KeyDown += TextBox_Num4_KeyDown;
            textBox_Num4.TextChanged += TextBox_Num4_TextChanged;
            textBox_Num5.KeyDown += TextBox_Num5_KeyDown;
            textBox_Num5.TextChanged += TextBox_Num5_TextChanged;
            textBox_Num6.KeyDown += TextBox_Num6_KeyDown;
            textBox_Num6.TextChanged += TextBox_Num6_TextChanged;
            textBox_Num7.KeyDown += TextBox_Num7_KeyDown;
            textBox_Num7.TextChanged += TextBox_Num7_TextChanged;
            textBox_Num8.KeyDown += TextBox_Num8_KeyDown;
            textBox_Num8.TextChanged += TextBox_Num8_TextChanged;
            textBox_Num9.KeyDown += TextBox_Num9_KeyDown;
            textBox_Num9.TextChanged += TextBox_Num9_TextChanged;


            textBox_送出.KeyDown += TextBox_送出_KeyDown;
            textBox_送出.TextChanged += TextBox_送出_TextChanged;
            Basic.Keyboard.Hook.Hook_Start();
            Basic.Keyboard.Hook.KeyDown += Hook_KeyDown;

        }

    

        private void CheckBox_設定模式_CheckStateChanged(object sender, EventArgs e)
        {
            textBox_清除號碼.Enabled = checkBox_設定模式.Checked;
            textBox_加1.Enabled = checkBox_設定模式.Checked;
            textBox_加10.Enabled = checkBox_設定模式.Checked;
            textBox_加4.Enabled = checkBox_設定模式.Checked;
            textBox_Num0.Enabled = checkBox_設定模式.Checked;
            textBox_Num1.Enabled = checkBox_設定模式.Checked;
            textBox_Num2.Enabled = checkBox_設定模式.Checked;
            textBox_Num3.Enabled = checkBox_設定模式.Checked;
            textBox_Num4.Enabled = checkBox_設定模式.Checked;
            textBox_Num5.Enabled = checkBox_設定模式.Checked;
            textBox_Num6.Enabled = checkBox_設定模式.Checked;
            textBox_Num7.Enabled = checkBox_設定模式.Checked;
            textBox_Num8.Enabled = checkBox_設定模式.Checked;
            textBox_Num9.Enabled = checkBox_設定模式.Checked;
            textBox_送出.Enabled = checkBox_設定模式.Checked;

        }

        private void Hook_KeyDown(int nCode, IntPtr wParam, Keys Keys)
        {
            if (checkBox_設定模式.Checked) return;
            int int_wParam = wParam.ToInt32();
            string keys_str = Keys.ToString();
            if (keys_str == "RMenu") return;
            if(textBox_清除號碼.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.D5, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.D5, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_加1.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.D0, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.D0, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_加10.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.D3, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.D3, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_加4.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.D2, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.D2, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_Num0.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.Numbpad0, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.Numbpad0, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_Num1.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.Numbpad1, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.Numbpad1, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_Num2.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.Numbpad2, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.Numbpad2, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_Num3.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.Numbpad3, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.Numbpad3, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_Num4.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.Numbpad4, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.Numbpad4, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_Num5.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.Numbpad5, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.Numbpad5, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_Num6.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.Numbpad6, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.Numbpad6, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_Num7.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.Numbpad7, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.Numbpad7, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_Num8.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.Numbpad8, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.Numbpad8, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
            if (textBox_Num9.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.Numbpad9, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.Numbpad9, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }

            if (textBox_送出.Text == Keys.ToString())
            {

                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.D4, 0, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event((byte)keys_code.ALT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                keybd_event((byte)keys_code.D4, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }

        }

        private void TextBox_清除號碼_TextChanged(object sender, EventArgs e)
        {
            textBox_清除號碼.Text = myConfigClass.清除號碼;
        }
        private void TextBox_清除號碼_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.清除號碼 = e.KeyCode.ToString();
            textBox_清除號碼.Text = myConfigClass.清除號碼;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_加1_TextChanged(object sender, EventArgs e)
        {
            textBox_加1.Text = myConfigClass.加1;
        }
        private void TextBox_加1_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.加1 = e.KeyCode.ToString();
            textBox_加1.Text = myConfigClass.加1;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_加10_TextChanged(object sender, EventArgs e)
        {
            textBox_加10.Text = myConfigClass.加10;
        }
        private void TextBox_加10_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.加10 = e.KeyCode.ToString();
            textBox_加10.Text = myConfigClass.加10;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_加4_TextChanged(object sender, EventArgs e)
        {
            textBox_加4.Text = myConfigClass.加4;
        }
        private void TextBox_加4_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.加4 = e.KeyCode.ToString();
            textBox_加4.Text = myConfigClass.加4;
            SaveMyConfig();
            e.Handled = false;
        }

        private void TextBox_Num0_TextChanged(object sender, EventArgs e)
        {
            textBox_Num0.Text = myConfigClass.Num0;
        }
        private void TextBox_Num0_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.Num0 = e.KeyCode.ToString();
            textBox_Num0.Text = myConfigClass.Num0;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_Num1_TextChanged(object sender, EventArgs e)
        {
            textBox_Num1.Text = myConfigClass.Num1;
        }
        private void TextBox_Num1_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.Num1 = e.KeyCode.ToString();
            textBox_Num1.Text = myConfigClass.Num1;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_Num2_TextChanged(object sender, EventArgs e)
        {
            textBox_Num2.Text = myConfigClass.Num2;
        }
        private void TextBox_Num2_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.Num2 = e.KeyCode.ToString();
            textBox_Num2.Text = myConfigClass.Num2;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_Num3_TextChanged(object sender, EventArgs e)
        {
            textBox_Num3.Text = myConfigClass.Num3;
        }
        private void TextBox_Num3_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.Num3 = e.KeyCode.ToString();
            textBox_Num3.Text = myConfigClass.Num3;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_Num4_TextChanged(object sender, EventArgs e)
        {
            textBox_Num4.Text = myConfigClass.Num4;
        }
        private void TextBox_Num4_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.Num4 = e.KeyCode.ToString();
            textBox_Num4.Text = myConfigClass.Num4;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_Num5_TextChanged(object sender, EventArgs e)
        {
            textBox_Num5.Text = myConfigClass.Num5;
        }
        private void TextBox_Num5_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.Num5 = e.KeyCode.ToString();
            textBox_Num5.Text = myConfigClass.Num5;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_Num6_TextChanged(object sender, EventArgs e)
        {
            textBox_Num6.Text = myConfigClass.Num6;
        }
        private void TextBox_Num6_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.Num6 = e.KeyCode.ToString();
            textBox_Num6.Text = myConfigClass.Num6;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_Num7_TextChanged(object sender, EventArgs e)
        {
            textBox_Num7.Text = myConfigClass.Num7;
        }
        private void TextBox_Num7_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.Num7 = e.KeyCode.ToString();
            textBox_Num7.Text = myConfigClass.Num7;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_Num8_TextChanged(object sender, EventArgs e)
        {
            textBox_Num8.Text = myConfigClass.Num8;
        }
        private void TextBox_Num8_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.Num8 = e.KeyCode.ToString();
            textBox_Num8.Text = myConfigClass.Num8;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_Num9_TextChanged(object sender, EventArgs e)
        {
            textBox_Num9.Text = myConfigClass.Num9;
        }
        private void TextBox_Num9_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.Num9 = e.KeyCode.ToString();
            textBox_Num9.Text = myConfigClass.Num9;
            SaveMyConfig();
            e.Handled = false;
        }
        private void TextBox_送出_TextChanged(object sender, EventArgs e)
        {
            textBox_送出.Text = myConfigClass.送出;
        }
        private void TextBox_送出_KeyDown(object sender, KeyEventArgs e)
        {
            myConfigClass.送出 = e.KeyCode.ToString();
            textBox_送出.Text = myConfigClass.送出;
            SaveMyConfig();
            e.Handled = false;
        }
        #region MyConfigClass
        private const string MyConfigFileName = "MyConfig.txt";
        public MyConfigClass myConfigClass = new MyConfigClass();
        public class MyConfigClass
        {

            private string _清除號碼 = "";
            private string _加1 = "";
            private string _加10 = "";
            private string _加4 = "";
            private string _送出 = "";
            private string num0 = "";
            private string num1 = "";
            private string num2 = "";
            private string num3 = "";
            private string num4 = "";
            private string num5 = "";
            private string num6 = "";
            private string num7 = "";
            private string num8 = "";
            private string num9 = "";


            public string 清除號碼 { get => _清除號碼; set => _清除號碼 = value; }
            public string 加1 { get => _加1; set => _加1 = value; }
            public string 加10 { get => _加10; set => _加10 = value; }
            public string 加4 { get => _加4; set => _加4 = value; }
            public string Num0 { get => num0; set => num0 = value; }
            public string Num1 { get => num1; set => num1 = value; }
            public string Num2 { get => num2; set => num2 = value; }
            public string Num3 { get => num3; set => num3 = value; }
            public string Num4 { get => num4; set => num4 = value; }
            public string Num5 { get => num5; set => num5 = value; }
            public string Num6 { get => num6; set => num6 = value; }
            public string Num7 { get => num7; set => num7 = value; }
            public string Num8 { get => num8; set => num8 = value; }
            public string Num9 { get => num9; set => num9 = value; }
            public string 送出 { get => _送出; set => _送出 = value; }
        }
        private void LoadMyConfig()
        {
            string jsonstr = MyFileStream.LoadFileAllText($".//{MyConfigFileName}");
            if (jsonstr.StringIsEmpty())
            {
                jsonstr = Basic.Net.JsonSerializationt<MyConfigClass>(new MyConfigClass(), true);
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($".//{MyConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{MyConfigFileName}檔案失敗!");
                }
                MyMessageBox.ShowDialog($"未建立參數文件!請至子目錄設定{MyConfigFileName}");
                Application.Exit();
            }
            else
            {
                myConfigClass = Basic.Net.JsonDeserializet<MyConfigClass>(jsonstr);

                jsonstr = Basic.Net.JsonSerializationt<MyConfigClass>(myConfigClass, true);
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($".//{MyConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{MyConfigFileName}檔案失敗!");
                }

            }

            textBox_清除號碼.Text = myConfigClass.清除號碼;
            textBox_加1.Text = myConfigClass.加1;
            textBox_加10.Text = myConfigClass.加10;
            textBox_加4.Text = myConfigClass.加4;
            textBox_Num0.Text = myConfigClass.Num0;
            textBox_Num1.Text = myConfigClass.Num1;
            textBox_Num2.Text = myConfigClass.Num2;
            textBox_Num3.Text = myConfigClass.Num3;
            textBox_Num4.Text = myConfigClass.Num4;
            textBox_Num5.Text = myConfigClass.Num5;
            textBox_Num6.Text = myConfigClass.Num6;
            textBox_Num7.Text = myConfigClass.Num7;
            textBox_Num8.Text = myConfigClass.Num8;
            textBox_Num9.Text = myConfigClass.Num9;
            textBox_送出.Text = myConfigClass.送出;
        }
        private void SaveMyConfig()
        {
            string jsonstr = Basic.Net.JsonSerializationt<MyConfigClass>(myConfigClass, true);


            List<string> list_jsonstring = new List<string>();
            list_jsonstring.Add(jsonstr);
            if (!MyFileStream.SaveFile($".//{MyConfigFileName}", list_jsonstring))
            {
                MyMessageBox.ShowDialog($"建立{MyConfigFileName}檔案失敗!");
            }
        }
        #endregion
    }
}

