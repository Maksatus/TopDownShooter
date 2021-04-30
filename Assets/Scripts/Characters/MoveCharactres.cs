using UnityEngine;

namespace Characters
{
   public class MoveCharactres : MonoBehaviour
   {
      [SerializeField] private LayerMask layerMask;
      private Quaternion _rotation;
      private bool _isRotationNavMeshAgent;
      private Player _player;

      private void Start()
      {
         _player = Player.Instance;
         
         _player.GetNavMeshAgent().speed = _player.GetCharacterInfo().Speed;
         _player.GetNavMeshAgent().angularSpeed = _player.GetCharacterInfo().AngularSpeed;
         _player.GetNavMeshAgent().acceleration = _player.GetCharacterInfo().Acceleration;
      }
      private void Update()
      {
         if (Input.GetMouseButton(0))
         {
            LeftMouseButton();
         }
         else if (Input.GetMouseButtonDown(1))
         {
            RightMouseButton();
         }
         if (!_isRotationNavMeshAgent)
         {
            transform.rotation = Quaternion.Lerp(transform.rotation,_rotation,Time.deltaTime *  _player.GetSpeedRotate());   
         }
      }

      private void LeftMouseButton()
      {
         if (GettingPoint(out var hitInfo))
            return;
         _player.GetNavMeshAgent().isStopped = false;
         _isRotationNavMeshAgent = true;
         var clickWordPoint = hitInfo.point;
         _player.GetNavMeshAgent().SetDestination(clickWordPoint);
      }
      
      private void RightMouseButton()
      {
         if (GettingPoint(out var hitInfo))
            return;
         
         _isRotationNavMeshAgent = false;
         _player.GetNavMeshAgent().isStopped = true;
         var clickWordPoint = new Vector3(hitInfo.point.x,transform.position.y,hitInfo.point.z);
         var direction = clickWordPoint - transform.position;
         _rotation = Quaternion.LookRotation(direction);
      }
      private bool GettingPoint(out RaycastHit hitInfo)
      {
         var ray = _player.GetCameraMain().ScreenPointToRay(Input.mousePosition);
         var hisSomething = Physics.Raycast(ray, out hitInfo,layerMask);

         return !hisSomething;
      }
   }
}
