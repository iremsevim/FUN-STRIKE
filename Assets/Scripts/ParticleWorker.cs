using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWorker:MonoBehaviour
{
    public static ParticleWorker instance;
    public List<ParticleProfil> allparticles;


    public void Awake()
    {
        instance = this;
    }
    public void CreateParticle(string ID,Vector3 pos)
    {
      ParticleProfil findedparticle=allparticles.Find(x => x.ID == ID);
        GameObject createdparticle = Instantiate(findedparticle.particleprefab, pos, Quaternion.identity);
        Destroy(createdparticle.gameObject, 1.5f);
    }



    public class ParticleProfil
    {
        public GameObject particleprefab;
        public string ID;
       
    }
}



