using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NetworkComRoomTest
{
    public enum statusResult
    {
        UnChecked,
        Online,
        Offline,
        TimedOut
    }

    public delegate void UpdateControlsDelegate(); // thread delegate
    

    public partial class Form1 : Form
    {
        public static Form1 instance;


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


        // child form window
        public AlertContactsListForm alertContactsListForm = new AlertContactsListForm();
        public bool alertContactButton = false;
        
        


        public Form1()
        {
            //alertContactsListForm.Parent = this;

            if (instance != null)
            {
                return;
            }

            instance = this;


            // this is for the contact list Form 
            
            alertContactsListForm.Enabled = false;
            alertContactsListForm.Visible = false;
            //alertContactsListForm.TopLevel = true;
            //alertContactsListForm.TopMost = true;
            

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

        // THREADING UPDATER BACKGROUND WORK STARTS
        public void ThreadBackGroundWorkMethod()
        {
            InvokeUpdateControls();
        }

        //THREAD UPDATER
        public void InvokeUpdateControls()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateControlsDelegate(UpdateControls));
            }
            else
            {
                UpdateControls();
            }
        }

        // THREAD UPDATER CONTINUTED
        private void UpdateControls()
        {
            ScanAll();
        }


        private void LoadPingList(int id)
        {
            if (File.Exists(filePath) is false)
            {
                try
                {
                    LogHelper.Log(LogTarget.File, "Creating config file. " + DateTime.Now);


                    // create file, if it failes catch will get it.
                    using (File.Create(filePath)) ;


                        // add header to file.
                        // using (FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    using (var writeFile = new StreamWriter(filePath, true))
                    {
                        writeFile.WriteLine("# Format like this per Line (NO SPACES): Room #,IP Address,");
                        writeFile.WriteLine("#--------------------------------------------------");
                        
                        /*
                        writeFile.WriteLine("P107,10.11.0.7");
                        writeFile.WriteLine("P110,10.11.0.10");
                        writeFile.WriteLine("P134,10.11.0.34");
                        writeFile.WriteLine("P155,10.11.0.55");
                        writeFile.WriteLine("P156,10.11.0.56");
                        writeFile.WriteLine("120,10.11.1.20");
                        writeFile.WriteLine("138,10.11.1.38");
                        writeFile.WriteLine("200,10.11.2.0");
                        writeFile.WriteLine("233,10.11.2.33");
                        writeFile.WriteLine("280,10.11.2.80");
                        writeFile.WriteLine("329,10.11.3.29");
                        writeFile.WriteLine("363,10.11.3.63");
                        writeFile.WriteLine("380,10.11.3.80");
                        writeFile.WriteLine("400,10.11.4.0");
                        writeFile.WriteLine("431,10.11.4.31");
                        writeFile.WriteLine("461,10.11.4.61");
                        writeFile.WriteLine("490,10.11.4.90");
                        writeFile.WriteLine("506,10.11.5.6");
                        writeFile.WriteLine("539,10.11.5.39");
                        writeFile.WriteLine("564,10.11.5.64");
                        writeFile.WriteLine("600,10.11.6.0");
                        writeFile.WriteLine("634,10.11.6.34");
                        writeFile.WriteLine("671,10.11.6.71");
                        */

                        writeFile.Close();


                        LogHelper.Log(LogTarget.File, "Config File Successfully Created. " + DateTime.Now);
                    }        

                }
                catch (IOException e)
                {
                    MessageBox.Show("Error file not found, could not create file...\nmaybe you lack permission to do so. check with your admin.\n\nError MSG:\n\n" + e.Message);
                    LogHelper.Log(LogTarget.ErrorFile, "IOException Error ==>  Creating Config File");

                    Environment.Exit(-1);
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error creating File, check your premissions and try again. Error MSG: " + e.Message);
                    LogHelper.Log(LogTarget.ErrorFile, "Exception error ==>   Cant Create Config File");

                    Environment.Exit(-1);
                }

            }

            try
            {
                LogHelper.Log(LogTarget.File, "Loading from Config file. " + DateTime.Now);

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

                LogHelper.Log(LogTarget.File, "Config file successfully loaded. " + DateTime.Now);
            }
            catch(Exception e)
            {
                // failed to load file information to list
                MessageBox.Show("Error adding file information to Application loader, check formatting and try again.");
                LogHelper.Log(LogTarget.ErrorFile, "Exception Error ==>  Format Error loading Data from config file to Application. Check \"config file \" Formatting");

                Environment.Exit(-1);
            }





             //   return true;
        }





        private async void AutoPingTimer()
        {
            bool HeartBeatFailure = false;
            int HeartBeatFailureCount = 0;
            lblHeartBeatCounter.Text = HeartBeatFailureCount.ToString();

            
            txtBoxTimer.Text = "Scanning";
            txtBoxTimer.Refresh();


            while (isAutoPingSet == true || chkBoxAutoPing.Checked == true)
            {
                HeartBeatFailure = AutoScanAll();

                if (HeartBeatFailure == true)
                {
                    HeartBeatFailureCount++;

                    lblHeartBeatCounter.Text = HeartBeatFailureCount.ToString();

                    HeartBeatFailure = false;
                }





                int minsTillRefresh = int.Parse(txtBoxRefreshtime.Text);
                startTime = DateTime.Now;

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 1000 };
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
                
                HeartBeatFailure = AutoScanAll();

                if (HeartBeatFailure == true)
                {
                    HeartBeatFailureCount++;

                    lblHeartBeatCounter.Text = HeartBeatFailureCount.ToString();

                    HeartBeatFailure = false;
                }
                else
                {
                    // heartbeat counter starts over if we have a good run.
                    HeartBeatFailureCount = 0;
                }


                if (minsTillRefresh < 100 && HeartBeatFailureCount >=4 || 
                    minsTillRefresh > 100 && minsTillRefresh < 800 && HeartBeatFailureCount >= 2 || 
                    minsTillRefresh > 800 && HeartBeatFailureCount >= 1)
                {
                    EmailAlertSystem.EMail();

                    // reset heartbeat failure counter and failures
                    HeartBeatFailureCount = 0;
                    HeartBeatFailure = false;
                }
                
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


            // Thread scanThread = new Thread(ScanAll);
            // scanThread.Start();
            ScanAll();


            btnScanAll.Enabled = true;
        }


        private bool AutoScanAll()
        {
            bool DeviceFailure = false;


            ResetScanObjects();

            try
            {
                int timeout = 1000;
                Ping ping = null;
                byte[] buffer = new byte[32];
                PingOptions pingOptions = new PingOptions(128, true);

                foreach (ScanData item in dataList)
                {
                    ping = new Ping();

                    PingReply pingReply = ping.Send(item.IPAddress, timeout, buffer, pingOptions);
                    

                    for (int i = 0; i < 4; i++)
                    {                        
                        pingReply = ping.Send(item.IPAddress.ToString(), 1000, buffer, pingOptions);

                        if (pingReply.Status == IPStatus.Success)
                        {
                            // connection was found exit
                            break;
                        }
                        else
                        {
                            DeviceFailure = true;
                        }

                        pingReply = null;                     
                    }


                    SuspendLayout();
                    SetStatus(item, pingReply);

                    ResumeLayout();

                    dataGridView.Refresh();



                    ping.Dispose();
                }

                dataGridView.Refresh();

                LogHelper.Log(LogTarget.File, "IP Status hass been updated - " + DateTime.Now);
            }

            catch (PingException ex)
            {
                //MessageBox.Show("Ping Exception Error: " + ex.Message + "\n____________________________________________________\n\n" +                     ex.ToString() + "\n___________________________________________________________________\n\n\n\n" + ex.InnerException +                     "\n\n----------------------------------------\n\nMake sure you dont have any spaces in an IP");

                LogHelper.Log(LogTarget.ErrorFile, "PingException Error ==>  Make sure the config file has the correct information - (remove any spaces or characters from IPs)");
            }
            catch (Exception e)
            {
                //MessageBox.Show("Exception Error: " + e.Message + "\n___________________________________________________\n\n\n" + e.InnerException);

                LogHelper.Log(LogTarget.ErrorFile, "Exception Error ==>  Check config file (for proper ips, with no extra spaces or characters)");
            }

            return DeviceFailure;
        } // end of AutoScanAll with return bool (true = connection failed, false = connection successful)



        private void ScanAll()
        {
            if (dataList.Count == 0)
                return;

            ResetScanObjects();

           
            try
            {
                int timeout = 1000;                
                Ping ping = null;
                byte[] buffer = new byte[32];
                PingOptions pingOptions = new PingOptions(128, true);

                foreach (ScanData item in dataList)
                {
                    ping = new Ping();

                    PingReply pingReply = ping.Send(item.IPAddress, timeout, buffer, pingOptions);

                    for (int i = 0; i < 4; i++)
                    {

                        pingReply = ping.Send(item.IPAddress.ToString(), 1000, buffer, pingOptions);

                        if (pingReply.Status == IPStatus.Success)
                        {
                            // connection was found exit
                            break;
                        }

                        pingReply = null;
                    }


                    SuspendLayout();
                    SetStatus(item, pingReply);

                    ResumeLayout();

                    dataGridView.Refresh();


                    ping.Dispose();
                }

                dataGridView.Refresh();

                LogHelper.Log(LogTarget.File, "IP Status hass been updated - " + DateTime.Now);
            }
            
            catch (PingException ex)
            {
                //MessageBox.Show("Ping Exception Error: " + ex.Message + "\n____________________________________________________\n\n" + 
                //    ex.ToString() + "\n___________________________________________________________________\n\n\n\n" + ex.InnerException + 
                //    "\n\n----------------------------------------\n\nMake sure you dont have any spaces in an IP");

                LogHelper.Log(LogTarget.ErrorFile, "PingException Error ==>  Make sure the config file has the correct information - (remove any spaces or characters from IPs)");
            }
            catch (Exception e)
            {
                //MessageBox.Show("Exception Error: " + e.Message + "\n___________________________________________________\n\n\n" + e.InnerException);

                LogHelper.Log(LogTarget.ErrorFile, "Exception Error ==>  Check config file (for proper ips, with no extra spaces or characters)");
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
            if (dataList.Count == 0)
                return;


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
                chkBoxAutoPing.Refresh();

                grpBoxHeartBeats.Enabled = true;
                grpBoxHeartBeats.Visible = true;
                grpBoxHeartBeats.Refresh();


                btnScanAll.Enabled = false;
                btnScanAll.Visible = false;
                btnScanAll.Refresh();

                txtBoxRefreshtime.Enabled = false;


                AutoPingTimer();
            }
            else
            {
                txtBoxTimer.Text = "AutoPing OFF";

                grpBoxHeartBeats.Enabled = false;
                grpBoxHeartBeats.Visible = false;
                grpBoxHeartBeats.Refresh();

                btnScanAll.Enabled = true;
                btnScanAll.Visible = true;
                btnScanAll.Refresh();

                txtBoxRefreshtime.Enabled = true;

                isAutoPingSet = false;
                chkBoxAutoPing.Refresh();
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

        private void OnApplicationExit(object sender, FormClosingEventArgs e)
        {
            LogHelper.Log(LogTarget.File, "Application Exiting - " + DateTime.Now);
        }

        //private void groupBox3_Enter(object sender, EventArgs e)
        //{

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            alertContactButton = !alertContactButton; // inverse per click

            switch (alertContactButton)
            {
                case true:
                    {
                        //int centerX = this.DesktopBounds.Left + (this.Width - alertContactsListForm.Width) / 2;
                        //int centerY = this.DesktopBounds.Top + (this.Height - alertContactsListForm.Height) / 2;
                        //alertContactsListForm.SetDesktopLocation(centerX, centerY);
                        alertContactsListForm.StartPosition = FormStartPosition.Manual;
                        alertContactsListForm.Location = new Point(this.Location.X + (this.Width - alertContactsListForm.Width) / 2, this.Location.Y + (this.Height - alertContactsListForm.Height) / 2);
                        //alertContactsListForm.Show(this);

                        this.Enabled = false;

                        alertContactsListForm.Enabled = true;
                        alertContactsListForm.Visible = true;

                        break;
                    }
                case false:
                    {
                        
                        alertContactsListForm.Enabled = false;
                        alertContactsListForm.Visible = false;

                        this.Enabled = false;

                        break;
                    }
                default:
                    break;
            }

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            LogHelper.canLogDebugLogging = checkBoxDebugLogging.Checked;

            LogHelper.Log(LogTarget.File, $"Logging Debugging is {LogHelper.canLogDebugLogging}");
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
