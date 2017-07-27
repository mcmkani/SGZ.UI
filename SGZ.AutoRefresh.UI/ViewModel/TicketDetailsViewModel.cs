using SGZ.AutoRefresh.UI;
using SGZ.DataAccess;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SGZ.AutoRefresh.UI
{
    public class TicketDetailsViewModel : NotificationObject, IDisposable
    {

        ObservableCollection<tbl_tickets> data;
        Random r = new Random(123345345);
        internal DispatcherTimer timer;
        private bool enableTimer = false;        
        private double timerValue;        
        private int noOfUpdates = 500;

        public ObservableCollection<tbl_tickets> listTicketDetails
        {
            get
            {
                return this.data;
            }
        }

        public TicketDetailsViewModel()
        {
            this.data = new ObservableCollection<tbl_tickets>();

            //listTicketDetails = new ObservableCollection<tbl_tickets>();
            this.RefreshData();

            this.timer = new DispatcherTimer();
            this.ResetRefreshFrequency(2500);
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
            //btonClick = new DelegateCommand<object>(ButtonClicked, CanButtonClick);

        }

        public void SetInterval(TimeSpan time)
        {
            this.timer.Interval = time;
        }

        public void StartTimer()
        {
            if (!this.timer.IsEnabled)
            {
                this.timer.Start();
                //this.ButtonContnt = "Stop Timer";
            }
        }

        /// <summary>
        /// Gets or sets the timer value.
        /// </summary>
        /// <value>The timer value.</value>
        public double TimeSpanValue
        {
            get
            {
                return timerValue;
            }
            set
            {
                timerValue = value;
                this.timer.Interval = TimeSpan.FromMilliseconds(timerValue);
                RaisePropertyChanged("TimeSpanValue");
            }
        }
                
        /// <summary>
        /// Determines whether this instance [can button click].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance [can button click]; otherwise, <c>false</c>.
        /// </returns>
        bool CanButtonClick(object param)
        {
            return true;
        }


        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void StopTimer()
        {
            this.timer.Stop();
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, object e)
        {
            int startTime = DateTime.Now.Millisecond;
            RefreshData();
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enable timer].
        /// </summary>
        /// <value><c>true</c> if [enable timer]; otherwise, <c>false</c>.</value>
        public bool EnableTimer
        {
            get
            {
                return this.enableTimer;
            }
            set
            {
                this.enableTimer = value;
            }
        }


        public void ResetRefreshFrequency(int changesPerTick)
        {
            if (this.timer == null)
            {
                return;
            }

            if (!this.noOfUpdates.Equals(changesPerTick))
            {
                this.StopTimer();
                this.noOfUpdates = changesPerTick;
                if (enableTimer)
                    this.StartTimer();
            }
        }

        public void Dispose()
        {
            if (this.timer != null)
            {
                this.timer.Tick -= timer_Tick;
                this.StopTimer();
            }
        }
        
        private void RefreshData()
        {
            TicketDetails dataRepository = new TicketDetails();
            listTicketDetails.Clear();
            var getData = dataRepository.TicketInfo;            
            foreach(var item in getData)
            {
                listTicketDetails.Add(item);
            }
        }

    }
}
