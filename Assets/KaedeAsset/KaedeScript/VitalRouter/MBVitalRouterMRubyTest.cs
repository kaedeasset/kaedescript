using System;
using System.Threading.Tasks;
using UnityEngine;
using VitalRouter;
using VitalRouter.MRuby;

namespace KaedeAsset.KaedeScript.VitalRouter
{
    public class MBVitalRouterMRubyTest : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Debug.Log("MBVitalRouterMRubyTest Start");
            Test5();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        string ReadAsset(string path)
        {
            Debug.Log($"ReadAsset {path}");
            // ResourcesフォルダからLuaファイルを読み込む
            TextAsset luaTextAsset = Resources.Load<TextAsset>(path); // 拡張子は不要
            if (luaTextAsset == null)
            {
                Debug.LogError($"スクリプトが見つかりません: {path}");
                return null;
            }

            string luaScripts = luaTextAsset.text;
            Debug.Log($"path {luaScripts}");
            return luaScripts;
        }
        
        // MRubyContext
        // スクリプトはC#のstrings
        async Task Test1()
        {
            Debug.Log("Test");
            var presenter = new MyPresentor();
            presenter.MapTo(Router.Default);
            
            var context = MRubyContext.Create();
            context.Router = Router.Default;                // ... 1
            context.CommandPreset = new MyCommandPreset(); // ... 2
            // Your ruby script source here
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
        
        // MRubyContext
        // リソースからファイルをリード
        // Loadでメソッド呼び出しを可能にする
        async Task Test2()
        {
            Debug.Log("Test2");
            var presenter = new MyPresentor();
            presenter.MapTo(Router.Default);
            
            var context = MRubyContext.Create();
            context.Router = Router.Default;               // ... 1
            context.CommandPreset = new MyCommandPreset(); // ... 2
            
            var loadTxt = ReadAsset("loadTxt1"); //トップレベルメソッド speak wait move
            // Evaluate arbitrary ruby script
            try
            {
                context.Load(loadTxt);
            }
            catch (Exception ex)
            {
                Debug.Log($"Load Exception {ex}");
            }

            // Your ruby script source here
            var newFile = ReadAsset("NewFile5");

            // using MRubyScript script1 = context.CompileScript(rubySource1);    
            // When a syntax error is detected, CompileScript throws an exception.
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
        
        // SharedState
        async Task Test3()
        {
            Debug.Log("Test3-1");
            var presenter = new MyPresentor();
            presenter.MapTo(Router.Default);
            
            var context = MRubyContext.Create();
            context.Router = Router.Default;               // ... 1
            context.CommandPreset = new MyCommandPreset(); // ... 2
            
            // SharedState
            context.SharedState.Set("int_value", 1234);
            context.SharedState.Set("bool_value", true);
            context.SharedState.Set("float_value", (float)678.9);
            context.SharedState.Set("string_value", "Hoge Hoge");
            context.SharedState.Set("symbol_value", "fuga_fuga", asSymbol: true);
            
            var loadTxt = ReadAsset("loadTxt1");
            // Evaluate arbitrary ruby script
            try
            {
                context.Load(loadTxt);
            }
            catch (Exception ex)
            {
                Debug.Log($"Load Exception {ex}");
            }

            // Your ruby script source here
            var newFile = ReadAsset("NewFile6");

            // using MRubyScript script1 = context.CompileScript(rubySource1);    
            // When a syntax error is detected, CompileScript throws an exception.
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
        
        // KaedeScript test
        // MRubyContext
        // リソースからファイルをリード
        // Loadでメソッド呼び出しを可能にする
        async Task Test5()
        {
            Debug.Log("Test5 Kaede Script");
            var presenter = new MyPresentor();
            presenter.MapTo(Router.Default);
            
            var context = MRubyContext.Create();
            context.Router = Router.Default;               // ... 1
            context.CommandPreset = new MyCommandPreset(); // ... 2
            
            var loadTxt = ReadAsset("loadTxt1"); //トップレベルメソッド speak wait move
            // Evaluate arbitrary ruby script
            try
            {
                context.Load(loadTxt);
            }
            catch (Exception ex)
            {
                Debug.Log($"Load Exception {ex}");
            }

            // Your ruby script source here
            var newFile = ReadAsset("NewFile5");

            // using MRubyScript script1 = context.CompileScript(rubySource1);    
            // When a syntax error is detected, CompileScript throws an exception.
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
    }
}
