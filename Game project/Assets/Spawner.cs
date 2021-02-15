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
            GameObject G = Instantiate(Resources.Load("platform")) as GameObject;
            G.transform.position = gameObject.transform.position;
            gameObject.transform.Translate(0,4.8f,0);
            float spawnPointX = Random.Range(G.transform.position.x-3, G.transform.position.x+3);
            float spawnPointY = Random.Range(G.transform.position.y, G.transform.position.y+1);
            Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, 0);
            Instantiate(player, spawnPosition, Quaternion.identity);
        }
    }

    public void Spawn()
{
    // this basically does FindObjectWithTag("Main camera")
    
    //implement later spawn object within the camera, might use this to destroy when off camera
    var camera = Camera.main.transform;
   
    Instantiate(platform, camera.position + camera.forward * 10f, Quaternion.identity);
}
}
