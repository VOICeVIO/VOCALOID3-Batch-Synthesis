using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApp1
{
    class Controller
    {
        public Process vProc;
        public string vsqxDir = "";
        public string outputDir = "";
        public Controller()
        {
            this.updateVocaloidProc();
        }
        public Controller(string dir, string outputDir)
        {
            this.vsqxDir = dir;
            this.outputDir = outputDir;
            this.updateVocaloidProc();
        }
        /// <summary>
        /// 更新VOCALOID所在进程号
        /// </summary>
        public void updateVocaloidProc()
        {
            Process[] procList;
            procList = Process.GetProcessesByName("VOCALOID3");
            if (procList.Length > 0)
            {
                vProc = procList[0];
            }
        }
        /// <summary>
        /// 激活窗口
        /// </summary>
        public void focusWindow()
        {
            Utils.Focus(vProc.MainWindowHandle);
        }
        /// <summary>
        /// 关闭所有警告窗口
        /// </summary>
        public void clearWarning()
        {
            bool isFound = false;
            do
            {
                Thread.Sleep(500);
                isFound = false;
                if(Utils.FindWindow(null, "VOCALOID Editor") != IntPtr.Zero || Utils.FindWindow(null, "VOCALOID3 Editor") != IntPtr.Zero)
                {
                    isFound = true;
                    KeyBoard.Send(new byte[] { KeyBoard.keyEnter });
                }
            } while (isFound);
        }
        public void waitUntillSynthesisFinish()
        {
            bool isFound = false;
            do
            {
                Thread.Sleep(1000);
                isFound = false;
                if (Utils.FindWindow(null, "VOCALOID合成") != IntPtr.Zero)
                {
                    isFound = true;
                }
            } while (isFound);
        }
        /// <summary>
        /// 合成单个音频
        /// </summary>
        /// <param name="vsqxFile"></param>
        public void synthesisOne(string vsqxFile, string outputWav)
        {
            if (File.Exists(outputWav))
            {
                File.Delete(outputWav);
            }
            this.focusWindow();
            //发送打开文件快捷键
            KeyBoard.Send(new byte[] { KeyBoard.keyControl, KeyBoard.keyO });
            this.clearWarning();
            ClipBoard.Set(vsqxFile);
            Thread.Sleep(1000);
            KeyBoard.Send(new byte[] { KeyBoard.keyControl, KeyBoard.keyV });
            Thread.Sleep(100);
            KeyBoard.Send(new byte[] { KeyBoard.keyEnter });
            Thread.Sleep(500);
            this.clearWarning();
            Thread.Sleep(500);
            //开始合成
            KeyBoard.Send(new byte[] { KeyBoard.keyAlt, KeyBoard.keyF });
            Thread.Sleep(100);
            KeyBoard.Send(new byte[] { KeyBoard.keyE });
            Thread.Sleep(100);
            KeyBoard.Send(new byte[] { KeyBoard.keyW });
            /* 只合成单音轨
            Thread.Sleep(100);
            KeyBoard.Send(new byte[] { KeyBoard.keyAlt, KeyBoard.keyU });*/
            Thread.Sleep(100);
            KeyBoard.Send(new byte[] { KeyBoard.keyEnter });
            Thread.Sleep(100);
            this.clearWarning();
            ClipBoard.Set(outputWav);
            KeyBoard.Send(new byte[] { KeyBoard.keyControl, KeyBoard.keyV });
            Thread.Sleep(100);
            KeyBoard.Send(new byte[] { KeyBoard.keyEnter });
            //阻塞，直到合成结束
            this.waitUntillSynthesisFinish();
        }
        public void run()
        {
            string[] files = Directory.GetFiles(this.vsqxDir, "*.vsqx");
            foreach(string file in files)
            {
                string output = file.Substring(file.LastIndexOf("\\") + 1).Replace(".vsqx", "");
                Console.WriteLine("Synthesizing {0}....", output);
                this.synthesisOne(file, this.outputDir + "\\" + output + ".wav");
            }
            
        }
    }
}
