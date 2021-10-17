using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] GameObject bladeTrailPrefab;

    [SerializeField] float  minCuttingVelocity = .001f;

    private Camera cam;

    private GameObject currentTrail;

    private Rigidbody2D rb;

    private bool isCutting = false;

    private CircleCollider2D col;

    private Vector2 previousPosition;

    void Start()
    {
        cam = Camera.main;
        col = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if(isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition ).magnitude * Time.deltaTime;

        if(velocity > minCuttingVelocity)
        {
            col.enabled = true;
        }
        else
        {
            col.enabled = false;
        }
        previousPosition = newPosition;
    }

    void StartCutting()
    {
        isCutting = true;
        currentTrail = Instantiate(bladeTrailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        col.enabled = false;
    }
    void StopCutting()
    {
        isCutting = false;
        currentTrail.transform.SetParent(null);
        Destroy(currentTrail,2.0f);
        col.enabled = false;
    }
}
