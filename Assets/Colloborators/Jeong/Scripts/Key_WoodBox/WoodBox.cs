using UnityEngine;

namespace Jeong
{
    public class WoodBox : MonoBehaviour
    {
        [SerializeField] GameObject boxKey;
        [SerializeField] GameObject bomb;
        [SerializeField] GameObject effect;
        [SerializeField] GameObject hintPaper;
        Rigidbody rigid;
        

        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();
            
        }

        private void Start()
        {
            boxKey.SetActive(true);
            gameObject.SetActive(true);
            bomb.SetActive(false);
            hintPaper.SetActive(false);
            effect.SetActive(false);
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }

        public void Open()
        {
            Debug.Log("BoxOpen");
          
            rigid.constraints = RigidbodyConstraints.None;
            hintPaper.SetActive(true);
            bomb.SetActive(true);
            boxKey.SetActive(false);
            gameObject.SetActive(false);
            effect.SetActive(true);
        }
    }

}
