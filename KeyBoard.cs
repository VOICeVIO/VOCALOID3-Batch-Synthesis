using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ConsoleApp1
{
    class KeyBoard
    {
        public const byte keyLButton = 0x1;    // 鼠标左键
        public const byte keyRButton = 0x2;    // 鼠标右键
        public const byte keyCancel = 0x3;     // CANCEL 键
        public const byte keyMButton = 0x4;    // 鼠标中键
        public const byte keyBack = 0x8;       // BACKSPACE 键
        public const byte keyTab = 0x9;        // TAB 键
        public const byte keyClear = 0xC;      // CLEAR 键
        public const byte keyEnter = 0xD;     // ENTER 键
        public const byte keyShift = 0x10;     // SHIFT 键
        public const byte keyControl = 0x11;   // CTRL 键
        public const byte keyAlt = 18;         // Alt 键  (键码18)
        public const byte keyMenu = 0x12;      // MENU 键
        public const byte keyPause = 0x13;     // PAUSE 键
        public const byte keyCapital = 0x14;   // CAPS LOCK 键
        public const byte keyEscape = 0x1B;    // ESC 键
        public const byte keySpace = 0x20;     // SPACEBAR 键
        public const byte keyPageUp = 0x21;    // PAGE UP 键
        public const byte keyEnd = 0x23;       // End 键
        public const byte keyHome = 0x24;      // HOME 键
        public const byte keyLeft = 0x25;      // LEFT ARROW 键
        public const byte keyUp = 0x26;        // UP ARROW 键
        public const byte keyRight = 0x27;     // RIGHT ARROW 键
        public const byte keyDown = 0x28;      // DOWN ARROW 键
        public const byte keySelect = 0x29;    // Select 键
        public const byte keyPrint = 0x2A;     // PRINT SCREEN 键
        public const byte keyExecute = 0x2B;   // EXECUTE 键
        public const byte keySnapshot = 0x2C;  // SNAPSHOT 键
        public const byte keyDelete = 0x2E;    // Delete 键
        public const byte keyHelp = 0x2F;      // HELP 键
        public const byte keyNumlock = 0x90;   // NUM LOCK 键

        //常用键 字母键A到Z
        public const byte keyA = 65;
        public const byte keyB = 66;
        public const byte keyC = 67;
        public const byte keyD = 68;
        public const byte keyE = 69;
        public const byte keyF = 70;
        public const byte keyG = 71;
        public const byte keyH = 72;
        public const byte keyI = 73;
        public const byte keyJ = 74;
        public const byte keyK = 75;
        public const byte keyL = 76;
        public const byte keyM = 77;
        public const byte keyN = 78;
        public const byte keyO = 79;
        public const byte keyP = 80;
        public const byte keyQ = 81;
        public const byte keyR = 82;
        public const byte keyS = 83;
        public const byte keyT = 84;
        public const byte keyU = 85;
        public const byte keyV = 86;
        public const byte keyW = 87;
        public const byte keyX = 88;
        public const byte keyY = 89;
        public const byte keyZ = 90;

        //数字键盘0到9
        public const byte key0 = 48;    // 0 键
        public const byte key1 = 49;    // 1 键
        public const byte key2 = 50;    // 2 键
        public const byte key3 = 51;    // 3 键
        public const byte key4 = 52;    // 4 键
        public const byte key5 = 53;    // 5 键
        public const byte key6 = 54;    // 6 键
        public const byte key7 = 55;    // 7 键
        public const byte key8 = 56;    // 8 键
        public const byte key9 = 57;    // 9 键


        public const byte keyNumpad0 = 0x60;    //0 键
        public const byte keyNumpad1 = 0x61;    //1 键
        public const byte keyNumpad2 = 0x62;    //2 键
        public const byte keyNumpad3 = 0x63;    //3 键
        public const byte keyNumpad4 = 0x64;    //4 键
        public const byte keyNumpad5 = 0x65;    //5 键
        public const byte keyNumpad6 = 0x66;    //6 键
        public const byte keyNumpad7 = 0x67;    //7 键
        public const byte keyNumpad8 = 0x68;    //8 键
        public const byte keyNumpad9 = 0x69;    //9 键
        public const byte keyMultiply = 0x6A;   // MULTIPLICATIONSIGN(*)键
        public const byte keyAdd = 0x6B;        // PLUS SIGN(+) 键
        public const byte keySeparator = 0x6C;  // ENTER 键
        public const byte keySubtract = 0x6D;   // MINUS SIGN(-) 键
        public const byte keyDecimal = 0x6E;    // DECIMAL POINT(.) 键
        public const byte keyDivide = 0x6F;     // DIVISION SIGN(/) 键


        //F1到F12按键
        public const byte keyF1 = 0x70;   //F1 键
        public const byte keyF2 = 0x71;   //F2 键
        public const byte keyF3 = 0x72;   //F3 键
        public const byte keyF4 = 0x73;   //F4 键
        public const byte keyF5 = 0x74;   //F5 键
        public const byte keyF6 = 0x75;   //F6 键
        public const byte keyF7 = 0x76;   //F7 键
        public const byte keyF8 = 0x77;   //F8 键
        public const byte keyF9 = 0x78;   //F9 键
        public const byte keyF10 = 0x79;  //F10 键
        public const byte keyF11 = 0x7A;  //F11 键
        public const byte keyF12 = 0x7B;  //F12 键

        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keyBoardCall(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public static void Send(byte[] keys)
        {
            //按下
            foreach(byte key in keys)
            {
                keyBoardCall(key, 0, 0, 0);
            }
            //松开
            foreach (byte key in keys)
            {
                keyBoardCall(key, 0, 2, 0);
            }
        }
    }
}
