using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{

    private Transform target;
    private int wavepointIndex = 0;
    private Player player;

    private float playerSpeed;
    public bool speedPowerUpActive = false;
    public float speedPowerUpMultiplier = 1.0f;

    private void Start()
    {
        player = GetComponent<Player>();
        target = Waypoints.points[0];
        playerSpeed = player.speed;
    }
    private void Update()
    {
        if(speedPowerUpActive)
        {
            speedPowerUpMultiplier = 1.5f;
        } else
        {
            speedPowerUpMultiplier = 1f;
        }
        
        if (GameManager.Instance.playerPoints >= GameManager.Instance.pointsToComplete / Waypoints.points.Length)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * playerSpeed * speedPowerUpMultiplier * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }
    }

    private void GetNextWaypoint()
    {
        int pointsToUnlockWaypoint = GameManager.Instance.pointsToComplete / Waypoints.points.Length; //76
        Debug.Log("Points to unlock waypoint: " + pointsToUnlockWaypoint);
        Debug.Log(GameManager.Instance.playerPoints);
        Debug.Log(wavepointIndex);

        if (GameManager.Instance.playerPoints / pointsToUnlockWaypoint > wavepointIndex)
        {
            if (wavepointIndex >= Waypoints.points.Length - 1)
            {
                EndPath();
                return; //to avoid the error
            }
            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];

        } else
        {
            return;
        }

    }

    IEnumerator SpeedPowerUp()
    {
        speedPowerUpActive = true;
        yield return new WaitForSeconds(1);
        speedPowerUpActive = false;
    }

    public void ActivateSpeedPowerUp()
    {
        StartCoroutine(SpeedPowerUp());
    }

    void EndPath()
    {
        Debug.Log("The game finished!");
        GameManager.Instance.CompleteChallenge();


    }
}
