using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private float accelerationSpeed = 500.0f;
    [SerializeField] private float rotationSpeed = 500.0f;
    [SerializeField] private float thrustFadeRate = 1.0f;
    [SerializeField] AudioClip Thrust;
    [SerializeField] ParticleSystem explosionParticle;

    private Rigidbody playerRigidbody;
    private AudioSource thrustAudio;


    // Start is called before the first frame update    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        thrustAudio = GetComponent<AudioSource>();

        Debug.Log(SceneManager.sceneCount);

        explosionParticle.Pause();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();     

        CheatCodes();
    }

    private void CheatCodes()
    {
        MeshCollider collider = GetComponent<MeshCollider>();
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(collider.enabled == true)
            {
                collider.enabled = false;
            }
            else
            {
                collider.enabled = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<CollisionHandler>().HandleFinish();
        }
    }

    public void ProcessThrust()
    {      
        GameObject flame = GameObject.FindGameObjectWithTag("Particle");  
        
       if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            HandleUpPress(flame);
        }
        else
        {
            ReleaseUpPress(flame);
        }
    }

    private void ReleaseUpPress(GameObject flame)
    {
        flame.GetComponent<ParticleSystem>().enableEmission = false;
        FadeSound();
    }

    private void HandleUpPress(GameObject flame)
    {
        flame.GetComponent<ParticleSystem>().enableEmission = true;
        thrustAudio.volume = 1;
        playerRigidbody.AddRelativeForce(Vector3.up * accelerationSpeed * Time.deltaTime);
        if (!thrustAudio.isPlaying)
        {
            thrustAudio.PlayOneShot(Thrust);
        }
    }

    public void FadeSound()
    {
        thrustAudio.volume -= 0.1f * Time.deltaTime * thrustFadeRate;
    }

    public void ProcessRotation()
    {
       Vector3 relativeRotation = Vector3.forward * rotationSpeed * Time.deltaTime;

       if(Input.GetKey(KeyCode.RightArrow))
       {
            playerRigidbody.AddRelativeTorque(-relativeRotation);
       }
        else if(Input.GetKey(KeyCode.LeftArrow))
       {
            playerRigidbody.AddRelativeTorque(relativeRotation);
       }
    }
}
