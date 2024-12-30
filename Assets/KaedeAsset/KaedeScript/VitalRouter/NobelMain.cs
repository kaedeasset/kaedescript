using System.Threading.Tasks;
using KaedeAsset.KaedeScript.Presenter;
using UnityEngine;
using VContainer.Unity;

namespace KaedeAsset.KaedeScript.VitalRouter
{
    /// <summary>
    /// Main controller for Novel system
    /// ノベルシステムのメインコントローラー
    /// </summary>
    public class NobelMain: IStartable
    {
        private readonly NobelPresenter _nobelPresenter;
        private readonly VCVitalRouterMRubyTest _vCVitalRouterMRubyTest;

        /// <summary>
        /// Constructor - Initializes Novel system components
        /// コンストラクタ - ノベルシステムのコンポーネントを初期化
        /// </summary>
        public NobelMain(NobelPresenter  nobelPresenter, 
            VCVitalRouterMRubyTest vCVitalRouterMRubyTest)
        {
            Debug.Log("NobelMain Constructor");
            _nobelPresenter = nobelPresenter;
            _vCVitalRouterMRubyTest = vCVitalRouterMRubyTest;
        }       
        
        /// <summary>
        /// Entry point for the Novel system
        /// ノベルシステムのエントリーポイント
        /// </summary>
        public async void Start()
        {
            Debug.Log("NobelMain Start");
            await NobelRunAsync();
        }

        /// <summary>
        /// Main execution flow for Novel system
        /// Loads and runs the novel script files
        /// ノベルシステムのメイン実行フロー
        /// ノベルスクリプトファイルの読み込みと実行を行う
        /// </summary>
        async Task NobelRunAsync()
        {
            Debug.Log("NobelMain NobelRunAsync");
            
            // Load initial script file
            // 初期スクリプトファイルの読み込み
            var result = _vCVitalRouterMRubyTest.Load("Ruby01/Ksload1.ruby");
            if (!result.Equals("ok"))
            {
                Debug.LogError($"NobelMain NobelRunAsync Error {result}");
            }

            // Execute text display script
            // テキスト表示スクリプトの実行
            string sf;
            //sf = "Ruby01/KsFile2img.ruby";
            //await _vCVitalRouterMRubyTest.RunAsync(sf);
            
            //sf = "Ruby01/KsFile3text.ruby";
            //await _vCVitalRouterMRubyTest.RunAsync(sf);
            
            sf = "Ruby01/KsFile1.ruby";
            await _vCVitalRouterMRubyTest.RunAsync(sf);
            
            sf = "Ruby01/ksFile5voice.ruby";
            await _vCVitalRouterMRubyTest.RunAsync(sf);
            
            sf = "Ruby01/KsFile4choice.ruby";
            await _vCVitalRouterMRubyTest.RunAsync(sf);
            
            if (!result.Equals("ok"))
            {
                Debug.LogError($"NobelMain NobelRunAsync Error {result}");
            }
        }
    }       
}