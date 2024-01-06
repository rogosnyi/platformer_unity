using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//namespace Assets.Scripts.Player.PlayerInput
//{
//    class PlayerPcInput : MonoBehaviour
//    {
//        [SerializeField] private PlayerMover _playerMover;
//        private float _direction;
//        private bool _jump;
//        private bool _crouch;

//        private void Update()
//        {
//            _direction = Input.GetAxisRaw("Horizontal");
//            if (!_jump && Input.GetKeyUp(KeyCode.Space))
//            {
//                _jump = true;
//            }
//            _crouch = Input.GetKey(KeyCode.C);

//        }
//        private void FixedUpdate()
//        {
//            _playerMover.Move(_direction, _jump, _crouch);
//            _jump = false;
//        }
//    }
//}
