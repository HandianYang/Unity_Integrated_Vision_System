# Integrated Vision System for Marslite

Integration of Augmented Reality (AR) and the cameras' vision based on an Unity3D project

* Author: Handian Yang
* Email: ych0610765@gmail.com
* Last update: Mon, May 6, 2024

<!--
## Prerequisites

### Hardware
- 
- [Oculus Quest 2](https://www.meta.com/tw/quest/products/quest-2/)
- IntelRealsense camera

### Software
- Windows OS
- [Unity Hub](https://unity.com/unity-hub) with editor version: **2022.3.9f1**
- [Oculus PC application](https://www.meta.com/zh-tw/help/quest/articles/headsets-and-accessories/oculus-rift-s/install-app-for-link/)
-->

## Description

You should see the camera's view in the Unity3D world!

## Development

### Step 1. Open the `VRRenderScene` scene

Once the project has been launched, delete the current scene and drag `Assets/Scenes/VRRenderScene` to `hierarchy`.

### Step 2. Modify IP address for connection

1. Click on the `RosConnector` object and guide to the `Ros Connector (Script)` component
2. Select the `Protocol` as `Web Socket Sharp` if using Windows 7 or lower, and as `Web Socket NET` if using Windows 8 or higher
3. Change the IP address in `Ros Bridge Server Url` as your Ubuntu PC's IP address. The url format should be `ws://<IP_ADDRESS_>:9090`. 

### Step 3. Modify your camera's topic name

1. Click on the `RosConnector` object and guide to the `Image Subscriber (Script)` component
2. Modify the topic name in `Topic` based on your camera's topic name (for RGB image) 
  **[Note] The RGB image message should be `geometry_msgs/CompressedImage` type!!**