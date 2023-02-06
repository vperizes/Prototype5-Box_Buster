using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSwipe : MonoBehaviour
{
    GameManager gameManager;
    Camera cam;
    BoxCollider col;
    TrailRenderer trailRender;


    private Vector3 mousePosWorld;
    bool swiping = false;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        cam = Camera.main;
        col = GetComponent<BoxCollider>();
        trailRender = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartSwipe();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopSwipe();
            }

            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }

    void UpdateMousePosition()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        mousePosWorld = cam.ScreenToWorldPoint(mousePos);
        transform.position = mousePosWorld;

    }

    void StartSwipe()
    {
        swiping = true;
        col.enabled = swiping;
        trailRender.enabled = swiping;
    }

    void StopSwipe()
    {
        swiping = false;
        col.enabled = swiping;
        trailRender.enabled = swiping;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>()) //accessing target script
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}
