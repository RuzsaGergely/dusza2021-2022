using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Pop_it_GUI
{
    public partial class Hub : Form
    {
        public List<MapObject> online_maps = new List<MapObject>();
        public Logger logger = new Logger("logs.txt");
        public string server_url = "https://dev.ruzger.hu/dusza/";
        public Hub()
        {
            InitializeComponent();
            var request = WebRequest.Create($"{server_url}palyak-lista.php");
            var stream = request.GetResponse().GetResponseStream();
            var stream_reader = new StreamReader(stream);
            while (!stream_reader.EndOfStream)
            {
                string[] data_split = stream_reader.ReadLine().Split(';');
                if(data_split[1].Length > 2)
                {
                    online_maps.Add(new MapObject(data_split));
                }
            }
            lbox_onlinelist.DisplayMember = "MapName";
            lbox_onlinelist.ValueMember = "MapUrl";
            foreach (var item in online_maps)
            {
                lbox_onlinelist.Items.Add(item);
            }
            lbox_onlinelist.DataSource = online_maps;
        }

        private void btn_letoltes_Click(object sender, EventArgs e)
        {
            lbl_download_status.Text = "";
            pbar_status.Value = 0;
            var client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            try
            {
                MapObject file_name = (MapObject)lbox_onlinelist.SelectedItem;
                client.DownloadFileAsync(new Uri((string)lbox_onlinelist.SelectedValue), $"./palyak/{file_name.MapName}.txt");
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex}");
            }
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            lbl_download_status.Text = "Letöltve: " + e.BytesReceived + " / " + e.TotalBytesToReceive;
            pbar_status.Value = int.Parse(Math.Truncate(percentage).ToString());
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lbl_download_status.Text = "Letöltve!";
        }

        private void btn_feltoltes_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(server_url);
        }
    }
    public class MapObject
    {
        public int Id { get; set; }
        public string MapName { get; set; }
        public string MapUrl { get; set; }
        public MapObject(string[] row)
        {
            Id = Convert.ToInt32(row[0]);
            MapName = row[1];
            MapUrl = row[2];
        }
    }
}
