# Deep Learning Introduction in VR
This is my master thesis project, with the goal of exploring how VR can be utilized as a tool for learning in AI education. 
I developed a prototype application for the Oculus Quest, where students are given an introduction to deep learning and neural networks. 
Users find themselves in an escape room environment, where topics have been split into separate rooms. 
The user progress through the application by doing 3D-puzzles, calculations, and quizzes, based on the course-material. 

# Motivation
There is a large need for AI competence worldwide. Having good technological tools for learning has shown to be more important than ever, due to the global pandemic of 2020.
We wanted to see if VR can be a valuable tool for fulfulling the need of AI competence. 

# Publications
A link to the master thesis report will be added here when it is published. 

The research paper I wrote has been published by Springer and can be found here [Making Use of Virtual Reality for Artificial Intelligence Education](https://link.springer.com/chapter/10.1007/978-3-030-67435-9_5/ "Making Use of Virtual Reality for Artificial Intelligence Education"). I presented the work on the HELMeTO 2020 conference in September 2020. 

# Application's contents
## Video
This [5-minute YouTube video](https://youtu.be/TvlN-dxAn4M/ "5-minute YouTube video") explains the core-concepts and shows what was developed for the application. 

## Screenshots
![Screenshot of neural network notation task and gradient descent visualization](https://github.com/SolveH/master-thesis-unity/blob/master/Assets/Resources/NNnotation_gradient_descent_screenshot.png)
The image to the left shows one of the tasks where the user learns neural network notation by placing neurons in a neural network. 
The image to the right shows the visualization of gradient descent. 

## Description
### Tutorial Scene
Since many users in the target audience are assumed to be new to VR, they have to play through a 5-10 minute tutorial, where every interaction needed is taught.  [Tutorial play-through video](https://youtu.be/w62h4PyNVGA " Tutorial play-through YouTube video").

### Deep Learning Introduction Scene
The curriculum was split into separate rooms. The user needs to collect and win cartridges loaded with quizzes for each topic in order to complete the application. Playing through the application takes approximately 30-90 minutes. [Deep learning introduction play-through video](https://youtu.be/Mfcauuc-pD8 "Deep learning introduction play-through YouTube video"). The topics covered in the application are:
1. Neurons
2. Cost functions
3. Gradient Descent
4. Backpropagation



# Technology
The technologies listed below were used for developing the application for the Oculus Quest. I used inspiration from the [Design, Develop, and Deploy for VR](https://learn.unity.com/course/oculus-vr "Design, Develop, and Deploy for VR") Unity Learn course by Oculus for setting up the fundamentals. This project supports the Oculus Quest, Rift, and Rift S, but it should be possible to port it to OpenVR devices without too much effort. 

## Game Engine
[Unity](https://unity.com/ "Unity") 2018 LTS version. 

## SDKs
* [Oculus Integration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022 "Virtual Reality Toolkit v4 (VRTK)") for hardware integration.
* [Virtual Reality Toolkit v4 (VRTK)](https://www.vrtk.io/ "Virtual Reality Toolkit v4 (VRTK)") for interactions. 

## Other useful stuff
* [JSON .NET For Unity](https://assetstore.unity.com/packages/tools/input-management/json-net-for-unity-11347/ "JSON .NET For Unity") for handling JSON files in Unity. 
* [Unity Snaps](https://unity.com/products/snaps/ "Unity Snaps") for efficiently building room layouts.

# Usage
## Setting up the project
1. Download or clone the project. 
2. Open [Unity Hub](https://unity3d.com/get-unity/download "Unity Hub") and add the project. 
3. Make sure you have the right version of Unity installed. 
4. Open the project. 

## Try the application
If you want to try the application, you can find it in this [Google Drive for Oculus Quest, Rift, and Rift S](https://drive.google.com/drive/folders/1gGYGSx95d3tFXYZE2iuZ6CZ1LorzNztE?usp=sharing "Google Drive with application"). Installation guides are provided for all devices.  

# Credits
The application was developed by Sølve Robert Bø Hunvik during his master thesis project at the Norwegian University of Science and Technology in the Department of Computer Science. 
Frank Lindseth was the project's supervisor. Every free resource used for the project is credited within the game menu. 

# License
The project is licensed under the MIT license. 
More details in [LICENSE.md](https://github.com/SolveH/master-thesis-unity/blob/master/LICENSE.md "LICENSE.md").

Copyright © 2020 Sølve Robert Bø Hunvik
