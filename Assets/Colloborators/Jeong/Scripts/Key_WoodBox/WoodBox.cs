using UnityEngine;

namespace Jeong
{
    public class WoodBox : MonoBehaviour
    {
        [SerializeField] GameObject boxKey;
        [SerializeField] GameObject bomb;
        [SerializeField] GameObject effect;
        [SerializeField] GameObject hintPaper;

        [SerializeField] AudioSource[] caveBoxAudio;

        Rigidbody rigid;

        private void Keys()
        {
            key[0] = "BoxOpenSound";
        }

        private string[] key = new string[1];
         
        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();
            Keys();
            for (int i = 0; i < key.Length; i++)
            {
                GameManager.Sound.AddCaveSound(key[i], caveBoxAudio[i]);
            }
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
            rigid.constraints = RigidbodyConstraints.None;
            hintPaper.SetActive(true);
            GameManager.Sound.PlayCaveSound("BoxOpenSound");
            bomb.SetActive(true);
            boxKey.SetActive(false);
            gameObject.SetActive(false);
            effect.SetActive(true);
        }
    }

}
