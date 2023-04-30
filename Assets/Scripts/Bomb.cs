using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public PlayerPawn player;
    private Rigidbody2D rigidbodyComp;
    [SerializeField] private float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComp = GetComponent<Rigidbody2D>();
        GameManager.instance.bombs.Add(this);

        AttachToPlayer();
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BuildingPawn building = null ;
        collision.TryGetComponent<BuildingPawn>(out building);

        if (building != null && rigidbodyComp.gravityScale != 0)
        {
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.explode);
            if (building.isAlive == true)
            {
                PlayerController playerController = player.GetComponent<PlayerController>();
                building.isAlive = false;
                playerController.score++;
                playerController.gameplayUI.UpdateScoreText();
                AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.scoreIncrease);

            }
            AttachToPlayer();
        }
        
    }

    public void AttachToPlayer()
    {
        this.gameObject.transform.parent = player.transform;
        this.transform.localPosition = new Vector3(0, -0.5f, 0);

        rigidbodyComp.velocity = Vector3.zero;
        rigidbodyComp.gravityScale = 0;
    }

    public void Drop()
    {
        this.gameObject.transform.parent = player.transform.parent;
        rigidbodyComp.gravityScale = fallSpeed;


    }
}
