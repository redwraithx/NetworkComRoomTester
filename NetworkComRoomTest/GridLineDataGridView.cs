using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkComRoomTest
{
    class GridLineDataGridView : Form1
    {
        public static DataGridView grid;

        public GridLineDataGridView()
        {
            if (grid != null)
            {
                return;
            }

            grid = alertContactsListForm.dataGridView1;


            //grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int rowHeight = grid.RowTemplate.Height;

            int h = grid.ColumnHeadersHeight + rowHeight * grid.RowCount;
            int imgWidth = grid.Width - 2;
            Rectangle rFrame = new Rectangle(0, 0, imgWidth, rowHeight);
            Rectangle rFill = new Rectangle(1, 1, imgWidth - 2, rowHeight);
            Rectangle rowHeader = new Rectangle(2, 2, grid.RowHeadersWidth - 3, rowHeight);

            Pen pen = new Pen(grid.GridColor,1);

            Bitmap rowImg = new Bitmap(imgWidth, rowHeight);
            Graphics g = Graphics.FromImage(rowImg);
            g.DrawRectangle(pen, rFrame);
            g.FillRectangle(new SolidBrush(grid.DefaultCellStyle.BackColor), rFill);
            g.FillRectangle(new SolidBrush(grid.RowHeadersDefaultCellStyle.BackColor), rowHeader);

            int w = grid.RowHeadersWidth - 1;
            for (int j = 0; j < grid.ColumnCount; j++)
            {
                g.DrawLine(pen, new Point(w, 0), new Point(w, rowHeight));
                w += grid.Columns[j].Width;
            }

            int loop = (grid.Height - h) / rowHeight;
            for (int j = 0; j < loop + 1; j++)
            {
                e.Graphics.DrawImage(rowImg, 1, h + j * rowHeight);
            }

        }





    }

}
