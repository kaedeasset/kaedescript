using System.Collections.Generic;
using UnityEngine;

namespace KaedeAsset.KaedeScript.View
{
    public class PrefabManager : MonoBehaviour
    {
        // シリアライズフィールドを使用して、Unityエディタからプレハブを割り当てます
        [SerializeField] private List<GameObject> prefabs;

        // プレハブとキーを関連付けるためのDictionary
        private Dictionary<string, GameObject> _prefabDictionary;
        private GameObject _prefabParent;

        void Start()
        {
            // Dictionaryの初期化
            _prefabDictionary = new Dictionary<string, GameObject>();
            // Prefabsフォルダを探す
            _prefabParent = GameObject.Find("Prefabs");
            // 各プレハブをDictionaryに追加
            foreach (GameObject prefab in prefabs)
            {
                // プレハブの名前をキーとして使用
                _prefabDictionary.Add(prefab.name, prefab);
            }

            // テストとして、特定のプレハブをシーンに追加
            // AddPrefabToScene("Cube");
        }

        // 指定されたキーに基づいてプレハブをシーンに追加するメソッド
        public void AddPrefabToScene(string key, Vector3 position)
        {
            if (_prefabParent == null)
            {
                Debug.LogError("Prefabsがnullです");
                return;
            }
            if (_prefabDictionary.TryGetValue(key, out GameObject prefab))
            {
                // プレハブをインスタンス化し、Prefabsフォルダの子として設定
                /***
                GameObject instance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                instance.transform.SetParent(_prefabParent.transform);
                ***/
                
                // Instantiate(prefab, Vector3.zero, Quaternion.identity);
                Instantiate(prefab, position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("指定されたキーのプレハブが見つかりません: " + key);
            }
        }
    }
}