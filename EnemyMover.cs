using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] private float speed = 1f;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    
    void OnEnable() 
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    public void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if(waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    public void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    public void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);    
    }

    public IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path) 
        {      
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercentage = 0f;

            transform.LookAt(endPosition);

            while(travelPercentage < 1f)
            {
                travelPercentage += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercentage);

                yield return new WaitForEndOfFrame();
            }
            
            //yield return new WaitForSeconds(waitTime);
        }   

        FinishPath();
    }    
}
