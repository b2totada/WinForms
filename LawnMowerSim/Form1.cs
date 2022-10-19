using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawnMowerSim
{
    public partial class LawnMowerSim : Form
    {
        private Random random = new Random();
        private DataGridView gardenGrid = null;
        List<DataGridViewCell> visited;
        String[] algorithms = { "LineFill", "DFS", "BFS", "LineFill2" };
        String[] speeds = { "1x", "2x", "3x", "4x" };
        String[] obstChance = { "0%", "25%", "50%" };
        int obstacleChance;
        int[] dirRow = { -1, +1, 0, 0 };
        int[] dirCol = { 0, 0, +1, -1 };
        Queue<int> rowQ = new Queue<int>();
        Queue<int> colQ = new Queue<int>();

        public LawnMowerSim()
        {
            InitializeComponent();
        }

        private void LawnMoverSim_Load(object sender, EventArgs e)
        {
            obstacleChance = random.Next(0, 10);
            this.algoSelComboBox.DataSource = algorithms;
            this.selSpeedComboBox.DataSource = speeds;
            this.obstChanceComboBox.DataSource = obstChance;
            this.startBtn.Visible = false;
            this.checkResBtn.Visible = false;
        }

        private void gardenGeneratorBtn_Click(object sender, EventArgs e)
        {
            CreateGarden();
            this.startBtn.Visible = true;
            this.checkResBtn.Visible = false;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void CreateGarden()
        {
            if (gardenGrid != null)
            {
                gardenGrid.Dispose();
            }

            visited = new List<DataGridViewCell>();

            gardenGrid = new DataGridView();

            gardenGrid.ReadOnly = true;

            gardenGrid.ColumnHeadersVisible = false;
            gardenGrid.RowHeadersVisible = false;

            gardenGrid.Size = new Size(800, 542);
            gardenGrid.Location = new Point(40, 70);

            gardenGrid.RowCount = random.Next(2, 8 + 1);
            gardenGrid.ColumnCount = random.Next(2, 8 + 1);

            foreach (DataGridViewRow row in gardenGrid.Rows)
            {
                row.Height = (gardenGrid.ClientRectangle.Height - gardenGrid.ColumnHeadersHeight) / gardenGrid.Rows.Count;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if ((string)obstChanceComboBox.SelectedItem == "0%")
                    {
                        obstacleChance = random.Next(2, 4);
                    }
                    else if ((string)obstChanceComboBox.SelectedItem == "25%")
                    {
                        obstacleChance = random.Next(0, 4);
                    }
                    else if ((string)obstChanceComboBox.SelectedItem == "50%")
                    {
                        obstacleChance = random.Next(0, 2);
                    }

                    if (obstacleChance == 0 && cell.OwningColumn.Index != 0 && cell.OwningRow.Index != 0)
                    {
                        cell.Style.BackColor = Color.Black;
                    }
                    else
                    {
                        cell.Style.BackColor = Color.DarkGreen;
                    }
                }
            }

            gardenGrid.Enabled = false;
            gardenGrid.RowsDefaultCellStyle.SelectionBackColor = gardenGrid.Rows[0].Cells[0].Style.BackColor;
            gardenGrid.RowsDefaultCellStyle.SelectionForeColor = gardenGrid.Rows[0].Cells[0].Style.ForeColor;
            gardenGrid.DefaultCellStyle.Font = new Font("Tahoma", 20);
            gardenGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Controls.Add(gardenGrid);
        }

        private async void PlaceLawnmower(int col, int row, int delay)
        {
            gardenGrid.Rows[row].Cells[col].Value = "H";
            gardenGrid.Rows[row].Cells[col].Style.BackColor = Color.LightGreen;
            if (col == 0 && row == 0)
            {
                gardenGrid.RowsDefaultCellStyle.SelectionBackColor = gardenGrid.Rows[0].Cells[0].Style.BackColor;
                gardenGrid.RowsDefaultCellStyle.SelectionForeColor = gardenGrid.Rows[0].Cells[0].Style.ForeColor;
            }
            await Task.Delay(delay);
            gardenGrid.Rows[row].Cells[col].Value = null;
        }

        private int Obstacles()
        {
            int obstacles = 0;
            foreach (DataGridViewRow row in gardenGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor == Color.Black)
                    {
                        obstacles++;
                    }
                }
            }

            return obstacles;
        }

        private async void LineFill(int x, int y, int delay)
        {
            int total = gardenGrid.RowCount * gardenGrid.ColumnCount - Obstacles();

            Queue<Point> obstacles = new Queue<Point>();
            while (y < gardenGrid.RowCount)
            {
                for (int i = 0; i < gardenGrid.ColumnCount; i++)
                {
                    if (gardenGrid.Rows[y].Cells[i].Style.BackColor == Color.DarkGreen)
                    {
                        await Task.Delay(delay);

                        PlaceLawnmower(i, y, delay);
                        visited.Add(gardenGrid.Rows[y].Cells[i]);
                    }
                    else if (gardenGrid.Rows[y].Cells[i].Style.BackColor == Color.Black)
                    {
                        obstacles.Enqueue(new Point(i, y));
                        break;
                    }
                }
                y++;
            }

            while (total > visited.Count)
            {
                Point temp = obstacles.Dequeue();
                for (int i = temp.X + 1; i < gardenGrid.ColumnCount; i++)
                {
                    if (i >= gardenGrid.ColumnCount)
                    {
                        break;
                    }
                    if (gardenGrid.Rows[temp.Y].Cells[i].Style.BackColor == Color.DarkGreen)
                    {
                        await Task.Delay(delay);

                        PlaceLawnmower(i, temp.Y, delay);
                        visited.Add(gardenGrid.Rows[temp.Y].Cells[i]);
                    }
                    else if (gardenGrid.Rows[temp.Y].Cells[i].Style.BackColor == Color.Black)
                    {
                        obstacles.Enqueue(new Point(i, temp.Y));
                        break;
                    }
                }
            }
        }

        private async void DFS(int x, int y, List<DataGridViewCell> visited, int delay)
        {
            if (x < 0 || x > gardenGrid.ColumnCount - 1 || y < 0 || y > gardenGrid.RowCount - 1)
            {
                return;
            }
            DataGridViewCell cell = gardenGrid.Rows[y].Cells[x];
            if (visited.Contains(cell))
            {
                return;
            }

            if (cell.Style.BackColor == Color.Black)
            {
                if (!visited.Contains(cell))
                {
                    visited.Add(cell);
                }
            }
            else
            {
                PlaceLawnmower(x, y, delay);
                visited.Add(cell);

                await Task.Delay(delay);
                DFS(x + 1, y, visited, delay);

                await Task.Delay(delay);
                DFS(x - 1, y, visited, delay);

                await Task.Delay(delay);
                DFS(x, y - 1, visited, delay);

                await Task.Delay(delay);
                DFS(x, y + 1, visited, delay);
            }
        }
        private async void BFS(int x, int y, int delay)
        {
            List<DataGridViewCell> queue = new List<DataGridViewCell>();
            DataGridViewCell cell = null;

            queue.Add(gardenGrid.Rows[y].Cells[x]);
            int i = 0;
            while (queue.Count > i)
            {
                cell = queue[i];
                visited.Add(cell);
                i++;
                if (cell.Style.BackColor != Color.Black)
                {
                    await Task.Delay(delay);

                    PlaceLawnmower(cell.OwningColumn.Index, cell.OwningRow.Index, delay);
                    
                    if (cell.OwningRow.Index + 1 >= 0 && cell.OwningRow.Index + 1 < gardenGrid.RowCount && !queue.Contains(gardenGrid.Rows[cell.OwningRow.Index + 1].Cells[cell.OwningColumn.Index]))
                    {
                        queue.Add(gardenGrid.Rows[cell.OwningRow.Index + 1].Cells[cell.OwningColumn.Index]);
                    }
                    if (cell.OwningRow.Index - 1 >= 0 && cell.OwningRow.Index - 1 < gardenGrid.RowCount && !queue.Contains(gardenGrid.Rows[cell.OwningRow.Index - 1].Cells[cell.OwningColumn.Index]))
                    {
                        queue.Add(gardenGrid.Rows[cell.OwningRow.Index - 1].Cells[cell.OwningColumn.Index]);
                    }
                    if (cell.OwningColumn.Index + 1 >= 0 && cell.OwningColumn.Index + 1 < gardenGrid.ColumnCount && !queue.Contains(gardenGrid.Rows[cell.OwningRow.Index].Cells[cell.OwningColumn.Index + 1]))
                    {
                        queue.Add(gardenGrid.Rows[cell.OwningRow.Index].Cells[cell.OwningColumn.Index + 1]);
                    }
                    if (cell.OwningColumn.Index - 1 >= 0 && cell.OwningColumn.Index - 1 < gardenGrid.ColumnCount && !queue.Contains(gardenGrid.Rows[cell.OwningRow.Index].Cells[cell.OwningColumn.Index - 1]))
                    {
                        queue.Add(gardenGrid.Rows[cell.OwningRow.Index].Cells[cell.OwningColumn.Index - 1]);
                    }
                }
            }
        }

        private async void LineFill2(int curCol, int curRow, int delay)
        {
            foreach (DataGridViewRow row in gardenGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor == Color.DarkGreen)
                    {
                        await Task.Delay(delay);

                        PlaceLawnmower(cell.ColumnIndex, cell.RowIndex, delay);
                    }
                    else if (cell.Style.BackColor == Color.Black)
                    {
                        break;
                    }
                }
            }

            List<DataGridViewCell> cellsLeft = new List<DataGridViewCell>();
            foreach (DataGridViewRow row in gardenGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor == Color.DarkGreen)
                    {
                        cellsLeft.Add(cell);
                    }
                }
            }

            foreach (DataGridViewCell cell in cellsLeft)
            {
                if (BFSForLeftover(cell))
                {
                    await Task.Delay(delay);

                    PlaceLawnmower(cell.ColumnIndex, cell.RowIndex, delay);
                }
                else
                {
                    cell.Style.BackColor = Color.Red;
                }
            }
        }

        private bool BFSForLeftover(DataGridViewCell start)
        {
            visited.Clear();
            rowQ.Clear();
            colQ.Clear();

            bool endReached = false;

            rowQ.Enqueue(start.RowIndex);
            colQ.Enqueue(start.ColumnIndex);

            visited.Add(start);

            while(rowQ.Count > 0)
            {
                int actRow = rowQ.Dequeue();
                int actCol = colQ.Dequeue();

                if (gardenGrid.Rows[actRow].Cells[actCol] == gardenGrid.Rows[0].Cells[0])
                {
                    endReached = true;
                    break;
                }

                FindAdjacent(actRow, actCol);
            }

            return endReached;
        }

        private void FindAdjacent(int row, int col)
        {
            for (int i = 0; i < 4; i++)
            {
                int nextRow = row + dirRow[i];
                int nextCol = col + dirCol[i];

                if (nextRow < 0 || nextCol < 0)
                {
                    continue;
                }
                if (nextRow >= gardenGrid.RowCount || nextCol >= gardenGrid.ColumnCount)
                {
                    continue;
                }

                if (visited.Contains(gardenGrid.Rows[nextRow].Cells[nextCol]))
                {
                    continue;
                }
                if (gardenGrid.Rows[nextRow].Cells[nextCol].Style.BackColor == Color.Black)
                {
                    visited.Add(gardenGrid.Rows[nextRow].Cells[nextCol]);
                    continue;
                }

                rowQ.Enqueue(nextRow);
                colQ.Enqueue(nextCol);
                visited.Add(gardenGrid.Rows[nextRow].Cells[nextCol]);
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            visited.Clear();

            int delay = 0;
            if ((string)selSpeedComboBox.SelectedItem == "1x")
            {
                delay = 500; 
            }
            else if ((string)selSpeedComboBox.SelectedItem == "2x")
            {
                delay = 250;
            }
            else if ((string)selSpeedComboBox.SelectedItem == "3x")
            {
                delay = 100;
            }

            if (gardenGrid == null)
            {
                MessageBox.Show("No garden generated yet!");
            }
            else
            {
                if ((string)algoSelComboBox.SelectedItem == "DFS")
                {
                    DFS(0, 0, visited, delay);
                }
                else if ((string)algoSelComboBox.SelectedItem == "BFS")
                {
                    BFS(0, 0, delay);
                }
                else if ((string)algoSelComboBox.SelectedItem == "LineFill")
                {
                    LineFill(0, 0, delay);
                }
                else if ((string)algoSelComboBox.SelectedItem == "LineFill2")
                {
                    LineFill2(0, 0, delay);
                }
            }

            this.startBtn.Visible = false;
            this.checkResBtn.Visible = true;
        }

        private void checkResBtn_Click(object sender, EventArgs e)
        {
            int totalCells = gardenGrid.RowCount * gardenGrid.ColumnCount;
            int obstacles = Obstacles();
            int completedCells = 0;
            int missed = 0;
            bool success;
            foreach (DataGridViewRow row in gardenGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor == Color.DarkGreen)
                    {
                        missed++;
                    }
                    else if (cell.Style.BackColor == Color.LightGreen)
                    {
                        completedCells++;
                    }
                }
            }
            success = missed == 0;

            this.checkResBtn.Visible = false;

            MessageBox.Show($"Total cells in garden: {totalCells}\nObstacles: {obstacles}\nMowed cells: {completedCells}\nMissed: {missed}\nSuccess?: {success}");
        }

        private void gardenSet1Btn_Click(object sender, EventArgs e)
        {
            if (gardenGrid != null)
            {
                gardenGrid.Dispose();
            }

            this.checkResBtn.Visible = false;

            visited = new List<DataGridViewCell>();

            gardenGrid = new DataGridView();

            gardenGrid.ReadOnly = true;

            gardenGrid.ColumnHeadersVisible = false;
            gardenGrid.RowHeadersVisible = false;

            gardenGrid.Size = new Size(800, 542);
            gardenGrid.Location = new Point(40, 70);

            gardenGrid.RowCount = 8;
            gardenGrid.ColumnCount = 8;

            gardenGrid.Rows[0].Cells[0].Style.BackColor = Color.DarkGreen;

            foreach (DataGridViewRow row in gardenGrid.Rows)
            {
                row.Height = (gardenGrid.ClientRectangle.Height - gardenGrid.ColumnHeadersHeight) / gardenGrid.Rows.Count;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningRow.Index != 0 || cell.OwningColumn.Index != 0)
                    {
                        cell.Style.BackColor = Color.Black;
                    }
                }
            }

            gardenGrid.Enabled = false;
            gardenGrid.RowsDefaultCellStyle.SelectionBackColor = gardenGrid.Rows[0].Cells[0].Style.BackColor;
            gardenGrid.RowsDefaultCellStyle.SelectionForeColor = gardenGrid.Rows[0].Cells[0].Style.ForeColor;
            gardenGrid.DefaultCellStyle.Font = new Font("Tahoma", 20);
            gardenGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Controls.Add(gardenGrid);

            this.startBtn.Visible = true;
        }

        private void gardenSet2Btn_Click(object sender, EventArgs e)
        {
            if (gardenGrid != null)
            {
                gardenGrid.Dispose();
            }

            this.checkResBtn.Visible = false;

            visited = new List<DataGridViewCell>();

            gardenGrid = new DataGridView();

            gardenGrid.ReadOnly = true;

            gardenGrid.ColumnHeadersVisible = false;
            gardenGrid.RowHeadersVisible = false;

            gardenGrid.Size = new Size(800, 542);
            gardenGrid.Location = new Point(40, 70);

            gardenGrid.RowCount = 8;
            gardenGrid.ColumnCount = 8;

            gardenGrid.Rows[0].Cells[0].Style.BackColor = Color.DarkGreen;

            foreach (DataGridViewRow row in gardenGrid.Rows)
            {
                row.Height = (gardenGrid.ClientRectangle.Height - gardenGrid.ColumnHeadersHeight) / gardenGrid.Rows.Count;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.DarkGreen;
                }
            }

            int j = gardenGrid.ColumnCount - 1;
            for (int i = 0; i < gardenGrid.RowCount; i++)
            {
                gardenGrid.Rows[i].Cells[j].Style.BackColor = Color.Black;
                j--;
            }

            gardenGrid.Enabled = false;
            gardenGrid.RowsDefaultCellStyle.SelectionBackColor = gardenGrid.Rows[0].Cells[0].Style.BackColor;
            gardenGrid.RowsDefaultCellStyle.SelectionForeColor = gardenGrid.Rows[0].Cells[0].Style.ForeColor;
            gardenGrid.DefaultCellStyle.Font = new Font("Tahoma", 20);
            gardenGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Controls.Add(gardenGrid);

            this.startBtn.Visible = true;
        }
    }
}
