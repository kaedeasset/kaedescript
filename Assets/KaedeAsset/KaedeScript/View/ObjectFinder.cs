using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace KaedeAsset.KaedeScript.View
{
    public class ObjectFinder : MonoBehaviour
    {
        // Parent object / 親オブジェクト
        public Transform parentObject;

        // Dictionary to store GameObject names and their corresponding GameObjects
        // GameObject nameとGameObject自体を格納する辞書
        private readonly Dictionary<string, GameObject> _objectDictionary = new Dictionary<string, GameObject>();
    
        // List of parent object Transforms / 親オブジェクトのTransformのリスト
        public List<Transform> parentObjects;
    
        // Dictionary with parent Transform as key and list of child GameObjects as value
        // 親Transformをキーとし、子GameObjectのリストをバリューとする辞書
        private readonly Dictionary<Transform, List<GameObject>> _parentChildMap = new Dictionary<Transform, List<GameObject>>();
    
        async void Start()
        {
            // Search for child objects and add them to the dictionary
            // 子オブジェクトを検索して辞書に追加
            AddChildrenToDictionary(parentObject);
        
            // Log the contents of the dictionary for verification
            // 辞書の内容をログに出力（確認用）
            Debug.Log("objectDictionary.Count=" + _objectDictionary.Count);
            foreach (var item in _objectDictionary)
            {
                parentObjects.Add(item.Value.transform);
            }
        
            // Register parent-child relationships
            // 親と子の関係を登録
            RegisterParentChildRelationships();
        
            // Log the contents of the parent-child map for verification
            // 辞書の内容をログに出力（確認用）
            foreach (var item in _parentChildMap)
            {
                foreach (var child in item.Value)
                {
                    // Debug.Log($"Child= {item.Key.name} {child.name}");
                }
            }
        
            // Player();
        }

        public async void Player()
        {
            // Example sequence to activate different child objects
            // 異なる子オブジェクトをアクティブにする例
            Debug.Log("Player");
            SetActive("!口", "*あ");
            await Task.Delay(1000);
            SetActive("!口", "*い");
            await Task.Delay(1000);
            SetActive("!口", "*う");
            await Task.Delay(1000);
            SetActive("!口", "*え");
            await Task.Delay(1000);
            SetActive("!口", "*お");
            await Task.Delay(1000);
            SetActive("!口", "*綴じ\u3000－");
        }
    
        // Recursively add child objects to the dictionary
        // 再帰的に子オブジェクトを辞書に追加するメソッド
        void AddChildrenToDictionary(Transform parent)
        {
            foreach (Transform child in parent)
            {
                // Add child object to the dictionary
                // 子オブジェクトを辞書に追加
                _objectDictionary.Add(child.name, child.gameObject);
            
                // Process the children of this child object
                // さらにその子オブジェクトに対しても同様に処理
                AddChildrenToDictionary(child);
            }
        }
    
        // Register parent-child relationships in the dictionary
        // 親と子の関係を辞書に登録するメソッド
        void RegisterParentChildRelationships()
        {
            foreach (Transform parent in parentObjects)
            {
                List<GameObject> children = new List<GameObject>();

                foreach (Transform child in parent)
                {
                    // Add child GameObject to the list
                    // 子GameObjectをリストに追加
                    children.Add(child.gameObject);
                }

                if (children.Count > 0)
                {
                    // Register the parent-child relationship in the dictionary
                    // 辞書に親子関係を登録
                    _parentChildMap[parent] = children;
                }
            }
        }
    
        // Get the list of child GameObjects for a specific parent object
        // 特定の親オブジェクトに対応する子オブジェクトのリストを取得するメソッド
        List<GameObject> GetChildren(Transform parent)
        {
            if (_parentChildMap.ContainsKey(parent))
            {
                return _parentChildMap[parent];
            }
            else
            {
                // Return an empty list if there are no children
                // 子がいない場合は空のリストを返す
                return new List<GameObject>();
            }
        }

        // Set a specific child object active based on the parent Transform and child name
        // 親Transformと子の名前に基づいて特定の子オブジェクトをアクティブにする
        public GameObject SetActive(Transform parent, string chileName)
        {
            List<GameObject> children = GetChildren(parent);
            GameObject activeChild = null;
            foreach (GameObject child in children)
            {
                if (child.name == chileName)
                {
                    child.SetActive(true);
                    activeChild = child;
                }
                else
                {
                    child.SetActive(false);
                }
            }
            return activeChild;
        }

        // Set a specific child object active based on the parent name and child name
        // 親の名前と子の名前に基づいて特定の子オブジェクトをアクティブにする
        public GameObject SetActive(string parentName, string chileName)
        {
            Debug.Log($"SetActive {parentName} / {chileName}");
            if (_objectDictionary.ContainsKey(parentName))
            {
                return SetActive(_objectDictionary[parentName].transform, chileName);
            }
            else
            {
                Debug.LogError("Parent not found.");
                return null;
            }
        }

        // Update is called once per frame
        // 毎フレーム呼び出されるUpdateメソッド
        void Update()
        {
        
        }
    }
}