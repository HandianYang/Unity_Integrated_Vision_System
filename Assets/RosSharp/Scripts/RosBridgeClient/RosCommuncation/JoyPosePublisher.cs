/**
 * Unity_Integrated_Vision_System - JoyPosePublisher.cs
 * 
 * Copyright (C) 2024 Handian Yang
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <https://www.gnu.org/licenses/>.
 */

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class JoyPosePublisher : UnityPublisher<MessageTypes.Geometry.PoseStamped>
    {
        public string FrameId = "Unity";
        public GameObject controller;

        private MessageTypes.Geometry.PoseStamped _message;

        protected override void Start()
        {
            base.Start();

            _message = new MessageTypes.Geometry.PoseStamped();
            _message.header.frame_id = FrameId;
        }

        private void Update()
        {
            _message.header.Update();

            Vector3 controllerTranslation = TransformExtensions.Unity2Ros(controller.transform.position);
            _message.pose.position.x = controllerTranslation.x;
            _message.pose.position.y = controllerTranslation.y;
            _message.pose.position.z = controllerTranslation.z;

            Quaternion controllerRotation = TransformExtensions.Unity2Ros(controller.transform.rotation);
            _message.pose.orientation.x = controllerRotation.x;
            _message.pose.orientation.y = controllerRotation.y;
            _message.pose.orientation.z = controllerRotation.z;
            _message.pose.orientation.w = controllerRotation.w;
            //_message.pose.orientation.x = 0;
            //_message.pose.orientation.y = 0;
            //_message.pose.orientation.z = 0;
            //_message.pose.orientation.w = 1;

            Publish(_message);
        }
    }
}
