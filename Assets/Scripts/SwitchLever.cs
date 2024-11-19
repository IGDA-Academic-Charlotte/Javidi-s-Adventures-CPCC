using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class SwitchLever : MonoBehaviour
{
    public Transform castOrigin;
    public Animator animator;
    public UnityEvent OnActivated = new UnityEvent();
    private bool isInRange = false;
    private bool isInSight = false;
    private bool isReusable = false;
    private bool locked = false;
    private Collider collidingPlayer;
    private CapsuleCollider capsuleCollider;
    private float shaderAlpha = 0f;
    private float fadeoutDuration = 0.25f;
    private float elapsedFadeoutTime = 0f;
    private float playerDetectionRange;
    private float sphereCastRadius = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerDetectionRange = capsuleCollider.radius;
    }

    // Update is called once per frame
    void Update()
    {
        if(!locked)
        {
            if(isInRange)
            {
                Vector3 playerPosition = collidingPlayer.ClosestPoint(castOrigin.position);

                RaycastHit hit;
                Physics.SphereCast(castOrigin.position, sphereCastRadius, playerPosition - castOrigin.position, out hit);
                isInSight = hit.transform == collidingPlayer.transform;

                if(isInSight)
                {
                    Debug.DrawRay(castOrigin.position, playerPosition - castOrigin.position, Color.white);
                    shaderAlpha = 1 - (Vector3.Distance(transform.position, playerPosition) / playerDetectionRange);
                    shaderAlpha = Mathf.Clamp(shaderAlpha, 0, 1); // A negative shader alpha will result in a negative color (ex: yellow -> blue)
                    ChangeHighlightMaterialAlpha(shaderAlpha);

                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        animator.SetTrigger("Pull");
                        OnActivated.Invoke();
                        if(!isReusable)
                        {
                            locked = true;
                        }
                    }
                }
                else
                {
                    ChangeHighlightMaterialAlpha(0);
                    Debug.DrawLine(castOrigin.position, hit.point, Color.yellow);
                    Debug.DrawLine(playerPosition, hit.point, Color.red);
                }
            }
        }
        else
        {
            elapsedFadeoutTime += Time.deltaTime;
            float fadeoutAlpha = Mathf.Lerp(shaderAlpha, 0, elapsedFadeoutTime / fadeoutDuration);
            ChangeHighlightMaterialAlpha(fadeoutAlpha);
        }
    }

    private List<Material> GetAllHighlightMaterials(Transform parent)
    {
        List<Material> allHighlightMaterials = new List<Material>();

        foreach(Transform child in parent)
        {
            MeshRenderer potentialMeshRenderer = child.GetComponent<MeshRenderer>();
            if(potentialMeshRenderer != null && potentialMeshRenderer.materials.Length > 1)
            {
                allHighlightMaterials.Add(potentialMeshRenderer.materials[1]);
            }
            allHighlightMaterials.AddRange(GetAllHighlightMaterials(child));
        }

        return allHighlightMaterials;
    }

    private void ChangeHighlightMaterialAlpha(float alpha)
    {
        List<Material> materials = GetAllHighlightMaterials(this.transform);
        foreach(Material material in materials)
        {
            material.SetFloat("_Alpha", alpha);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isInRange = true;
            collidingPlayer = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isInRange = false;
            isInSight = false;
            ChangeHighlightMaterialAlpha(0);
        }
    }
}
