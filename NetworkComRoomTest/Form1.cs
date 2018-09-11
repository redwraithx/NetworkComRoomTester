using System;
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
        private List<ScanData> dataList = new List<ScanData>();
        private ScanData scanData;

        // keep a index while iterating through the list, else its -1 (null in my app)
        private int currentCell = -1;





        public Form1()
        {
            InitializeComponent();

            // status text alignment
            this.dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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




            #region AddRoomsToList


            // build ip list (HARD CODED FOR NOW) as the follow order: ID, ROOM #, IP Address, Status, Ping Response
            scanData = new ScanData("1", "P107", "10.11.0.7", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("2", "P110", "10.11.0.10", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("3", "P134", "10.11.0.34", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("4", "P155", "10.11.0.55", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("5", "120", "10.11.1.20", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("6", "138", "10.11.1.38", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("7", "200", "10.11.2.0", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("8", "233", "10.11.2.33", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("9", "280", "10.11.2.80", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("10", "329", "10.11.3.29", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("11", "363", "10.11.3.63", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("12", "380", "10.11.3.80", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("13", "400", "10.11.4.0", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("14", "431", "10.11.4.31", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("15", "461", "10.11.4.61", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("16", "490", "10.11.4.90", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("17", "506", "10.11.5.6", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("18", "539", "10.11.5.39", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("19", "564", "10.11.5.64", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("20", "600", "10.11.6.0", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("21", "634", "10.11.6.34", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);
            scanData = new ScanData("22", "671", "10.11.6.71", statusResult.UnChecked.ToString(), "-1");
            dataList.Add(scanData);


            #endregion // end AddRoomsToList




            foreach (ScanData item in dataList)
            {
                dataGridView.Rows.Add(item.ID, item.RoomNumber, item.IPAddress, item.Status, item.PingDelay);
            }



            SelectClear();
        }






        private void btnScanAll_Click(object sender, EventArgs e)
        {
            try
            {
                int timeout = 400;
                Ping ping;
            
                foreach (ScanData item in dataList)
                {
                    // iter through list ping and report
                    ping = new Ping();

                    PingReply pingReply = ping.Send(item.IPAddress, timeout);

                    SuspendLayout();
                    SetStatus(item, pingReply);

                    ResumeLayout();

                    dataGridView.Refresh();
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
                cell.Value = "999";
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
            else if (pingReply.Status == IPStatus.TimedOut)
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
                cell.Style.BackColor = Color.White;
                                     
                dataGridView.CurrentCell = dataGridView.Rows[currentCell - 1].Cells[dataGridView.ColumnCount - 2];
                
                                
                currentCell = -1;


                SetPingResponse(item, pingReply);
            }

            
            SelectClear();
        }





        private void SelectClear()
        {
            dataGridView[0, 0].Selected = true;
            dataGridView.ClearSelection();
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
