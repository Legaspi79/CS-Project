using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject player;
    public Transform Cam;
    // Start is called before the first frame update
    void Start()
    {
    Cam = GameObject.Find("Main Camera").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y-12f<Cam.position.y){
            //spawn platform
            GameObject G = Instantiate(Resources.Load("platform")) as GameObject;
            G.transform.position = gameObject.transform.position;
            gameObject.transform.Translate(0,4.8f,0);
            //spawn player
            float spawnPointX = Random.Range(G.transform.position.x-1, G.transform.position.x+5);
            float spawnPointY = Random.Range(G.transform.position.y, G.transform.position.y+1);
            Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, 0);
            Instantiate(player, spawnPosition, Quaternion.identity);
        }
    }
    void SpawnPlatform(){
        
    }
}
