# Unity User Interface and ROS-Sharp Communication for Oculus Quest 2

An Unity3D project built for an interface for Oculus Quest 2 and, with the help of [ROS-sharp package](https://github.com/siemens/ros-sharp), for transmitting messages of headsets and joysticks in ROS message type.

## Note

1. This repository is one part of my whole marslite project. [The main repository](https://github.com/HandianYang/marslite_simulation_ws) should be launched with the corresponding [Docker environment](https://hub.docker.com/repository/docker/handianyang/marslite_simulation/general).
2. This repository does not support VR image rendering for headset, but this feature could possibly be appended in future.


## Prerequisites

### Hardware
- [Oculus Quest 2](https://www.meta.com/tw/quest/products/quest-2/)

### Software
- Windows 7 or above
- [Unity Hub](https://unity.com/unity-hub) with editor version: **2022.3.9f1**
- [Oculus PC application](https://www.meta.com/zh-tw/help/quest/articles/headsets-and-accessories/oculus-rift-s/install-app-for-link/)

## Features

#### Published ROS topics:
- `/unity/joy/left [Sensor/Joy]` - joy inputs of the left joystick based on `Unity` frame
- `/unity/joy_pose/left [Geometry/PoseStamped]` - pose of the left joystick based on the frame of the robotic arm (`tm_base`)



## Development

### In ROS (on Ubuntu PC/Virtual Machine)

#### Step 1. Download the [ROS workspace](https://github.com/HandianYang/marslite_simulation_ws) and follow the instructions in README.md

### In Unity (on Windows PC)

#### Step 1. Open the `RosSharpCommunicationScene` scene

Once the project has been launched, delete the current scene and drag `Assets/Scenes/RosSharpCommunicationScene` to `hierarchy`.

#### Step 2. Modify IP address for ROS-sharp connection

1. Click on the `RosConnector` object and guide to the `Ros Connector (Script)` component.
2. Select the `Protocol` as `Web Socket Sharp` if using Windows 7 or lower, or as `Web Socket NET` if using Windows 8 or higher.
3. Change the IP address in `Ros Bridge Server Url` as the IP address of your Ubuntu PC/VM. The url format should be `ws://<IP_ADDRESS_>:9090`. 

### In Oculus

[TODO] Finish this part