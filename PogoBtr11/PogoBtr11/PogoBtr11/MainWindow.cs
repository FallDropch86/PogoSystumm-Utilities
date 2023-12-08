using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PogoBtr11
{
    public partial class closebtn : Form
    {
        Registry_funcs registryfns = new Registry_funcs();
        Restartexplcomp_funcs restartexplcomp_funcs = new Restartexplcomp_funcs();

        bool mouseDownonBorder;
        bool mouseDownonBordertext;
        private Point offset;

        public closebtn()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void uwplabel_Click(object sender, EventArgs e)
        {

        }

        private void contextmenulabel_Click(object sender, EventArgs e)
        {

        }

        private void uwpcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uwpcheckbox.Checked == true)
            {
                registryfns.exploreruwpribbonenable();
            }

            else if (this.uwpcheckbox.Checked == false)
            {
                registryfns.exploreruwpribbondisable();
            }

            else
            {
                Console.WriteLine("UWP Error while enabling or disabling with checkbox");
            }
        }

        private void contextmenucheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.contextmenucheckbox.Checked == true)
            {
                registryfns.contextmenuenable();
            }

            else if (this.contextmenucheckbox.Checked == false)
            {
                registryfns.contextmenudisable();
            }

            else
            {
                Console.WriteLine("Context menu Error while enabling or disabling with checkbox");
            }
        }

        private void explrestart_button_Click(object sender, EventArgs e)
        {
            restartexplcomp_funcs.restartexplorer();
        }

        private void comprestar_button_Click(object sender, EventArgs e)
        {
            restartexplcomp_funcs.restartcomputer();
        }

        private void smalltaskbarcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.smalltaskbarcheckbox.Checked == true)
            {
                registryfns.smalltaskbarenable();
            }

            else if (this.smalltaskbarcheckbox.Checked == false)
            {
                registryfns.smalltaskbardisable();
            }

            else
            {
                Console.WriteLine("Small Taskbar Error while enabling or disabling with checkbox");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bordermousedown_event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDownonBorder = true;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bordermousemove_event(object sender, MouseEventArgs e)
        {
            if (mouseDownonBorder==true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void bordermouseup_event(object sender, MouseEventArgs e)
        {
            mouseDownonBorder = false;
        }

        private void textbordermousedown_event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDownonBordertext = true;
        }

        private void textbordermouseup_event(object sender, MouseEventArgs e)
        {
            mouseDownonBordertext = false;
        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void textbordermousemove_event(object sender, MouseEventArgs e)
        {
            if (mouseDownonBordertext == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
