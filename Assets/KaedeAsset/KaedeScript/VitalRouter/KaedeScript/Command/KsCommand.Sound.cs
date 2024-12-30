using Cysharp.Threading.Tasks;

using UnityEngine;

namespace KaedeAsset.KaedeScript.VitalRouter.KaedeScript.Command
{
    public partial class KsCommand
    {
        /// <summary>
        /// Plays audio using the provided PaCommand object.
        /// 指定されたPaCommandオブジェクトを使用してオーディオを再生します。
        /// </summary>
        /// <param name="cmd">The command containing the file name to play. 再生するファイル名を含むコマンド。</param>
        public void Pa(PaCommand cmd) // PlayAudio
        {
            Debug.Log($"KsCommand Pa {cmd.FileName} ");
            _nobelPresenter.PlayAudio(cmd.FileName);
            Debug.Log($"KsCommand Pa -2");
        }
        
        /// <summary>
        /// Plays audio using the provided file name.
        /// 指定されたファイル名を使用してオーディオを再生します。
        /// </summary>
        /// <param name="fileName">The name of the file to play. 再生するファイルの名前。</param>
        public void Pa(string fileName) // PlayAudio
        {
            Debug.Log($"KsCommand Pa {fileName} ");
            _nobelPresenter.PlayAudio(fileName);
            Debug.Log($"KsCommand Pa -2");
        }
        
        /// <summary>
        /// Delays execution for a specified number of milliseconds.
        /// 指定されたミリ秒数だけ実行を遅延させます。
        /// </summary>
        /// <param name="cmd">The command containing the delay duration in milliseconds. 遅延時間をミリ秒で含むコマンド。</param>
        public async UniTask Delay(DelayCommand cmd)
        {
            Debug.Log($"KsCommand Delay {cmd.MSec} ");
            if (cmd.MSec > 10000)
            {
                cmd.MSec = 10000;
                Debug.Log($"m={cmd.MSec}");
            }
            await UniTask.Delay(cmd.MSec);
            Debug.Log($"KsCommand Delay -2");
        }
    }
}