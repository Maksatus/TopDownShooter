using UnityEngine;
using UnityEngine.AI;

public class MoveCharactres : MonoBehaviour
{
   [SerializeField] private CharacterInfo characterInfo;
   [SerializeField] private NavMeshAgent navMeshAgent;

   private void Start()
   {
      navMeshAgent.speed = characterInfo.Speed;
      navMeshAgent.angularSpeed = characterInfo.AngularSpeed;
      navMeshAgent.acceleration = characterInfo.Acceleration;
   }
   private void Update()
   {
      if (Input.GetMouseButton(0))
      {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         bool hisSomething = Physics.Raycast(ray, out RaycastHit hitInfo);

         if (hisSomething)
         {
            Vector3 clickWordPoint = hitInfo.point;
            navMeshAgent.SetDestination(clickWordPoint);
         }

      }
   }
}
