using System;
using RestartExplorerApp.BLL;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PogoBtr11
{
    public class Restartexplcomp_funcs
    {
        public void restartexplorer()
        {
            RestartExplorer restartExplorer = new RestartExplorer();

            restartExplorer.Execute(() =>
            {
                Console.WriteLine("Explorer restarting in progress...");
            });
        }

        public void restartcomputer()
        {
            MessageBoxButtons options = MessageBoxButtons.YesNo;
            DialogResult msgbox_display = MessageBox.Show("Are you sure you would like to restart your computer? Save your work and apps first!", "WARNING!", options, MessageBoxIcon.Exclamation);
            
            if (msgbox_display == DialogResult.Yes)
            {
                Console.WriteLine("User clicked yes to restart the computer");
                Process.Start("shutdown", "/r /t 5");
            }
            else if (msgbox_display == DialogResult.No)
            {
                Console.WriteLine("User clicked no to restart the computer");
            }
            else
            {
                Console.WriteLine("Message Box error");
            }
        }
    }
}
