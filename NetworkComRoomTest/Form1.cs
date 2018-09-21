using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;


namespace NetworkComRoomTest
{
    public enum statusResult
    {
        UnChecked,
        Online,
        Offline,
        TimedOut
    }





    public partial class Form1 : Form
    {
        private const string filePath = @".\Data.csv";
        private int idCounter = 0;
        private List<ScanData> dataList = new List<ScanData>();
        private ScanData scanData;

        // keep a index while iterating through the list, else its -1 (null in my app)
        private int currentCell = -1;


        // for auto ping time
        private int currentSetTimerValue = 0;
        private bool isAutoPingSet = false;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        DateTime startTime;

        public Form1()
        {
            InitializeComponent();

            // enter key to click scanbutton
            this.AcceptButton = btnScanAll;

            // status text alignment
            this.dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // ID
            this.dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // ROOM #
            this.dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // IP Address
            this.dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Status
            this.dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Ping Response in (ms)

            // set rows font / style
            this.dataGridView.RowHeadersDefaultCellStyle.Font = new Font("Aria", 8F, FontStyle.Bold, GraphicsUnit.Pixel);

            // set rows default color
            this.dataGridView.RowsDefaultCellStyle.BackColor = Color.LightBlue;
                                   

            // align and set font / style for the column headers
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            // make virtical scroll bar visible at all times even when you cant scroll
            // dataGridView.Controls[0].Enabled = false; // horizontal scrollbar
            // dataGridView.Controls[1].Enabled = true; // vertical scrollbar
            //dataGridView.Controls[VerticalScroll.Value].Enabled = true;
            
            

            txtBoxRefreshtime.Text = "60";


            // hardcoded list                 *** this will change to a File for easy user expansion for the future ***
            #region AddRoomsToList


            //// build ip list (HARD CODED FOR NOW) as the follow order: ID, ROOM #, IP Address, Status, Ping Response
            //scanData = new ScanData("1", "P107", "10.11.0.7", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("2", "P110", "10.11.0.10", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("3", "P134", "10.11.0.34", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("4", "P155", "10.11.0.55", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("5", "P156", "10.11.0.56", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("6", "120", "10.11.1.20", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("7", "138", "10.11.1.38", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("8", "200", "10.11.2.0", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("9", "233", "10.11.2.33", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("10", "280", "10.11.2.80", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("11", "329", "10.11.3.29", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("12", "363", "10.11.3.63", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("13", "380", "10.11.3.80", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("14", "400", "10.11.4.0", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("15", "431", "10.11.4.31", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("16", "461", "10.11.4.61", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("17", "490", "10.11.4.90", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("18", "506", "10.11.5.6", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("19", "539", "10.11.5.39", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("20", "564", "10.11.5.64", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("21", "600", "10.11.6.0", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("22", "634", "10.11.6.34", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);
            //scanData = new ScanData("23", "671", "10.11.6.71", statusResult.UnChecked.ToString(), "-1");
            //dataList.Add(scanData);


            #endregion // end AddRoomsToList


            #region BackedUpInitialList
            //P107, 10.11.0.7
            //P110, 10.11.0.10
            //P134, 10.11.0.34
            //P155, 10.11.0.55
            //P156, 10.11.0.56
            //120, 10.11.1.20
            //138, 10.11.1.38
            //200, 10.11.2.0
            //233, 10.11.2.33
            //280, 10.11.2.80
            //329, 10.11.3.29
            //363, 10.11.3.63
            //380, 10.11.3.80
            //400, 10.11.4.0
            //431, 10.11.4.31
            //461, 10.11.4.61
            //490, 10.11.4.90
            //506, 10.11.5.6
            //539, 10.11.5.39
            //564, 10.11.5.64
            //600, 10.11.6.0
            //634, 10.11.6.34
            //671, 10.11.6.71

            #endregion // BackedUpInitialList



            #region LoadComRooms


            LoadPingList(idCounter);


            #endregion // LoadComRooms


            //dataGridView.Height = (dataGridView.Rows. * dataGridView.Rows.GetRowsHeight);

            foreach (ScanData item in dataList)
            {
                dataGridView.Rows.Add(item.ID, item.RoomNumber, item.IPAddress, item.Status, item.PingDelay);
            }

        }




        private void LoadPingList(int id)
        {
            if (File.Exists(filePath) is false)
            {
                try
                {

                    // create file, if it failes catch will get it.
                    using (File.Create(filePath)) ;



                        // add header to file.
                        // using (FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    using (var writeFile = new StreamWriter(filePath, true))
                    {
                        writeFile.WriteLine("# Format like this per Line: Room #, IP Address,");
                        writeFile.WriteLine("#--------------------------------------------------");

                        writeFile.WriteLine("P107, 10.11.0.7");
                        writeFile.WriteLine("P110, 10.11.0.10");
                        writeFile.WriteLine("P134, 10.11.0.34");
                        writeFile.WriteLine("P155, 10.11.0.55");
                        writeFile.WriteLine("P156, 10.11.0.56");
                        writeFile.WriteLine("120, 10.11.1.20");
                        writeFile.WriteLine("138, 10.11.1.38");
                        writeFile.WriteLine("200, 10.11.2.0");
                        writeFile.WriteLine("233, 10.11.2.33");
                        writeFile.WriteLine("280, 10.11.2.80");
                        writeFile.WriteLine("329, 10.11.3.29");
                        writeFile.WriteLine("363, 10.11.3.63");
                        writeFile.WriteLine("380, 10.11.3.80");
                        writeFile.WriteLine("400, 10.11.4.0");
                        writeFile.WriteLine("431, 10.11.4.31");
                        writeFile.WriteLine("461, 10.11.4.61");
                        writeFile.WriteLine("490, 10.11.4.90");
                        writeFile.WriteLine("506, 10.11.5.6");
                        writeFile.WriteLine("539, 10.11.5.39");
                        writeFile.WriteLine("564, 10.11.5.64");
                        writeFile.WriteLine("600, 10.11.6.0");
                        writeFile.WriteLine("634, 10.11.6.34");
                        writeFile.WriteLine("671, 10.11.6.71");

                        writeFile.Close();
                    }
                        
                    
                        

                }
                catch (IOException e)
                {
                    MessageBox.Show("Error file not found, could not create file...\nmaybe you lack permission to do so. check with your admin.\n\nError MSG:\n\n" + e.Message);
                    Environment.Exit(-1);
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error creating File, check your premissions and try again. Error MSG: " + e.Message);
                    Environment.Exit(-1);
                }


            }

            try
            {
                using (StreamReader readFile = new StreamReader(filePath))
                {


                    while (!readFile.EndOfStream)
                    {
                        string[] token = readFile.ReadLine().Split(',');
                                                
                        if (token[0].Contains("#"))
                        {
                            continue;
                        }


                        idCounter++;

                        


                        // "1", "P107", "10.11.0.7", statusResult.UnChecked.ToString(), "-1"
                        scanData = new ScanData();

                        scanData.ID = idCounter.ToString();
                        scanData.RoomNumber = token[0]; // ID
                        scanData.IPAddress = token[1]; // IP Address
                        scanData.Status = statusResult.UnChecked.ToString();
                        scanData.PingDelay = "-1";


                        dataList.Add(scanData);
                    }
                }
            }
            catch(Exception e)
            {
                // failed to load file information to list
                MessageBox.Show("Error adding file information to Application loader, check formatting and try again.");
                Environment.Exit(-1);
            }





             //   return true;
        }





        private async void AutoPingTimer()
        {
            while (isAutoPingSet == true || chkBoxAutoPing.Checked == true)
            {
                int minsTillRefresh = int.Parse(txtBoxRefreshtime.Text);
                startTime = DateTime.Now;

                Timer timer = new Timer() { Interval = 1000 };
                timer.Tick += new EventHandler(T_tick);


                TimeSpan timeSpan = new TimeSpan(0, minsTillRefresh, 0); 
                timer.Start();


                while (timeSpan != TimeSpan.Zero)
                {
                    if (isAutoPingSet == false || chkBoxAutoPing.Checked == false)
                    {
                        return;
                    }


                    timeSpan = timeSpan.Subtract(TimeSpan.FromSeconds(1)); 


                    await System.Threading.Tasks.Task.Delay(1000);

                    T_tick(this, EventArgs.Empty);

                    if (chkBoxAutoPing.Checked == true)
                        txtBoxTimer.Text = string.Format($"Time left: {timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}");
                    else
                        return;                    
                }

                txtBoxTimer.Text = "Scanning";        
                
                ScanAll();
            }

            txtBoxTimer.Text = "Timer Off";
        }

        
        private void T_tick(object sender, EventArgs e)
        {
            TimeSpan ts = startTime.Subtract(DateTime.Now);            
        }




        private void btnScanAll_Click(object sender, EventArgs e)
        {            
            btnScanAll.Enabled = false;

            ScanAll();

            btnScanAll.Enabled = true;
        }





        private void ScanAll()
        {
            ResetScanObjects();

            try
            {
                int timeout = 1000;
                Ping ping;

                foreach (ScanData item in dataList)
                {
                    ping = new Ping();
                    PingReply pingReply = ping.Send(item.IPAddress, timeout);

                    for (int i = 0; i < 4; i++)
                    {                       

                        pingReply = ping.Send(item.IPAddress, timeout);

                        if (pingReply.Status == IPStatus.Success)
                        {
                            // connection was found exit
                            break;
                        }

                        pingReply = ping.Send(item.IPAddress, timeout);
                    }


                    SuspendLayout();
                    SetStatus(item, pingReply);

                    ResumeLayout();

                    dataGridView.Refresh();


                    ping.Dispose();
                }

                dataGridView.Refresh();
            }
            catch (PingException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }





        private void SetPingResponse(ScanData item, PingReply pingReply)//, Ping ping)
        {
            if (pingReply.Status == IPStatus.Success)
            {
                currentCell = int.Parse(item.ID);
                item.PingDelay = Convert.ToString(pingReply.RoundtripTime);

                dataGridView.CurrentCell = dataGridView.Rows[currentCell - 1].Cells[dataGridView.ColumnCount - 1];

                DataGridViewCell cell = dataGridView.Rows[currentCell - 1].Cells[4];
                cell.Value = item.PingDelay;                
            }
            else
            {
                dataGridView.CurrentCell = dataGridView.Rows[currentCell - 1].Cells[dataGridView.ColumnCount - 1];

                DataGridViewCell cell = dataGridView.Rows[currentCell - 1].Cells[4];
                cell.Value = "9999";
            }

        }




        private void SetStatus(ScanData item, PingReply pingReply)
        {          

            if (pingReply.Status == IPStatus.Success)
            {
                currentCell = int.Parse(item.ID);

                // online
                dataGridView.CurrentCell = dataGridView.Rows[currentCell - 1].Cells[dataGridView.ColumnCount - 2];                              
                
                dataGridView.CurrentCell.Value = statusResult.Online;

                DataGridViewCell cell = dataGridView.Rows[currentCell - 1].Cells[3];
                cell.Style.BackColor = Color.Green;


                SetPingResponse(item, pingReply);
            }
            else if (pingReply.Status == IPStatus.TimedOut) // offline
            {
                currentCell = int.Parse(item.ID);
                
                dataGridView.CurrentCell = dataGridView.Rows[currentCell - 1].Cells[dataGridView.ColumnCount - 2];
                
                dataGridView.CurrentCell.Value = statusResult.Offline;

                DataGridViewCell cell = dataGridView.Rows[currentCell - 1].Cells[3];
                cell.Style.BackColor = Color.Red;


                SetPingResponse(item, pingReply);
            }            
            else
            {
                currentCell = int.Parse(item.ID);

                DataGridViewCell cell = dataGridView.Rows[currentCell - 1].Cells[3];
                cell.Style.BackColor = Color.FromArgb(0, 192, 192);
                                     
                dataGridView.CurrentCell = dataGridView.Rows[currentCell - 1].Cells[dataGridView.ColumnCount - 2];                
                                
                currentCell = -1;

                SetPingResponse(item, pingReply);
            }

            
            SelectClear();
        }





        private void ResetScanObjects()
        {
            int currentCell = -1;

            foreach (ScanData item in dataList)
            {
                currentCell = int.Parse(item.ID);

                DataGridViewCell cell = dataGridView.Rows[currentCell - 1].Cells[3];
                cell.Value = statusResult.UnChecked;
                dataGridView.CurrentCell = dataGridView.Rows[currentCell - 1].Cells[dataGridView.ColumnCount - 2];

                cell = dataGridView.Rows[currentCell - 1].Cells[3];
                cell.Style.BackColor = Color.LightBlue;

                dataGridView.CurrentCell = dataGridView.Rows[currentCell - 1].Cells[dataGridView.ColumnCount - 1];

                cell = dataGridView.Rows[currentCell - 1].Cells[4];
                cell.Value = "-1";
            }

            SelectClear();
        }





        private void SelectClear()
        {
            dataGridView[0, 0].Selected = true;
            dataGridView.ClearSelection();
        }





        private void chkBoxAutoPing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxAutoPing.Checked == true)
            {
                isAutoPingSet = true;

                btnScanAll.Enabled = false;
                txtBoxRefreshtime.Enabled = false;

                AutoPingTimer();
            }
            else
            {
                txtBoxTimer.Text = "AutoPing OFF";

                btnScanAll.Enabled = true;
                txtBoxRefreshtime.Enabled = true;

                isAutoPingSet = false;
            }
        }





        private void txtBoxRefreshtime_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxRefreshtime.Text == "")
            {
                isAutoPingSet = false;

                return;
            }

            int parsedValue;
            if (!int.TryParse(txtBoxRefreshtime.Text, out parsedValue))
            {
                MessageBox.Show(this, "Enter a Value number 1 to 720");

                txtBoxRefreshtime.Text = "";

                return;
            }

            currentSetTimerValue = int.Parse(txtBoxRefreshtime.Text);
        }
    }





    class ScanData
    {
        public string ID { get; set; }
        public string RoomNumber { get; set; }
        public string IPAddress { get; set; }
        public string Status { get; set; }
        public string PingDelay { get; set; }

        public ScanData()
        {

        }





        public ScanData(string id, string roomNumber, string ipAddress, string status, string pingDelay)
        {
            ID = id;
            RoomNumber = roomNumber;
            IPAddress = ipAddress;
            Status = status;
            PingDelay = pingDelay;
        }
    }
}
