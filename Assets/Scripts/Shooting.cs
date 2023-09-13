using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;
    public Animator lifAnimate;
    
    private void Update()
    {
        bool CanMoveOrInteract = FindObjectOfType<Lif>().CanMoveOrInteract();
        if(CanMoveOrInteract == false)
            return;

        if(Input.GetMouseButtonDown(0))
        {
            lifAnimate.Play("Lif_Archer_Draw");
        }
        if(Input.GetMouseButtonUp(0))
        {
            lifAnimate.Play("Lif_Archer_Loose");
             Shoot();

        }


    }

    void Shoot()
    {
        if (!canShoot)
            return;


        GameObject si = Instantiate(shootingItem, shootingPoint);
        si.transform.parent = null;
    }
}