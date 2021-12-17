using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tile
{
    public GameObject theTile;

    public float creationTime;

    public Tile(GameObject t, float ct)
    {
        theTile = t;
        creationTime = ct;
    }
}

public class GenerateInfinite : MonoBehaviour
{
    public GameObject plane;
    public GameObject cylinder;

    public GameObject objectToSpawn;

    private List<Vector3> tilePositions = new List<Vector3>();

    int planeSize = 10;
    int halfTilesX = 5;
    int halfTilesZ = 5;

    Vector3 startPos;

    private Hashtable tiles = new Hashtable();
     
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for(int x = - halfTilesX; x < halfTilesX; x++)
        {
            for(int z = -halfTilesZ; z < halfTilesZ; z++)
            {
                Vector3 pos = new Vector3((x * planeSize+startPos.x),
                        0,
                        (z * planeSize+startPos.z));
                GameObject t = (GameObject) Instantiate(plane, pos, Quaternion.identity);

                string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tilename, tile); 

                tilePositions.Add(t.transform.position);
                
            }
        }  
        SpawnObject();
       
    }

    private void SpawnObject(){

        for(int c =0; c < 10; c++){
            Debug.Log("Creating a cactus");
            Debug.Log("visit" + ObjectSpawnLocation());
            GameObject toPlaceObject = Instantiate(objectToSpawn, 
            ObjectSpawnLocation(),
            Quaternion.identity);
        }
    }

    private Vector3 ObjectSpawnLocation () {

        int rndIndex = Random.Range(0, tilePositions.Count);

        Vector3 newPos = new Vector3 (
            tilePositions[rndIndex].x,
            tilePositions[rndIndex].y + 5f,
            tilePositions[rndIndex].z
        );

        tilePositions.RemoveAt(rndIndex);
        return newPos;

    }

    // Update is called once per frame
    void Update()
    {
        //Determine how far player has moved
        int xMove = (int)(cylinder.transform.position.x - startPos.x);
        int zMove = (int)(cylinder.transform.position.z - startPos.z);

        Debug.Log("xMove: "+xMove);
        Debug.Log("zMove: "+zMove);

        //if move further than the planeSize
        if(Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
        {
            //timestamp for new tiles created
            float updateTime = Time.realtimeSinceStartup;

            //force integer position and round to nearest tilesize
            int playerX = (int)(Mathf.Floor(cylinder.transform.position.x/planeSize)*planeSize);
            int playerZ = (int)(Mathf.Floor(cylinder.transform.position.z/planeSize)*planeSize);

    
            for(int x = - halfTilesX; x < halfTilesX; x++)
            {
                for(int z = -halfTilesZ; z < halfTilesZ; z++)
                {
                    Vector3 pos = new Vector3((x * planeSize + playerX),
                                    0,
                                        (z * planeSize + playerZ)); //offset based on players position
                   
                    string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                    Debug.Log(tilename);
                    if(!tiles.ContainsKey(tilename))
                    {
                        GameObject t = (GameObject) Instantiate(plane, pos,
                                Quaternion.identity);

                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles.Add(tilename, tile);
                         
                    }
                    else
                    {
                        (tiles[tilename] as Tile).creationTime = updateTime;
                    }
                }
            }

            //destroy all tiles not just created ow with time updated
            //and put new tiles and tile to be kept ina new hashtable
            Hashtable newTerrain = new Hashtable();
            foreach(Tile tls in tiles.Values)
            {
                if(tls.creationTime != updateTime)
                {
                    //destroy gameObject
                    Destroy(tls.theTile);
                }
                else
                {
                    newTerrain.Add(tls.theTile.name, tls);
                }
            }
            //copy new hashtable contents to the working hashtable
            tiles = newTerrain;

            startPos = cylinder.transform.position;
        }
        
    }
}
