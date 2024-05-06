
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class JoyPosePublisher : UnityPublisher<MessageTypes.Geometry.PoseStamped>
    {
        public string FrameId = "Unity";
        public GameObject controller;

        private MessageTypes.Geometry.PoseStamped message;

        protected override void Start()
        {
            base.Start();

            message = new MessageTypes.Geometry.PoseStamped();
            message.header.frame_id = FrameId;
        }

        private void Update()
        {
            message.header.Update();

            Vector3 controllerTranslation = TransformExtensions.Unity2Ros(controller.transform.position);
            message.pose.position.x = controllerTranslation.x;
            message.pose.position.y = controllerTranslation.y;
            message.pose.position.z = controllerTranslation.z;

            Quaternion controllerRotation = TransformExtensions.Unity2Ros(controller.transform.rotation);
            message.pose.orientation.x = controllerRotation.x;
            message.pose.orientation.y = controllerRotation.y;
            message.pose.orientation.z = controllerRotation.z;
            message.pose.orientation.w = controllerRotation.w;

            Publish(message);
        }
    }
}
