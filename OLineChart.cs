namespace Org.Ochilab.OSimpleD3Wrapper
{
    class OLineChart
    {
        //RingArray<PerformanceInfo>[] list =new RingArray<PerformanceInfo>[3];
        //RingArray<PerformanceInfo>list =new RingArray<PerformanceInfo>(200);
        RingArray<PerformanceInfo>[] ring = new RingArray<PerformanceInfo>[3];

        EnumerableDataSource<PerformanceInfo>[] ds = new EnumerableDataSource<PerformanceInfo>[3];

        LineGraph[] chart = new LineGraph[3];
        private ChartPlotter cp;
       // LineGraph[] line = new LineGraph[3];
        Color[] lineColor = new Color[3];

        /**
         * コンストラクタ。
         * CP:描画するChartPlotterのインスタンスを受け取る
         * num ：グラフの数。最大3
         * 
         * */
        public OLineChart(ChartPlotter cp, int num)
        {

            this.cp = cp;
            
            //ペンの色を設定
            lineColor[0] = Colors.Red;
            lineColor[1] = Colors.Blue;
            lineColor[2] = Colors.Green;

            for (int i = 0; i < num; i++)
            {
                ring[i] = new RingArray<PerformanceInfo>(200);
                ds[i] = new EnumerableDataSource<PerformanceInfo>(ring[i]);
                ds[i].SetXMapping(pi => pi.Time);
                ds[i].SetYMapping(pi => pi.Value);
                chart[i] = cp.AddLineGraph(ds[i],lineColor[i],1.0);
                
            }

            cp.LegendVisible = false;
        }

        public void add(int id, int x, int y)
        {
            ring[id].Add(new PerformanceInfo(x, y));
            chart[id].DataSource = null;
            chart[id].DataSource = ds[id];

        }


        public void Visibility(int status)
        {
            switch (status)
            {
                case 7:
                    chart[0].Visibility = System.Windows.Visibility.Visible;
                    chart[1].Visibility = System.Windows.Visibility.Visible;
                    chart[2].Visibility = System.Windows.Visibility.Visible;
                    break;
                case 6:
                    chart[0].Visibility = System.Windows.Visibility.Visible;
                    chart[1].Visibility = System.Windows.Visibility.Visible;
                    chart[2].Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case 5:
                    chart[0].Visibility = System.Windows.Visibility.Visible;
                    chart[1].Visibility = System.Windows.Visibility.Collapsed;
                    chart[2].Visibility = System.Windows.Visibility.Visible;
                    break;
                case 4:
                    chart[0].Visibility = System.Windows.Visibility.Visible;
                    chart[1].Visibility = System.Windows.Visibility.Collapsed;
                    chart[2].Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case 3:
                    chart[0].Visibility = System.Windows.Visibility.Collapsed;
                    chart[1].Visibility = System.Windows.Visibility.Visible;
                    chart[2].Visibility = System.Windows.Visibility.Visible;
                    break;
                case 2:
                    chart[0].Visibility = System.Windows.Visibility.Collapsed;
                    chart[1].Visibility = System.Windows.Visibility.Visible;
                    chart[2].Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case 1:
                    chart[0].Visibility = System.Windows.Visibility.Collapsed;
                    chart[1].Visibility = System.Windows.Visibility.Collapsed;
                    chart[2].Visibility = System.Windows.Visibility.Visible;
                    break;
                case 0:
                    chart[0].Visibility = System.Windows.Visibility.Collapsed;
                    chart[1].Visibility = System.Windows.Visibility.Collapsed;
                    chart[2].Visibility = System.Windows.Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }

        public void Initialized(int id) 
        {
            chart[id].Remove();
        }

    }

    class PerformanceInfo
    {
        public PerformanceInfo()
        {
        }
        public PerformanceInfo(int time, int value)
        {
            Time = time;
            Value = value;

        }
        public int Time { get; set; }
        public int Value { get; set; }
    }
}
