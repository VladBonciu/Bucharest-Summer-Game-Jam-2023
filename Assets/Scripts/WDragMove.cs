using UnityEngine;
 using System.Collections;
 
 public class WDragMove : MonoBehaviour {
     public float amount = 0.02f;
     public float maxamount = 0.03f;
     public float smooth = 3;
     private Quaternion def;
  
     void  Start (){
         def = transform.localRotation;
     }
  
     void  Update (){
  
         float factorX = -(Input.GetAxis("Horizontal")) * amount;
         float factorY = -(Input.GetAxis("Jump")) * amount;
         float factorZ = -Input.GetAxis("Vertical") * amount;
         
         if (factorX > maxamount)
         factorX = maxamount;
  
         if (factorX < -maxamount)
         factorX = -maxamount;
  
         if (factorY > maxamount)
         factorY = maxamount;
  
         if (factorY < -maxamount)
         factorY = -maxamount; 
  
         if (factorZ > maxamount)
         factorZ = maxamount;
  
         if (factorZ < -maxamount)
         factorZ = -maxamount;
  
         Quaternion Final= Quaternion.Euler(def.z+factorX, def.z+factorY, def.z+factorZ);
         transform.localRotation = Quaternion.Lerp(transform.localRotation, Final, (Time.deltaTime * amount) * smooth);  
     } 
 }