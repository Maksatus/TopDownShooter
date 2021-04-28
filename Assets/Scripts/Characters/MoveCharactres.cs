using UnityEngine;
using UnityEngine.AI;
namespace Characters
{
   public class MoveCharactres : MonoBehaviour
   {
      [SerializeField] private CharacterInfo characterInfo;
      [SerializeField] private NavMeshAgent navMeshAgent;
      [SerializeField] private Camera cameraMain;

      private void Start()
      {
         cameraMain = Camera.main;
         navMeshAgent.speed = characterInfo.Speed;
         navMeshAgent.angularSpeed = characterInfo.AngularSpeed;
         navMeshAgent.acceleration = characterInfo.Acceleration;
      }
      private void Update()
      {
         if (Input.GetMouseButton(0))
         {
            var ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            var hisSomething = Physics.Raycast(ray, out var hitInfo);

            if (hisSomething)
            {
               var clickWordPoint = hitInfo.point;
               navMeshAgent.SetDestination(clickWordPoint);
            }
         }
         else if (Input.GetMouseButton(1))
         {
            var ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            var hisSomething = Physics.Raycast(ray, out var hitInfo);

            if (hisSomething)
            {
               var clickWordPoint = hitInfo.point;
            
            }
         }
      }
   }
}
