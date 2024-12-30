using System.Collections.Generic;
using KaedeAsset.KaedeScript.View.Helper;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VContainer.Unity;

namespace KaedeAsset.KaedeScript.View
{
    public class SpriteHandler : MonoBehaviour
    {
        // MonoBehaviourを継承、インスペクターから設定する
        public NovelView _novelView;
        
        private readonly Dictionary<string, ChSprite > _chSprites = new();
        private readonly Dictionary<string, Sprite> _sprites = new();

        readonly Dictionary<string, GameObject> _objs = new();
        readonly Dictionary<string, Image> _images = new();
        readonly Dictionary<string, SpriteRenderer > _srs = new();

        /***
        public SpriteHandler(NovelView novelView)
        {
            Debug.Log("SpriteHandler コンストラクタ");
            _novelView = novelView;
        }
        ***/

        
        public void Awake()
        {
            Debug.Log("SpriteHandler Awake");
            //Debug.Log($"novelView {_novelView}");
            
            SetChSprite(_novelView.objs);
            SetAll(_novelView.objs, _novelView.images, _novelView.srs);
        }
        
        void SetAll(GameObject[] objs, Image[] images, SpriteRenderer[] srs)
        {
            foreach (var obj in objs)
            {
                if (obj!=null)
                {
                    _objs[obj.name] = obj;
                }
            }
            foreach (var img in images)
            {
                if (img != null)
                {
                    _images[img.name] = img;
                }
            }
            foreach (var sr in srs)
            {
                if (sr != null)
                {
                    _srs[sr.name] = sr;
                }
            }
        }
        
        // Get
        public GameObject GetObj(string name)
        {
            if (_objs.TryGetValue(name, out var variable))
            {
                //Debug.Log($"GetObj {variable.name}");
                return variable;
            }
            Debug.LogError("GetObj not found.");
            throw new KeyNotFoundException($"_objs '{name}' not found.");
            //return null;
        }
        
        public Image GetImage(string name)
        {
            if (_images.TryGetValue(name, out var variable))
                return variable;
            
            Debug.LogError("GetImage not found.");
            throw new KeyNotFoundException($"_images '{name}' not found.");
        }

        public GameObject GetImageAndObj(string name)
        {
            if (_images.TryGetValue(name, out var variable))
                return variable.gameObject;
            if (_objs.TryGetValue(name, out var variable2))
                return variable2;
            
            Debug.LogError("GetImageAndObj not found.");
            throw new KeyNotFoundException($"{name}' not found.");
        }
        
        public SpriteRenderer GetSr(string name)
        {
            if (_srs.TryGetValue(name, out var variable))
                return variable;
            
            Debug.LogError("GetSr not found.");
            throw new KeyNotFoundException($"_srs '{name}' not found.");
        }
        
        // ChSprite
        void SetChSprite(GameObject[] objs)
        {
            foreach (var obj in objs)
            {
                if (obj.name.Contains("Sprite"))
                {
                    // このGameObjectとその子どもたちからすべてのSpriteRendererコンポーネントを取得
                    SpriteRenderer[] spriteRenderers = obj.GetComponentsInChildren<SpriteRenderer>();
                    _chSprites[obj.name] = new ChSprite
                    {
                        Name = obj.name,
                        Obj = obj,
                        SpriteRenderers = spriteRenderers
                    };
                }
            }
        }
        
        public ChSprite GetChSprite(string name)
        {
            if (_chSprites.TryGetValue(name, out var variable))
                return variable;
            
            Debug.LogError("GetChSprite not found.");
            throw new KeyNotFoundException($"ChSprite '{name}' not found.");
        }
        
        // Sprite
        public void SetSprite(string name, string path)
        {
            var sprite = Resources.Load<Sprite>(path);
            _sprites[name] = sprite;
        }
        public void SetSprite(string name, Sprite sprite)
        {
            _sprites[name] = sprite;
        }

        public Sprite GetSprite(string name)
        {
            if (_sprites.TryGetValue(name, out var variable))
                return variable;
            
            Debug.LogError("GetSprite not found.");
            throw new KeyNotFoundException($"Sprite '{name}' not found.");
        }
    }


}