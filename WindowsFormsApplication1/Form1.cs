using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SecondChangeEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Clock formClock = new Clock();



            // Create the display and tell it to
            // subscribe to the clock just created
            DisplayClock dc = new DisplayClock(textBox1);
            formClock.SecondChange += new Clock.SecondChangeHandler(dc.TimeHasChanged);


            // Create a Log object and tell it
            // to subscribe to the clock
            LogClock lc = new LogClock();
            formClock.SecondChange += new Clock.SecondChangeHandler(lc.WriteLogEntry);
            button1.Click += formClock.Run;

            
           // 
        }




        /* ======================= Event Subscribers =============================== */

        // An observer. DisplayClock subscribes to the
        // clock's events. The job of DisplayClock is
        // to display the current time
        public class DisplayClock
        {
            private TextBox ClockBox;

            public DisplayClock(TextBox textBox1)
            {
                this.ClockBox = textBox1;
            }

            // The method that implements the
            // delegated functionality
            public void TimeHasChanged(object theClock, TimeInfoEventArgs ti)
            {
                ClockBox.Text = (ti.hour.ToString() + ":" + ti.minute.ToString() + ":" + ti.second.ToString());
            }
        }


        // A second subscriber whose job is to write to a file
        public class LogClock
        {

            // This method should write to a file
            // we write to the console to see the effect
            // this object keeps no state
            public void WriteLogEntry(object theClock, TimeInfoEventArgs ti)
            {
                //Console.WriteLine("Logging to file: {0}:{1}:{2}",
                //   ti.hour.ToString(),
                //   ti.minute.ToString(),
                //   ti.second.ToString());
            }
        }

    }
}
