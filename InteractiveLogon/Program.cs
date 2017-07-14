using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
namespace InteractiveLogon
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process = 1st take the values, 2nd export the original reg key (backup) 3rd, feed caption, then text, 4th result.
            ConsoleSettings(ConsoleColor.Yellow );
            Console.WriteLine("Customised Interactive logon.- by alshell7");
            Console.WriteLine("\nMessage title for users attempting to log on :");
            string caption = Console.ReadLine();
            Console.WriteLine("\nMessage text for users attempting to log on :");            
            string text = Console.ReadLine();
                       
            string key = "HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\ " ;
            Console.WriteLine("\n\nQuering key " + key +" ...");
            Console.WriteLine("\nMaking key backup ...");
            Process.Start("reg", "export " + key + " C:\\reg_logon_backup.reg");
            Console.WriteLine("\nBackup successfully saved as C:\\reg_logon_backup.reg ...");
            string arg_cap = key + "/v legalnoticecaption /t REG_SZ /d " + "\""+ caption + "\""+ " /f";
            string arg_txt = key + "/v legalnoticetext /t REG_SZ /d " + "\"" + text  + "\"" + " /f";            
            //global::System.Windows.Forms.MessageBox.Show(arg_cap );
            //global::System.Windows.Forms.MessageBox.Show(arg_txt);
            Console.WriteLine("\nApplying the settings ...");
            Process.Start("reg", "add " + arg_cap);
            Process.Start("reg", "add " + arg_txt);
            Console.WriteLine("\nSuccessfully Updated !...\n");
            Console.ReadKey(true);
        }

        static void ConsoleSettings(ConsoleColor ForegroundColor)
        {
            Console.Title = "Customised Interactive logon.";
            //Console.WindowWidth = 70;
            Console.BackgroundColor = ConsoleColor.Black  ;
            Console.ForegroundColor = ForegroundColor  ;            
        }
    }
}
