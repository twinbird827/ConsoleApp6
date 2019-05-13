using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp6
{
    class AsyncTimer
    {
        public AsyncTimer()
        {
            Timer = new Timer(1);
            Timer.Elapsed += (sender, e) =>
            {
                Timer.Stop();

                if (CanExecute && NextExecuteDate <= DateTime.Now)
                {
                    CanExecute = false;
                    NextExecuteDate = NextExecuteDate + Interval;

                    Tick.Invoke(sender, e);
                }

                Timer.Start();
            };
        }

        /// <summary>
        /// 内部的に利用するﾀｲﾏｰ
        /// </summary>
        private Timer Timer { get; set; }

        /// <summary>
        /// 最後にｲﾍﾞﾝﾄを発行した日時
        /// </summary>
        private DateTime NextExecuteDate { get; set; }

        /// <summary>
        /// 1回のｲﾍﾞﾝﾄが完了したかどうか
        /// </summary>
        private bool CanExecute { get; set; } = true;

        /// <summary>
        /// ﾀｲﾏｰの起動間隔
        /// </summary>
        public TimeSpan Interval { get; set; } = TimeSpan.FromMilliseconds(1);

        /// <summary>
        /// ﾀｲﾏｰを起動します。
        /// </summary>
        public void Start()
        {
            NextExecuteDate = DateTime.Now + Interval;
            Timer.Start();
        }

        /// <summary>
        /// ﾀｲﾏｰを停止します。
        /// </summary>
        public void Stop()
        {
            Timer.Stop();
        }

        /// <summary>
        /// ｲﾍﾞﾝﾄが完了したことを通知します。
        /// </summary>
        public void Completed()
        {
            CanExecute = true;
        }

        /// <summary>
        /// 指定した間隔で実行するｲﾍﾞﾝﾄ
        /// </summary>
        public event EventHandler Tick;
    }
}
