using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Sqlite3Accessor : IDisposable
    {
        /// <summary>
        /// SQLite3ｱｸｾｽ用ｲﾝｽﾀﾝｽを生成します。
        /// </summary>
        private Sqlite3Accessor(string path)
        {
            var work = System.AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');

            var connectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = Path.Combine(work, path),
                DefaultIsolationLevel = System.Data.IsolationLevel.ReadCommitted,
                SyncMode = SynchronizationModes.Off,
                JournalMode = SQLiteJournalModeEnum.Wal
            };

            conn = new SQLiteConnection(connectionString.ToString());
            conn.Open();

            context = new DataContext(conn);
        }

        /// <summary>
        /// ｺﾈｸｼｮﾝ
        /// </summary>
        private SQLiteConnection conn;

        /// <summary>
        /// Linq用ｺﾝﾃｷｽﾄ
        /// </summary>
        private DataContext context;

        public static Sqlite3Accessor GetAccessor()
        {
            return GetAccessor(@"lib\database.sqlite3");
        }

        public static Sqlite3Accessor GetAccessor(string path)
        {
            return new Sqlite3Accessor(path);
        }

        /// <summary>
        /// SQLｺﾏﾝﾄﾞを取得します。
        /// </summary>
        /// <returns></returns>
        public Sqlite3Command GetCommand()
        {
            return new Sqlite3Command(conn);
        }

        /// <summary>
        /// Linq用に任意のﾃｰﾌﾞﾙを取得します。
        /// </summary>
        /// <typeparam name="T">ﾃｰﾌﾞﾙ</typeparam>
        /// <returns></returns>
        public Table<T> GetTables<T>() where T : class
        {
            return context.GetTable<T>();
        }

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)。
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }

                    if (conn != null)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
                // TODO: 大きなフィールドを null に設定します。

                disposedValue = true;
            }
        }

        // TODO: 上の Dispose(bool disposing) にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
        // ~Sqlite3Accessor() {
        //   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
        //   Dispose(false);
        // }

        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(true);
            // TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
