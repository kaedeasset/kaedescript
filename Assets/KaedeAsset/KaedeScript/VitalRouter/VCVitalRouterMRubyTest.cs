using System;
using System.Threading.Tasks;
using KaedeAsset.KaedeScript.Presenter;
using KaedeAsset.KaedeScript.View;
using KaedeAsset.KaedeScript.VitalRouter.KaedeScript;
using KaedeAsset.KaedeScript.VitalRouter.KaedeScript.Command;
using UnityEngine;
using VitalRouter;
using VitalRouter.MRuby;

namespace KaedeAsset.KaedeScript.VitalRouter
{
    public class VCVitalRouterMRubyTest
    {
        // Fields for presenter, view, and scene loader
        // プレゼンター、ビュー、シーンローダーのフィールド
        readonly NobelPresenter _nobelPresenter;
        readonly NovelView _novelView;
        readonly SceneLoader _sceneLoader; 
        MRubyContext _context;

        // Constructor to initialize the class with necessary components
        // 必要なコンポーネントでクラスを初期化するコンストラクタ
        protected VCVitalRouterMRubyTest(NovelView novelView, NobelPresenter novelPresenter, SceneLoader sceneLoader)
        {
            Debug.Log("VCVitalRouterMRubyTest Constructor");
            _novelView = novelView;
            _nobelPresenter = novelPresenter;
            _sceneLoader = sceneLoader;
            Initialization();
        }

        // Initialization method to set up MRuby context and command presets
        // MRubyコンテキストとコマンドプリセットを設定する初期化メソッド
        void Initialization()
        {
            Debug.Log("VCVitalRouterMRubyTest Initialization");
            var ksCommand = new KsCommand(_nobelPresenter);
            var presenter = new KsPresentor(ksCommand);
            presenter.MapTo(Router.Default);

            _context = MRubyContext.Create();
            _context.Router = Router.Default; // ... 1
            _context.CommandPreset = new KsCommandPreset(); // ... 2
            ksCommand.SetContext(_context);
            
            // Set shared state variables
            // 共有状態変数を設定
            _context.SharedState.Set("int_value", 1234);
            _context.SharedState.Set("selected_choice", 9);
            Debug.Log("VCVitalRouterMRubyTest Initialization-2");
        }

        // Method to load a Ruby script from a file
        // ファイルからRubyスクリプトを読み込むメソッド
        public string Load(string fileName)
        {
            var loadTxt = ReadAsset(fileName);
            try
            {
                _context.Load(loadTxt);
                return "ok";
            }
            catch (Exception ex)
            {
                Debug.Log($"Load Exception {ex}");
                return $"fail {ex}";
            }
        }

        // Asynchronous method to run a Ruby script
        // Rubyスクリプトを実行する非同期メソッド
        public async Task<string> RunAsync(string fileName)
        {
            var newFile = ReadAsset(fileName);
            try
            {
                using MRubyScript script1 = _context.CompileScript(newFile); 
                Debug.Log($"RunAsync");
                await script1.RunAsync();
                Debug.Log($"RunAsync-2 Executed");
                return "ok";
            }
            catch (Exception ex)
            {
                Debug.LogError($"RunAsync Exception {ex}");
                Debug.Log($"RunAsync-3");
                return $"fail {ex}";
            }
        }
        
        // Test method demonstrating command preset and script execution
        // コマンドプリセットとスクリプト実行を示すテストメソッド
        async Task Test6()
        {
            Debug.Log("Test6 KsCommandPreset");
            var ksCommand = new KsCommand(_nobelPresenter);
            
            var presenter = new KsPresentor(ksCommand);
            presenter.MapTo(Router.Default);
            
            _context = MRubyContext.Create();
            _context.Router = Router.Default;               // ... 1
            _context.CommandPreset = new KsCommandPreset(); // ... 2
            
            // Set shared state variables
            // 共有状態変数を設定
            _context.SharedState.Set("int_value", 1234);
            _context.SharedState.Set("selected_choice", 9);
            
            var loadTxt = ReadAsset("Ksload1");
            try
            {
                _context.Load(loadTxt);
            }
            catch (Exception ex)
            {
                Debug.Log($"Load Exception {ex}");
            }

            var newFile = ReadAsset("KsFile3text");
            try
            {
                using MRubyScript script1 = _context.CompileScript(newFile); 
                Debug.Log($"RunAsync");
                await script1.RunAsync();
            }
            catch (Exception ex)
            {
                Debug.Log($"RunAsync Exception {ex}");
            }
            
            Debug.Log("Test5 end");
        }

        // Update method called once per frame
        // フレームごとに呼び出されるUpdateメソッド
        void Update()
        {
        
        }

        // Method to read a text asset from the Resources folder
        // Resourcesフォルダからテキストアセットを読み込むメソッド
        string ReadAsset(string path)
        {
            Debug.Log($"ReadAsset {path}");
            TextAsset luaTextAsset = Resources.Load<TextAsset>(path);
            if (luaTextAsset == null)
            {
                Debug.LogError($"Script not found: {path}");
                return null;
            }

            string rubyScripts = luaTextAsset.text;
            Debug.Log($"ReadAsset {rubyScripts}");
            return rubyScripts;
        }
        
        // Test method demonstrating MRubyContext and script execution
        // MRubyContextとスクリプト実行を示すテストメソッド
        async Task Test1()
        {
            Debug.Log("Test");
            var presenter = new MyPresentor();
            presenter.MapTo(Router.Default);
            
            var context = MRubyContext.Create();
            context.Router = Router.Default;                // ... 1
            context.CommandPreset = new MyCommandPreset(); // ... 2
            var rubySource1 = "cmd :speak, id: 'Bob', text: 'Hello'";
            var rubySource2 = "cmd :move, id: 'Bob', to: [5, 5]";
            var rubySource3 = "cmd :speak2, id: 'Bob', text: 'Hello'";
            var rubySource4 = 
                "cmd :speak, id: 'Bob', text: 'Hello'\n" +
                "cmd :speak2, id: 'Bob', text: 'Hello'";

            var rubySource5 = "def speak(id, text) = cmd :speak, id:, text:" +
                              "speak 'Bob','Hello'";
            
#if true
            using MRubyScript script1 = context.CompileScript(rubySource1);    
            await script1.RunAsync();
#endif
            
#if false
            using MRubyScript script2 = context.CompileScript(rubySource2);    
            await script2.RunAsync();
#endif
            
            Debug.Log("Test-2");
        }
        
        // Test method demonstrating loading and executing scripts from resources
        // リソースからスクリプトを読み込み実行するテストメソッド
        async Task Test2()
        {
            Debug.Log("Test2");
            var presenter = new MyPresentor();
            presenter.MapTo(Router.Default);
            
            var context = MRubyContext.Create();
            context.Router = Router.Default;               // ... 1
            context.CommandPreset = new MyCommandPreset(); // ... 2
            
            var loadTxt = ReadAsset("loadTxt1");
            try
            {
                context.Load(loadTxt);
            }
            catch (Exception ex)
            {
                Debug.Log($"Load Exception {ex}");
            }

            var newFile = ReadAsset("NewFile5");
            try
            {
                using MRubyScript script1 = context.CompileScript(newFile); 
                Debug.Log($"RunAsync");
                await script1.RunAsync();
            }
            catch (Exception ex)
            {
                Debug.Log($"RunAsync Exception {ex}");
            }
            
            Debug.Log("Test-2");
        }
        
        // Test method demonstrating shared state usage
        // 共有状態の使用を示すテストメソッド
        async Task Test3()
        {
            Debug.Log("Test3-1");
            var presenter = new MyPresentor();
            presenter.MapTo(Router.Default);
            
            var context = MRubyContext.Create();
            context.Router = Router.Default;               // ... 1
            context.CommandPreset = new MyCommandPreset(); // ... 2
            
            // Set shared state variables
            // 共有状態変数を設定
            context.SharedState.Set("int_value", 1234);
            context.SharedState.Set("bool_value", true);
            context.SharedState.Set("float_value", (float)678.9);
            context.SharedState.Set("string_value", "Hoge Hoge");
            context.SharedState.Set("symbol_value", "fuga_fuga", asSymbol: true);
            
            var loadTxt = ReadAsset("loadTxt1");
            try
            {
                context.Load(loadTxt);
            }
            catch (Exception ex)
            {
                Debug.Log($"Load Exception {ex}");
            }

            var newFile = ReadAsset("NewFile6");
            try
            {
                using MRubyScript script1 = context.CompileScript(newFile); 
                Debug.Log($"RunAsync");
                await script1.RunAsync();
            }
            catch (Exception ex)
            {
                Debug.Log($"RunAsync Exception {ex}");
            }
            Debug.Log($"RunAsync-2");
            
            var int_value = context.SharedState.Get<int>("int_value");
            Debug.Log($"int_value {int_value}");
            
            Debug.Log("Test3-2");
        }
        
        // Test method demonstrating command publishing
        // コマンド発行を示すテストメソッド
        void Test4()
        {
            Debug.Log("Test4-1");
            var presenter = new MyPresentor();
            presenter.MapTo(Router.Default);
            Router.Default.PublishAsync(new MyCSCommandPreset.FooCommand
            {
                X = 111,
                Y = "222",
            });
            
            Debug.Log("Test4-2");
        }
        
        // Test method demonstrating custom command preset and script execution
        // カスタムコマンドプリセットとスクリプト実行を示すテストメソッド
        async Task Test5()
        {
            Debug.Log("Test5 MyCommandPreset");
            var presenter = new MyPresentor();
            presenter.MapTo(Router.Default);
            
            var context = MRubyContext.Create();
            context.Router = Router.Default;               // ... 1
            context.CommandPreset = new MyCommandPreset(); // ... 2
            
            var loadTxt = ReadAsset("loadTxt1");
            try
            {
                context.Load(loadTxt);
            }
            catch (Exception ex)
            {
                Debug.Log($"Load Exception {ex}");
            }

            var newFile = ReadAsset("NewFile5");
            try
            {
                using MRubyScript script1 = context.CompileScript(newFile); 
                Debug.Log($"RunAsync");
                await script1.RunAsync();
            }
            catch (Exception ex)
            {
                Debug.Log($"RunAsync Exception {ex}");
            }
            
            Debug.Log("Test5 end");
        }
    }
}