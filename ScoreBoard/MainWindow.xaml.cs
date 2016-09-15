using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ScoreBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer tymer;
        TimeSpan tyme;
        public MainWindow()
        {
            InitializeComponent();
            tyme = TimeSpan.FromSeconds(1200);

            tymer = new DispatcherTimer(new TimeSpan(0,0, 1), DispatcherPriority.Normal, delegate
            {
                string fex = tyme.ToString("c");
                gtime.Text = fex.Substring(3);
                if (tyme == TimeSpan.Zero)
                {
                    tymer.Stop();
                    if (First.IsChecked == true)
                    {
                        tyme = tyme.Add(TimeSpan.FromSeconds(1200));
                        Second.IsChecked = true;
                        tymer.Start();
                    }
                    else if (Second.IsChecked == true)
                    {
                        int sa = getAscore();
                        int sb = getBscore();
                        if (sa == sb)
                        {
                            tyme = tyme.Add(TimeSpan.FromSeconds(300));
                            Overtime.IsChecked = true;
                            tymer.Start();
                        }
                    }
                }
                tyme = tyme.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
              tymer.Stop();
            
        }
        public int getAscore()
        {
            string b = scoreA.Text;
            int a = Int32.Parse(b);
            return a;
        }
        public int getBscore()
        {
            string b = scoreB.Text;
            int a = Int32.Parse(b);
            return a;
        }

        private void teamA2_Click(object sender, RoutedEventArgs e)
        {
            int x = getAscore();
            x = x + 2;
            scoreA.Text = x+"";
        }

        private void teamB2_Click(object sender, RoutedEventArgs e)
        {
            int x = getBscore();
            x = x + 2;
            scoreB.Text = x + "";
        }

        private void teamA3_Click(object sender, RoutedEventArgs e)
        {
            int x = getAscore();
            x = x + 3;
            scoreA.Text = x + "";
        }

        private void teamB3_Click(object sender, RoutedEventArgs e)
        {
            int x = getBscore();
            x = x + 3;
            scoreB.Text = x + "";
        }

        private void teamAFT_Click(object sender, RoutedEventArgs e)
        {
            int x = getAscore();
            x++;
            scoreA.Text = x + "";
        }

        private void teamBFT_Click(object sender, RoutedEventArgs e)
        {
            int x = getBscore();
            x++;
            scoreB.Text = x + "";
        }
        private void Checknumber(TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }
        }

        private void score_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Checknumber(e);
        }

        int kstart = 0;
        private void button_Click(object sender, RoutedEventArgs e)
        {
        if (kstart == 0)
            {
                tymer.Start();
                kstart = 1;
            } else
            {
                tymer.Stop();
                kstart = 0;
            }
        }
        int[] Apts = new int[12];
        int[] Arebs = new int[12];
        int[] Aasts = new int[12];
        private void TeamAPlayers_DropDownClosed(object sender, EventArgs e)
        {
            int ac = TeamAPlayers.SelectedIndex;
            if (ac != -1)
            {
                pointsPA.Text = Apts[ac] + "";
                rebsPA.Text = Arebs[ac] + "";
                astsPA.Text = Aasts[ac] + "";
            }
        }
        int[] Bpts = new int[12];
        int[] Brebs = new int[12];
        int[] Basts = new int[12];
        private void TeamBPlayers_DropDownClosed(object sender, EventArgs e)
        {
            int bc = TeamBPlayers.SelectedIndex;
            if (bc !=-1)
            {
                pointsPB.Text = Bpts[bc] + "";
                rebsPB.Text = Brebs[bc] + "";
                astsPB.Text = Basts[bc] + "";
            }
        }

        private void TeamAPlayers_DropDownOpened(object sender, EventArgs e)
        {
            int v;
            int ao = TeamAPlayers.SelectedIndex;
            if (ao != -1)
            {
                v = Back2Int(pointsPA.Text);
                Apts[ao] = v;
                v = Back2Int(rebsPA.Text);
                Arebs[ao] = v;
                v = Back2Int(astsPA.Text);
                Aasts[ao] = v;
            }
        }

        private void TeamBPlayers_DropDownOpened(object sender, EventArgs e)
        {
            int v;
            int bo = TeamBPlayers.SelectedIndex;
            if (bo != -1)
            {
                v = Back2Int(pointsPB.Text);
                Bpts[bo] = v;
                v = Back2Int(rebsPB.Text);
                Brebs[bo] = v;
                v = Back2Int(astsPB.Text);
                Basts[bo] = v;
            }
        }

        public int Back2Int(string x)
        {

            int a = Int32.Parse(x);
            return a;

        }
        Opshuns optionz = new Opshuns();
        private void options_Click(object sender, RoutedEventArgs e)
        {
            tymer.Stop();
            Window popup = new Window();
            optionz.button.Click += specialK;
            optionz.button1.Click += specialKay;
            optionz.button2.Click += special1K;
            optionz.button3.Click += specialC;
            updatenml();
            popup.Height = 400;
            popup.Width = 400;
            popup.Content = optionz;
            popup.Show();
        }
        private void specialK (object sender, RoutedEventArgs e)
        {
            TeamA.Content = optionz.NTA.Text;
        }
        private void specialKay(object sender, RoutedEventArgs e)
        {
            TeamB.Content = optionz.NTB.Text;
        }
        private void special1K(object sender, RoutedEventArgs e)
        {
            int ax = optionz.comboBox.SelectedIndex;
            if (ax != -1)
            {
                TferA(ax);
                updateVvsa();
            }
        }
        private void specialC(object sender, RoutedEventArgs e)
        {
            int ax = optionz.comboBoxB.SelectedIndex;
            if (ax != -1)
            {
                TferB(ax);
                updateVvsa();
            }
        }
        public void updatenml()
        {
            optionz.NP1.Content = APlayer1.Content;
            optionz.NP2.Content = APlayer2.Content;
            optionz.NP3.Content = APlayer3.Content;
            optionz.NP4.Content = APlayer4.Content;
            optionz.NP5.Content = APlayer5.Content;
            optionz.NP6.Content = APlayer6.Content;
            optionz.NP7.Content = APlayer7.Content;
            optionz.NP8.Content = APlayer8.Content;
            optionz.NP9.Content = APlayer9.Content;
            optionz.NP10.Content = APlayer10.Content;
            optionz.NP11.Content = APlayer11.Content;
            optionz.NP12.Content = APlayer12.Content;
            optionz.BNP1.Content = BPlayer1.Content;
            optionz.BNP2.Content = BPlayer2.Content;
            optionz.BNP3.Content = BPlayer3.Content;
            optionz.BNP4.Content = BPlayer4.Content;
            optionz.BNP5.Content = BPlayer5.Content;
            optionz.BNP6.Content = BPlayer6.Content;
            optionz.BNP7.Content = BPlayer7.Content;
            optionz.BNP8.Content = BPlayer8.Content;
            optionz.BNP9.Content = BPlayer9.Content;
            optionz.BNP10.Content = BPlayer10.Content;
            optionz.BNP11.Content = BPlayer11.Content;
            optionz.BNP12.Content = BPlayer12.Content;
        }
        public void updateVvsa()
        {
            APlayer1.Content= optionz.NP1.Content;
            APlayer2.Content= optionz.NP2.Content;
            APlayer3.Content= optionz.NP3.Content;
            APlayer4.Content= optionz.NP4.Content;
            APlayer5.Content= optionz.NP5.Content;
            APlayer6.Content= optionz.NP6.Content;
            APlayer7.Content= optionz.NP7.Content;
            APlayer8.Content= optionz.NP8.Content;
            APlayer9.Content= optionz.NP9.Content;
            APlayer10.Content= optionz.NP10.Content;
            APlayer11.Content= optionz.NP11.Content;
            APlayer12.Content= optionz.NP12.Content;
            BPlayer1.Content= optionz.BNP1.Content;
            BPlayer2.Content= optionz.BNP2.Content;
            BPlayer3.Content= optionz.BNP3.Content;
            BPlayer4.Content= optionz.BNP4.Content;
            BPlayer5.Content= optionz.BNP5.Content;
            BPlayer6.Content= optionz.BNP6.Content;
            BPlayer7.Content= optionz.BNP7.Content;
            BPlayer8.Content= optionz.BNP8.Content;
            BPlayer9.Content= optionz.BNP9.Content;
            BPlayer10.Content= optionz.BNP10.Content;
            BPlayer11.Content= optionz.BNP11.Content;
            BPlayer12.Content= optionz.BNP12.Content;
        }
        public void TferA(int a)
        {
           if (a == 0)
            {
                optionz.NP1.Content = optionz.NPA.Text;
            }
            if (a == 1)
            {
                optionz.NP2.Content = optionz.NPA.Text;
            }
            if (a == 2)
            {
                optionz.NP3.Content = optionz.NPA.Text;
            }
            if (a == 3)
            {
                optionz.NP4.Content = optionz.NPA.Text;
            }
            if (a == 4)
            {
                optionz.NP5.Content = optionz.NPA.Text;
            }
            if (a == 5)
            {
                optionz.NP6.Content = optionz.NPA.Text;
            }
            if (a == 6)
            {
                optionz.NP7.Content = optionz.NPA.Text;
            }
            if (a == 7)
            {
                optionz.NP8.Content = optionz.NPA.Text;
            }
            if (a == 8)
            {
                optionz.NP9.Content = optionz.NPA.Text;
            }
            if (a == 9)
            {
                optionz.NP10.Content = optionz.NPA.Text;
            }
            if (a == 10)
            {
                optionz.NP11.Content = optionz.NPA.Text;
            }
            if (a == 11)
            {
                optionz.NP12.Content = optionz.NPA.Text;
            }
        }
        public void TferB(int a)
        {
            if (a == 0)
            {
                optionz.BNP1.Content = optionz.NPB.Text;
            }
            if (a == 1)
            {
                optionz.BNP2.Content = optionz.NPB.Text;
            }
            if (a == 2)
            {
                optionz.BNP3.Content = optionz.NPB.Text;
            }
            if (a == 3)
            {
                optionz.BNP4.Content = optionz.NPB.Text;
            }
            if (a == 4)
            {
                optionz.BNP5.Content = optionz.NPB.Text;
            }
            if (a == 5)
            {
                optionz.BNP6.Content = optionz.NPB.Text;
            }
            if (a == 6)
            {
                optionz.BNP7.Content = optionz.NPB.Text;
            }
            if (a == 7)
            {
                optionz.BNP8.Content = optionz.NPB.Text;
            }
            if (a == 8)
            {
                optionz.BNP9.Content = optionz.NPB.Text;
            }
            if (a == 9)
            {
                optionz.BNP10.Content = optionz.NPB.Text;
            }
            if (a == 10)
            {
                optionz.BNP11.Content = optionz.NPB.Text;
            }
            if (a == 11)
            {
                optionz.BNP12.Content = optionz.NPB.Text;
            }
        }
    }
}
