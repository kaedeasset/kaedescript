using KaedeAsset.KaedeScript.Presenter;
using KaedeAsset.KaedeScript.View;
using KaedeAsset.KaedeScript.VitalRouter;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace KaedeAsset.KaedeScript.VContainer
{
    /// <summary>
    /// Manages dependency injection container configuration for the game
    /// ゲームの依存性注入コンテナの設定を管理
    /// </summary>
    public class GameLifetimeScope : LifetimeScope
    {
        // View components to be set in Unity Inspector
        // Unity インスペクターで設定するViewコンポーネント
        [SerializeField] ImageFader imageFader;
        [SerializeField] NovelView novelView;
        [SerializeField] SpriteHandler spriteHandler;
        [SerializeField] SceneLoader sceneLoader;
        [SerializeField] ChoiceView choiceView;

        /// <summary>
        /// Configures dependency injection container
        /// 依存性注入コンテナの設定を行う
        /// </summary>
        /// <param name="builder">Container builder / コンテナビルダー</param>
        protected override void Configure(IContainerBuilder builder)
        {
            // Log the start of the configuration process
            // 設定プロセスの開始をログに記録
            Debug.Log("GameLifetimeScope Configure-1");

            // Register View components
            // Viewコンポーネントの登録
            builder.RegisterComponent(imageFader);
            builder.RegisterComponent(novelView);
            builder.RegisterComponent(spriteHandler);
            builder.RegisterComponent(sceneLoader);
            builder.RegisterComponent(choiceView);
            
            // Register Scoped lifetime components
            // These components maintain state within game session/scene
            // スコープ付きライフタイムコンポーネントの登録
            // これらのコンポーネントはゲームセッション/シーン内で状態を維持
            builder.Register<NobelPresenter>(Lifetime.Scoped);
            builder.Register<VCVitalRouterMRubyTest>(Lifetime.Scoped);
            
            // Log the progress of the configuration
            // 設定の進行状況をログに記録
            Debug.Log("GameLifetimeScope Configure-2");

            // Configure entry points for the game
            // ゲームのエントリーポイントを設定
            builder.UseEntryPoints(Lifetime.Scoped, entryPoints =>
            {
                entryPoints.Add<NobelMain>();  
            });
           
            // Log the completion of the configuration process
            // 設定プロセスの完了をログに記録
            Debug.Log("GameLifetimeScope Configure-4");
        }
    }
}
