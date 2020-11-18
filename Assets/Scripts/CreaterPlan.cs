using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreaterPlan : MonoBehaviour
{
    public static CreaterPlan instance;
    public List<GameObject> planepackes;
    public GameObject sonzemin;
    public List<GameObject> AllPlanes;


    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        int randomplane = Random.Range(0, planepackes.Count);
        GameObject zemin = Instantiate(planepackes[randomplane], Vector3.zero, Quaternion.identity);
      
        sonzemin = zemin;
        AllPlanes.Add(sonzemin);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void CreatePlane()
    {
       int randomplane = Random.Range(0, planepackes.Count);

        Vector3 pos = sonzemin.transform.position;
       Vector3 newpos = new Vector3(0, 0, pos.z + 48.1f);


        GameObject findplane= Instantiate(planepackes[randomplane],newpos, Quaternion.identity);
        AllPlanes.Add(findplane);
        sonzemin = findplane;
        if(AllPlanes.Count>=4)
        {
            Destroy(AllPlanes[0]);
            AllPlanes.RemoveAt(0);
        }

        if (Time.timeScale >= 3) return;
        Time.timeScale += 0.05f;
     
    }
    
    
}
