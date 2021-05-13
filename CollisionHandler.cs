using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip destruction;
    [SerializeField] float maxLandingSpeed = 1;
    [SerializeField] ParticleSystem explosionSystem;

    private bool isActive = true;

    private void OnCollisionEnter(Collision other) 
    {
        string currentTag = other.gameObject.tag;

        switch(currentTag)
        {
            case "Obstacle":    HandleObstacle();
                                break; 
            case "Finish":      HandleFinish();
                                break;
            case "Fuel":        HandleFuel();
                                break;            
            default:            break;
        }

    }

    private void HandleObstacle()
    {
        Explode();
    }

    public void Explode()
    {       
        if(isActive)
        {     
        GameObject flame = GameObject.FindGameObjectWithTag("Particle");
        //GameObject Explosion = GameObject.FindGameObjectWithTag("ExplosionParticle");  
        //Explosion.GetComponent<ParticleSystem>().enableEmission = true;   
        GetComponent<Movement>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        AudioSource rocketSounds = GetComponent<AudioSource>();       
        flame.GetComponent<ParticleSystem>().enableEmission = false;   
        ParticleSystem temp = GameObject.FindGameObjectWithTag("ExplosionParticle").GetComponent<ParticleSystem>();
        temp.enableEmission = true;
        temp.Play();
        rocketSounds.Stop();
        rocketSounds.volume = 1;
        rocketSounds.PlayOneShot(destruction);
        Invoke("ReloadLevel", 2.5f);   
        isActive = false;
        GetComponent<MeshRenderer>().enabled = false;
        }    
    }

    public void ReloadLevel()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HandleFinish()
    {
        if(GetComponent<Rigidbody>().velocity.magnitude < maxLandingSpeed)
        {
        int totalLevels = 8;
        //Debug.Log(Scene);
        int currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if(currentLevel > totalLevels)
        {
            currentLevel = SceneManager.GetSceneByName("RocketMenu").buildIndex;
        }
        SceneManager.LoadScene(currentLevel);
        Debug.Log("Finish");
        }
        else
        {
            Explode();
        }
    }

    public void HandleFuel()
    {
        Debug.Log("Fuel");
    }



}
