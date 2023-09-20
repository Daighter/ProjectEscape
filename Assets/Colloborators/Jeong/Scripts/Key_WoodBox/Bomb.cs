using System.Collections;
using UnityEngine;

namespace Jeong
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] GameObject rock1;
        [SerializeField] GameObject rock2;
        [SerializeField] GameObject rock3;
        [SerializeField] GameObject rock4;
        [SerializeField] GameObject rock5;
        [SerializeField] GameObject rock6;
        [SerializeField] GameObject rock7;
        
        [SerializeField] GameObject effect1;
        [SerializeField] GameObject effect2;
        [SerializeField] GameObject effect3;
        [SerializeField] GameObject effect4;
        [SerializeField] GameObject effect5;
        [SerializeField] GameObject effect6;
        [SerializeField] GameObject effect7;

        [SerializeField] GameObject bomb;
        [SerializeField] GameObject bombexplosion;

        [SerializeField] AudioSource[] caveBombAudio;

        private string[] key = new string[2];

        private void Awake()
        {
            Keys();
            for(int i = 0; i < key.Length; i++)
            {
                GameManager.Sound.AddCaveSound(key[i], caveBombAudio[i]);
            }
        }

        private void Keys()
        {
            key[0] = "BombFireSound";
            key[1] = "BombTimerSound";
        }

        private void Start()
        {
            bombexplosion.SetActive(false);
          
            effect1.SetActive(false);
            effect2.SetActive(false);
            effect3.SetActive(false);
            effect4.SetActive(false);
            effect5.SetActive(false);
            effect6.SetActive(false);
            effect7.SetActive(false);
            
            rock1.SetActive(true);
            rock2.SetActive(true);
            rock3.SetActive(true);
            rock4.SetActive(true);
            rock5.SetActive(true);
            rock6.SetActive(true);
            rock7.SetActive(true);
            gameObject.SetActive(true);
        }

        public void Delete()
        {
            if (rock1 && rock2 && rock3 && rock4 && rock5 && rock6 && rock7 == null)
                return;

            StartCoroutine(RockExplosionRoutine());
        }

        public IEnumerator RockExplosionRoutine()
        {
            
            yield return new WaitForSeconds(0.3f);

            GameManager.Sound.PlayCaveSound("BombTimerSound");
            Debug.Log("5");
            yield return new WaitForSeconds(1.0f);
            Debug.Log("4");
            yield return new WaitForSeconds(1.0f);
            Debug.Log("3");
            yield return new WaitForSeconds(1.0f);
            Debug.Log("2");
            yield return new WaitForSeconds(1.0f);
            Debug.Log("1");
            Debug.Log("Bomb!");
            //오디오재생
            GameManager.Sound.PlayCaveSound("BombFireSound");
            yield return new WaitForSeconds(0.2f);
            bombexplosion.SetActive(true);
            bomb.SetActive(false);

            yield return new WaitForSeconds(0.2f);
            effect5.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            effect5.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            effect5.SetActive(true);
            rock5.SetActive(false);
            
            yield return new WaitForSeconds(0.2f);
            effect2.SetActive(true);
            effect3.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            effect2.SetActive(false);
            effect3.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            effect2.SetActive(true);
            effect3.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            effect1.SetActive(true);
            effect4.SetActive(true);
            effect6.SetActive(true);
            effect7.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            rock2.SetActive(false);
            rock3.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            effect1.SetActive(false);
            effect4.SetActive(false);
            effect6.SetActive(false);
            effect7.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            effect1.SetActive(true);
            effect4.SetActive(true);
            effect6.SetActive(true);
            effect7.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            rock1.SetActive(false);
            rock4.SetActive(false);
            rock6.SetActive(false);
            rock7.SetActive(false);

            yield return new WaitForSeconds(0.2f);
            gameObject.SetActive(false);
        }
    }
}

