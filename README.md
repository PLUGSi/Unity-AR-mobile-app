# PLUGSi AR App

The AR app is designed for the IoT-based module in PLUGSi.

## Overview

The app is built with the Unity game development platform, meaning it is a mobile app developed in Unity. Augmented reality is included using the Vuforia SDK with image targeting (Image Targets represent images that Vuforia Engine can detect and track).

The MQTT protocol is used to communicate with a broker. It is coded in C# within the Unity app scripts.

## Add-ons Integrated

The Unity app integrates several free add-ons:
1. UI Button Pack 2
2. Safe Area Helper
3. Lean GUI
4. Lean Touch

## App Pages

The Unity app has three pages:
1. **Intro Page**: Continuously running a video.
2. **Digital Twin Page**: Accessible via a button on the Intro page, it activates your camera to find the targeted image.
3. **Control Page**: With the camera on, this page features two buttons:
   - **PLUGSi**: Turns on/off the device connected to the base when the IoT module is connected. It also changes the digital twin's color to red or green to indicate the current status (On or Off).
   - **Start**: Returns you to the Intro page.

## Screenshots

![AR1](https://github.com/PLUGSi/Unity-AR-mobile-app/assets/123849272/5da332ff-5104-4d6e-95be-3df3d8d697f0)
![AR2](https://github.com/PLUGSi/Unity-AR-mobile-app/assets/123849272/ec9bae76-b716-48df-91bd-75e8f302de7e)
![AR3](https://github.com/PLUGSi/Unity-AR-mobile-app/assets/123849272/3749e872-4f46-499e-bf67-e65405f835d0)
