using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TestMain:MonoBehaviour
    {
        public Button Btn1;
        public Button Btn2;
        public Button Btn3;
        
        private void Awake()
        {
            Btn1.onClick.AddListener(OnBtn1Click);
            Btn2.onClick.AddListener(OnBtn2Click);
            Btn3.onClick.AddListener(OnBtn3Click);
        }

        private void OnBtn1Click()
        {
            Debug.Log("btn1 clicked!!");
        }
    
        private void OnBtn2Click()
        {
            Debug.Log("btn2 clicked!!");
        }
        
        private void OnBtn3Click()
        {
            Debug.Log("btn3 clicked!!");
        }
    }
}