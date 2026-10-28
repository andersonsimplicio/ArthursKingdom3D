using UnityEngine;

public class Crab : Enemy
{
    
 [SerializeField] bool isPlayerVisible;
 [SerializeField] float detectionRadius = 1f;
 [SerializeField] float rotationSpeed = 1f;
 [SerializeField] GameObject AlertCanva;
 [SerializeField] float alertZOffSet = -0f;

    private void Update()
    {
        if (isPlayerVisible == false)
        {
            float distance = Vector3.Distance(transform.position,Player.Instance.transform.position);
            if(distance <= detectionRadius)
            {
                isPlayerVisible = true;
                Debug.Log("Viu o Jogador");
    
                GameObject alert = Instantiate(AlertCanva,transform.position + new Vector3(-2f,1f,-2f),transform.rotation);
                alert.transform.forward = Camera.main.transform.forward;
                Destroy(alert,2f);
            }
        }
        else{
            
            RotationTowarsPlayer();
        }
       
    }

    private void RotationTowarsPlayer()
    {
        Vector3 direction =(Player.Instance.transform.position - transform.position).normalized;
        direction.y = 0f;
        if(direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed*Time.deltaTime); 
        }
    }

}
