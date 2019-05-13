using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Sqlite3Command : IDisposable
    {
        /// <summary>
        /// SQLite3ｱｸｾｽ用ｲﾝｽﾀﾝｽを生成します。
        /// </summary>
        public Sqlite3Command(SQLiteConnection conn)
        {
            command = conn.CreateCommand();
        }

        /// <summary>
        /// ｺﾏﾝﾄﾞ
        /// </summary>
        private SQLiteCommand command;

        public async Task BeginTransaction()
        {
            await ExecuteNonQuery("BEGIN");
        }

        /// <summary>
        /// SQLを実行します。
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="parameters">SQLﾊﾟﾗﾒｰﾀ</param>
        /// <returns>影響を及ぼした件数</returns>
        public async Task<int> ExecuteNonQuery(string sql, params SQLiteParameter[] parameters)
        {
            command.CommandText = sql;
            command.Parameters.Clear();
            command.Parameters.AddRange(parameters);
            return await command.ExecuteNonQueryAsync();
        }

        public SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] parameters)
        {
            command.CommandText = sql;
            command.Parameters.Clear();
            command.Parameters.AddRange(parameters);
            return command.ExecuteReader();
        }
        /// <summary>
        /// SQLの実行結果を戻します。
        /// </summary>
        public async Task Rollback()
        {
            await ExecuteNonQuery("ROLLBACK");
        }

        /// <summary>
        /// SQLの実行結果を確定します。
        /// </summary>
        public async Task Commit()
        {
            await ExecuteNonQuery("COMMIT");
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
                    if (command != null)
                    {
                        if (command.Transaction != null)
                        {
                            command.Transaction.Dispose();
                            command.Transaction = null;
                        }
                        command.Dispose();
                        command = null;
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
