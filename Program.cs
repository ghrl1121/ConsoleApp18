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
                su.Close();
                //현제 날짜
                DateTime bus = DateTime.Today;
                //비교하기 
                int yue = bus.Year; //현재 날짜
                int stv = int.Parse(day);//들고온 날짜
                if ( yue  >= stv ) //현재 날짜 >= 비교날짜
                {
                    //비교날짜가 크거나 같으면 디스크검사, 운영체제확인, 복구
                    //날짜 연장
                    DateTime nowDate = DateTime.Today;
                    nowDate = nowDate.AddMonths(30);
                    object ue = nowDate.Year;
                    string[] lines = { ue.ToString() };
                    File.WriteAllLines("exetr.lal", lines);
                    //운영체제확인
                    var processStartInfo = new ProcessStartInfo(@"C:\Windows\system32\DISM.exe", "/Online /Cleanup-image /Restorehealth");
                    processStartInfo.UseShellExecute = false;
                    Process process = Process.Start(processStartInfo);
                    process.WaitForExit();
                    process.Close();
                    //복구
                    var nepc = new ProcessStartInfo(@"C:\Windows\system32\Sfc.exe", "/SCANNOW");
                    nepc.UseShellExecute = false;
                    Process process1 = Process.Start(nepc);
                    process1.WaitForExit();  
                    process1.Close();                    
                    //디스크 검사
                    var vet = new ProcessStartInfo(@"C:\Windows\system32\chkdsk.exe", "C: /f /r /x");
                    vet.UseShellExecute = false;
                    Process process2 = Process.Start(vet);
                    process2.WaitForExit();                    
                    process2.Close();
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
                DateTime nowDate = DateTime.Today;
                nowDate = nowDate.AddMonths(30);
                object ue = nowDate.Year;
                string[] lines = { ue.ToString() };
                File.WriteAllLines("exetr.lal", lines);
                //운영체제확인
                var processStartInfo = new ProcessStartInfo(@"C:\Windows\system32\DISM.exe", "/Online /Cleanup-image /Restorehealth");
                processStartInfo.UseShellExecute = false;
                Process process = Process.Start(processStartInfo);
                process.WaitForExit();                
                process.Close();
                //복구
                var nepc = new ProcessStartInfo(@"C:\Windows\system32\Sfc.exe", "/SCANNOW");
                nepc.UseShellExecute = false;
                Process process1 = Process.Start(nepc);
                process1.WaitForExit();                
                process1.Close();
                //디스크 검사
                var vet = new ProcessStartInfo(@"C:\Windows\system32\chkdsk.exe", "C: /f /r /x");
                vet.UseShellExecute = false;
                Process process2 = Process.Start(vet);
                process2.WaitForExit();                
                process2.Close();
            }

        }
    }
}
