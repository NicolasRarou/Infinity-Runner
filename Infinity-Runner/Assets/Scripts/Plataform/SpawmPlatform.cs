using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmPlatform : MonoBehaviour
{
    
    public List<GameObject> platforms = new List<GameObject> (); //Lista dos prefabs das plataformas

    private List <Transform> currentPlatforms = new List<Transform> (); //lista das plataformas geradas na cena

    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;
    const float platformHeight = -4.5f;



    public float offset;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
   

        for (int i = 0; i < platforms.Count; i++)
        {
            Transform p = Instantiate(platforms[i], new Vector2(i * 30, platformHeight), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 30f;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
        
    }

   void Update()
    {
        PlatformCreator();
    }

    void PlatformCreator() //Função responsável por movimentar as plataformas durante o jogo
    {
        float distance = player.position.x - currentPlatformPoint.position.x; //salvando a diferença da posição x do player e do finalpoint da plataforma atual.
        if(distance >= 1) //sed o distance for maior que 1, recicla a plataforma. Enviando para frente. 
        {
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if(platformIndex > currentPlatforms.Count - 1)
            {
                platformIndex = 0;
            }


            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
        }

        void Recycle(GameObject platform) //Função feita para reciclar plataformas 
        {
            platform.transform.position = new Vector2(offset, platformHeight);

            if (platform.GetComponent<Platform>().SpawnObj != null) //checando se spwanObj está preenchida.
            {
                platform.GetComponent<Platform>().SpawnObj.ReSpawnEnemy();
            }

            offset += 30f;
        }
    }
}
