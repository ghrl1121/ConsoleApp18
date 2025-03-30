using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Diagnostics;

namespace ConsoleApp18
{
    internal class Program
    {
        //첫 실행시
        static void Main(string[] args)
        {
            //파일이 있는경우
            if (File.Exists("exetr.lal"))
            {
                //파일 읽기
                StreamReader su = new StreamReader("exetr.lal");
                string day = su.ReadLine();
                //현제 날짜
                DateTime bus = DateTime.Now;
                //비교하기 
                int yue = bus.Day;
                int stv = int.Parse(day);
                su.Close();
                if (yue == stv)
                {
                    //같으면 디스크검사, 운영체제확인
                    //날짜 연장
                    
                    DateTime nowDate = DateTime.Now;
                    DateTime oneAfterYearDate = nowDate.AddMonths(3);
                    int ue = oneAfterYearDate.Day;
                    string use = ue.ToString();
                    string[] lines = { use };
                    File.WriteAllLines("exetr.lal", lines);
                    //수정
                    string[] lines2 = {"@echo off","title 확인중...", @"cd C:\Windows\System32\","Dism.exe /Online /Cleanup-image /Restorehealth", "pause", "sfc /scannow", "pause", "cls","title 확인중...",@"cd C:\Windows\System32\","chkdsk.exe /f /r /x" , "pause" };
                    File.WriteAllLines("comm.bat", lines2);  
                    Process process =new Process();
                    process.StartInfo.FileName = "comm.bat";
                    process.Start();
                    process.WaitForExit();
                    File.Delete("comm.bat");
                }
                else
                {
                    //다음 실행
                    MessageBox.Show("다음에 실행해 주세요!");
                }
            }
            else
            {
                //초기 실행
                //날짜 넣고
                DateTime nowDate = DateTime.Now;
                DateTime oneAfterYearDate = nowDate.AddMonths(3);
                int ue = oneAfterYearDate.Day;
                string use = ue.ToString();
                string[] lines = { use };
                File.WriteAllLines("exetr.lal", lines);
                //운영체제확인
                string[] lines2 = { "@echo off", "title 확인중...", @"cd C:\Windows\System32","Dism.exe /Online /Cleanup-image /Restorehealth", @"cd C:\Windows\System32", "sfc /scannow", "cls", "title 확인중...", @"cd C:\Windows\System32\","chkdsk.exe /f /r /x" };
                File.WriteAllLines("comm.bat", lines2);
                Process process = new Process();
                process.StartInfo.FileName = "comm.bat";
                process.Start();
                process.WaitForExit();
                File.Delete("comm.bat");
            }

        }
    }
}
