using System;
using System.Drawing;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;

namespace grafik_kaliiiiii
{
    public partial class Form1 : Form
    {
        private TabControl tabControl;
        private TabPage tabBar, tabLine, tabPie;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Dashboard Grafik Warung Makan";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            tabControl = new TabControl { Dock = DockStyle.Fill };
            tabBar = new TabPage("📊 Bar Chart");
            tabLine = new TabPage("📈 Line Chart");
            tabPie = new TabPage("🥧 Pie Chart");
            tabControl.TabPages.AddRange(new[] { tabBar, tabLine, tabPie });
            this.Controls.Add(tabControl);

            IsiBarChart();
            IsiLineChart();
            IsiPieChart();
        }

        // ── BAR CHART ─────────────────────────────────────────────
        private void IsiBarChart()
        {
            var model = new PlotModel { Title = "Penjualan Per Bulan (Porsi)" };

            // CategoryAxis HARUS di sumbu Y untuk BarSeries
            model.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = new[] { "Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Agu", "Sep", "Okt", "Nov", "Des" }
            });
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Jumlah Porsi",
                Minimum = 0
            });

            double[] dataMie = { 100, 60, 55, 70, 65, 80, 75, 90, 85, 100, 95, 110 };
            double[] dataBaks = { 30, 40, 35, 45, 42, 55, 50, 62, 58, 70, 65, 75 };
            double[] dataEst = { 80, 95, 88, 105, 98, 120, 112, 130, 125, 145, 138, 155 };

            var mieAyam = new BarSeries { Title = "Mie Ayam", FillColor = OxyColor.FromRgb(42, 120, 214) };
            var bakso = new BarSeries { Title = "Bakso", FillColor = OxyColor.FromRgb(27, 175, 122) };
            var esTeh = new BarSeries { Title = "Es Teh", FillColor = OxyColor.FromRgb(237, 161, 0) };

            for (int i = 0; i < 12; i++)
            {
                mieAyam.Items.Add(new BarItem(dataMie[i]));
                bakso.Items.Add(new BarItem(dataBaks[i]));
                esTeh.Items.Add(new BarItem(dataEst[i]));
            }

            model.Series.Add(mieAyam);
            model.Series.Add(bakso);
            model.Series.Add(esTeh);

            tabBar.Controls.Add(new PlotView { Model = model, Dock = DockStyle.Fill });
        }

        // ── LINE CHART ────────────────────────────────────────────
        private void IsiLineChart()
        {
            var model = new PlotModel { Title = "Keuangan Per Bulan kayaknya (Rp Ribu)" };
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Rp (Ribu)", Minimum = 0 });
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Bulan",
                Minimum = 1,
                Maximum = 12,
                LabelFormatter = v => {
                    string[] bln = { "", "Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Agu", "Sep", "Okt", "Nov", "Des" };
                    int idx = (int)v;
                    return (idx >= 1 && idx <= 12) ? bln[idx] : "";
                }
            });

            double[] pendapatan = { 1200, 1500, 1350, 1700, 1600, 1900, 1800, 2100, 2000, 2400, 2200, 2600 };
            double[] pengeluaran = { 800, 900, 850, 1000, 950, 1100, 1050, 1200, 1150, 1350, 1300, 1500 };
            double[] keuntungan = { 400, 600, 500, 700, 650, 800, 750, 900, 850, 1050, 900, 1100 };

            model.Series.Add(BuatLine("Pendapatan", pendapatan, OxyColor.FromRgb(42, 120, 214)));
            model.Series.Add(BuatLine("Pengeluaran", pengeluaran, OxyColor.FromRgb(227, 73, 72)));
            model.Series.Add(BuatLine("Keuntungan", keuntungan, OxyColor.FromRgb(27, 175, 122)));

            tabLine.Controls.Add(new PlotView { Model = model, Dock = DockStyle.Fill });
        }

        private LineSeries BuatLine(string judul, double[] data, OxyColor warna)
        {
            var series = new LineSeries
            {
                Title = judul,
                Color = warna,
                StrokeThickness = 2.5,
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerFill = warna,
            };
            for (int i = 0; i < data.Length; i++)
                series.Points.Add(new DataPoint(i + 1, data[i]));
            return series;
        }

        // ── PIE CHART ─────────────────────────────────────────────
        private void IsiPieChart()
        {
            var model = new PlotModel { Title = "Distribusi Penjualan Per Menu (%)" };

            var pie = new PieSeries
            {
                StrokeThickness = 1.5,
                InsideLabelPosition = 0.65,
                AngleSpan = 360,
                StartAngle = 0,
            };

            pie.Slices.Add(new PieSlice("Mie Ayam", 35) { Fill = OxyColor.FromRgb(42, 120, 214) });
            pie.Slices.Add(new PieSlice("Bakso", 25) { Fill = OxyColor.FromRgb(27, 175, 122) });
            pie.Slices.Add(new PieSlice("Es Teh", 20) { Fill = OxyColor.FromRgb(237, 161, 0) });
            pie.Slices.Add(new PieSlice("Nasi Goreng", 12) { Fill = OxyColor.FromRgb(74, 58, 167) });
            pie.Slices.Add(new PieSlice("Lainnya", 8) { Fill = OxyColor.FromRgb(227, 73, 72) });

            model.Series.Add(pie);
            tabPie.Controls.Add(new PlotView { Model = model, Dock = DockStyle.Fill });
        }
    }
}