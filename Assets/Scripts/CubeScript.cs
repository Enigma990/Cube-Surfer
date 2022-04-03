using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private bool bIsAdded = true;

    private void OnTriggerEnter(Collider other)
    {
        if (bIsAdded)
        {
            if (other.CompareTag("Cube"))
            {
                PlayerController.Instance.AddCube();
                Destroy(other.gameObject);
            }

            if (other.CompareTag("Wall"))
            {
                bIsAdded = false;
                this.transform.SetParent(null);
                PlayerController.Instance.RemoveCube();
            }

            if (other.CompareTag("Collectables"))
            {
                PlayerController.Instance.UpdateScore();
                Destroy(other.gameObject);
            }

            if (other.CompareTag("Finish"))
            {
                GameManager.Instance.LevelComplete();
            }
        }
    }
}
