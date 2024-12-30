using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KaedeAsset.KaedeScript.View
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            // Debug.Log("LoadScene");
                
            // シーンの非同期読み込みをObservableとしてラップ
            Observable.FromCoroutine(() => LoadSceneAsync(sceneName))
                .Subscribe(
                    _ => { }, // シーン読み込み中の処理（例えば、進捗状況の表示など）
                    () => Debug.Log("LoadScene loaded successfully.") // 読み込み完了時の処理
                );
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            // 非同期操作が完了するまで待機
            while (!asyncOperation.isDone)
            {
                // 進捗状況に基づいて何かをする（例：ロードバーの更新）
                yield return null;
            }
        }
    }
}