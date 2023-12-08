using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;

namespace PogoBtr11
{
    public class Registry_funcs
    {
        public void contextmenuenable()
        {
            try
            {
                var hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                RegistryKey contextmenuregkey = hkcu.OpenSubKey("SOFTWARE\\CLASSES\\CLSID", true);
                contextmenuregkey.CreateSubKey("{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32");
                contextmenuregkey.SetValue("", "", RegistryValueKind.String);
                contextmenuregkey.Close();

                Console.WriteLine("Context menu enabled");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while contextmenuenable: {ex.Message}");
            }
        }

        public void contextmenudisable()
        {
            try
            {
                var hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                RegistryKey contextmenuregkey = hkcu.OpenSubKey("SOFTWARE\\CLASSES\\CLSID", true);
                contextmenuregkey.DeleteSubKey("{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32");
                contextmenuregkey.DeleteSubKey("{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}");
                contextmenuregkey.Close();

                Console.WriteLine("Context menu disabled");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while contextmenudisable: {ex.Message}");
            }
        }

        public void exploreruwpribbonenable()
        {
            try
            {
                var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey uwpribbonregkey = hklm.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Blocked", true);
                uwpribbonregkey.SetValue("{e2bf9676-5f8f-435c-97eb-11607a5bedf7}", "", RegistryValueKind.String);
                uwpribbonregkey.Close();

                Console.WriteLine("UWP ribbon enabled");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while exploreruwpribbonenable: {ex.Message}");
            }
        }

        public void exploreruwpribbondisable()
        {
            try
            {
                var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey uwpribbonregkey = hklm.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions", true);
                uwpribbonregkey.DeleteSubKey("Blocked");
                uwpribbonregkey.Close();

                Console.WriteLine("UWP ribbon disabled");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while exploreruwpribbondisable: {ex.Message}");
            }
        }

        public void smalltaskbarenable()
        {
            try
            {
                var hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                RegistryKey smalltaskbarregkey = hkcu.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
                smalltaskbarregkey.SetValue("TaskbarSmallicons", 1, RegistryValueKind.DWord);
                smalltaskbarregkey.Close();

                Console.WriteLine("Small Taskbar enabled (broken)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while smalltaskbarenable: {ex.Message}");
            }
        }

        public void smalltaskbardisable()
        {
            try
            {
                var hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                RegistryKey smalltaskbarregkey = hkcu.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
                smalltaskbarregkey.SetValue("TaskbarSmallicons", 0, RegistryValueKind.DWord);
                smalltaskbarregkey.Close();

                Console.WriteLine("Small Taskbar disabled");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while smalltaskbardisable: {ex.Message}");
            }
        }
    }
}