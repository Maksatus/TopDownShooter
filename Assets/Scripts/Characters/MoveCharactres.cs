using UnityEngine;
using UnityEngine.AI;

namespace Characters
{
   public class MoveCharactres : MonoBehaviour
   {
      [SerializeField] private CharacterInfo characterInfo;
      [SerializeField] private NavMeshAgent navMeshAgent;
      [SerializeField] private Camera cameraMain;
      [SerializeField] private float speedRotate = 6f;

      private Quaternion _rotation;
      private bool _isRotationNavMeshAgent;

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
            LeftMouseButton();
         }
         else if (Input.GetMouseButton(1))
         {
            RightMouseButton();
         }
         if (!_isRotationNavMeshAgent)
         {
            transform.rotation = Quaternion.Lerp(transform.rotation,_rotation,Time.deltaTime * speedRotate);   
         }
      }

      private void LeftMouseButton()
      {
         if (GettingPoint(out var hitInfo))
            return;
         
         _isRotationNavMeshAgent = true;
         var clickWordPoint = hitInfo.point;
         navMeshAgent.SetDestination(clickWordPoint);
      }
      
      private void RightMouseButton()
      {
         if (GettingPoint(out var hitInfo))
            return;
         
         _isRotationNavMeshAgent = false;
         var clickWordPoint = new Vector3(hitInfo.point.x,transform.position.y,hitInfo.point.z);
         var direction = clickWordPoint - transform.position;
         _rotation = Quaternion.LookRotation(direction);
      }
      private bool GettingPoint(out RaycastHit hitInfo)
      {
         var ray = cameraMain.ScreenPointToRay(Input.mousePosition);
         var hisSomething = Physics.Raycast(ray, out hitInfo);

         return !hisSomething;
      }
   }
}
