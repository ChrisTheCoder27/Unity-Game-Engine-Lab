# Project Information
Name: Christopher Dupas <br/>
Student number: 100916289 <br/>
Project title: Get That Firewood! <br/>
The player will move around a small 3D environment where they collect firewood logs and dodge wolves and bears! If the player's health reaches 0, then the level will restart. Once they've collected enough firewood they can return to their cabin to finish the level.
# Diagram and Reflection
<img width="1444" height="1129" alt="image" src="https://github.com/user-attachments/assets/9155c679-c66b-43d9-98a1-3851a97b0b97" />
1. My factory can spawn two types of objects, a bear enemy and a wolf enemy. Both of these enemies will constantly look at and move towards the player, with the wolf moving faster than the bear. When a bear or a wolf collides with the player, a debug statement will print depending on which enemy collided with the player. The player's health will also decrease by 10 points.
2. I think the factory pattern is useful for spawning enemies because it means you can separate the logic for spawning the enemies from what the enemies actually do. In the enemy subclasses, or the concrete products, I wrote the code for the behaviour of the wolf and bear enemies I created. Then in the enemy spawner subclasses, or the concrete factories, I wrote the actual spawning logic for these objects. You can then more easily choose when you want the enemies to be spawned and which enemy you want to spawn in. In this case, I'm using a game manager class to control the creation of the enemies. <br/>
References: Unity's Cinemachine package used for the camera movement.
