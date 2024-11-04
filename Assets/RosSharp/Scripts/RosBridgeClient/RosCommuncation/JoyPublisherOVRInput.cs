/**
 * Unity_Integrated_Vision_System - JoyPublisherOVRInput.cs
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
using static OVRInput;

namespace RosSharp.RosBridgeClient
{ 
    public class JoyNewPublisher : UnityPublisher<MessageTypes.Sensor.Joy>
    {
        public string FrameId = "Unity";
        private MessageTypes.Sensor.Joy message;

        protected override void Start()
        {
            base.Start();
            message = new MessageTypes.Sensor.Joy();
            message.header.frame_id = FrameId;
            message.axes = new float[4];    // TODO: Modify this to match the number of axes
        }

        private void Update()
        {
            message.header.Update();

            Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            message.axes[0] = axis.y;
            message.axes[1] = -axis.x;
            message.axes[2] = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
            message.axes[3] = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);

            Publish(message);
        }
    }

}
