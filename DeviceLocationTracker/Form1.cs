using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceLocationTracker
{

    public partial class Form1 : Form
    {
        private string latitude;
        private string logitude;
        GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = latitude;
            textBox2.Text = logitude;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            watcher = new GeoCoordinateWatcher();
            watcher.StatusChanged += Watcher_StatusChanged;
            watcher.Start();
        }

        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            try
            {
                if (e.Status == GeoPositionStatus.Ready)
                {
                    if (watcher.Position.Location.IsUnknown)
                    {
                        latitude = "0";
                        logitude = "0";
                    }
                    else
                    {
                        latitude = watcher.Position.Location.Latitude.ToString();
                        logitude = watcher.Position.Location.Latitude.ToString();
                    }
                }
                else
                {
                    latitude = "0";
                    logitude = "0";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
