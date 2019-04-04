using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationNode : MonoBehaviour
{
    public enum Rotate { Left, Right};
    public Rotate RotatePosition;

    [SerializeField]
    float AmountToMakeItRotate;
   

    bool hasbeenUsed = false;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Change Turn Node to TransformValue
    private void OnTriggerEnter(Collider other)
    {
        if (!hasbeenUsed)
        {
           
            if (other.gameObject.GetComponent<CarHealth>() != null)
            {
                hasbeenUsed = true;
                switch (RotatePosition)
                {

                    
                    case Rotate.Left:
                        other.gameObject.transform.Rotate(new Vector3(0, AmountToMakeItRotate, 0));
                        break;
                    case Rotate.Right:
                        other.gameObject.transform.Rotate(new Vector3(0, AmountToMakeItRotate * -1, 0));
                        break;
                    default:
                        break;
                }
                StartCoroutine(RechargeUsedBool());
            }
        }
    }

    IEnumerator RechargeUsedBool()
    {
        yield return new WaitForSeconds(1.5f);
        hasbeenUsed = false;
    }
}
